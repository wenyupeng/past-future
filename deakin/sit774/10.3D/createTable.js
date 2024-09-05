let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_3D')

db.serialize(function(){
    db.run('CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, password TEXT, email TEXT, phone TEXT, workarea TEXT, state TEXT, subcode TEXT, experience TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })

    db.run('CREATE TABLE IF NOT EXISTS News (id INTEGER PRIMARY KEY AUTOINCREMENT, imgurl TEXT, description TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })

    db.run('CREATE TABLE IF NOT EXISTS News (id INTEGER PRIMARY KEY AUTOINCREMENT, imgurl TEXT, description TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })
})

db.close;
