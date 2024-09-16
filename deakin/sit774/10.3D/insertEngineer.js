
let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_3D')

let engineers = [
    {
        name: 'Sarah Chen',
        type: 'electrician',
        area: 'Burwood',
        price: 80,
        imgurl: './img/star engineer1.png',
        description: 'Sarah is a detail-oriented and customer-focused electrician known for her exceptional problem-solving skills and'
            + 'commitment to safety and quality.',
    },
    {
        name: 'Emily Davis',
        type: 'electrician',
        area: 'Hawthorn',
        price: 90,
        imgurl: './img/star engineer2.png',
        description: 'Emily is a highly skilled and reliable electrician with a strong focus on safety, precision, and delivering top-quality service'
            + 'to her clients.',
    },
    {
        name: 'James Wilson',
        type: 'electrician',
        area: 'Richmond',
        price: 78,
        imgurl: './img/star engineer3.png',
        description: 'James is an experienced and dependable electrician, known for his expertise in complex electrical systems, quick'
            + 'problem-solving abilities, and a commitment to ensuring every job is done efficiently and safely',
    }, {
        name: 'John Doe',
        type: 'electrician',
        area: 'Richmond',
        price: 90,
        imgurl: './img/engineer list2.png',
        description: 'John is an experienced electrician with over 10 years of expertise in both residential and commercial electrical systems. He is known for his efficiency and reliability.'
    },
    {
        name: 'Emily Zhang',
        type: 'electrician',
        area: 'Hawthorn',
        price: 85,
        imgurl: './img/engineer list3.png',
        description: 'Emily is a skilled electrician with a strong attention to detail and a passion for sustainable energy solutions. She excels at delivering high-quality results.'
    },
    {
        name: 'James Lee',
        type: 'electrician',
        area: 'Camberwell',
        price: 75,
        imgurl: './img/engineer list4.png',
        description: 'James is a certified electrician specializing in smart home installations and energy-efficient systems. He is dedicated to providing excellent service and innovative solutions.'
    },
    {
        name: 'Laura Williams',
        type: 'electrician',
        area: 'Box Hill',
        price: 78,
        imgurl: './img/engineer list1.png',
        description: 'Laura is a highly competent electrician with a focus on residential wiring and troubleshooting. Her attention to detail and friendly customer service make her a top choice for homeowners.'
    }
]

db.serialize(function () {
    engineers.forEach(e => {
        db.run('INSERT INTO Engineer (name ,type ,area ,price ,imgurl, description) VALUES (?,?,?,?,?,?) ',
            [e.name, e.type, e.area, e.price, e.imgurl, e.description], function (err) {
                if (err) {
                    return console.log('insert failed, err: ', err.message)
                }
                console.log('insert success')
            })
    });
})

db.close;
