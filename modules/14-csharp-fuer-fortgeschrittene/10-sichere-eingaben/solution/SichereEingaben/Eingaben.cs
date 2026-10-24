namespace SichereEingaben;

public static class Eingaben
{
    /// <summary>Entfernt Leerraum an den Rändern; null und Leerraum werden zu "(leer)".</summary>
    public static string Bereinige(string? s)
    {
        var t = s?.Trim();
        return string.IsNullOrEmpty(t) ? "(leer)" : t;
    }

    /// <summary>Erstes Wort des Textes, "" wenn es keines gibt.</summary>
    public static string ErstesWort(string? s) =>
        s?.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";

    /// <summary>Wert zum Schlüssel "alter" als Zahl; 0, wenn es kein Wörterbuch, keinen Eintrag oder keine Zahl gibt.</summary>
    public static int Alter(Dictionary<string, string>? daten) =>
        int.TryParse(daten?.GetValueOrDefault("alter"), out var alter) ? alter : 0;
}
