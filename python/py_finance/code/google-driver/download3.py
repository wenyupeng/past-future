from __future__ import print_function
import os
import io
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from google.auth.transport.requests import Request
from googleapiclient.discovery import build
from googleapiclient.http import MediaIoBaseDownload

# 如果修改 SCOPES，删除 token.json 文件
SCOPES = ['https://www.googleapis.com/auth/drive.readonly']

def download_file(service, file_id, file_name, local_folder):
    """下载单个文件到指定的本地文件夹"""
    request = service.files().get_media(fileId=file_id)
    file_path = os.path.join(local_folder, file_name)

    # 如果本地文件夹不存在，创建它
    if not os.path.exists(local_folder):
        os.makedirs(local_folder)

    # 下载文件
    with io.FileIO(file_path, 'wb') as fh:
        downloader = MediaIoBaseDownload(fh, request)
        done = False
        while not done:
            try:
                status, done = downloader.next_chunk()
            except IOError:
                print("Error")
            else:
                print(f"下载 {file_name} {int(status.progress() * 100)}% 完成")
            finally:
                print('somethings wrong')

def list_and_download_files(service, folder_id=None, local_folder=".", indent_level=0):
    """递归列出并下载文件夹中的内容，跳过名为 'book' 的文件夹"""
    page_token = None
    indent = ' ' * indent_level  # 用于递归显示时缩进
    while True:
        query = f"'{folder_id}' in parents" if folder_id else "'root' in parents"
        response = service.files().list(
            q=query,
            pageSize=100,
            fields="nextPageToken, files(id, name, mimeType)",
            pageToken=page_token
        ).execute()
        items = response.get('files', [])

        if not items:
            print(indent + '没有找到文件。')
            break

        for item in items:
            file_type = "文件夹" if item['mimeType'] == 'application/vnd.google-apps.folder' else "文件"
            print(f"{indent}{item['name']} ({file_type}, ID: {item['id']})")

            # 如果是文件夹，递归列出并下载其中的内容
            if item['mimeType'] == 'application/vnd.google-apps.folder':
                # 跳过名为 'book' 的文件夹
                if item['name'].lower() == 'book':
                    print(f"{indent}跳过文件夹: {item['name']}")
                    continue
                # 在本地创建对应的文件夹
                new_local_folder = os.path.join(local_folder, item['name'])
                list_and_download_files(service, item['id'], new_local_folder, indent_level + 2)
            else:
                # 下载文件到本地文件夹
                download_file(service, item['id'], item['name'], local_folder)

        page_token = response.get('nextPageToken', None)

        if page_token is None:
            break

def main():
    """展示 Google Drive 文件和文件夹结构，并递归下载"""
    creds = None
    # 检查是否已经保存用户凭据
    if os.path.exists('token.json'):
        creds = Credentials.from_authorized_user_file('token.json', SCOPES)
    # 如果没有有效的凭据，进行登录
    if not creds or not creds.valid:
        if creds and creds.expired and creds.refresh_token:
            creds.refresh(Request())
        else:
            flow = InstalledAppFlow.from_client_secrets_file(
                'credentials.json', SCOPES)
            creds = flow.run_local_server(port=0)
        # 保存用户凭据供下次使用
        with open('token.json', 'w') as token:
            token.write(creds.to_json())

    # 使用 Google Drive API 连接服务
    service = build('drive', 'v3', credentials=creds)

    # 开始从根目录列出并下载文件，跳过名为 'book' 的文件夹
    list_and_download_files(service, local_folder="./GoogleDriveDownload")

if __name__ == '__main__':
    main()

