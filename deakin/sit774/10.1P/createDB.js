let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_1P')

db.serialize(function(){
    db.run('CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, fname TEXT, sname TEXT, email TEXT, mobile TEXT, numcaps TEXT, favourite TEXT, comment TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })
})

db.close;

