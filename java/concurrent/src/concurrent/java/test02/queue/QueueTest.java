package concurrent.java.test02.queue;

public class QueueTest {
    public static void main(String[] args) throws InterruptedException {
        BlockedQueue<String> blockedQueue = new BlockedQueue<>();
        new Thread(()->{
            try {
                blockedQueue.deq();
            } catch (InterruptedException e) {
                System.out.println(e.getMessage());
            }
        }).start();

        new Thread(() -> {
            for (int i = 1; i < 11; i++) {
                try {
                    blockedQueue.enq(i+"");
                } catch (InterruptedException e) {
                    System.out.println(e.getMessage());
                }
            }
            System.out.println("all value have been enqueued");
        }).start();

        Thread.sleep(10000);
    }
}
