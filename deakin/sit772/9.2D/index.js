const express = require('express')
const morgan = require('morgan')
const path = require('path')
const { body, validationResult } = require('express-validator')
const { Sequelize, Model, DataTypes } = require('sequelize')

const sequelize = new Sequelize('sit772_4_2c', 'root', 'root', {
    host: 'localhost',
    dialect: 'mysql'
})

const port = 3000
const app = express()

class User extends Model { }
User.init({
    USER_ID: {
        type: DataTypes.BIGINT,
        autoIncrement: true,
        primaryKey: true
    },
    FIRST_NAME: DataTypes.STRING,
    SURNAME: DataTypes.STRING,
    PASSWORD: DataTypes.STRING,
    PHONE: DataTypes.STRING,
    EMAIL: DataTypes.STRING,
    BIRTHDAY: DataTypes.DATE,
    GENDER: DataTypes.TINYINT,
    LANGUAGE: DataTypes.TINYINT,
    ADDR: DataTypes.STRING,
    SUBURB: DataTypes.STRING,
    STATE: DataTypes.STRING,
    POSTCODE: DataTypes.STRING,
    COUNTRY: DataTypes.STRING,
    RESIDENTIAL_AREA: DataTypes.STRING,
    HOBBY: DataTypes.STRING
}, { sequelize, timestamps: false, modelName: 'users' })

app.use(express.static('public'))
app.use(morgan('common'))
app.use(express.urlencoded({ extended: false }));
app.use(express.json())
app.set('views', path.join(__dirname, 'public'))
app.set('view engine', 'ejs')

app.get('/', (req, res) => {
    res.render('index', {})
})

app.post('/addUser', [
    body('firstName').notEmpty().withMessage('firstName cannot be empty'),
    body('firstName').isLength({ max: 25 }).withMessage('the max length of firstName is 25'),
    body('surname').notEmpty().withMessage('surname should not be empty'),
    body('surname').isLength({ max: 25 }).withMessage('surname should not be empty'),
    body('password').notEmpty().withMessage('password cannot be empty'),
    body('password').isLength({ max: 50 }).withMessage('the max length of password is 50'),
    body('phone').notEmpty().withMessage('phone cannot be empty'),
    body('phone').isLength({ max: 10 }).withMessage('the max length of phone is 10'),
    body('email').custom((value, { req }) => {
        if (!value) {
            return true
        } else {
            return body('email').isEmail()
        }
    }),
    body('addr').notEmpty().withMessage('addr cannot be empty'),
    body('addr').isLength({ max: 50 }).withMessage('the max length of addr is 50'),
    body('suburb').notEmpty().withMessage('suburb cannot be empty'),
    body('suburb').isLength({ max: 10 }).withMessage('the max length of suburb is 10'),
    body('state').notEmpty().withMessage('state cannot be empty'),
    body('state').isLength({ max: 5 }).withMessage('the max length of state is 5'),
    body('postcode').notEmpty().withMessage('postcode cannot be empty'),
    body('postcode').isLength({ max: 4 }).withMessage('the max length of postcode is 4'),
], async (req, res) => {
    let errors = validationResult(req)
    if (!errors.isEmpty()) {
        return res.status(400).json({ message: errors.array() })
    }

    let users = await User.findAll({
        where: {
            FIRST_NAME: req.body.firstName,
            SURNAME: req.body.surname,
            PHONE: req.body.phone
        }
    })

    if (users.length > 0) {
        return res.status(400).json({ message: 'user existed' })
    } else {
        await User.create({
            FIRST_NAME: req.body.firstName,
            SURNAME: req.body.surname,
            PASSWORD: req.body.password,
            PHONE: req.body.phone,
            EMAIL: req.body.email,
            BIRTHDAY: req.body.birthday,
            GENDER: req.body.gender,
            LANGUAGE: req.body.language,
            ADDR: req.body.addr,
            SUBURB: req.body.suburb,
            STATE: req.body.state,
            POSTCODE: req.body.postcode,
            COUNTRY: req.body.country,
            RESIDENTIAL_AREA: req.body.residential,
            HOBBY: req.body.hoby
        })
        return res.status(200).json({ message: 'user inserted successfully' })
    }

})

app.listen(port, () => {
    console.log(`server address http://localhost:${port}`)
    console.log('Ctrl + C to quit')
})