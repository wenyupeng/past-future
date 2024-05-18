def func_01():
    l = [1, 2, 3, 4]
    l[3] = 40  # 和很多语言类似，python 中索引同样从 0 开始，l[3] 表示访问列表的第四个元素
    l.append(5) # 添加元素 5 到原列表的末尾
    print(l)
    tup = (1, 2, 3, 4)
    tup[3] = 40
    print(tup)  # tuple' object does not support item assignment

def func_02():
    tup = (1, 2, 3, 4)
    new_tup = tup + (5, ) # 创建新的元组 new_tup，并依次填充原元组的值
    print(new_tup)


def func_03():
    l = [1, 2, 3, 4]
    print(l[-1])
    print(l[-2])
    print(l[1:3])
    print(l.__sizeof__()) # 72

    tup = (1, 2, 3, 4)
    print(tup[-1])
    print(tup[1:3])
    print(tup.__sizeof__()) # 56


def func_04():
    l = []
    print(l.__sizeof__())
    print('空列表的存储空间为 %d 字节',l.__sizeof__())

    l.append(1)
    print(l.__sizeof__())
    print('加入了元素 1 之后，列表为其分配了可以存储 4 个元素的空间 (72 - 40)/8 = 4')

    l.append(2)
    print(l.__sizeof__())
    print('由于之前分配了空间，所以加入元素 2，列表空间不变')

    l.append(3)
    print(l.__sizeof__())
    print('由于之前分配了空间，所以加入元素 3，列表空间不变')

    l.append(4)
    print(l.__sizeof__())
    print('由于之前分配了空间，所以加入元素 4，列表空间不变')

    l.append(5)
    print(l.__sizeof__())
    print('加入元素 5 之后，列表的空间不足，所以又额外分配了可以存储 4 个元素的空间')


if __name__ == '__main__':
    # func_01()
    # func_02()
    # func_03()
    func_04()

