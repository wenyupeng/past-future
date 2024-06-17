package concurrent.java.test02.lock;

import java.util.LinkedList;
import java.util.Queue;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class BlockedQueue<T> {
    final Queue<T> queue=new LinkedList<>();
    final Lock lock = new ReentrantLock();
    final Condition notFull = lock.newCondition();
    final Condition notEmpty = lock.newCondition();

    void enq(T x){
        lock.lock();
        try {
            // 队列已满
            while (queue.size()>10){
                //等待队列不满
                notFull.await();
            }
            // 省略入队操作

            notEmpty.signal();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        } finally {
            lock.unlock();
        }
    }

    /**
     * Lock&Condition 实现的管程里只能使用 await()、signal()、signalAll()，
     * 而 wait()、notify()、notifyAll() 只有在 synchronized 实现的管程里才能使用
     */
    void deq(){
        lock.lock();
        try {
            while (queue.size()==0){
                notEmpty.await();
            }
            // 省略出队
            notFull.signal();

        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }finally {
            lock.unlock();
        }
    }
}
