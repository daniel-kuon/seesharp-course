// Alle Methoden rekursiv lösen, also ohne Schleife.
public static class Rekursiv {
    // Quersumme einer Zahl n >= 0: 1234 -> 1 + 2 + 3 + 4 = 10.
    public static int Quersumme(int n) {
        // TODO: einstellige Zahl -> n selbst; sonst letzte Ziffer + Quersumme vom Rest
        throw new NotImplementedException();
    }

    // basis hoch exponent (exponent >= 0) mit schneller Potenzierung:
    // x^n = (x^(n/2))^2, bei ungeradem n noch einmal mal x.
    public static long Potenz(long basis, int exponent) {
        // TODO
        throw new NotImplementedException();
    }

    // Binomialkoeffizient "n über k" nach dem Pascalschen Dreieck (0 <= k <= n).
    public static long Binomial(int n, int k) {
        // TODO: Rand des Dreiecks (k == 0 oder k == n) -> 1; sonst die Summe der beiden Werte darüber
        throw new NotImplementedException();
    }

    // Mindestanzahl der Züge bei den Türmen von Hanoi mit n Scheiben.
    public static long HanoiZuege(int n) {
        // TODO: n - 1 Scheiben weg, die größte umsetzen, n - 1 Scheiben wieder drauf
        throw new NotImplementedException();
    }

    // Fibonacci-Zahl F(n), schnell: a und b sind die beiden letzten Werte.
    // Aufruf von außen: Fibonacci(n, 0, 1).
    public static long Fibonacci(int n, long a, long b) {
        // TODO: n == 0 -> a; sonst einen Schritt weiter mit (n - 1, b, a + b)
        throw new NotImplementedException();
    }
}
