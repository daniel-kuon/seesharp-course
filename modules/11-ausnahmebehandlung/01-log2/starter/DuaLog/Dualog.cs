public static class Dualog
{
    // Dualer Logarithmus. Im Moment liefert die Methode für x <= 0 NaN oder -Infinity
    // und niemand merkt, dass etwas schiefging.
    // TODO: Für x <= 0 eine ArgumentOutOfRangeException werfen. Parametername "x",
    // eine deutsche Meldung (Konstruktor mit paramName, actualValue, message).
    public static double Log2(double x)
    {
        return Math.Log2(x);
    }

    // Quadratwurzel; Math.Sqrt liefert für negative Zahlen NaN.
    // TODO: Für x < 0 ebenfalls eine ArgumentOutOfRangeException mit Parametername "x" werfen.
    public static double Wurzel(double x)
    {
        return Math.Sqrt(x);
    }

    // n! für n von 0 bis 20 (danach passt das Ergebnis nicht mehr in ein long).
    // TODO: Für n < 0 eine ArgumentOutOfRangeException mit Parametername "n" werfen.
    public static long Fakultaet(int n)
    {
        long ergebnis = 1;
        for (int i = 2; i <= n; i++)
            ergebnis *= i;
        return ergebnis;
    }
}
