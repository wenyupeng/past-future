package util_anyone_reply

import (
	"fmt"
	"runtime"
	"testing"
	"time"
	"unsafe"
)

func runTask(id int) string {
	time.Sleep(time.Millisecond * 10)
	return fmt.Sprintf("the result is from %d", id)
}

func FirstResponse() string {
	numOfRunner := 10
	//ch := make(chan string)
	ch := make(chan string, 10)
	for i := 0; i < numOfRunner; i++ {
		go func(i int) {
			ret := runTask(i)
			fmt.Println("==== insert ", i)
			ch <- ret
			fmt.Println("==== ch size ", unsafe.Sizeof(ch))
		}(i)
	}
	return <-ch
}

func TestFirstResponse(t *testing.T) {
	t.Log("before:", runtime.NumGoroutine())
	t.Log(FirstResponse())
	time.Sleep(time.Second * 1)
	t.Log("after:", runtime.NumGoroutine())
}
