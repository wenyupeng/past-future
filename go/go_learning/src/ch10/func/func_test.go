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

func Sum(ops ...int) int {
	ret := 0
	for _, op := range ops {
		ret += op
	}
	return ret
}

func TestVarParam(t *testing.T) {
	t.Log(Sum(1, 2, 3, 4))
	t.Log(Sum(1, 2, 3, 4, 5))
}

func TestDefer(t *testing.T) {
	defer func() {
		t.Log("clear resources")
	}()
	t.Log("Started")
	panic("Fatal error") //抛出程序异常，defer仍会执行
}

func Clear() {
	fmt.Println("execute defer")
	fmt.Println("clear resources.")
}

func TestDefer2(t *testing.T) {
	t.Log("before defer")
	defer Clear()
	t.Log("after defer")
	panic("throw err")
	t.Log("after panic")
}
