import java.util.List;

public interface Product {
    String getName();
    void setName(String name);

    int getPrice();
    void setPrice(int price);

    List<Integer> getReviews();
    void addReview(int review);

    // Бизнес-метод для расчета средней оценки товара
    double calculateAverageReview() throws NoReviewsException;
}
