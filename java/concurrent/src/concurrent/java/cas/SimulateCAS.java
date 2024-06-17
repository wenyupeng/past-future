package concurrent.java.cas;

public class SimulateCAS {
    volatile int count;
    // 实现 count+=1
    void addOne() {
        int newValue;
        int oldValue;
        do {
            oldValue = count;
            newValue = count + 1;
        } while (oldValue != cas(oldValue, newValue)); //②
    }

    // 模拟实现 CAS，仅用来帮助理解
    synchronized int cas(int expect, int newValue){
        // 读目前 count 的值
        int curValue = count;
        // 比较目前 count 值是否 == 期望值
        if(curValue == expect){
            // 如果是，则更新 count 的值
            count = newValue;
        }
        // 返回写入前的值
        return curValue;
    }
}
