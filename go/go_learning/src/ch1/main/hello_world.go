package main

import (
	"fmt"
	"os"
)

func main() {
	fmt.Println(os.Args)
	if len(os.Args) > 1 {
		// go run hello_world.go wen
		fmt.Println("Hello World", os.Args[1])
	}

	os.Exit(-1)
}
