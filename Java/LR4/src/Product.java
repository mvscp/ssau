import java.io.OutputStream;
import java.io.Writer;
import java.util.List;

public interface Product {
    String getName();
    void setName(String name);

    int getPrice();
    void setPrice(int price);

    List<Integer> getReviews();
    void addReview(int review);

    double calculateAverageReview() throws NoReviewsException;

    void output(OutputStream out);
    void write(Writer out);
}
