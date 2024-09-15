let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_3D')

db.serialize(function(){
    db.run('CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, password TEXT, email TEXT, phone TEXT, state TEXT, subcode TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })

    // db.run('INSERT INTO USER(name, password, email, phone, state, subcode) VALUES(?,?,?,?,?,?)', [users[i][0], users[i][1], users[i][2], users[i][3], users[i][4], users[i][5]], function (err) {
    //     if (err) {
    //         return console.log('insert failed, err: ', err.message)
    //     }
    //     console.log('insert success')
    // })

    db.run('CREATE TABLE IF NOT EXISTS News (id INTEGER PRIMARY KEY AUTOINCREMENT, imgurl TEXT, description TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table News')
    })

    db.run('CREATE TABLE IF NOT EXISTS Engineer (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, type TEXT, area TEXT, price REAL, imgurl TEXT, description TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table Engineer')
    })

    db.run('CREATE TABLE IF NOT EXISTS Home_Issues (id INTEGER PRIMARY KEY AUTOINCREMENT, type TEXT, imgurl TEXT, description TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table Home_Issues')
    })
})

db.close;
