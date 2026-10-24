namespace Musterabgleich;

public enum Kategorie { Ungueltig, Kind, Jugendlicher, Erwachsener, Senior }

public static class Muster
{
    // TODO: switch-Ausdruck mit Relationsmustern und or:
    //       0 bis 12 Kind, 13 bis 17 Jugendlicher, 18 bis 64 Erwachsener,
    //       65 bis 150 Senior, negativ oder über 150 Ungueltig.
    public static Kategorie Alterskategorie(int alter)
    {
        throw new NotImplementedException();
    }

    // TODO: switch-Ausdruck über object? mit Konstanten-, Typ- und Deklarationsmustern:
    //       null -> "null", int 5 -> "Ganzzahl 5", string "abcd" -> "Text mit 4 Zeichen",
    //       double, float oder decimal -> "Dezimalzahl", alles andere -> "unbekannt".
    public static string Beschreibe(object? o)
    {
        throw new NotImplementedException();
    }

    // TODO: ein is-Ausdruck mit Relationsmustern, and und or:
    //       Buchstaben a-z, A-Z und der Unterstrich.
    public static bool IstIdentifierZeichen(char c)
    {
        throw new NotImplementedException();
    }

    // TODO: x is not null and > 0
    public static bool IstPositiv(int? x)
    {
        throw new NotImplementedException();
    }
}
