import java.util.Random;

public class WriterThreadRunnable implements Runnable {
    private Product product;
    private final Semaphore semaphore;

    public WriterThreadRunnable(Product product, Semaphore semaphore) {
        this.product = product;
        this.semaphore = semaphore;
    }

    @Override
    public void run() {
        Random random = new Random();
        for (int i = 0; i < product.getReviews().size(); i++) {
            try {
                int val = random.nextInt(5) + 1;
                semaphore.write(product, val, i);
            } catch (Exception _) { }
        }
    }
}
