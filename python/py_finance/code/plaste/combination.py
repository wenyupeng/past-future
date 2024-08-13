import httpx
import time
import json

set = set()


def permutations(arr, position, end):
    if position == end:
        set.add(''.join(arr))
    else:
        for index in range(position, end):
            arr[index], arr[position] = arr[position], arr[index]
            permutations(arr, position + 1, end)
            arr[index], arr[position] = arr[position], arr[index]


def getRequest(url):
    headers = {
        'content-type': "application/json",
        'cache-control': "no-cache",
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36"
    }

    try:
        time.sleep(2)
        response = httpx.get(url, headers=headers)
        response.raise_for_status()
        return response.json()['success']
    except httpx._exceptions.HTTPError as http_err:
        print(f"HTTP error occurred: {http_err}")
    except httpx._exceptions.RequestError as req_err:
        print(f"Request error occurred: {req_err}")
    except json.JSONDecodeError as json_err:
        print(f"JSON decode error: {json_err}")
    return None


if __name__ == '__main__':
    array = ['9', '9', '9', '9', '9']
    charArr=['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','T','U','V','W','X','Y','Z']

    for char in charArr:
        l = array+ [char]
        permutations(l, 0, len(l))

    timestamp = int(round(time.time() * 1000))
    for combination in set:
        url = f'https://vplates.com.au/vplatesapi/checkcombo?vehicleType=car&combination={combination}&productType=Create&isRestyle=false&_= {timestamp}'
        msg = getRequest(url)
        print(combination + "==" + str(msg))
