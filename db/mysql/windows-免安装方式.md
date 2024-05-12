# 下载免安装压缩包
下载地址：dev.mysql.com/downloads/...
# 安装目录下新建`my.ini`文件
```markdown
[client]
# 设置mysql客户端默认字符集
default-character-set=utf8
 
[mysqld]
# 设置3306端口
port = 3306
# 设置mysql的安装目录
basedir=D:\my_tool\mysql-8.0.21-winx64\mysql-8.0.21-winx64
# 设置 mysql数据库的数据的存放目录
datadir=D:\my_tool\mysql-8.0.21-winx64\mysql-8.0.21-winx64\data
# 允许最大连接数
max_connections=20
# 服务端使用的字符集默认为8比特编码的latin1字符集
character-set-server=utf8
# 创建新表时将使用的默认存储引擎
default-storage-engine=INNODB
```

# 添加环境变量 
`....\mysql\bin`

# 管理员权限执行命令
1. 进入安装目录
```shell
cd D:\db\mysql\bin
```
2. 将`MySQL`加入`Windows`服务中
```shell
mysqld --install
# Service successfully installed.
```
3. 初始化数据库，自动生成data目录，获取默认密码
```shell
mysqld --initialize --user=root --console
# ... A temporary password is generated for root@localhost: kyM&OIwj,2C!...
```
4. 启动`mysql`服务
```shell
net start mysql
```
5. 进入`Mysql`修改初始密码
```shell
mysql -u root -p
alter user user() identified by 'XXX'
```
6. 使用`DBeaver`连接时打开驱动属性，配置`allowPublicKeyRetrieval`=True


Dear Gradient Recruitment Team,

I am writing to express my interest in the Application Developer position at Gradient, as advertised on Deakin Talent. I have a passion for coding and a love for logic, which has always captivated me. Moreover, I am aware that Gradient is a team full of enthusiasm and vitality, and I would be thrilled to contribute to such a talented team.

Currently, I am a Master's student in Information Technology at Deakin University. Previously, I served as the system lead for critical systems at a Fortune 500 company.

Throughout my career, I have demonstrated the ability to expand and maintain complex application functionalities, ensuring they meet stringent performance and reliability standards. My strong analytical and problem-solving skills have helped rectify significant production hazards, earning recognition from both leaders and colleagues. Additionally, my attention to detail and exceptional problem-solving ability have contributed to my growth in environments that emphasize effective communication. My passion for coding drives me to continually seek innovative solutions and contribute to the design and delivery of new features.

In previous roles, I utilized my expertise in Java, Spring, Spring Boot, and more to develop RESTful-style APIs and construct highly available and scalable microservice systems. From automated testing of applications using JUnit to ensuring efficient CI/CD pipelines with tools such as Docker, Jenkins, and Ansible scripts, I have gained diverse experience. I am well-versed in Alibaba Cloud services and concepts such as VPC, EC2, ECS, SG, CloudFormation, CloudWatch, and RDS. Additionally, I am familiar with event broker messaging frameworks like RabbitMQ and Kafka. Furthermore, I have self-studied AWS-related knowledge, understanding that while platforms may differ, the underlying principles remain the same. My proficiency in automated testing with JUnit and familiarity with various databases, including DynamoDB and MySQL, further enhance my ability to deliver robust solutions.

Moreover, I prioritize driving strategic roadmaps, collaborating with stakeholders, and ensuring solutions are adequately documented and transitioned into business-as-usual operations. My commitment to continuous improvement aligns with Gradient's dedication to delivering exceptional results while maintaining cost control.

I am eager to bring my development skills, cloud infrastructure expertise, and collaborative approach to Gradient. I believe my skills and experience make me a strong candidate for this position, and I look forward to discussing how I can further contribute to your team.

Thank you for considering my application. I am excited about the possibility of joining Gradient and contributing to its success. Please find my resume attached.

Sincerely,


The attachment contains my application materials. Please review them at your convenience.