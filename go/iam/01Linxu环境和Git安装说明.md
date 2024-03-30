# 新建用户
- useradd going # 创建 going 用户，通过 going 用户登录开发机进行开发
- passwd going # 设置密码
- su going # 切换用户

# 添加 sudoers
- sed -i '/^root.*ALL=(ALL).*ALL/a\going\tALL=(ALL) \tALL' /etc/sudoers

# 配置 $HOME/.bashrc
- 进入路径 /home/going
- vi .bashrc
````
# .bashrc
# User specific aliases and functions
alias rm='rm -i'
alias cp='cp -i'
alias mv='mv -i'
# Source global definitions
if [ -f /etc/bashrc ]; then
. /etc/bashrc
fi
# User specific environment
# Basic envs
export LANG="en_US.UTF-8" # 设置系统语言为 en_US.UTF-8，避免终端出现中文乱码
export PS1='[\u@dev \W]\$ ' # 默认的 PS1 设置会展示全部的路径，为了防止过长，这里只展示
export WORKSPACE="$HOME/workspace" # 设置工作目录
export PATH=$HOME/bin:$PATH # 将 $HOME/bin 目录加入到 PATH 变量中
# Default entry folder
cd $WORKSPACE # 登录系统，默认进入 workspace 目录
````

- mkdir -p $HOME/workspace # 创建 workspace目录
# 依赖安装和配置
# 安装依赖
- sudo yum -y install make autoconf automake cmake perl-CPAN libcurl-devel libtool gcc gcc-c++ glibc-headers zlib-devel git-lfs telnet ctags lrzsz jq expat-devel openssl-devel

# 安装 Git
- cd /tmp
- wget https://mirrors.edge.kernel.org/pub/software/scm/git/git-2.30.2.tar.gz
- tar -xvzf git-2.30.2.tar.gz
- cd git-2.30.2/
- ./configure
- make
- sudo make install
- git --version # 输出 git 版本号，说明安装成功
git version 2.30.2

# 把 git 的 bin 目录添加到 PATH 中
tee -a $HOME/.bashrc <<'EOF' # Configure for git
export PATH=/usr/local/libexec/git-core:$PATH
EOF

# 配置 git 
- git config --global user.name "chris" # 用户名改成自己的
- git config --global user.email "chrisyupengwen@gmail.com" # 邮箱改成自己的
- git config --global credential.helper store # 设置 Git，保存用户名和密码
- git config --global core.longpaths true # 解决 Git 中 'Filename too long' 的错误

## 在 git 中，会把非ASCII字符叫做Unusual字符。此类字符在Git输出到终端的时候默认是用8进制转义字符输出（以防乱码），但现在的终端多数都支持直接显示ASCII字符，这个特性需要关闭
- git config --global core.quotepath off

# 提高 github 访问速度
-  git config --global url."https://github.com.cnpmjs.org/".insteadOf "https://github.com/"
> 通过镜像网站访问仅能对HTTPS协议生效，对SSH协议不生效，并且github.com.cnpmjs.org的同步时间间隔为1天

# 安装 Git Large File Storage 
- git lfs install --skip-repo
> Github限制最大只能克隆100M的仓库，为了能够克隆容量大于100M的仓库，需要安装 Git Large File Storage
