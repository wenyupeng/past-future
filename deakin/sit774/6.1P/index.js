const express =require('express')

const app = express()

app.use(express.static('public_html'))
app.use(express.static('js'))

app.listen(3000,()=>{
    console.log(`Server Address http://localhost:3000`)
    console.log('click Ctrl+C to quit')
})