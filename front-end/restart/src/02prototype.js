var cat = {
    say(){
        console.log("meow~");
    },
    jump(){
        console.log("jump");
    }
}

var tiger = Object.create(cat,  {
    say:{
        writable:true,
        configurable:true,
        enumerable:true,
        value:function(){
            console.log("roar!");
        }
    }
})


var anotherCat = Object.create(cat);

anotherCat.say();

var anotherTiger = Object.create(tiger);

anotherTiger.say();

var cat = {
    say(){
        console.log("meow~");
    },
    jump(){
        console.log("jump");
    }
}

var tiger = Object.create(cat,  {
    say:{
        writable:true,
        configurable:true,
        enumerable:true,
        value:function(){
            console.log("roar!");
        }
    }
})


var anotherCat = Object.create(cat);

anotherCat.say();

var anotherTiger = Object.create(tiger);

anotherTiger.say();


var o = new Object;
var n = new Number;
var s = new String;
var b = new Boolean;
var d = new Date;
var arg = function(){ return arguments }();
var r = new RegExp;
var f = new Function;
var arr = new Array;
var e = new Error;
console.log([o, n, s, b, d, arg, r, f, arr, e].map(v => Object.prototype.toString.call(v)));


var o = { [Symbol.toStringTag]: "MyObject" }
console.log(o + ""); // 字符串加法触发了 Object.prototype.toString 的调用

function c1(){
    this.p1 = 1;
    this.p2 = function(){
        console.log(this.p1);
    }
}
var o1 = new c1;
o1.p2(); // 第一种方法是直接在构造器中修改 this，给 this 添加属性。



function c2(){
}
c2.prototype.p1 = 1;
c2.prototype.p2 = function(){
    console.log(this.p1);
}

var o2 = new c2;
o2.p2(); // 第二种方法是修改构造器的 prototype 属性指向的对象，它是从这个构造器构造出来的所有对象的原型。

Object.create = function(prototype){
    var cls = function(){}
    cls.prototype = prototype;
    return new cls;
}

