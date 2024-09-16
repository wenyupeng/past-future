const util = require('util');
const sqlite3 = require('sqlite3').verbose()
const express = require('express')
const bcrypt = require('bcryptjs');

let router = express.Router()

router.get('/', async (req, res) => {
    let login = false
    if (req.session.user) {
        login = true
    }

    let db = new sqlite3.Database('10_4HD')
    let dbAll = util.promisify(db.all).bind(db)
    let dbGet = util.promisify(db.get).bind(db)

    let totalPages = 0;
    let pageNo = req.query.page || 1

    let type = req.query.type

    let queryStr = `SELECT * FROM Engineer e `
    let params = []
    if (type) {
        queryStr += ` WHERE type = ?`
        params.push(type)
    }

    let field = req.query.field
    if (field) {
        queryStr += ` order by ${field} DESC`
    }

    queryStr += ` LIMIT 4 OFFSET ?`
    params.push((pageNo - 1) * 4)

    try {
        let result = await dbGet('SELECT COUNT(1) AS totalNum FROM Engineer', [])
        totalPages = Math.ceil(result.totalNum / 4)
        console.log(result)
        let stars = await dbAll('SELECT * FROM Engineer e ORDER BY price DESC LIMIT 3 OFFSET 0', [])

        console.log(queryStr)
        let engineers = await dbAll(queryStr, params)
        console.log(engineers)
        res.render('engineers', {
            stars: stars,
            engineers: engineers,
            currentPage: pageNo,
            totalPages: totalPages,
            login: login
        })

    } catch (error) {
        console.error('err: ', error.message)
    } finally {
        db.close((err) => {
            if (err) {
                console.err("db close err: ", err.message)
            }
        })
    }
})

module.exports = router
