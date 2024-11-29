import java.io.*;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Product> products = new ArrayList<>();

        boolean running = true;
        while (running) {
            System.out.println("\nChoose an option:");
            System.out.println("1 - Add product");
            System.out.println("2 - Save products to binary file");
            System.out.println("3 - Load products from binary file");
            System.out.println("4 - Save products to text file");
            System.out.println("5 - Load products from text file");
            System.out.println("6 - Serialize products to binary file");
            System.out.println("7 - Deserialize products from binary file");
            System.out.println("8 - Save products to formatted text file");
            System.out.println("9 - Load products from formatted text file");
            System.out.println("10 - Show all products");
            System.out.println("0 - Exit");

            int choice = scanner.nextInt();
            scanner.nextLine();

            switch (choice) {
                case 1 -> addProduct(scanner, products);
                case 2 -> saveProductsToBinaryFile(products);
                case 3 -> loadProductsFromBinaryFile(products);
                case 4 -> saveProductsToTextFile(products);
                case 5 -> loadProductsFromTextFile(products);
                case 6 -> serializeProductsToBinaryFile(products);
                case 7 -> deserializeProductsFromBinaryFile(products);
                case 8 -> saveProductsToFormattedTextFile(products);
                case 9 -> loadProductsFromFormattedTextFile(products);
                case 10 -> showAllProducts(products);
                case 0 -> running = false;
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }

        scanner.close();
    }

    private static void addProduct(Scanner scanner, List<Product> products) {
        Product product = null;

        System.out.println("Enter product type (online/store): ");
        String type = scanner.nextLine().trim();

        System.out.println("Enter product name: ");
        String name = scanner.nextLine().trim();

        System.out.println("Enter price: ");
        int price = scanner.nextInt();

        System.out.println("Enter number of reviews: ");
        int reviewCount = scanner.nextInt();
        List<Integer> reviews = new ArrayList<>();
        System.out.println("Enter reviews (integers): ");
        for (int i = 0; i < reviewCount; i++) {
            reviews.add(scanner.nextInt());
        }
        scanner.nextLine();

        if (type.equalsIgnoreCase("online")) {
            System.out.println("Enter URL: ");
            String url = scanner.nextLine().trim();
            product = new ProductOnline(name, price, reviews, url);
        } else if (type.equalsIgnoreCase("store")) {
            System.out.println("Enter stock quantity: ");
            int stock = scanner.nextInt();
            product = new ProductInStore(name, price, reviews, stock);
        }

        if (product != null) {
            products.add(product);
            System.out.println("Product added: " + product);
        } else {
            System.out.println("Error: Product was not added.");
        }
    }

    private static void saveProductsToBinaryFile(List<Product> products) {
        try (FileOutputStream fos = new FileOutputStream("products.bin")) {
            for (Product product : products) {
                ProductIO.outputProduct(product, fos);
            }
            System.out.println("Products saved to binary file.");
        } catch (IOException e) {
            System.out.println("Error saving products to binary file.");
            e.printStackTrace();
        }
    }

    private static void loadProductsFromBinaryFile(List<Product> products) {
        try (FileInputStream fis = new FileInputStream("products.bin")) {
            products.clear();
            while (fis.available() > 0) {
                Product product = ProductIO.inputProduct(fis);
                if (product != null) {
                    products.add(product);
                }
            }
            System.out.println("Products loaded from binary file.");
        } catch (IOException e) {
            System.out.println("Error loading products from binary file.");
            e.printStackTrace();
        }
    }

    private static void saveProductsToTextFile(List<Product> products) {
        try (FileWriter fw = new FileWriter("products.txt")) {
            for (Product product : products) {
                ProductIO.writeProduct(product, fw);
            }
            System.out.println("Products saved to text file.");
        } catch (IOException e) {
            System.out.println("Error saving products to text file.");
            e.printStackTrace();
        }
    }

    private static void loadProductsFromTextFile(List<Product> products) {
        try (FileReader fr = new FileReader("products.txt")) {
            products.clear();
            BufferedReader reader = new BufferedReader(fr);
            String line;
            while ((line = reader.readLine()) != null) {
                Product product = ProductIO.readProduct(new StringReader(line));
                if (product != null) {
                    products.add(product);
                }
            }
            System.out.println("Products loaded from text file.");
        } catch (IOException e) {
            System.out.println("Error loading products from text file.");
            e.printStackTrace();
        }
    }

    private static void serializeProductsToBinaryFile(List<Product> products) {
        try (FileOutputStream fos = new FileOutputStream("serialized_products.bin")) {
            for (Product product : products) {
                ProductIO.serializeProduct(product, fos);
            }
            System.out.println("Products serialized to binary file.");
        } catch (IOException e) {
            System.out.println("Error serializing products to binary file.");
            e.printStackTrace();
        }
    }

    private static void deserializeProductsFromBinaryFile(List<Product> products) {
        try (FileInputStream fis = new FileInputStream("serialized_products.bin")) {
            products.clear();
            while (fis.available() > 0) {
                Product product = ProductIO.deserializeProduct(fis);
                if (product != null) {
                    products.add(product);
                }
            }
            System.out.println("Products deserialized from binary file.");
        } catch (IOException e) {
            System.out.println("Error deserializing products from binary file.");
            e.printStackTrace();
        }
    }

    private static void saveProductsToFormattedTextFile(List<Product> products) {
        try (FileWriter fw = new FileWriter("formatted_products.txt")) {
            for (Product product : products) {
                ProductIO.writeFormatProduct(product, fw);
            }
            System.out.println("Products saved to formatted text file.");
        } catch (IOException e) {
            System.out.println("Error saving products to formatted text file.");
            e.printStackTrace();
        }
    }

    private static void loadProductsFromFormattedTextFile(List<Product> products) {
        try (FileReader fr = new FileReader("formatted_products.txt")) {
            products.clear();
            Scanner scanner = new Scanner(fr);
            while (scanner.hasNextLine()) {
                Product product = ProductIO.readFormatProduct(scanner);
                if (product != null) {
                    products.add(product);
                }
            }
            System.out.println("Products loaded from formatted text file.");
        } catch (IOException e) {
            System.out.println("Error loading products from formatted text file.");
            e.printStackTrace();
        }
    }

    private static void showAllProducts(List<Product> products) {
        if (products.isEmpty()) {
            System.out.println("No products available.");
        } else {
            System.out.println("\nAll products:");
            for (Product product : products) {
                System.out.println(product);
            }
        }
    }
}
