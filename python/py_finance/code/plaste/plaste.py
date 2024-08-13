import requests
import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions

from selenium.webdriver.support.wait import WebDriverWait

set = set()


def permutations(arr, position, end):
    if position == end:
        set.add(''.join(arr))

    else:
        for index in range(position, end):
            arr[index], arr[position] = arr[position], arr[index]
            permutations(arr, position + 1, end)
            arr[index], arr[position] = arr[position], arr[index]


def getRequest():
    url = "https://vplates.com.au/vplatesapi/checkcombo"


    querystring = {"vehicleType": "car", "combination": "777777", "productType": "Create", "isRestyle": "false",
                   "_": "1723116334615"}

    payload = "{\n\t\"name\": \"Kevin Anderson\",\n\t\"age\": 31,\n\t\"avatar\": \"profile-img.jpg\",\n\t\"first_name\": \"Kevin\",\n\t\"last_name\": \"Anderson\",\n\t\"password\": \"123456\",\n\t\"email\":\"reta1iate001@hotmail.com\",\n\t\"phone_number\": \"0424068322\"\n}"
    headers = {
        'content-type': "application/json",
        'cache-control': "no-cache",
        'postman-token': "e7d423a5-f3e6-72b1-724c-6486fac06ea9"
    }

    response = requests.request("GET", url, data=payload, headers=headers, params=querystring)
    print(response)
    return response.text

if __name__ == '__main__':
    # array = ['9', '9', '9', '9', '9', 'V']
    # permutations(array, 0, len(array))
    #
    # # for combination in set:
    #
    # timestamp = int(round(time.time() * 1000))
    # combination = '888888'
    # url = f'https://vplates.com.au/vplatesapi/checkcombo?vehicleType=car&combination={combination}&productType=Create&isRestyle=false&_= {timestamp}'
    #
    # msg = getRequest()
    # print(msg)
    browser =webdriver.Chrome()
    browser.get("https://vplates.com.au/create/check-combination")
    kw_input =browser.find_element(By.ID,'combination')
    kw_input.send_keys('777777')
    su_button = browser.find_element(By.CSS_SELECTOR, '.combination-checker__actions .button--full-width')
    su_button.click()

    wait_obj = WebDriverWait(browser, 10)
    # wait_obj.until(
    #     expected_conditions.presence_of_element_located(
    #         (By.CSS_SELECTOR, '#content_left')
    #     )
    # )