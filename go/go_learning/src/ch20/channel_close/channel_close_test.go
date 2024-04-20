package channel_close

import (
	"fmt"
	"sync"
	"testing"
)

func dataProducer(ch chan int, wg *sync.WaitGroup) {
	go func() {
		for i := 0; i < 10; i++ {
			ch <- i
		}
		close(ch)
		//ch <- 11 //往关闭的channel发送消息会导致一场
		wg.Done()
	}()
}

func dataReceiver(no int, ch chan int, wg *sync.WaitGroup) {
	fmt.Println("receiver no : ", no)
	go func() {
		for {
			if data, ok := <-ch; ok {
				fmt.Println(no, "=====", data)
			} else {
				break
			}
		}
		wg.Done()
	}()
}

func TestCloseChannel(t *testing.T) {
	var wg sync.WaitGroup
	ch := make(chan int)
	wg.Add(1)
	dataProducer(ch, &wg)
	wg.Add(1)
	dataReceiver(1, ch, &wg)
	wg.Add(1)
	dataReceiver(2, ch, &wg)
	wg.Wait()
}
