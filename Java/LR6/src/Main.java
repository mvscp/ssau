import java.io.*;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ProductIO.setFactory(new ProductOnlineFactory());
        Product product = ProductIO.createInstance();
        for (int i = 0; i < 5; i++) {
            product.addReview(i+1);
        }

        boolean running = true;
        while (running) {
            System.out.println("\nChoose an option:");
            System.out.println("1 - Iterator");
            System.out.println("2 - Unmodifiable");
            System.out.println("3 - Factory");
            System.out.println("0 - Exit");

            int choice = scanner.nextInt();
            scanner.nextLine();

            switch (choice) {
                case 1:
                    System.out.println("While:");
                    Iterator<Integer> iterator = product.iterator();
                    while (iterator.hasNext()) {
                        System.out.print(iterator.next() + " ");
                    }

                    System.out.println("\nFor:");
                    for (Integer i : product) {
                        System.out.print(i + " ");
                    }

                    break;

                case 2:
                    Product unmodifiableProduct = ProductIO.unmodifiableProduct(product);

                    try {
                        System.out.printf("Введите новое название: ");
                        String newName = scanner.next();
                        System.out.print("\n");
                        unmodifiableProduct.setName(newName);
                    } catch (UnsupportedOperationException e) {
                        System.out.println("Этот объект нельзя изменять");
                    }

                    break;

                case 3:
                    System.out.println(product);
                    break;

                case 0:
                    running = false;
                    break;

                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }

        scanner.close();
    }
}
