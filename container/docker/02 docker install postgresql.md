1. 前提
   postgreSQL

Docker

由于在安装过程中，需要获取 PostgreSQL 的镜像，所以请及时 [[Docker-01：Docker安装及更换源]]。

2. 下载PostgreSQL镜像
   2.1. 检索当前镜像

$ docker search postgres
20220705152209

列名	列描述
NAME	镜像名称
DESCRIPTION	镜像描述
STARS	标星数
OFFICIAL	官方的
AUTOMATED	自动化
话不多说，肯定选官方提供的镜像，同事它也是标星数量最多的。

2.2. 拉取当前镜像
不带版本号，代表为当前阶段最新的，如果需要指定的版本，请使用 docker pull postgres:${VERSION} 其中 ${VERSION} 代表你需要的版本号。

此处演示需要直接用最新版本。


$ docker pull postgres
pull 镜像后，查看镜像


$ docker images
20220705152846

3. 创建挂载文件夹
   在运行 Docker 的系统中，创建一个可以挂在 PostgreSQL 数据文件的地方，方便后面做数据迁移等工作。

此处演示需要，使用了 /data/postgres 当作挂在文件的目录。


[root@localhost ~]$ cd /data/
[root@localhost data]$ mkdir postgres
[root@localhost postgres]$ pwd
/data/postgres
4. 启动镜像

docker run --name postgresql --privileged -e POSTGRES_PASSWORD=password -p 15433:5432 -v /data/postgres:/var/lib/postgresql/data -d postgres
4.1. 查看日志
20220705155606


PostgreSQL Database directory appears to contain a database; Skipping initialization

2022-07-05 07:36:51.259 UTC [1] LOG:  starting PostgreSQL 14.1 (Debian 14.1-1.pgdg110+1) on x86_64-pc-linux-gnu, compiled by gcc (Debian 10.2.1-6) 10.2.1 20210110, 64-bit
2022-07-05 07:36:51.261 UTC [1] LOG:  listening on IPv4 address "0.0.0.0", port 5432
2022-07-05 07:36:51.261 UTC [1] LOG:  listening on IPv6 address "::", port 5432
2022-07-05 07:36:51.264 UTC [1] LOG:  listening on Unix socket "/var/run/postgresql/.s.PGSQL.5432"
2022-07-05 07:36:51.271 UTC [26] LOG:  database system was interrupted; last known up at 2022-07-05 07:24:38 UTC
2022-07-05 07:36:51.292 UTC [26] LOG:  database system was not properly shut down; automatic recovery in progress
2022-07-05 07:36:51.294 UTC [26] LOG:  redo starts at 0/16FAFF0
4.2. 查看进程

docker ps -a
20220705154046

5. 使用连接
   测试数据库是否连接成功，用户名为 postgres；密码为: password。

https://developer.aliyun.com/article/1025077