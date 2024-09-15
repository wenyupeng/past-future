const util = require('util');
const sqlite3 = require('sqlite3').verbose()
const express = require('express')
const bcrypt = require('bcryptjs');
const { log } = require('console');

let router = express.Router()

router.get('/', (req, res) => {
    res.render('login', { login: false })
})

router.post('/checkUser', async (req, res) => {
    let db = new sqlite3.Database('10_3D')

    const dbGet = util.promisify(db.get).bind(db)
    let { name, password } = req.body

    try {
        let result = await dbGet('SELECT * FROM User WHERE name = ?', [name])
        if (!result) {
            return res.status(400).send({ msg: 'User not found' })
        }

        let isMatch = await bcrypt.compare(password, result.password)
        if (!isMatch) {
            return res.status(400).send({ msg: 'Invalid password' })
        }

        req.session.user = {
            id: result.id,
            name: result.name
        }

        res.send({
            id: result.id,
            name: result.name
        })
    } catch (err) {
        console.error('Database error:', err.message);
        res.status(500).send({ msg: 'Database error' });
    } finally {
        db.close()
    }
})

module.exports = router
