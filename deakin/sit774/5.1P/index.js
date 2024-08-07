const express =require('express')

const app = express()

app.use(express.static('public_html'))
app.use(express.static('resources'))

const port =3000

app.listen(port,()=>{
    console.log(`Server address http://localhost:${port}`)
    console.log(`Ctrl+C to quit`)
})