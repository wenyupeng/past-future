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