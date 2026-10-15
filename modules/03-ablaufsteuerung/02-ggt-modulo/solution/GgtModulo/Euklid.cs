public class Euklid {
    public static int GgtModulo(int a, int b) {
        int rest;
        do {
            rest = a % b;
            a = b;
            b = rest;
        } while (rest > 0);
        return a;
    }

    public static int Kgv(int a, int b) => a / GgtModulo(a, b) * b;
}
