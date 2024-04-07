# 下载
官网：[MariaDB](https://mariadb.org/download/)
选择 MariaDB 10.11.7 版本，操作系统 Windows，架构 x86_64，包格式ZIP file，选好后点Download来下载

# 安装
管理员身份运行powershell
进入mariadb下bin目录，执行 mysql_install_db.exe --datadir=D:\\db\\mariadb-10.11.7\\data --service=mariadb1011 --password=123456
- mariadb1011是服务名称
- root/123456

# 卸载
- 删除环境变量
- 删除服务
以管理员身份运行：sc delete mariadb1011
- 删除安装包和解压文件