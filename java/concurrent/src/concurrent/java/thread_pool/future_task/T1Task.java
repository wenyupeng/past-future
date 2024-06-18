package concurrent.java.thread_pool.future_task;

import java.util.concurrent.Callable;
import java.util.concurrent.FutureTask;
import java.util.concurrent.TimeUnit;

public class T1Task implements Callable<String> {
    FutureTask<String> futureTask;

    public T1Task(FutureTask<String> futureTask) {
        this.futureTask = futureTask;
    }

    @Override
    public String call() throws Exception {
        System.out.println("T1: 洗水壶...");
        TimeUnit.SECONDS.sleep(1);

        System.out.println("T1: 烧开水...");
        TimeUnit.SECONDS.sleep(15);
        // 获取 T2 线程的茶叶
        String tf = futureTask.get();
        System.out.println("T1: 拿到茶叶:"+tf);

        System.out.println("T1: 泡茶...");
        return " 上茶:" + tf;
    }
}
