using System;

public class Zahlenreihen {
    public static string Einmaleins(int zahl) {
        string reihe = "" + zahl;
        for (int i = 2; i <= 10; i++)
            reihe += " " + zahl * i;
        return reihe;
    }

    public static int Quersumme(long n) {
        int summe = 0;
        while (n > 0) {
            summe += (int)(n % 10);
            n /= 10;
        }
        return summe;
    }

    public static long Umgedreht(long n) {
        long ergebnis = 0;
        while (n > 0) {
            ergebnis = ergebnis * 10 + n % 10;
            n /= 10;
        }
        return ergebnis;
    }

    public static bool IstPalindrom(long n) => Umgedreht(n) == n;

    public static long Potenz(int basis, int exponent) {
        long ergebnis = 1;
        for (int i = 0; i < exponent; i++)
            ergebnis *= basis;
        return ergebnis;
    }
}
