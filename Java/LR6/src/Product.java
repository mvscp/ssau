import java.io.OutputStream;
import java.io.Writer;
import java.util.List;

public interface Product extends Iterable<Integer> {
    String getName();
    void setName(String name);

    int getPrice();
    void setPrice(int price);

    List<Integer> getReviews();
    void addReview(int review);

    void setReview(int index, int value);
    int getReview(int index);

    double calculateAverageReview() throws NoReviewsException;

    void output(OutputStream out);
    void write(Writer out);
}
