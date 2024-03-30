package _func

import (
	"fmt"
	"math/rand"
	"testing"
	"time"
)

func returnMultiValues() (int, int) {
	return rand.Intn(10), rand.Intn(20)
}

func TestFn(t *testing.T) {
	//a, b := returnMultiValues()
	a, _ := returnMultiValues()
	//t.Log(a, b)
	t.Log(a)
}

/*
*
类似装饰者模式
*/
func timeSpent(inner func(op int) int) func(op int) int {
	return func(n int) int {
		start := time.Now()
		fmt.Println("before run slowFun")
		ret := inner(n) // 调用原函数
		fmt.Println("time spent:", time.Since(start).Seconds())
		return ret
	}
}

func slowFun(op int) int {
	fmt.Println("slowFun is running")
	time.Sleep(time.Second * 1)
	return op
}

func TestFun(t *testing.T) {
	a, _ := returnMultiValues()
	t.Log(a)

	tsSF := timeSpent(slowFun)
	t.Log(tsSF(10))

}
