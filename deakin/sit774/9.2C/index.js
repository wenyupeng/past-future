const express = require('express')
const morgan = require('morgan')
const path = require('path')

const port = 3000
const app = express()
app.use(express.static('public'))
app.use(express.urlencoded(false))
app.use(morgan('common'))

app.set('views', path.join(__dirname, '\\public\\views'))
app.set('view engine', 'ejs')

app.get('/', (req, res) => {
    res.render('index', {
        title: 'Ice Cream Review'
    })
})

app.post('/submitmembership', (req, res) => {
    let body = req.body
    let errMsgs = []
    for (key in body) {
        if (body[key] == undefined || body[key] == '') {
            errMsgs.push({ fieldName: key, msg: 'Missing ' + key })
        } else {
            if (key == 'email' && !body[key].endsWith('@deakin.edu.au')) {
                errMsgs.push({ fieldName: key, msg: 'invalid email' })
            }
        }
    }

    if (body['inputNumCaps'] == undefined || body['inputNumCaps'] == '') {
        errMsgs.push({ fieldName: 'inputNumCaps', msg: 'invalid email' })
    }

    if (body['capstyle'] == undefined || body['capstyle'] == '') {
        errMsgs.push({ fieldName: 'capstyle', msg: 'invalid email' })
    }

    if (errMsgs.length > 0) {
        res.render('formErr', {
            title: 'Ice Cream Review',
            msgCount: errMsgs.length,
            errMsgs: errMsgs
        })
    } else {
        res.render('thankyou', {
            title: 'Ice Cream Review',
            firstname: body.firstname,
            surname: body.surname,
            email: body.email,
            mobile: body.mobileNumber,
            capStyle: body.capstyle,
            capsOwned: body.inputNumCaps,
            comments: body.comments
        })
    }

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
    res.status(status).send(`Something wrong with the server, error msg: ${err.toString()}`)
})

app.listen(port, () => {
    console.log(`Web server running at: http://localhost:${port}`);
    console.log(`Type Ctrl+C to shut down the web server`);
})