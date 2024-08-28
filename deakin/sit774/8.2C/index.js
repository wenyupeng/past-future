const express = require('express')
const morgan = require('morgan')

const app = express()
const port = 3000

app.use(express.static('public_html'))

app.listen(port, () => {
    console.log(`Web server running at: http://localhost:${port}`);
    console.log(`Type Ctrl+C to shut down the web server`);
})
