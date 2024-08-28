const express = require('express')
const morgan = require('morgan')

const app = express()
const port = 3000

app.use(express.static('public_html'))
// include the logging for all requests
app.use(morgan('common'))

app.get('/', (req, res) => {
    let date = Date()
    console.log(date)
    res.status = 200
    res.send(date + '\r\n server receives a request \r\n ')
})

app.get('/forceerror',(req,res)=>{
    console.log('Get a request to force an error...')
    let f;
    console.log(`f=${f.nomethod()}`)
})

app.use((req, res) => {
    res.status(404).send('404: File not found')
})

app.use((error, req, res, next) => {
    let errorStatus = error.status || 500;
    res.status(errorStatus)
    res.send('Error(' + errorStatus + '): ' + error.toString())
})
app.listen(port, () => {
    console.log(`Web server running at: http://localhost:${port}`);
    console.log(`Type Ctrl+C to shut down the web server`);
})