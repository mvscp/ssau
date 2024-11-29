public class ReaderThread extends Thread {
    private final Product product;

    public ReaderThread(Product product) {
        this.product = product;
    }

    @Override
    public void run() {
        for (int i = 0; i < product.getReviews().size(); i++) {
            int value = product.getReview(i);
            System.out.println("Read: " + value + " from position " + i);
        }
    }
}
