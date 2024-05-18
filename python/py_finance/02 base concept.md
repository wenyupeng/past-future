- 列表是动态的：长度大小不固定，可以随意地增加、删减或者改变元素（mutable）
- 元组是静态的：长度大小固定、无法增加删减或者改变（immutable）
参考 test.py -> func_01

- Python中的列表和元组都支持负数索引，-1 表示最后一个元素，-2表示倒数第二个元素
- 列表和元组都支持切片操作，[1:3] 表示从索引为1开始，到索引为2的所有元素
- 列表和元组都可以随意嵌套
```
l = [[1, 2, 3], [4, 5]] # 列表的每一个元素也是一个列表
tup = ((1, 2, 3), (4, 5, 6)) # 元组的每一个元素也是一元组
```

- 列表和元组可以通过`list()`和`tuple()`函数进行转换
```
list((1, 2, 3))
[1, 2, 3]
 
tuple([1, 2, 3])
(1, 2, 3)
```
- 列表和元祖常用的内置函数
```
list: count()\index()\reverse()\sort()
tuple: count()\index()\sorted(tup)
list(reversed(tup)) # 元组转换为列表
```
- 计算初始化一个相同元素的列表和元组分别所需的时间
```
python -m timeit 'x=(1,2,3,4,5,6)'
20000000 loops, best of 5: 9.97 nsec per loop
python -m timeit 'x=[1,2,3,4,5,6]'
5000000 loops, best of 5: 50.1 nsec per loop
# 元组的初始化速度，要比列表快 5 倍
```
- 索引操作: 列表和元组的速度差别非常小
```
python -m timeit -s 'x=[1,2,3,4,5,6]' 'y=x[3]'
10000000 loops, best of 5: 22.2 nsec per loop
python -m timeit -s 'x=(1,2,3,4,5,6)' 'y=x[3]'
10000000 loops, best of 5: 21.9 nsec per loop
```
- 列表和元组的使用场景
```markdown
1. 如果存储的数据和数量不变，比如有一个函数，需要返回的是一个地点的经纬度，然后直接传给前端渲染，那么肯定选用元组更合适。
def get_location():
.....
return (longitude, latitude)
2. 如果存储的数据或数量是可变的，比如社交平台上的一个日志功能，是统计一个用户在一周之内看了哪些用户的帖子，那么则用列表更合适。
viewer_owner_id_list = [] # 里面的每个元素记录了这个 viewer 一周内看过的所有 owner 的 id
records = queryDB(viewer_id) # 索引数据库，拿到某个 viewer 一周内的日志
for record in records:
viewer_owner_id_list.append(record.id)
```
- 列表和元组的区别
  - 列表是动态的，长度可变，可以随意的增加、删减或改变元素。列表的存储空间略大于元组，性能略逊于元组。
  - 元组是静态的，长度大小固定，不可以对元素进行增加、删减或者改变操作。元组相对于列表更加轻量级，性能稍优。

- 集合和字典的区别
  - 字典在`Python3.7+`后被设计为有序，长度大小可变，元素可以任意地删减和改变
  - 集合没键值对，是一系列无序的、唯一的元素组合