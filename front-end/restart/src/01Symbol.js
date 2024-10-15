var o = new Object

o[Symbol.iterator] = function() {
    var v = 0
    return {
        next: function() {
            return { value: v++, done: v > 10 }
        }
    }
};

for(var v of o)
    console.log(v);

Symbol.prototype.hello = () => console.log("hello");

var a = Symbol("a");
console.log(typeof a); //symbol，a 并非对象
a.hello(); //hello，有效