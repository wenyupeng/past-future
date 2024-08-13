# 使用python的 request库发起get或post请求返回403代码错误，使用postman发起请求发现状态码<200>竟然成功了。这是什么原因？首先排除ip问题，ip有问题的话postman也访问不了。难道是headers出现了问题吗，通过对比发现也不是headers的问题
其实遇到这种情况大概率是遇到了“原生模拟浏览器 TLS/JA3 指纹的验证”，浏览器和postman都有自带指纹验证，而唯独requests库没有。这就让反爬有了区分人为和爬虫的突破口。

# 使用pyhttpx
## 安装
pip install pyhttpx
## 代码
```python
import pyhttpx

headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36",
}
session = pyhttpx.HttpSession()
res = session.get(url='https://www.baidu.com/',headers=headers)
print(res.text)
```

# curl_cffi库
## 安装
pip install curl_cffi
## 代码
```python
from curl_cffi import requests
res = requests.get(url='https://www.baidu.com/',impersonate="chrome101")
print(res.text)
```

# 使用httpx库
## 安装
pip install httpx
## 代码
```python
import httpx

headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36",
}

res = httpx.get(url='https://www.baidu.com/', headers=headers, timeout=10, verify=False)
print(res.text)
```