const express = require('express');
const jwt = require('jsonwebtoken');
const bcrypt = require('bcryptjs');
const app = express();

app.use(express.urlencoded({ extended: true }));

const users = [
    { id: 1, username: 'admin', password: '$2a$10$VcOiEuUHwIayOdDgSDdkYeWpmcYI1I0FNsCFIaOxxuDypuNTO9GnG' } // 密码是 'password'
];

const secretKey = 'your-secret-key';

// 登录路由
app.post('/login', async (req, res) => {
    const { username, password } = req.body;
    const user = users.find(u => u.username === username);

    if (!user) {
        return res.status(400).send('User not found');
    }

    // 验证密码
    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) {
        return res.status(400).send('Invalid password');
    }

    // 生成 JWT 令牌
    const token = jwt.sign({ userId: user.id }, secretKey, { expiresIn: '1h' });
    res.json({ token });
});

// 验证 JWT 中间件
function authenticateToken(req, res, next) {
    const token = req.headers['authorization'];
    if (!token) return res.status(401).send('Access denied');

    jwt.verify(token, secretKey, (err, user) => {
        if (err) return res.status(403).send('Invalid token');
        req.user = user;
        next();
    });
}

// 保护路由 (需要 JWT 令牌才能访问)
app.get('/dashboard', authenticateToken, (req, res) => {
    res.send('Welcome to the dashboard');
});

app.listen(3000, () => {
    console.log('Server running on port 3000');
});
