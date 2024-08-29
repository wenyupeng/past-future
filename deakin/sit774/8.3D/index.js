const express = require('express')
const morgan = require('morgan')
const path = require('path')

const app = express()
const port = 3000

const jsonCapTypeData = require(path.join(__dirname, 'data/captypes'));
const jsonColourData = require(path.join(__dirname, 'data/colours'));
const jsonStaffData = require(path.join(__dirname, 'data/staff'));
const jsonTransactionData = require(path.join(__dirname, 'data/transactions'));

app.use(express.static('public_html'))
app.use(morgan('common'))

app.set('views', path.join(__dirname, 'views'))
app.set('view engine', 'ejs')

app.get('/', (req, res, next) => {
    res.render('index', { title: 'dKin Cap Sales' });
});

app.get('/captypes', (req, res, next) => {
    res.json(jsonCapTypeData);
});

app.get('/colourtypes', (req, res, next) => {
    res.json(jsonColourData);
});

app.get('/stafflist', (req, res, next) => {
    res.json(jsonStaffData);
});

app.get('/transactions', (req, res, next) => {
    res.json(jsonTransactionData);
});

app.get('/sales', (req, res, next) => {
    res.render('list', {
        title: 'dKin Cap Sales',
        transactions: jsonTransactionData.transactions,
        types: jsonCapTypeData.captypes,
        colours: jsonColourData.colours,
        staff: jsonStaffData.staff
    });
});

app.use((req, res) => {
    res.render('404', {
        title: 'dKin Cap Sales',
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