import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Product> products = new ArrayList<>();

        while (true) {
            System.out.println("\nМеню:");
            System.out.println("1. Добавить онлайн продукт");
            System.out.println("2. Добавить продукт в магазине");
            System.out.println("3. Показать все продукты");
            System.out.println("4. Найти продукты с одинаковой средней оценкой");
            System.out.println("5. Разбить продукты по типам (онлайн/магазин)");
            System.out.println("6. Выйти");
            System.out.print("Выберите действие: ");
            int choice = scanner.nextInt();
            scanner.nextLine(); // Очистить буфер

            switch (choice) {
                case 1 -> addProductOnline(scanner, products);
                case 2 -> addProductInStore(scanner, products);
                case 3 -> displayAllProducts(products);
                case 4 -> findProductsWithSameAverageReview(products);
                case 5 -> splitProductsByType(products);
                case 6 -> {
                    System.out.println("Завершение работы программы.");
                    return;
                }
                default -> System.out.println("Неверный выбор. Попробуйте снова.");
            }
        }
    }

    private static void addProductOnline(Scanner scanner, List<Product> products) {
        System.out.print("Введите название продукта: ");
        String name = scanner.nextLine();

        System.out.print("Введите цену: ");
        int price = scanner.nextInt();
        scanner.nextLine();

        System.out.print("Введите URL продукта: ");
        String url = scanner.nextLine();

        List<Integer> reviews = new ArrayList<>();
        System.out.print("Введите количество отзывов: ");
        int reviewCount = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < reviewCount; i++) {
            System.out.print("Введите отзыв (1-5): ");
            int review = scanner.nextInt();
            scanner.nextLine();
            reviews.add(review);
        }

        products.add(new ProductOnline(name, price, reviews, url));
        System.out.println("Онлайн продукт добавлен.");
    }

    private static void addProductInStore(Scanner scanner, List<Product> products) {
        System.out.print("Введите название продукта: ");
        String name = scanner.nextLine();

        System.out.print("Введите цену: ");
        int price = scanner.nextInt();
        scanner.nextLine();

        System.out.print("Введите количество на складе: ");
        int stockQuantity = scanner.nextInt();
        scanner.nextLine();

        List<Integer> reviews = new ArrayList<>();
        System.out.print("Введите количество отзывов: ");
        int reviewCount = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < reviewCount; i++) {
            System.out.print("Введите отзыв (1-5): ");
            int review = scanner.nextInt();
            scanner.nextLine();
            reviews.add(review);
        }

        products.add(new ProductInStore(name, price, reviews, stockQuantity));
        System.out.println("Продукт в магазине добавлен.");
    }

    private static void displayAllProducts(List<Product> products) {
        if (products.isEmpty()) {
            System.out.println("Продуктов нет.");
        } else {
            System.out.println("\nСписок всех продуктов:");
            for (Product product : products) {
                System.out.println(product);
            }
        }
    }

    private static void findProductsWithSameAverageReview(List<Product> products) {
        Map<Double, List<Product>> averageReviewMap = new HashMap<>();

        for (Product product : products) {
            try {
                double averageReview = product.calculateAverageReview();
                averageReviewMap.putIfAbsent(averageReview, new ArrayList<>());
                averageReviewMap.get(averageReview).add(product);
            } catch (NoReviewsException e) {
                System.out.println(product.getName() + " не имеет отзывов.");
            }
        }

        // Показать группы продуктов с одинаковой средней оценкой
        for (Map.Entry<Double, List<Product>> entry : averageReviewMap.entrySet()) {
            if (entry.getValue().size() > 1) {
                System.out.println("\nПродукты с одинаковой средней оценкой " + entry.getKey() + ":");
                for (Product product : entry.getValue()) {
                    System.out.println(product);
                }
            }
        }
    }

    private static void splitProductsByType(List<Product> products) {
        List<ProductOnline> onlineProducts = new ArrayList<>();
        List<ProductInStore> inStoreProducts = new ArrayList<>();

        for (Product product : products) {
            if (product instanceof ProductOnline) {
                onlineProducts.add((ProductOnline) product);
            } else if (product instanceof ProductInStore) {
                inStoreProducts.add((ProductInStore) product);
            }
        }

        System.out.println("\nОнлайн продукты:");
        for (ProductOnline product : onlineProducts) {
            System.out.println(product);
        }

        System.out.println("\nПродукты в магазине:");
        for (ProductInStore product : inStoreProducts) {
            System.out.println(product);
        }
    }
}
