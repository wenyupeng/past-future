软件开发的新挑战
1. 多核硬件架构
2. 超大规模分布式计算集群
3. Web模式导致的前所未有的开发规模和更新速度

符合大于继承
安装：

https://github.com/jjz/blog/blob/master/golang/Atom%E9%85%8D%E7%BD%AEgo%E5%BC%80%E5%8F%91%E7%8E%AF%E5%A2%83.md
https://golang.google.cn/dl/

应用程序入口
1. 必须是main包：package main
2. 必须是main方法：func main()
3. 文件名不一定是main.go

推出返回值
- Go中main函数不支持任何返回值
- 通过os.Exit来返回状态

获取命令行参数
- main函数不支持传入参数 func main(arg []string)
- 程序中直接通过os.Args获取命令行参数

编写测试程序
1. 源码文件以_test结尾：xxx_test.go
2. 测试方法名以Test开头：func TestXXX(t *testing.T){....}

变量赋值
- 赋值可以进行自动类型推断
- 在一个赋值语句中可以对多个变量进行同时赋值

常量定义
快速设置连续值
const(
Monday = iota +1
Tuesday
Wednesday
Thursday
Friday
Saturday
Sunday
)

const(
Open = 1 << iota
Close
Pending
)

基本数据类型
bool
string
int int8 int16 int32 int64
uint uint8 uint16 uint32 uint64 uintptr
byte // alias for uint
rune // alias for int32, represents a Unicode code point
float32 float64
complex64 complex128

类型转换
1. Go语言不允许隐式类型转换
2. 别名和原有类型也不能进行隐式类型转换

类型的预定义值
1. math.MaxInt64
2. math.MaxFloat64
3. math.MaxUint32

指针类型
1. 不支持指针运算
2. string 是值类型，其默认的初始化值为空字符串，而不是nil

算术运算符
A=10
B=20

| 运算符 | 描述  | 实例        |
|-----|-----|-----------|
| +   | 相加  | A+B = 30  |
| -   | 相减  | A-B = -10 |
| *   | 相乘  | A*B = 200 |
| /   | 相除  | B/A = 2   |
| %   | 求余  | B%A =0    |
| ++  | 自增  | A++ =11   |
| --  | 自减  | A-- =9    |

Go语言没有前置的++,--,

-------------
比较运算符

| 运算符 | 描述             |
|-----|----------------|
| ==  | 检查两个值是否相等      |
| !=  | 检查两个值是否不相等     |
| >   | 检查左边值是否大于右边值   |
| <   | 检查左边值是否小于右边值   |
| >=  | 检查左边值是否大于等于右边值 |
| <=  | 检查左边值是否小于等于右边值 |

用 == 比较数组
- 相同维数且含有相同个数元素的数组才可以比较
- 每个元素都相同的才相等

-------------
逻辑运算符
- && 与 AND 如果两边的操作数都是True，则条件为True
- || 或 OR 如果两边的操作数有一个为True，则条件为True，否则为False
- ! 非 NOT 如果条件为True，则逻辑NOT条件为False 

-------------
位运算符
- & 按位与运算符"&"是双目运算符。其功能是参与运算的两数各对应的二进位相与
- | 按位或运算符"|"是双目运算符。其功能是参与运算的两数各对应的二进位相或
- ^ 按位异或运算符"&"是双目运算符。其功能是参与运算的两数各对应的二进位相异或
- << 左移位运算符"<<"是双目运算符，左移n位就是乘以2的n此番。
- >> 右移位运算符">>"是双目运算符，右移n位就是乘以2的n此番。
- &^ 按位置零 右边为1，则清零， 右边不为1，则左边保留原值
  - 1 &^ 0 -- 1
  - 1 &^ 1 -- 0
  - 0 &^ 1 -- 0
  - 0 &^ 0 -- 0
-------------

循环
Go语言仅仅支持循环关键字 for
for (j := 7; j<=9; j++)

if 条件
1. condition 表达式结果必须为布尔值
2. 支持变量赋值
if condition{
}else{}

if condition -1{}
else if condition -2{}
else{}

if var declaration; condition{}

switch条件
1. 条件表达式不限制为常量或者整数；
2. 单个case中，可以出现多个结果选项，使用逗号分隔；
3. 与C语言等规则相反，Go语言不需要用break来明确退出一个case；
4. 可以不设定switch之后的条件表达式，在此种情况下，整个switch结构与多个if...else...的逻辑作用相同
switch os :=runtime.GOOS; os{
case "darwin":
fmt.Println("OS X.")
case "linux":
fmt.printLn("Linux.")
default:
fmt.Printf("%s.",os)
}

switch{
case 0<=Num && Num <=3
fmt.Printf("0-3")
case 4<=Num && Num <=6
fmt.Printf("4-6")
case 7<=Num && Num <=9
fmt.Printf("7-9")
}

数组的声明
var a [3]int //声明并初始化为默认零值
a[0] =1
b :=[3]int{1,2,3} //声明同时初始化
c :=[2][2] int{{1,2},{3,4}} //多维数组初始化


数组元素遍历
func TestTravelArray(t *testing.T){
a :=[...]int{1,2,3,4,5}//不指定元素个数
for idx/*索引*/,elem/*元素*/ :=range a {
fmt.Println(idx,elem)}
}

数组截取
a[开始索引(包含),结束索引(不包含)]
a :=[...]int{1,2,3,4,5}
a[1:2] //2
a[1:3] //2,3
a[1:len(a)] //2,3,4,5
a[1:] //2,3,4,5
a[:3] //1,2,3

切片内部结构
ptr(*Elem):
len(int): 元素个数
cap(int): 内部数组的容量

切片声明
var s0 []int
s0 = append(s0,1)
s := []int[]
s1 := []int{1, 2, 3, 4}
s1 := make([]int,2,4)  => []type,len,cap
len个元素会被初始化为默认零值，未初始化元素不可以访问

数组与切片
1. 容量是否可伸缩
2. 是否可以进行比较

Map 声明
m := map[string]int{"one":1,"two":2,"three":3}
m1 := map[string]int{}
m1["one"]=1
m2 := make(map[string]int,10)

Map 元素的访问
在访问的key不存在时，仍会返回零值，不能通过返回nil来判断元素是否存在
if v, ok := m["four"]; ok {
t.Log("four",v)
} else {
t.Log("not existing.")
}

Map遍历
m := map[string]int{"one":1,"two":2,"three":3}
for k,v :=range m{
t.Log(k,v)
}

Map与工厂模式
- Map的value可以是一个方法
- 与GO的Dock type接口方式一起，可以方便的实现单一方法对象的工厂模式 

实现Set
Go的内置集合中没有Set实现，可以map[type]bool
1. 元素的唯一性

字符串
1. string是数据类型，而不是引用或指针类型
2. string是只读的 byte slice， len函数显示它所包含的byte数
3. string的byte数组可以存放任何数据

Unicode UTF8
1. Unicode 是一种字符集(code point)
2. UTF8 是unicode的存储实现(转换为字节序列的规则)
编码与存储

| 字符            | "中"              |
|---------------|------------------|
| Unicode       | 0x4E2D           |
| UTF-8         | 0xE4B8AD         |
| string/[]byte | [0xE4,0xB8,0xAD] |

常用字符串函数
1. strings 包(https://golang.org/pkg/strings/)
2. strconv 包(https://golang.org/pkg/strconv)

函数
1. 可以有多个返回值
2. 所有参数都是值传递: slice, map, channel 会有传引用的错觉
3. 函数可以作为变量的值
4. 函数可以作为参数和返回值

学习函数式编程: <计算机程序的构造和解释>

可变参数
func sum(ops ...int) int{
s :=0
for _,op := range ops{
s+=op}
return s 
}

defer函数
defer func() {
t.Log("clear resources")
}()
t.Log("Started")
panic("Fatal error") //defer仍会执行

结构体定义
type Employee struct {
Id string
Name string
Age int
}

实例创建及初始化
e :=Employee{"0","Bob",20}
e1 :=Employee{Name:"Mike",Age:30}
e2 := new(Employee) //注意这里返回的引用/指针,相当于 e :=&Employee{}
e2.Id ="2" //与其他主要编程语言的差异: 通过实例的指针访问成员不需要使用
e2.Age =22
e2.Name ="Rose"

type Employee struct {
Id   string
Name string
Age  int
}

// 第一种定义方式在实例对应方法被调用时，实例的成员会进行值复制
func (e Employee) String() string {
fmt.Printf("Address is %x \n", unsafe.Pointer(&e.Name))
return fmt.Sprintf("ID:%s/Name:%s/Age:%d", e.Id, e.Name, e.Age)
}

// 通常情况下为避免内存拷贝，使用第二种定义方式
//func (e *Employee) String() string {
//	fmt.Printf("Address is %x \n", unsafe.Pointer(&e.Name))
//	return fmt.Sprintf("ID:%s/Name:%s/Age:%d", e.Id, e.Name, e.Age)
//}

type Programmer interface {
WriteHelloWorld() Code
}

type GoProgrammer struct {
}

func (p *GoProgrammer) WriteHelloWorld() Code {
return "fmt.Println(\"Hello World!\")"
}

Go 接口
1. 接口为非入侵性，实现不依赖于接口定义
2. 所以接口的定义可以包含在接口使用者包内


自定义类型
1. type IntConvertionFn func(n int) int
2. type MyPoint int

type Code string
type Programmer interface {
writeHelloWorld() Code
}

type GoProgrammer struct {
}

func (p *GoProgrammer) writeHelloWorld() Code {
return "fmt.Println(\"Hello World!\")"
}

type JavaProgrammer struct {
}

func (p *JavaProgrammer) writeHelloWorld() Code {
return "System.out.Println(\"Hello World!\")"
}

func writeFirstProgram(p Programmer) {
fmt.Printf("%T %v\n", p, p.writeHelloWorld())
}

func TestPolymorphism(t *testing.T) {
goProg := new(GoProgrammer) // new(GoProgrammer) &GoProgrammer{} 产生指针 GoProgrammer{}产生实例
javaProg := new(GoProgrammer)
writeFirstProgram(goProg)
writeFirstProgram(javaProg)
}

空接口与断言
1. 空接口可以表示任何类型
2. 通过断言来将空接口转换为定制类型 v,ok :=p.(int) // ok =true 时转换成功

Go接口最佳实践
倾向于使用小的接口定义，很多接口只包含一个方法
````
type Reader interface{
 Read(p []byte)(n int,err,error)
}
type Writer interface{
  Write(p []byte)(n int,err,error)
}
````
较大的接口定义，可以由多个小接口定义组合而成
````
type ReadWriter interface{
 Reader
 Writer
}
````
只依赖于必要功能的最小接口
````
func StoreData(reader Reader)error{
...
}
````

Go的错误机制
1. 没有异常机制
2. error类型实现了error接口
````
type error interface {
Error() string
}
````
3. 可以通过errors.New来快速创建错误实例 errors.New("n must be in the range [0,10]")


panic
- panic 用于不可以恢复的错误
- panic退出前会执行defer指定的内容

os.Exit
- os.Exit 退出时不会调用defer指定的函数
- os.Exit 退出时不输出当前调用栈信息

package 
1. 基本复用模块单元：以首字母大写来表明可被包外代码访问
2. 代码的 package 可以和所在的目录不一致
3. 同一目录理的Go代码的 package 要保持一致

GO111MODULE
- 默认模式（未设置该环境变量或 GO111MODULE=auto）：Go 命令行工具在同时满足以下两个条件时使用 Go Modules：
当前目录不在 GOPATH/src/ 下；
在当前目录或上层目录中存在 go.mod 文件。
- GOPATH 模式（GO111MODULE=off）：Go 命令行工具从不使用 Go Modules。相反，它查找 vendor 目录和 GOPATH 以查找依赖项。
- Go Modules 模式（GO111MODULE=on）：Go 命令行工具只使用 Go Modules，从不咨询 GOPATH。GOPATH 不再作为导入目录，但它仍然存储下载的依赖项（GOPATH/pkg/mod/）和已安装的命令（GOPATH/bin/），只移除了 GOPATH/src/。

init方法
- 在main被执行前，所有依赖的package的init方法都会被执行
- 不同包的init函数按照包导入的依赖关系决定执行顺序
- 每个包可以有多个init函数
- 包的每个源文件也可以有多个init函数

package
1. 通过 go get 来获取远程依赖
   a. go get -u 强制从网络更新远程依赖
2. 注意代码在GitHub上的组织形式，以适应 go get
   a. 直接以代码路径开始，不要有src

GO未解决的问题
1. 同一环境下，不同项目使用同一包的不同版本
2. 无法管理对包的特定版本的依赖

vendor路径
随着Go 1.5 release版本的发布，vendor目录被添加到除了 GOPATH 和 GOROOT 之外的依赖目录查找的解决方案。在 Go 1.6 之前，你需要手动设置环境变量
查找依赖包路径的解决方案：
1. 当前包下的vendor目录
2. 向上级目录查找，直到找到 src下的 vendor目录
3. 在 GOPATH 下面查找依赖包
4. 在 GOROOT 目录下查找

常用的依赖管理工具
godep https://github.com/tools/godep
glide https://github.com/Masterminds/glide
dep https:// github.com/golang/dep

Thread vs Groutine
1. 创建时默认的stack的大小
   1. JDK5后默认 java Thread stack 大小为1M
   2. Groutine的 Stack初始化大小为 2k
2. 和KSE (Kernel Space Entity) 的对应关系
   1. Java Thread 是 1:1
   2. Groutine 是 M:N

WaitGroup
var wg sync.WaitGroup
for i:=0; i<5000; i++{
wg.Add(1)
go func(){
defer func(){
wg.Done()
}()
...
}()
}
wg.Wait() 
 
CSP vs.Actor
- 和Actor的直接通讯不同，CSP模式是通过 Channel 进行通信
- Go中 channel 是有容量限制并且独立于处理 Groutine ，而如Erlang, Actor模式中的mailbox容量是无限的，接收进程也总是被动处理消息

多渠道选择
select {
case ret := <- retCh1:
    t.Logf("result %s",ret)
case ret := <- retCh2:
    t.Logf("result %s",ret)
default:
    t.Error("No one returned")
}

超时控制
select{
case ret := <-retCh:
    t.Logf("result %s",ret)
case <- time.After(time.Second *1):
    t.Error("time out")
}

channel 的关闭
- 向关闭的 channel 发送数据，会导致 panic
- v,ok <- ch; ok 为 bool 值， true 表示正常接受，false 表示通道关闭；
- 所有的 channel 接受者都会在 channel 关闭时，立刻从阻塞等待中返回且上述 ok 值为 false。这个广播机制常被利用，进行向多个订阅者发送信号。如退出信号。

Context
- 根 Context：通过 context.Background() 创建
- 子 Context: context.WithCancel(parentContext)创建
  - ctx,cancel := context.WithCancel(context.BackGround())
- 当前 Context 被取消时，基于他的子 context 都会被取消
- 接收取消通知 <- ctx.Done()


