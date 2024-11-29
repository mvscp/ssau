import java.io.*;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        boolean running = true;
        while (running) {
            System.out.println("\nChoose an option:");
            System.out.println("1 - Task 1");
            System.out.println("2 - Task 2");
            System.out.println("3 - Task 3");
            System.out.println("0 - Exit");

            int choice = scanner.nextInt();
            scanner.nextLine();

            switch (choice) {
                case 1:
                    Product product = new ProductOnline();
                    for (int i = 0; i < 100; i++) {
                        product.addReview(1);
                    }

                    WriterThread writerThread = new WriterThread(product);
                    ReaderThread readerThread = new ReaderThread(product);

                    writerThread.setPriority(10);
                    readerThread.setPriority(1);

                    writerThread.start();
                    readerThread.start();

                    try {
                        writerThread.join();
                        readerThread.join();
                    } catch (InterruptedException e) {
                        System.err.println("Нить прервана: " + e.getMessage());
                    }

                    System.out.println("\nИтоговый объект: " + product);
                    break;

                case 2:
                    Product productOnline = new ProductOnline();
                    for (int i = 0; i < 100; i++) {
                        productOnline.addReview(1);
                    }

                    Semaphore semaphore = new Semaphore();

                    WriterThreadRunnable writerThreadRunnable = new WriterThreadRunnable(productOnline, semaphore);
                    ReaderThreadRunnable readerThreadRunnable = new ReaderThreadRunnable(productOnline, semaphore);

                    Thread t1 = new Thread(writerThreadRunnable);
                    t1.start();
                    Thread t2 = new Thread(readerThreadRunnable);
                    t2.start();

                    try {
                        t1.join();
                        t2.join();
                    } catch (InterruptedException e) {
                        System.err.println("Нить прервана: " + e.getMessage());
                    }

                    System.out.println("\nИтоговый объект: " + productOnline);
                    break;

                case 3:
                    Product product1 = new ProductOnline();
                    for (int i = 0; i < 100; i++) {
                        product1.addReview(1);
                    }

                    product1 = ProductIO.getThreadSafeDevice(product1);

                    WriterThread writerThread1 = new WriterThread(product1);
                    ReaderThread readerThread1 = new ReaderThread(product1);

                    writerThread1.start();
                    readerThread1.start();

                    try {
                        writerThread1.join();
                        readerThread1.join();
                    } catch (InterruptedException e) {
                        System.err.println("Нить прервана: " + e.getMessage());
                    }

                    System.out.println("\nИтоговый объект: " + product1);
                    break;

                case 0:
                    running = false;
                    break;

                default: System.out.println("Invalid choice. Please try again.");
            }
        }

        scanner.close();
    }
}
