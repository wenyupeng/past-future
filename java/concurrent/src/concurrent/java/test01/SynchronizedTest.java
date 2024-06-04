package concurrent.java.test01;

public class SynchronizedTest {
    long value = 0L;
    static long staticValue = 0L;

    long get() {
        return value;
    }

    static synchronized long staticSyncGet() {
        return staticValue;
    }

    synchronized long objSyncGet() {
        return value;
    }

    void addOne() {
        value += 1;
    }

    static synchronized void staticSyncAddOne() {
        staticValue += 1;
    }

    synchronized void objSyncAddOne() {
        value += 1;
    }

    public static void main(String[] args) throws InterruptedException {
//        testNormal();
//        multiThreadTestNormal();
//        multiThreadTestNormal_unsafe();
        SynchronizedTest test = new SynchronizedTest();
        for (int i = 0; i < 1000; i++) {
            staticSyncAddOne();
        }
        System.out.println(staticSyncGet());
    }

    private static void multiThreadTestNormal_unsafe() throws InterruptedException {
        SynchronizedTest test = new SynchronizedTest();
        Thread t1 = new Thread(()->{
            for (int i = 0; i < 10000; i++) {
//                test.addOne(); // 并发问题 a
//                test.objSyncAddOne(); // 并发问题 b
                staticSyncAddOne(); // 并发问题 C
            }
        });
        t1.start();
        Thread t2 = new Thread(()->{
//            System.out.println(test.get());// 并发问题 a
//            System.out.println(test.objSyncGet());// 并发问题 b
            System.out.println(staticSyncGet());//并发问题C
        });
        t2.start();
        Thread.sleep(10000);
    }

    private static void multiThreadTestNormal() throws InterruptedException {
        SynchronizedTest test = new SynchronizedTest();
        Thread t1 = new Thread(()->{
            for (int i = 0; i < 10000; i++) {
                test.addOne();
            }
        });
        t1.start();
        t1.join(); // 主线程等待子线程返回结果

        System.out.println(test.get());
    }

    private static void testNormal() {
        SynchronizedTest test = new SynchronizedTest();
        long result = 0;
        boolean interruptFlag = false;
        while (!interruptFlag) {
            test.value = 0;
            for (int i = 0; i < 1000000; i++) {
                test.addOne();
            }

            result = test.get();
            if (result != 1000000) {
                interruptFlag = true;
                System.out.println(result);
            }
        }
    }

}