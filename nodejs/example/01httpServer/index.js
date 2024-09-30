var http = require('http')

http.createServer(function(req, res) {
    // 发送 HTTP 头部
    res.writeHead(200, {'Content-Type': 'text/plain'});
    // 发送响应数据 Hello World
    res.end('Hello World\n');
}).listen(8080);

console.log('Server started');