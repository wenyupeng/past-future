package concurrent.java.safe_container;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

public class SafeArrayList <T>{
    // 封装 ArrayList
    List<T> c = new ArrayList<>();
    // 控制访问路径
    synchronized T get(int idx){
        return c.get(idx);
    }

    synchronized void add(int idx, T t) {
        c.add(idx, t);
    }

    /**
     * 组合操作需要注意竞态条件
     */
    synchronized boolean addIfNotExist(T t){
        if(!c.contains(t)) {
            c.add(t);
            return true;
        }
        return false;
    }
}
