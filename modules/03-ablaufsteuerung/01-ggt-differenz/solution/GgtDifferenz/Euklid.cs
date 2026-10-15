public class Euklid {
    public static int GgtDifferenz(int a, int b) {
        while (a != b) {
            if (a > b)
                a -= b;
            else
                b -= a;
        }
        return a;
    }

    public static int GroessterExponent() {
        double eps = 1.0;
        int i = 0;
        while (1.0 + eps / 2.0 > 1.0) {
            eps /= 2.0;
            i++;
        }
        return i;
    }
}
