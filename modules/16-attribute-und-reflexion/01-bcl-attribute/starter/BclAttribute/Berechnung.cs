public static class Berechnung
{
    public static int Neu(int a, int b) => a + b;

    // TODO: Markiere die Methode mit [Obsolete] und der Meldung "Bitte Neu(...) verwenden".
    //       Wer sie noch aufruft, soll nur eine Warnung bekommen, keinen Fehler.
    public static int Alt(int a, int b) => Neu(a, b);
}
