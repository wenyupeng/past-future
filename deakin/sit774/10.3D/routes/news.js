const express = require('express')
const sqlite3 = require('sqlite3').verbose();
const router = express.Router()

let db = new sqlite3.Database('10_3D')

router.get('/', function (req, res, next) {
    let totalPages = 0;
    db.get('SELECT COUNT(1) AS totalNum FROM News', (err, result) => {
        if (err) {
            return console.log('select failed, err: ', err.message)
        }
        totalPages = Math.ceil(result.totalNum / 3)
    })

    let pageNo = req.query.page || 1
    db.all('SELECT * FROM News Limit 3 Offset ? ', [(pageNo - 1) * 3], (err, rows) => {
        if (err) {
            return console.log('select failed, err: ', err.message)
        }
        res.render('news', {
            news: rows,
            currentPage: pageNo,
            totalPages: totalPages,
            login: false
        })
    })
    db.close
})

module.exports = router