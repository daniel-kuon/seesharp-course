namespace Musterabgleich;

public enum Kategorie { Ungueltig, Kind, Jugendlicher, Erwachsener, Senior }

public static class Muster
{
    /// <summary>0 bis 12 Kind, 13 bis 17 Jugendlicher, 18 bis 64 Erwachsener, 65 bis 150 Senior, sonst ungültig.</summary>
    public static Kategorie Alterskategorie(int alter) => alter switch
    {
        < 0 or > 150 => Kategorie.Ungueltig,
        < 13 => Kategorie.Kind,
        < 18 => Kategorie.Jugendlicher,
        < 65 => Kategorie.Erwachsener,
        _ => Kategorie.Senior
    };

    public static string Beschreibe(object? o) => o switch
    {
        null => "null",
        int i => $"Ganzzahl {i}",
        string s => $"Text mit {s.Length} Zeichen",
        double or float or decimal => "Dezimalzahl",
        _ => "unbekannt"
    };

    public static bool IstIdentifierZeichen(char c) =>
        c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or '_';

    public static bool IstPositiv(int? x) => x is not null and > 0;
}
