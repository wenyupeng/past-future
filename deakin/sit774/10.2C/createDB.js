let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_2C')

let users = [
['Mick','Hobbs','mick@deakin.edu.au','0499000111','Between 1 and 10 caps','Snapback Cap','I wash my cap 3 times a week!'],
['Sam','Smith','samsmith@deakin.edu.au','0411987987','More than 30 caps','Sun cap','Never go outside in the sun with out my trusty cap.'],
['Alexander','Nguyen','aln@deakin.edu.au','0424366221','Between 1 and 10 caps','Runners Cap',"I wash my cap at least 7 times a week... l don't like dirty caps"],
['Sophia','Taylor',"sophie@deakin.edu.au",'04337757750','0 caps','Bucket Hat','Yet to get a cap... But when l do the first will be a Blue Bucket Hap'],
['Noah','Rodriguez','noah@deakin.edu.au','0462421133','30+ caps','Trucker Cap',"Sometimes, wearing a trucker's cap gives me a feeling of anonymity or privacy, helping me blend in or go unnoticed in a crowd."],
['Derick','Long','dericklong@deakin.edu.au','0499111000','1-10 caps','Trucker Cap','I love my trucker cap. I wear it in the morning when l go to work as a barista.'],
['Petra','Smithton','pppsss@deakin.edu.au','0400000001','30+ caps','Beanie','My beanie is warm and fluffy! I love my beanie.'],
['Astrid','LaWsOn','starz@deakin.edu.au','0455666999','Between 1 and 10 caps','Sun cap','I spend lots of time outside, so my trusty sun cap is always on my head. Gotta be sun smart!'],
['Brodie','Hammersmith','hammer@deakin.edu.au','04123545678','1-10 caps','Snapback cap','One cap... l love it... but I never, ever wash it.']
]

db.serialize(function(){
    db.run('CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, fname TEXT, sname TEXT, email TEXT, mobile TEXT, numcaps TEXT, favourite TEXT, comment TEXT) ',function(err){
        if(err){
            return console.log(err)
        }
        console.log('create table User')
    })

    for (let i in users) {
        db.run('INSERT INTO USER(fname, sname, email, mobile, numcaps, favourite,comment) VALUES(?,?,?,?,?,?,?)', [users[i][0], users[i][1], users[i][2], users[i][3], users[i][4], users[i][5], users[i][6]], function (err) {
            if (err) {
                return console.log('insert failed, err: ', err.message)
            }
            console.log('insert success')
        })
    }
    
})

db.close;

