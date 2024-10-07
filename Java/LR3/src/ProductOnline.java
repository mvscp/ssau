import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

class ProductOnline implements Product {
    private String name;
    private int price;
    private List<Integer> reviews;
    private String url; // Дополнительное поле для онлайн-продукта

    public ProductOnline() {
        this.name = "";
        this.price = 0;
        this.reviews = new ArrayList<>();
        this.url = "";
    }

    public ProductOnline(String name, int price, List<Integer> reviews, String url) {
        if (price < 0) {
            throw new InvalidProductDataException("Price cannot be negative");
        }
        this.name = name;
        this.price = price;
        this.reviews = reviews != null ? reviews : new ArrayList<>();
        this.url = url;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        if (price < 0) {
            throw new InvalidProductDataException("Price cannot be negative");
        }
        this.price = price;
    }

    public List<Integer> getReviews() {
        return reviews;
    }

    public void addReview(int review) {
        if (review < 1 || review > 5) {
            throw new InvalidProductDataException("Review must be between 1 and 5");
        }
        reviews.add(review);
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public double calculateAverageReview() throws NoReviewsException {
        if (reviews.isEmpty()) {
            throw new NoReviewsException("No reviews available for this product");
        }
        return reviews.stream().mapToInt(Integer::intValue).average().orElse(0);
    }

    @Override
    public String toString() {
        return "ProductOnline: " +
                "name='" + name + '\'' +
                ", price=" + price +
                ", url='" + url + '\'' +
                ", reviews=" + reviews.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ProductOnline that = (ProductOnline) o;
        return price == that.price &&
                Objects.equals(name, that.name) &&
                Objects.equals(reviews, that.reviews) &&
                Objects.equals(url, that.url);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, price, reviews, url);
    }
}
