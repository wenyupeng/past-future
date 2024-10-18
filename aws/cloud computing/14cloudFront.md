Amazon CloudFront 是一项加快将静态和动态 Web 内容(例如.html、.css、.js 和图像文件)分发给用户的速度的 Web 服务。CloudFront 通过全球数据中心(称作边缘站点)网络传输内容。当用户请求您用 CloudFront 提供的内容时，请求被路由到提供最低延迟(时间延迟)的边缘站点，从而以尽可能最佳的性能传送内容。
如果该内容已经在延迟最短的边缘站点上，CloudFront将直接提供发
如果内容不在边缘站点中，CloudFront将从已定义的源(例如，已确定为内容最终版本的来源的 Amazon S3 存储桶、MediaPackage通道或 HTTP 服务器，如 Web 服务器)检索内容。