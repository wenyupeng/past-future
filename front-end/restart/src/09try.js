function foo(){
    try{
        return 0;
    } catch(err) {

    } finally {
        console.log("a")
    }
}

console.log(foo());
// a
// 0


function foo2(){
    try{
        return 0;
    } catch(err) {

    } finally {
        return 1;
    }
}

console.log(foo2());
// finally 中的 return “覆盖”了 try 中的 return