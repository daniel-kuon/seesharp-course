using System;

public class Bedingungen {
    public static bool IstSchaltjahr(int jahr) =>
        (jahr % 4 == 0 && jahr % 100 != 0) || jahr % 400 == 0;

    public static bool ImBereich(int x, int min, int max) => min <= x && x <= max;

    public static bool AusserhalbBereich(int x, int min, int max) => x < min || x > max;

    public static int Vorzeichen(int x) => x < 0 ? -1 : x > 0 ? 1 : 0;

    public static int Maximum(int a, int b, int c) =>
        a >= b ? (a >= c ? a : c)
               : (b >= c ? b : c);
}
