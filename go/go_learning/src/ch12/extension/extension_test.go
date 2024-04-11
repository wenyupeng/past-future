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
	p *Pet
}

func (d *Dog) Speak() {
	fmt.Print("Dog speak")
	d.p.Speak()
}

func (d *Dog) SpeakTo(host string) {
	fmt.Println("Dog speak to ", host)
	d.p.SpeakTo(host)
}

func TestDog(t *testing.T) {
	dog := new(Dog)
	dog.SpeakTo("hello")
}
