import java.io.OutputStream;
import java.io.Writer;
import java.util.Iterator;
import java.util.List;

public class ThreadSafeProduct implements Product {

    final private Product product;

    public ThreadSafeProduct(Product product) {
        this.product = product;
    }

    @Override
    public synchronized String getName() {
        return product.getName();
    }

    @Override
    public synchronized void setName(String name) {
        product.setName(name);
    }

    @Override
    public synchronized int getPrice() {
        return product.getPrice();
    }

    @Override
    public synchronized void setPrice(int price) {
        product.setPrice(price);
    }

    @Override
    public synchronized List<Integer> getReviews() {
        return product.getReviews();
    }

    @Override
    public synchronized void addReview(int review) {
        product.addReview(review);
    }

    @Override
    public synchronized void setReview(int index, int value) {
        product.setReview(index, value);
    }

    @Override
    public synchronized int getReview(int index) {
        return product.getReview(index);
    }

    @Override
    public synchronized double calculateAverageReview() throws NoReviewsException {
        return product.calculateAverageReview();
    }

    @Override
    public synchronized void output(OutputStream out) {
        product.output(out);
    }

    @Override
    public synchronized void write(Writer out) {
        product.write(out);
    }

    @Override
    public Iterator<Integer> iterator() {
        return product.iterator();
    }
}
