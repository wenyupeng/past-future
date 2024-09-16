const util = require('util');
const express = require('express');
const sqlite3 = require('sqlite3').verbose()
const bcrypt = require('bcryptjs')

let router = express.Router();

router.get('/', (req, res) => {
    res.render('register', { login: false })
})

router.post('/addUser', async (req, res, next) => {
    let db = new sqlite3.Database('10_4HD')

    const dbAll = util.promisify(db.all).bind(db);
    const dbRun = util.promisify(db.run).bind(db);

    const body = req.body;

    if (checkParam(body)) {
        return res.send({ msg: 'data check fail' });
    }

    try {
        const result = await dbAll('SELECT * FROM User WHERE name = ?', [body.name]);

        if (result.length > 0) {
            return res.status(400).send({ msg: 'User already exists' });
        }

        let encrypPwd = await bcrypt.hash(body.password,10)

        await dbRun('INSERT INTO User(name, password, email, phone, state, subcode) VALUES(?,?,?,?,?,?)',
            [body.name, encrypPwd, body.email, body.phone, body.state, body.subcode]);

        res.send({msg: 'add user success'});

    } catch (err) {
        console.error('Database error:', err.message);
        res.status(500).send({ msg: 'Database error' });
    } finally {
        db.close((err) => {
            if (err) {
                return console.error(err.message);
            }
            console.log('Closed the database connection.');
        });
    }
})

function checkParam(user) {
    return !user.name || !user.password || !user.email || !user.phone || !user.state || !user.subcode;
}

module.exports = router