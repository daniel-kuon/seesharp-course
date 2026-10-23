using System;

public class Umrechner {
    // TODO: öffentliche Konstante DmProEuro (decimal, 1,95583) anlegen

    // celsius * 9 / 5 + 32 — Vorsicht mit der Ganzzahldivision
    public static double CelsiusInFahrenheit(double celsius) {
        throw new NotImplementedException();
    }

    // (fahrenheit - 32) * 5 / 9
    public static double FahrenheitInCelsius(double fahrenheit) {
        throw new NotImplementedException();
    }

    // Euro in DM, kaufmännisch auf 2 Nachkommastellen gerundet
    public static decimal EuroInDm(decimal euro) {
        throw new NotImplementedException();
    }

    // DM und Pfennig (100 Pfennig = 1 DM) in Euro, auf Cent gerundet
    public static decimal DmInEuro(int dm, int pfennig) {
        throw new NotImplementedException();
    }

    // 12.34m -> "12 Euro und 34 Cent"
    public static string Kassenbon(decimal betrag) {
        throw new NotImplementedException();
    }
}
