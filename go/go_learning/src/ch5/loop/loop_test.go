package loop

import (
	"fmt"
	"testing"
)

func TestWhileLoop(t *testing.T) {
	n := 0
	//while 条件循环
	//while (n<5)
	for n < 5 {
		n++
		fmt.Println(n)
	}

	//无限循环
	//while (true)
	for {

	}
}
