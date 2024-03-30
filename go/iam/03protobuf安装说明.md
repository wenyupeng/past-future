# 安装 protoc
- 先安装 protoc-gen-go来完成 Go 语言的代码转换 
- cd /tmp/ 
- git clone --depth=1 https://github.com/protocolbuffers/protobuf
- cd protobuf 
- ./autogen.sh 
- ./configure
- make
- sudo make install
- protoc --version # 查看 protoc 版本，成功输出版本号，说明安装成功
  libprotoc 3.15.6

````
官网下载的版本缺少头文件
su root
git submodule update --init --recursive
cd protobuf/cmake
 
#创建build文件夹
mkdir build & cd build
 
#创建release文件夹
mkdir release & cd release
 
#生成makefiles文件
cmake -G "Unix Makefiles" -DCMAKE_BUILD_TYPE=Release -DCMAKE_INSTALL_PREFIX=../../../install/release -Dprotobuf_BUILD_SHARED_LIBS=ON -Dprotobuf_WITH_ZLIB=OFF -Dprotobuf_BUILD_TESTS=OFF ../../..

- 如果cmake报错 undefined symbol archive_write_add_filter_zstd 执行如下代码
yum install  libarchive
 
 
#安装
make install

./protoc --version

https://installati.one/centos/8/protobuf/
https://github.com/protocolbuffers/protobuf/releases
````
# 第二步：安装 protoc-gen-go
- go get -u github.com/golang/protobuf/protoc-gen-go


# 安装 NeoVim
- sudo pip3 install pynvim
- sudo yum -y install neovim

# 配置 $HOME/.bashrc。先配置 nvim 的别名为 vi，这样当我们执行 vi 时，Linux 系统就会默认调用 nvim。同时，配置 EDITOR 环境变量可以使一些工具，例如 Git 默认使用 nvim。配置方法如下
tee -a $HOME/.bashrc <<'EOF'
# Configure for nvim
export EDITOR=nvim # 默认的编辑器（git 会用到）
alias vi="nvim"
EOF

- 检查是否安装成功
- bash
- vi --version

