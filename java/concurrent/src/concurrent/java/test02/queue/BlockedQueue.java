package concurrent.java.test02.queue;

import java.util.Queue;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class BlockedQueue<T> {
    final Queue<T> queue = new ArrayBlockingQueue<>(10);
    final Lock lock = new ReentrantLock();
    // 条件变量：队列不满
    final Condition notFull = lock.newCondition();
    // 条件变量：队列不空
    final Condition notEmpty = lock.newCondition();

    // 入队
    void enq(T x) throws InterruptedException {
        lock.lock();
        try {
            while (queue.size() == 10) { // 队列已满
                System.out.println("queue is full");
                // 等待队列不满
                notFull.await(); // 相当于wait()
            }
            System.out.println("value: " +x);
            // 入队操作...
            queue.add(x);
            // 入队后, 通知可出队
            notEmpty.signal(); // 相当于notify()
        } finally {
            lock.unlock();
        }
    }

    // 出队
    void deq() throws InterruptedException {
        lock.lock();
        try {
            while (queue.isEmpty()) { //队列已空
                System.out.println("queue is empty");
                // 等待队列不空
                notEmpty.await();
            }
            // 出队操作...
            T poll = queue.poll();
            System.out.println("insert value: " + poll);
            // 出队后，通知可入队
            notFull.signal();
        } finally {
            lock.unlock();
        }
    }
}
