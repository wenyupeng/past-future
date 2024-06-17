package concurrent.java.test02.stpl;

import java.util.concurrent.locks.LockSupport;
import java.util.concurrent.locks.StampedLock;

/**
 * 通过乐观读获取验证标志，在返回前确认释放存在写入操作，如果存在写入操作说明，乐观读的结果不可信
 * 需要将乐观读升级为悲观读
 */
public class Point {
    private int x, y;
    final StampedLock sl = new StampedLock();

    // 计算到原点的距离
    double distanceFromOrigin() {
//        LockSupport.park();
        // 乐观读
        long stamp = sl.tryOptimisticRead();
        // 读入局部变量，
        // 读的过程数据可能被修改
        int curX = x, curY = y;
        // 判断执行读操作期间，
        // 是否存在写操作，如果存在，
        // 则 sl.validate 返回 false
        if (!sl.validate(stamp)) {
            // 升级为悲观读锁
            stamp = sl.readLock();
            try {
                curX = x;
                curY = y;
            } finally {
                // 释放悲观读锁
                sl.unlockRead(stamp);
            }
        }
        return Math.sqrt(curX * curX + curY * curY);
    }
}
