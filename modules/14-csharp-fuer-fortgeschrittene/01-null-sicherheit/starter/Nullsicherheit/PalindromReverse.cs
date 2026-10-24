using System.Diagnostics.CodeAnalysis;

namespace Nullsicherheit;

public static class PalindromReverse
{
    // TODO: Reverse soll null annehmen und dann null liefern, sonst den umgekehrten Text.
    //       Passe die Typen mit ? an und hänge [return: NotNullIfNotNull(nameof(s))] an,
    //       damit Aufrufer mit einem Text als Argument keinen null-Wert bekommen.
    public static string Reverse(string s)
    {
        throw new NotImplementedException();
    }

    // TODO: Gib mit [NotNullWhen(true)] am out-Parameter zu verstehen, dass treffer
    //       genau dann nicht null ist, wenn die Methode true liefert.
    //       Gesucht wird der erste Eintrag, der mit prefix beginnt (Ordinal-Vergleich).
    public static bool TryFinde(string[] daten, string prefix, out string treffer)
    {
        throw new NotImplementedException();
    }

    // Diese Methode funktioniert, bricht aber den Build: Die Nullzustandsanalyse
    // kennt den Rückgabetyp von First nur als string?.
    // TODO: Behebe die Warnung (Schleife) oder setze ! ein, wenn du es begründen kannst:
    //       Ein Kommentar über dem ! muss erklären, warum der Wert nicht null ist.
    public static string ErstesVorhandenes(string?[] daten)
    {
        if (!daten.Any(d => d is not null))
            throw new InvalidOperationException("Alle Einträge sind null.");
        return daten.First(d => d is not null);
    }
}
