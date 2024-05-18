console.log('hello Node.js')

// build a server
var http =require('http')

http.createServer(function (request, response) {
    response.writeHead(200, {'Content-Type': 'text/plain'})
    response.end('Hello Node.js')
}).listen(8080)