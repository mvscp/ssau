public class Main {
    public static void main(String[] args) {
        Vector vector1 = new Vector(3);
        vector1.setElement(0, 2.0);
        vector1.setElement(1, 1.0);
        vector1.setElement(2, 3.0);

        Vector vector2 = new Vector(3);
        vector2.setElement(0, 6.0);
        vector2.setElement(1, 4.0);
        vector2.setElement(2, 5.0);

        System.out.println("Вектор 1: " + vector1);
        System.out.println("Вектор 2: " + vector2);

        Vector sum = Vector.add(vector1, vector2);
        System.out.println("Сумма векторов: " + sum);

        double dotProduct = Vector.dotProduct(vector1, vector2);
        System.out.println("Скалярное произведение: " + dotProduct);

        System.out.println("Минимум вектора 1: " + vector1.getMin());
        System.out.println("Максимум вектора 1: " + vector1.getMax());

        vector1.sortAscending();
        System.out.println("Вектор 1 после сортировки: " + vector1);

        System.out.println("Евклидова норма вектора 1: " + vector1.getEuclideanNorm());

        vector1.multiplyByScalar(2.0);
        System.out.println("Вектор 1 после умножения на 2: " + vector1);
    }
}

