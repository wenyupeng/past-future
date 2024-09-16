const { text } = require('express');

let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_4hD')

db.serialize(function () {
    db.run('DROP TABLE User', [], function (err) {
        if (err) {
            return console.log('drop failed, err: ', err.message)
        }
        console.log('drop success')
    })
    db.run('CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, password TEXT, email TEXT, phone TEXT, state TEXT, subcode TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })
})

db.close;
