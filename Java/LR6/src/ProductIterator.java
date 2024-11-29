import java.util.Iterator;

public class ProductIterator implements Iterator<Integer> {
    private Product product;
    private int i;

    public ProductIterator (Product product){
        this.product = product;
        i = 0;
    }

    @Override
    public boolean hasNext(){
        return i < product.getReviews().size();
    }

    @Override
    public Integer next() {
        return product.getReview(i++);
    }
}
