using System;

public class Umrechner {
    public const decimal DmProEuro = 1.95583m;

    public static double CelsiusInFahrenheit(double celsius) => celsius * 9 / 5 + 32;

    public static double FahrenheitInCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

    public static decimal EuroInDm(decimal euro) =>
        Math.Round(euro * DmProEuro, 2, MidpointRounding.AwayFromZero);

    public static decimal DmInEuro(int dm, int pfennig) =>
        Math.Round((dm + pfennig / 100m) / DmProEuro, 2, MidpointRounding.AwayFromZero);

    public static string Kassenbon(decimal betrag) =>
        $"{(int)betrag} Euro und {(int)(betrag * 100) % 100} Cent";
}
