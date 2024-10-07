import java.util.Arrays;

public class Vector {
    private double[] elements;

    public Vector(int size) {
        if (size <= 0) {
            throw new IllegalArgumentException("Vector size must be greater than 0");
        }
        elements = new double[size];
    }

    public int getSize() {
        return elements.length;
    }

    public double getElement(int index) {
        if (index < 0 || index >= elements.length) {
            throw new IndexOutOfBoundsException("Index: " + index + ", Size: " + elements.length);
        }
        return elements[index];
    }

    public void setElement(int index, double value) {
        if (index < 0 || index >= elements.length) {
            throw new IndexOutOfBoundsException("Index: " + index + ", Size: " + elements.length);
        }
        elements[index] = value;
    }

    public double getMin() {
        return Arrays.stream(elements).min().orElseThrow(IllegalStateException::new);
    }

    public double getMax() {
        return Arrays.stream(elements).max().orElseThrow(IllegalStateException::new);
    }

    public void sortAscending() {
        Arrays.sort(elements);
    }

    public double getEuclideanNorm() {
        double sum = 0;
        for (double element : elements) {
            sum += element * element;
        }
        return Math.sqrt(sum);
    }

    public void multiplyByScalar(double scalar) {
        for (int i = 0; i < elements.length; i++) {
            elements[i] *= scalar;
        }
    }

    public static Vector add(Vector v1, Vector v2) {
        if (v1.getSize() != v2.getSize()) {
            throw new IllegalArgumentException("Vector size mismatch");
        }
        Vector result = new Vector(v1.getSize());
        for (int i = 0; i < v1.getSize(); i++) {
            result.setElement(i, v1.getElement(i) + v2.getElement(i));
        }
        return result;
    }

    public static double dotProduct(Vector v1, Vector v2) {
        if (v1.getSize() != v2.getSize()) {
            throw new IllegalArgumentException("Vector size mismatch");
        }
        double result = 0;
        for (int i = 0; i < v1.getSize(); i++) {
            result += v1.getElement(i) * v2.getElement(i);
        }
        return result;
    }

    @Override
    public String toString() {
        return Arrays.toString(elements);
    }
}
