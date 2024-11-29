import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ProductIO {

    public static void outputProduct(Product o, OutputStream out) {
        o.output(out);
    }

    public static Product inputProduct(InputStream in) {
        try {
            DataInputStream dis = new DataInputStream(in);
            String name = dis.readUTF();
            int price = dis.readInt();
            String url = dis.readUTF();
            int reviewCount = dis.readInt();
            List<Integer> reviews = new ArrayList<>();
            for (int i = 0; i < reviewCount; i++) {
                reviews.add(dis.readInt());
            }
            return new ProductOnline(name, price, reviews, url);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static void writeProduct(Product o, Writer out) {
        o.write(out);
    }

    public static Product readProduct(Reader in) {
        StreamTokenizer tokenizer = new StreamTokenizer(in);
        try {
            tokenizer.nextToken();
            String name = tokenizer.sval;

            tokenizer.nextToken();
            int price = (int) tokenizer.nval;

            tokenizer.nextToken();
            String url = tokenizer.sval;

            tokenizer.nextToken();
            int reviewCount = (int) tokenizer.nval;
            List<Integer> reviews = new ArrayList<>();
            for (int i = 0; i < reviewCount; i++) {
                tokenizer.nextToken();
                tokenizer.nextToken();
                reviews.add((int) tokenizer.nval);
            }
            return new ProductOnline(name, price, reviews, url);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static void serializeProduct(Product o, OutputStream out) {
        try {
            ObjectOutputStream oos = new ObjectOutputStream(out);
            oos.writeObject(o);
            oos.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Product deserializeProduct(InputStream in) {
        try {
            ObjectInputStream ois = new ObjectInputStream(in);
            return (Product) ois.readObject();
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static void writeFormatProduct(Product o, Writer out) {
        try {
            if (o instanceof ProductOnline) {
                ProductOnline online = (ProductOnline) o;
                out.write(String.format("Online Product: %s | Price: %d | URL: %s | Reviews: %s%n",
                        online.getName(), online.getPrice(), online.getUrl(), online.getReviews()));
            } else if (o instanceof ProductInStore) {
                ProductInStore inStore = (ProductInStore) o;
                out.write(String.format("In Store Product: %s | Price: %d | Stock: %d | Reviews: %s%n",
                        inStore.getName(), inStore.getPrice(), inStore.getStockQuantity(), inStore.getReviews()));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static Product readFormatProduct(Scanner in) {
        if (!in.hasNext()) return null;
        Product product = null;
        String[] info = in.nextLine().split("\\|");

        String type = info[0].split(":")[0].trim();
        String name = info[0].split(":")[1].trim();
        int price = Integer.parseInt(info[1].split(":")[1].trim());
        System.out.println(type + "   " + name + "   " + price);

        if (type.equalsIgnoreCase("Online Product")) {
            String url = info[2].split(":")[1].trim();
            product = new ProductOnline(name, price, new ArrayList<>(), url);
            System.out.println(url);
        } else if (type.equalsIgnoreCase("In Store Product")) {
            int stock = Integer.parseInt(info[2].split(":")[1].trim());
            product = new ProductInStore(name, price, new ArrayList<>(), stock);
            System.out.println(stock);
        }

        String reviewsPart = info[3].split(":")[1].trim();
        reviewsPart = reviewsPart.replace("[", "").replace("]", "").trim();
        String[] reviewStrings = reviewsPart.split(",");

        for (String review : reviewStrings) {
            product.addReview(Integer.parseInt(review.trim()));
        }

        return product;
    }

    public static Product getThreadSafeDevice(Product product) {
        return new ThreadSafeProduct(product);
    }
}
