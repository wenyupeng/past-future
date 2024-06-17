package concurrent.java.test02.lock;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class DemoLock {
    private final Lock rtl = new ReentrantLock();

    int value;

    public int get(){
        rtl.lock();
        try {
            return value;
        }finally {
            rtl.unlock();
        }
    }

    public void addOne(){
        rtl.lock(); // 第一次加锁
        try {
            value = 1+get(); // 第二次加锁
        }finally {
            rtl.unlock();
        }
    }

}
