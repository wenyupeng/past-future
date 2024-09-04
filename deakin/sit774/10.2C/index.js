const express = require('express')
const morgan = require('morgan')
const path = require('path')
const { title } = require('process')

const port = 3000
const app = express()

app.use(express.static('public'))
app.use(morgan('common'))

app.set('views', path.join(__dirname, '\\public\\views'))
app.set('view engine', 'ejs')

app.get('/', (req, res) => {
    res.render('index', { title: 'dKin Caps' })
})

app.use((req, res) => {
    let url = req.url
    res.render('404', {
        msg: 'no handler for url: ' + url
    })
})

app.use((err,req,res,next)=>{
    let errCode = err.status || 500
    res.render('500',{
        msg: 'error interrupts request, error msg: '+err.msg
    })
})

app.listen(port, () => {
    console.log(`Address http://localhost:${port}`)
    console.log(`Click Ctril + C to quit`)
})