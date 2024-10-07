import java.util.ArrayList;
import java.util.Objects;
import java.util.List;

class ProductInStore implements Product {
    private String name;
    private int price;
    private List<Integer> reviews;
    private int stockQuantity; // Количество на складе для физического магазина

    public ProductInStore() {
        this.name = "";
        this.price = 0;
        this.reviews = new ArrayList<>();
        this.stockQuantity = 0;
    }

    public ProductInStore(String name, int price, List<Integer> reviews, int stockQuantity) {
        if (price < 0) {
            throw new InvalidProductDataException("Price cannot be negative");
        }
        if (stockQuantity < 0) {
            throw new InvalidProductDataException("Stock quantity cannot be negative");
        }
        this.name = name;
        this.price = price;
        this.reviews = reviews != null ? reviews : new ArrayList<>();
        this.stockQuantity = stockQuantity;
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

    public int getStockQuantity() {
        return stockQuantity;
    }

    public void setStockQuantity(int stockQuantity) {
        if (stockQuantity < 0) {
            throw new InvalidProductDataException("Stock quantity cannot be negative");
        }
        this.stockQuantity = stockQuantity;
    }

    public double calculateAverageReview() throws NoReviewsException {
        if (reviews.isEmpty()) {
            throw new NoReviewsException("No reviews available for this product");
        }
        return reviews.stream().mapToInt(Integer::intValue).average().orElse(0);
    }

    @Override
    public String toString() {
        return "ProductInStore: " +
                "name='" + name + '\'' +
                ", price=" + price +
                ", stockQuantity=" + stockQuantity +
                ", reviews=" + reviews.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ProductInStore that = (ProductInStore) o;
        return price == that.price &&
                stockQuantity == that.stockQuantity &&
                Objects.equals(reviews, that.reviews) &&
                Objects.equals(name, that.name);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, price, reviews, stockQuantity);
    }
}