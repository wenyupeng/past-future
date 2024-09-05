const express = require('express')
const morgan = require('morgan')
const path = require('path')

const { login, register, introduction } = require('./public/js/func')

const port = 3000
const app = express()

app.use(express.static('public'))
app.use(express.urlencoded(false))
app.use(morgan('common'))

app.set('views', path.join(__dirname, '\\public\\views'))
app.set('view engine', 'ejs')

app.get('/', (req, res) => {
    res.render('introduction', { login: false })
})

app.get('/register', (req, res) => {
    res.render('register', { login: false })
})

app.get('/login', (req, res) => {
    res.render('login', { login: false })
})

app.get('/introduction', (req, res) => {
    res.render('introduction', { login: false })
})

app.get('/engineers', (req, res) => {
    res.render('engineers', { login: false })
})

app.get('/homeIssues', (req, res) => {
    res.render('homeIssues', { login: false })
})

app.get('/news', (req, res) => {
    res.render('news', { login: false })
})

app.post('/register', register)
app.post('/login', login)

app.listen(port, (req, res) => {
    console.log(`Server Address http://localhost:${port}`)
    console.log('Click Ctrl + C to quit')
})