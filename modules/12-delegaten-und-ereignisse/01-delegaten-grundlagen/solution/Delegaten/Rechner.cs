public class Rechner
{
    public double Exponent { get; set; } = 2;

    public static double Addiere(double a, double b) => a + b;
    public static double Subtrahiere(double a, double b) => a - b;
    public static double Multipliziere(double a, double b) => a * b;
    public static double Dividiere(double a, double b) => a / b;

    // Instanzmethode: braucht das Zielobjekt (this.Exponent)
    public double Potenz(double a, double b) => Math.Pow(a + b, Exponent);

    public static double Anwenden(Operation op, double a, double b) => op(a, b);

    public static double Reduziere(Operation op, double[] werte)
    {
        if (werte.Length == 0)
            throw new ArgumentException("Mindestens ein Wert erwartet.", nameof(werte));
        double ergebnis = werte[0];
        for (int i = 1; i < werte.Length; i++)
            ergebnis = op(ergebnis, werte[i]);
        return ergebnis;
    }

    public static Operation? Waehle(char zeichen) => zeichen switch
    {
        '+' => Addiere,
        '-' => Subtrahiere,
        '*' => Multipliziere,
        '/' => Dividiere,
        _ => null
    };

    public Operation PotenzDelegat() => Potenz;

    public static int Zaehle(double[] werte, Bedingung b)
    {
        int n = 0;
        foreach (double w in werte)
            if (b(w)) n++;
        return n;
    }

    public static bool IstPositiv(double wert) => wert > 0;
}
