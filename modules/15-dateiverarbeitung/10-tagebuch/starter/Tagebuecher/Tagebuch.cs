using System.Globalization;

namespace Tagebuecher;

/// <summary>Ein Tagebuch in einer Textdatei: pro Eintrag eine Zeile "yyyy-MM-dd;text".</summary>
public class Tagebuch(string pfad)
{
    // Hilfsmethode: Datum als "2025-06-04", unabhängig von der Spracheinstellung.
    static string Datum(DateOnly tag) => tag.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

    // TODO: Hänge eine Zeile "<datum>;<text>" an die Datei an (StreamWriter mit append: true, Close im
    //       finally). Enthält der Text einen Zeilenumbruch (\n oder \r), wirf eine ArgumentException,
    //       bevor etwas geschrieben wird.
    public void Schreibe(DateOnly tag, string text)
    {
        throw new NotImplementedException();
    }

    // TODO: Alle Texte des Tages (ohne "<datum>;") in der Reihenfolge des Schreibens, mit einem StreamReader (ReadLine bis null, Close im finally).
    //       Gibt es die Datei noch nicht, kommt eine leere Liste. Der Text darf selbst Semikolons enthalten.
    public List<string> Eintraege(DateOnly tag)
    {
        throw new NotImplementedException();
    }

    // TODO: Anzahl aller Einträge (Zeilen); ohne Datei 0. Mit File.ReadAllLines.
    public int AnzahlEintraege()
    {
        throw new NotImplementedException();
    }
}
