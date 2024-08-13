const express = require('express')
const port=3000
const app = express()

app.use(express.static('public_html'))

app.listen(port,()=>{
    console.log(`Server address http://localhost:${port}`)
    console.log(`Ctrl + C to quit`)
})