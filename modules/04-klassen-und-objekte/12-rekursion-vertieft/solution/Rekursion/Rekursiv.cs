// Alle Methoden rekursiv lösen, also ohne Schleife.
public static class Rekursiv {
    // Quersumme einer Zahl n >= 0: 1234 -> 1 + 2 + 3 + 4 = 10.
    public static int Quersumme(int n) {
        if (n < 10)
            return n;
        return n % 10 + Quersumme(n / 10);
    }

    // basis hoch exponent (exponent >= 0) mit schneller Potenzierung:
    // x^n = (x^(n/2))^2, bei ungeradem n noch einmal mal x.
    public static long Potenz(long basis, int exponent) {
        if (exponent == 0)
            return 1;
        long halb = Potenz(basis, exponent / 2);
        if (exponent % 2 == 0)
            return halb * halb;
        else
            return halb * halb * basis;
    }

    // Binomialkoeffizient "n über k" nach dem Pascalschen Dreieck (0 <= k <= n).
    public static long Binomial(int n, int k) {
        if (k == 0 || k == n)
            return 1;
        return Binomial(n - 1, k - 1) + Binomial(n - 1, k);
    }

    // Mindestanzahl der Züge bei den Türmen von Hanoi mit n Scheiben.
    public static long HanoiZuege(int n) {
        if (n == 0)
            return 0;
        return 2 * HanoiZuege(n - 1) + 1;
    }

    // Fibonacci-Zahl F(n), schnell: a und b sind die beiden letzten Werte.
    // Aufruf von außen: Fibonacci(n, 0, 1).
    public static long Fibonacci(int n, long a, long b) {
        if (n == 0)
            return a;
        return Fibonacci(n - 1, b, a + b);
    }
}
