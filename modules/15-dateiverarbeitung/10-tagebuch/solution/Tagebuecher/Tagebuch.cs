using System.Globalization;

namespace Tagebuecher;

/// <summary>Ein Tagebuch in einer Textdatei: pro Eintrag eine Zeile "yyyy-MM-dd;text".</summary>
public class Tagebuch(string pfad)
{
    static string Datum(DateOnly tag) => tag.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

    /// <summary>Hängt einen Eintrag an. Der Text darf keine Zeilenumbrüche enthalten.</summary>
    public void Schreibe(DateOnly tag, string text)
    {
        if (text.Contains('\n') || text.Contains('\r'))
            throw new ArgumentException("Der Text darf keinen Zeilenumbruch enthalten.", nameof(text));

        var schreiber = new StreamWriter(pfad, append: true);
        try
        {
            schreiber.WriteLine(Datum(tag) + ";" + text);
        }
        finally
        {
            schreiber.Close();
        }
    }

    /// <summary>Alle Texte eines Tages in der Reihenfolge des Schreibens; ohne Datei eine leere Liste.</summary>
    public List<string> Eintraege(DateOnly tag)
    {
        var ergebnis = new List<string>();
        if (!File.Exists(pfad))
            return ergebnis;

        string praefix = Datum(tag) + ";";
        var leser = new StreamReader(pfad);
        try
        {
            string? zeile;
            while ((zeile = leser.ReadLine()) != null)
            {
                if (zeile.StartsWith(praefix, StringComparison.Ordinal))
                    ergebnis.Add(zeile.Substring(praefix.Length));
            }
        }
        finally
        {
            leser.Close();
        }
        return ergebnis;
    }

    /// <summary>Anzahl aller Einträge; ohne Datei 0.</summary>
    public int AnzahlEintraege() => File.Exists(pfad) ? File.ReadAllLines(pfad).Length : 0;
}
