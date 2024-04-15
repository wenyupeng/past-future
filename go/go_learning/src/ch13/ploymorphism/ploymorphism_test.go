package ploymorphism

import (
	"fmt"
	"testing"
)

type Code string
type Programmer interface {
	writeHelloWorld() Code
}

type GoProgrammer struct {
}

func (p *GoProgrammer) writeHelloWorld() Code {
	return "fmt.Println(\"Hello World!\")"
}

type JavaProgrammer struct {
}

func (p *JavaProgrammer) writeHelloWorld() Code {
	return "System.out.Println(\"Hello World!\")"
}

func writeFirstProgram(p Programmer) {
	fmt.Printf("%T %v\n", p, p.writeHelloWorld())
}

func TestPolymorphism(t *testing.T) {
	goProg := new(GoProgrammer) // new(GoProgrammer) &GoProgrammer{} 产生指针 GoProgrammer{}产生实例
	javaProg := new(GoProgrammer)
	writeFirstProgram(goProg)
	writeFirstProgram(javaProg)
}
