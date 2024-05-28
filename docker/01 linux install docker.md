如果您需要在云服务ECS上安装Docker，可使用阿里云提供的Docker镜像源快速部署。本文主要介绍如何基于Alibaba Cloud Linux和CentOS镜像安装Docker、使用Docker制作镜像和部署docker-compose，以便更高效地构建、部署和管理应用程序。

准备资源
已创建一台基础ECS实例，并满足以下配置。如果您还未创建，请参见自定义购买实例。

操作系统：CentOS 7.x 64位、CentOS 8.x 64位、Alibaba Cloud Linux 3 64位、Alibaba Cloud Linux 2 64位

网络类型：专有网络VPC

IP地址：实例已分配公网IP地址或绑定弹性公网IP（EIP）。具体操作，请参见绑定和解绑弹性公网IP。

安全组：入方向放行80、22、8080端口。具体操作，请参见添加安全组规则。

安装Docker
远程连接ECS实例。

关于连接方式的介绍，请参见连接方式概述。

安装Docker。

Alibaba Cloud Linux 3Alibaba Cloud Linux 2CentOS 7.xCentOS 8.x
切换CentOS 8源地址。

CentOS 8操作系统版本结束了生命周期（EOL），按照社区规则，CentOS 8的源地址http://mirror.centos.org/centos/8/内容已移除，您在阿里云上继续使用默认配置的CentOS 8的源会发生报错。如果您需要使用CentOS 8系统中的一些安装包，则需要手动切换源地址。具体操作，请参见CentOS 8 EOL如何切换源？。

运行以下命令，安装DNF。


sudo yum -y install dnf
运行以下命令，安装Docker存储驱动的依赖包。


sudo dnf install -y device-mapper-persistent-data lvm2
运行以下命令，添加稳定的Docker软件源。


sudo dnf config-manager --add-repo=https://mirrors.aliyun.com/docker-ce/linux/centos/docker-ce.repo
运行以下命令，检查Docker软件源是否已添加。


sudo dnf list docker-ce
出现如下图所示回显，表示Docker软件源已添加。

image..png

运行以下命令安装Docker。


sudo dnf install -y docker-ce --no best
执行以下命令，检查Docker是否安装成功。


sudo docker -v
如下图回显信息所示，表示Docker已安装成功。

image..png

执行以下命令，启动Docker服务，并设置开机自启动。


sudo systemctl start docker
sudo systemctl enable docker
执行以下命令，查看Docker是否启动。


sudo systemctl status docker
如下图回显所示，表示Docker已启动。

image..png

Docker基本使用
下文只列出Docker基本用法，更详细的操作命令，请参见Docker官网。

管理Docker守护进程


sudo systemctl start docker     #运行Docker守护进程
sudo systemctl stop docker      #停止Docker守护进程
sudo systemctl restart docker   #重启Docker守护进程
sudo systemctl enable docker    #设置Docker开机自启动
sudo systemctl status docker    #查看Docker的运行状态
管理镜像

本文以阿里云仓库的Apache镜像为例，介绍如何使用Docker管理镜像。

拉取镜像。


sudo docker pull registry.cn-hangzhou.aliyuncs.com/lxepoo/apache-php5
修改标签。如果镜像名称较长，您可以修改镜像标签以便记忆区分。


sudo docker tag registry.cn-hangzhou.aliyuncs.com/lxepoo/apache-php5:latest aliweb:v1
查看已有镜像。


sudo docker images
强制删除镜像。


sudo docker rmi -f registry.cn-hangzhou.aliyuncs.com/lxepoo/apache-php5
管理容器

下文的<镜像ID>可通过docker images命令查询。

启动一个新容器。


sudo docker run -it <镜像ID> /bin/bash
启动一个新的容器，让容器在后台运行，并且指定容器的名称。


sudo docker run -d --name <容器名> <镜像ID>
查看容器ID。


sudo docker ps
将容器做成镜像。


sudo docker commit <容器ID或容器名> <仓库名>:<标签>
使用Docker制作镜像
本步骤指导如何通过Dockerfile定制制作一个简单的Nginx镜像。

执行以下命令，拉取镜像。本示例以拉取阿里云仓库的Apache镜像为例。


sudo docker pull registry.cn-hangzhou.aliyuncs.com/lxepoo/apache-php5
修改镜像名称标签，便于记忆。


sudo docker tag registry.cn-hangzhou.aliyuncs.com/lxepoo/apache-php5:latest aliweb:v1
执行以下命令，新建并编辑Dockerfile文件。

执行以下命令，新建并编辑Dockerfile文件。


vim Dockerfile
按i进入编辑模式，并添加以下内容，改造原镜像。


#声明基础镜像来源。
FROM aliweb:v1
#声明镜像拥有者。
MAINTAINER DTSTACK
#RUN后面接容器运行前需要执行的命令，由于Dockerfile文件不能超过127行，因此当命令较多时建议写到脚本中执行。
RUN mkdir /dtstact
#开机启动命令，此处最后一个命令需要是可在前台持续执行的命令，否则容器后台运行时会因为命令执行完而退出。
ENTRYPOINT ping www.aliyun.com
按Esc键，输入:wq并按Enter键，保存并退出Dockerfile文件。

执行以下命令，基于基础镜像nginx构建新镜像。

命令格式为docker build -t <镜像名称>:<镜像版本> .，命令末尾的.表示Dockerfile文件的路径，不能忽略。以构建新镜像aliweb:v2为例，则命令为：


sudo docker build -t aliweb:v2 .
执行以下命令，查看新镜像是否构建成功。


sudo docker images
如下图回显所示，表示构建成功。

image..png

安装并使用docker-compose
docker-compose是Docker官方提供的用于定义和运行多个Docker容器的开源容器编排工具，可以使用YAML文件来配置应用程序需要的所有服务，然后使用docker-compose运行命令解析YAML文件配置，创建并启动配置文件中的所有Docker服务，具有运维成本低、部署效率高等优势。

关于docker-compose的更多信息，请参见Docker官网。

重要
仅Python 3及以上版本支持docker-compose，并请确保已安装pip。

安装docker-compose
运行以下命令，安装setuptools。


sudo pip3 install -U pip setuptools
运行以下命令，安装docker-compose。


sudo pip3 install docker-compose
运行以下命令，验证docker-compose是否安装成功。


docker-compose --version
如果回显返回docker-compose版本信息，表示docker-compose已安装成功。

使用docker-compose部署应用
下文以部署WordPress为例，介绍如何使用docker-compose部署应用。

创建并编辑docker-compose.yaml文件。

运行以下命令，创建docker-compose.yaml文件。


sudo vim docker-compose.yaml
按下i键，进入编辑模式，新增以下内容。

本示例以安装WordPress为例。


version: '3.1'             # 版本信息

services:

wordpress:               # 服务名称         
image: wordpress       # 镜像名称
restart: always        # docker启动，当前容器必启动
ports:
- 80:80              # 映射端口
environment:           # 编写环境
WORDPRESS_DB_HOST: db
WORDPRESS_DB_USER: wordpress
WORDPRESS_DB_PASSWORD: 123456
WORDPRESS_DB_NAME: wordpress
volumes:               # 映射数据卷
- wordpress:/var/www/html

db:                      # 服务名称    
image: mysql:5.7       # 镜像名称
restart: always        # docker启动，当前容器必启动
ports:
- 3306:3306         # 映射端口
environment:           # 环境变量
MYSQL_DATABASE: wordpress
MYSQL_USER: wordpress
MYSQL_PASSWORD: 123456
MYSQL_RANDOM_ROOT_PASSWORD: '1'
volumes:               # 卷挂载路径
- db:/var/lib/mysql

volumes:
wordpress:
db:
按下Esc键，退出编辑模式，然后输入:wq保存并退出。

执行以下命令，启动应用.


sudo env "PATH=$PATH" docker-compose up -d
在浏览器中输入https://云服务器ECS实例的公网IP，即可进入WordPress配置页面，您可以根据界面提示配置相关参数后，访问WordPress。

https://help.aliyun.com/zh/ecs/use-cases/deploy-and-use-docker-on-alibaba-cloud-linux-2-instances#1db376a005047