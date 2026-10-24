public static class Dualog
{
    // Dualer Logarithmus. Für x <= 0 gibt es keinen: ArgumentOutOfRangeException statt NaN oder -Infinity.
    public static double Log2(double x)
    {
        if (x <= 0)
            throw new ArgumentOutOfRangeException(nameof(x), x, "Der duale Logarithmus ist nur für Zahlen größer als 0 definiert.");
        return Math.Log2(x);
    }

    // Quadratwurzel; für negative Zahlen ArgumentOutOfRangeException.
    public static double Wurzel(double x)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x), x, "Die Wurzel ist nur für Zahlen ab 0 definiert.");
        return Math.Sqrt(x);
    }

    // n! für n von 0 bis 20 (danach passt das Ergebnis nicht mehr in ein long); n < 0 ist ungültig.
    public static long Fakultaet(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), n, "Die Fakultät ist nur für n ab 0 definiert.");
        long ergebnis = 1;
        for (int i = 2; i <= n; i++)
            ergebnis *= i;
        return ergebnis;
    }
}
