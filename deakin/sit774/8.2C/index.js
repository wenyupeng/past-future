const express = require('express')
const morgan = require('morgan')
const path = require('path')

const app = express()
const port = 3000

app.set('views', path.join(__dirname, '\\public_html\\views'))
app.set('view engine', 'ejs')

let likesyellow = 0;
let likesgrey = 0;

app.use(morgan('common'))
app.use(express.static('public_html'))

app.get('/test', (req, res) => {
    likesyellow++;
    res.render('index', {
        title: "yellow",
        color: "yellow",
        likeyellow: likesyellow,
        likegrey: likesgrey,
        dateTime: now().toTimeString()
    })
})

app.get('/likeyellow', (req, res) => {
    likesyellow++;
    let dateTime =new Date().toTimeString();
    res.render('likeTemplate', {
        title: "yellow",
        color: "yellow",
        likeyellow: likesyellow,
        likegrey: likesgrey,
        dateTime: dateTime
    })
})

app.get('/likegrey', (req, res) => {
    likesgrey++;
    let dateTime =new Date().toTimeString();
    res.render('likeTemplate', {
        title: "grey",
        color: "grey",
        likeyellow: likesyellow,
        likegrey: likesgrey,
        dateTime: dateTime
    })
})

app.use((req, res) => {
    res.status(404).send('404 File Not Found');
})


app.use((err, req, res, next) => {
    let errorStatus = err.status || 500
    console.log(err.status)
    console.log(err.toString())
    res.status(errorStatus).send(`Error ${errorStatus}: ${err.toString()}`)
})

app.listen(port, () => {
    console.log(`Web server running at: http://localhost:${port}`);
    console.log(`Type Ctrl+C to shut down the web server`);
})
