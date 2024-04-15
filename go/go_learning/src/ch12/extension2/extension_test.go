package extension

import (
	"fmt"
	"testing"
)

type Pet struct {
}

func (p *Pet) Speak() {
	fmt.Print("Pet speak")
}

func (p *Pet) SpeakTo(host string) {
	p.Speak()
	fmt.Println(" ", host)
}

type Dog struct {
	Pet
}

func TestDog(t *testing.T) {
	//var dog *Dog = new(Dog)
	//var p = (*Pet)(Dog)
	dog := new(Dog)
	dog.SpeakTo("hello")
}
