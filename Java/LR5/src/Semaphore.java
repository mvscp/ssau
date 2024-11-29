public class Semaphore {
    private boolean write = true;

    synchronized public void write(Product product, int val, int idx) {
        try {
            while (!write) {
                wait();
            }
            product.setReview(idx, val);
            System.out.println("Write: " + val + " to position " + idx);
            write = false;
            notifyAll();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }

    synchronized public void read(Product product, int idx) {
        try {
            while (write) {
                wait();
            }
            int value = product.getReview(idx);
            System.out.println("Read: " + value + " from position " + idx);
            write = true;
            notifyAll();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }
}
