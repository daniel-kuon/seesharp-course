public class Gleitkomma {
    public static double SummeDouble() => 0.1 + 0.2;
    public static decimal SummeDecimal() => 0.1m + 0.2m;
    public static double EinsPlusZweiHochMinus(int i) => 1.0 + Math.Pow(2, -i);
    public static bool IstUngefaehrGleich(double a, double b, double toleranz) => Math.Abs(a - b) < toleranz;
    public static decimal RundeKaufmaennisch(decimal betrag) => Math.Round(betrag, 2, MidpointRounding.AwayFromZero);
}
