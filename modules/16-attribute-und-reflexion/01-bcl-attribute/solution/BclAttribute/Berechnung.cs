public static class Berechnung
{
    public static int Neu(int a, int b) => a + b;

    [Obsolete("Bitte Neu(...) verwenden")]
    public static int Alt(int a, int b) => Neu(a, b);
}
