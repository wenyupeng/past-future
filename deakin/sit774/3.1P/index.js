const express =require('express')

const app = express()
const port=3000;

app.use(express.static('public_html'))

app.listen(port,()=>{
    console.log(`Web server address: http://localhost:${port}`)
    console.log(`Type Ctrl+C to quit`)
})