const express = require('express')
const morgan = require('morgan')
const path = require('path')
const session = require('express-session')

const port = 3000
const app = express()

app.use(express.static('public'))
app.use(express.json())
app.use(express.urlencoded(false))
app.use(morgan('common'))

app.use(session({
    secret: 'Chris 224212855',
    resave: false,
    saveUninitialized: true,
    cookie: { secure: false }
}))

app.set('views', path.join(__dirname, '\\public\\views'))
app.set('view engine', 'ejs')

const newsRouter = require('./routes/news')
const registerRouter = require('./routes/register')
const loginRouter = require('./routes/login')
const homeIssueRouter = require('./routes/homeIssue')
const engineerRouter = require('./routes/engineer')

app.get('/', (req, res) => {
    if (req.session.user) {
        res.render('introduction', { login: true })
    } else {
        res.render('introduction', { login: false })
    }
})

app.get('/introduction', (req, res) => {
    if (req.session.user) {
        res.render('introduction', { login: true })
    } else {
        res.render('introduction', { login: false })
    }
})

app.use('/engineers',engineerRouter)
app.use('/homeIssues',homeIssueRouter)
app.use('/news', newsRouter)
app.use('/register', registerRouter)
app.use('/login', loginRouter)

app.listen(port, (req, res) => {
    console.log(`Server Address http://localhost:${port}`)
    console.log('Click Ctrl + C to quit')
})