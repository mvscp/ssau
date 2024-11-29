import java.util.Random;

public class WriterThread extends Thread {
    private Product product;
    private Random random = new Random();

    public WriterThread(Product product) {
        this.product = product;
    }

    @Override
    public void run() {
        for (int i = 0; i < product.getReviews().size(); i++) {
            int value = random.nextInt(5) + 1; // Генерация случайного числа (1-5)
            product.setReview(i, value);
            System.out.println("Write: " + value + " to position " + i);
        }
    }
}
