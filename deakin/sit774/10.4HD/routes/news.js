const util = require('util')
const express = require('express')
const sqlite3 = require('sqlite3').verbose();
const router = express.Router()


router.get('/', async (req, res, next) => {
    let login =false
    if(req.session.user){
        login =true
    }
    let db = new sqlite3.Database('10_4HD')
    let dbGet = util.promisify(db.get).bind(db)
    let dbAll = util.promisify(db.all).bind(db)

    let totalPages = 0;
    let pageNo = req.query.page || 1
    try {
        let result = await dbGet('SELECT COUNT(1) AS totalNum FROM News', [])
        totalPages = Math.ceil(result.totalNum / 3)

        let rows = await dbAll('SELECT * FROM News Limit 3 Offset ? ', [(pageNo - 1) * 3])
        res.render('news', {
            news: rows,
            currentPage: pageNo,
            totalPages: totalPages,
            login: login
        })
    } catch (err) {
        console.err('err: ', err.message)
    } finally {
        db.close
    }
})

module.exports = router