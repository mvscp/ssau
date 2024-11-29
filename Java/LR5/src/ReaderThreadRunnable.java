public class ReaderThreadRunnable implements Runnable {
    private Product product;
    private final Semaphore semaphore;

    public ReaderThreadRunnable(Product product, Semaphore semaphore) {
        this.product = product;
        this.semaphore = semaphore;
    }

    @Override
    public void run() {
        for (int i = 0; i < product.getReviews().size(); i++) {
            try {
                semaphore.read(product, i);
            } catch (Exception _) {
            }
        }
    }
}
