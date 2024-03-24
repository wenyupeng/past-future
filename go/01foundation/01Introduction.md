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
- |
- ^
- <<
- >>
