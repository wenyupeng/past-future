package concurrent.java.test02.rwl;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class Cache<K,V> {
    final Map<K,V> m = new HashMap<>();
    final ReadWriteLock rwl=new ReentrantReadWriteLock();
    final Lock readLock = rwl.readLock();
    final Lock writeLock = rwl.writeLock();

    V get(K key) {
        readLock.lock();
        try {
            return m.get(key);
        }finally {
            readLock.unlock();
        }
    }

    V put(K key, V value) {
        writeLock.lock();
        try {
            return m.put(key, value);
        }finally {
             writeLock.unlock();
        }
    }
}
