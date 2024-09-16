const util = require('util');
const sqlite3 = require('sqlite3').verbose()
const express = require('express')

let router = express.Router()

router.get('/', async (req, res) => {
    let loginFlag = false;
    if (req.session.user) {
        loginFlag = true
    }

    let db = new sqlite3.Database('10_4HD')
    const dbAll = util.promisify(db.all).bind(db)
    const dbGet = util.promisify(db.get).bind(db)

    let totalPages = 0;
    let pageNo = req.query.page || 1

    try {
        let result = await dbGet('SELECT COUNT(1) AS totalNum FROM Home_Issues WHERE type = ?', [1])
        totalPages = Math.ceil(result.totalNum / 4)

        let emergencyIssues = await dbAll('SELECT * FROM Home_Issues WHERE type = ? Limit 2 Offset ?', [0,0])
        let urgencyIssues = await dbAll('SELECT * FROM Home_Issues WHERE type = ? Limit 4 Offset ?', [1,(pageNo - 1) * 4])

        res.render('homeIssues', {
            currentPage: pageNo,
            totalPages: totalPages,
            emergencyIssues: emergencyIssues,
            urgencyIssues: urgencyIssues,
            login: loginFlag
        })
    } catch (err) {
        console.error('err: ', err.message)
    }
})


module.exports = router
