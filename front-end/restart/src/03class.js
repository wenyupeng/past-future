class Rectangle {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    // Getter
    get area() {
        return this.calcArea();
    }
    // Method
    calcArea() {
        return this.height * this.width;
    }
}

class Animal {
    constructor(name) {
        this.name = name;
    }

    speak() {
        console.log(this.name + ' makes a noise.');
    }
}

class Dog extends Animal {
    constructor(name) {
        super(name); // call the super class constructor and pass in the name parameter
    }

    speak() {
        console.log(this.name + ' barks.');
    }
}

let d = new Dog('Mitzie');
d.speak(); // Mitzie barks.


console.log(new Date); // 1
console.log(Date())

function f(){
    return 1;
}
var v = f(); // 把 f 作为函数调用
var o = new f(); // 把 f 作为构造器调用
