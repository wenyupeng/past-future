from __future__ import print_function
import pickle
import os
from googleapiclient.discovery import build
from google_auth_oauthlib.flow import InstalledAppFlow
from google.auth.transport.requests import Request
from googleapiclient.http import MediaIoBaseDownload
import io

SCOPES = ['https://www.googleapis.com/auth/drive']
os.environ['HTTP_PROXY'] = 'http://127.0.0.1:7890'
os.environ['HTTPS_PROXY'] = 'http://127.0.0.1:7890'

# To list folders
def listfolders(service, filid, des):
    results = service.files().list(
        pageSize=1000, q="\'" + filid + "\'" + " in parents",
        fields="nextPageToken, files(id, name, mimeType)").execute()
    folder = results.get('files', [])
    for item in folder:
        if str(item['mimeType']) == str('application/vnd.google-apps.folder'):
            if not os.path.isdir(des+"/"+item['name']):
                os.mkdir(path=des+"/"+item['name'])
            print(item['name'])
            listfolders(service, item['id'], des+"/"+item['name'])  # LOOP un-till the files are found
        else:
            downloadfiles(service, item['id'], item['name'], des)
            print(item['name'])
    return folder


# To Download Files
def downloadfiles(service, dowid, name, dfilespath):
    request = service.files().get_media(fileId=dowid)
    fh = io.BytesIO()
    downloader = MediaIoBaseDownload(fh, request)
    done = False
    while done is False:
        status, done = downloader.next_chunk()
        print("Download %d%%." % int(status.progress() * 100))
    with io.open(dfilespath, 'wb') as f:
        fh.seek(0)
        f.write(fh.read())


def main():
    """Shows basic usage of the Drive v3 API.
    Prints the names and ids of the first 10 files the user has access to.
    """
    creds = None
    # The file token.pickle stores the user's access and refresh tokens, and is
    # created automatically when the authorization flow completes for the first
    # time.
    if os.path.exists('token.pickle'):
        with open('token.pickle', 'rb') as token:
            creds = pickle.load(token)
    # If there are no (valid) credentials available, let the user log in.
    if not creds or not creds.valid:
        if creds and creds.expired and creds.refresh_token:
            creds.refresh(Request())
        else:
            flow = InstalledAppFlow.from_client_secrets_file(
                'credentials.json', SCOPES)  # credentials.json download from drive API
            creds = flow.run_local_server()
        # Save the credentials for the next run
        with open('token.pickle', 'wb') as token:
            pickle.dump(creds, token)

    service = build('drive', 'v3', credentials=creds)
    # Call the Drive v3 API

    Folder_id = "''"  # Enter The Downloadable folder ID From Shared Link

    results = service.files().list(
        pageSize=1000, q=Folder_id+" in parents", fields="nextPageToken, files(id, name, mimeType)").execute()
    items = results.get('files', [])

    print('Files:')

    while True:
        items_clean = []
        for item in items:
            filepath = os.path.join(outPath, item['name'])
            if os.path.exists(filepath):
                continue
            else:
                items_clean.append(item)
        if len(items_clean) == 0:
            exit(0)
        for item in items_clean:
            filepath = os.path.join(outPath, item['name'])
            print(filepath)
            if os.path.exists(filepath):
                continue
            else:
                try:
                    downloadfiles(service, item['id'], item['name'], filepath)
                except:
                    continue


if __name__ == '__main__':
    outPath = r""
    main()
