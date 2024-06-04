package concurrent.java.test01;

public class TestConcurrent_01 {
    private long count = 0;

    private void add10K() {
        int idx = 0;
        while (idx < 10000) {
            count += 1;
            idx++;
        }
    }

public long calc() throws InterruptedException {
    final TestConcurrent_01 test = new TestConcurrent_01();
    Thread thread1 = new Thread(test::add10K);
    Thread thread2 = new Thread(test::add10K);
    thread1.start();
    thread2.start();
    //等待两个线程结束
    thread1.join();
    thread2.join();
    return test.count;
}
}