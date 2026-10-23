using System;

public class Bedingungen {
    // durch 4 teilbar, aber nicht durch 100 — außer durch 400 teilbar
    public static bool IstSchaltjahr(int jahr) {
        throw new NotImplementedException();
    }

    // true, wenn min <= x <= max
    public static bool ImBereich(int x, int min, int max) {
        throw new NotImplementedException();
    }

    // Gegenteil von ImBereich, ohne ! (De Morgan)
    public static bool AusserhalbBereich(int x, int min, int max) {
        throw new NotImplementedException();
    }

    // -1, 0 oder 1, mit verschachteltem ?:
    public static int Vorzeichen(int x) {
        throw new NotImplementedException();
    }

    // größte der drei Zahlen, nur mit ?:
    public static int Maximum(int a, int b, int c) {
        throw new NotImplementedException();
    }
}
