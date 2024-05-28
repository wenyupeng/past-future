此文档目的在于方便大家快速搭建mongodb环境，不影响使用mongodb开发或者学习。
不可用于生产。
一、docker安装mongodb
（1）创建挂载目录：
docker volume create mongo_data_db;
docker volume create mongo_data_configdb;
（2）启动 MognoDB：
拉取镜像
docker pull mongo
通过mongodb镜像运行一个名字叫mymongo的容器
docker run -d \
--name mymongo \
-v mongo_data_configdb:/data/configdb \
-v mongo_data_db:/data/db \
-p 27017:27017 \
mongo --auth
查看容器：
（3）初始化管理员账号：
docker exec -it mymongo mongosh admin    
# docker exec -it <容器名> <mongo命令> <数据库名>
创建最高权限用户
db.createUser({ user: 'admin', pwd: 'adminpwd', roles: [ { role: "root", db: "admin" } ] });
user:用户名admin
pwd:密码adminpwd
role:角色root
db:授权使用admin库
(4）防火墙开放端口27017
firewall-cmd --zone=public --add-port=27017/tcp --permanent
firewall-cmd --reload
firewall-cmd --query-port=27017/tcp
二、使用第三方客户端连接

https://developer.aliyun.com/article/1499075?spm=5176.26934562.main.1.113e6737zem4ly