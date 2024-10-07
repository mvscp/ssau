package FirstPackage;

public class SecondClass {
    private int a, b;
    
    public SecondClass() {
        this.a = 2;
        this.b = 3;
    }

    public int getA() {
        return a;
    }

    public int getB() {
        return b;
    }

    public void setA(int val) {
        a = val;
    }

    public void setB(int val) {
        b = val;
    }

    public int sum() {
        return a + b;
    }
}
