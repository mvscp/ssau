import java.io.OutputStream;
import java.io.Writer;
import java.util.Iterator;
import java.util.List;

public class ProductUnmodifiable implements Product {
    private Product product;

    public ProductUnmodifiable(Product product) {
        this.product = product;
    }

    @Override
    public String getName() {
        return product.getName();
    }

    @Override
    public void setName(String name) {
        throw new UnsupportedOperationException();
    }

    @Override
    public int getPrice() {
        return product.getPrice();
    }

    @Override
    public void setPrice(int price) {
        throw new UnsupportedOperationException();
    }

    @Override
    public List<Integer> getReviews() {
        return product.getReviews();
    }

    @Override
    public void addReview(int review) {
        throw new UnsupportedOperationException();
    }

    @Override
    public int getReview(int idx) {
        return product.getReview(idx);
    }

    @Override
    public void setReview(int idx, int value) {
        throw new UnsupportedOperationException();
    }

    @Override
    public double calculateAverageReview() throws NoReviewsException {
        return product.calculateAverageReview();
    }

    @Override
    public void output(OutputStream out) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void write(Writer out) {
        throw new UnsupportedOperationException();
    }

    @Override
    public Iterator<Integer> iterator() {
        return product.iterator();
    }
}
