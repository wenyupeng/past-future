const express = require('express')
const morgan = require('morgan')
const path = require('path')
const { emit } = require('process')

const port = 3000
const app = express()

app.use(express.static('public_html'))
app.use(morgan('common'))
//configuring express to use body-parser as middle-ware.
app.use(express.urlencoded({ extended: false }));

app.set('views', path.join(__dirname, 'views'))
app.set('view engine', 'ejs')

app.get('/',(req,res)=>{
    res.render('index',{
        title: 'Ice Cream Review'
    })
})

app.post('/submitmembership',(req,res)=>{
    console.log(JSON.stringify(req.body))
    let body = req.body
    res.render('thankyou',{
        title: 'Ice Cream Review',
        firstname: body.firstname,
        surname: body.surname,
        email: body.email,
        mobile: body.mobileNumber,
        capStyle: body.capstyle,
        capsOwned: body.inputNumCaps,
        comments: body.comments
    })
})

app.use((req, res) => {
    res.render('404', {
        title: 'Ice Cream Review',
        message: `no handler for request ${req.url}`,
        url: req.url
    })
})

app.use((err, req, res, next) => {
    let status = err.status || 500
    res.status(status).send(`error code ${status} , error msg ${err.toString()}`)
})

app.listen(port, () => {
    console.log(`Web server running at: http://localhost:${port}`);
    console.log(`Type Ctrl+C to shut down the web server`);
})