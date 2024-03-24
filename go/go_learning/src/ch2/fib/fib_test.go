package fib

import (
	"testing"
)

func TestFibList(t *testing.T) {
	//定义变量方式1
	//var a int = 1
	//var b int = 1
	// 定义变量方式2
	//var (
	//	a int =1
	//	b int =1
	//)
	//定义变量方式3
	a := 1
	b := 1
	//fmt.Println(a, " ")
	t.Log(a, " ")
	for i := 0; i < 5; i++ {
		//fmt.Println(" ", b)
		t.Log(" ", b)
		tmp := a
		a = b
		b = tmp + a
	}
}

func TestExchange(t *testing.T) {
	a := 1
	b := 2
	//tmp := a
	//a = b
	//b = tmp
	a, b = b, a
	t.Log(a, b)
}
