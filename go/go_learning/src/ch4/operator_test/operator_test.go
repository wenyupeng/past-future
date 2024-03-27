package operator_test

import "testing"

func TestCompareArray(t *testing.T) {
	a := [...]int{1, 2, 3, 4}
	b := [...]int{1, 3, 4, 5}
	//c := [...]int{1, 2, 3, 4, 5}
	d := [...]int{1, 2, 3, 4}
	t.Log(a == b)
	//t.Log(a == c)// 数组维数不同报错
	t.Log(a == d)
}

const (
	Readable = 1 << iota
	Writable
	Executable
)

func TestBitClear(t *testing.T) {
	a := 7 //0111
	// &^ 按位置零 右边为1则清零，右边为零则左边保留原值
	a = a &^ Readable // 0110
	t.Log(a)
	t.Log(a&Readable == Readable, a&Writable == Writable, a&Executable == Executable)
}
