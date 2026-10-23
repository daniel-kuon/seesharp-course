using System;

public class Ziffern {
    public static int Quersumme(int n) => n / 100 + n / 10 % 10 + n % 10;

    public static int Umgedreht(int n) => n % 10 * 100 + n / 10 % 10 * 10 + n / 100;

    public static bool IstGerade(int n) => n % 2 == 0;

    public static string Uhrzeit(int sekunden) =>
        $"{sekunden / 3600:d2}:{sekunden / 60 % 60:d2}:{sekunden % 60:d2}";
}
