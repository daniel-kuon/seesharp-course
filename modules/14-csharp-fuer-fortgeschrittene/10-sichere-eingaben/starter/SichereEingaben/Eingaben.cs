namespace SichereEingaben;

// Die Methoden unten funktionieren nur für Eingaben, die nie null sind. Im echten Leben kommen
// aber null, leere Texte und fehlende Einträge vor. Das Projekt hat <WarningsAsErrors>nullable</WarningsAsErrors>:
// Wer mit ? und ?? arbeitet, bekommt keine Warnung; ein ! ist hier nicht nötig und nicht erwünscht.
public static class Eingaben
{
    // TODO: s darf null sein (string?). Entferne Leerraum an den Rändern (Trim);
    //       ist danach nichts übrig (oder s war null), kommt "(leer)" heraus.
    public static string Bereinige(string s)
    {
        var t = s.Trim();
        return t.Length == 0 ? "(leer)" : t;
    }

    // TODO: Erstes Wort des Textes (durch Leerzeichen getrennt, leere Teile ignorieren);
    //       "" für null, leeren Text oder nur Leerzeichen. Mit ?. und ?? lösbar.
    public static string ErstesWort(string s)
    {
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
    }

    // TODO: daten darf null sein. Gesucht ist der Eintrag "alter" als Zahl;
    //       0, wenn es kein Wörterbuch, keinen Eintrag oder keine Zahl gibt.
    //       Tipps: daten?.GetValueOrDefault("alter") und int.TryParse.
    public static int Alter(Dictionary<string, string> daten)
    {
        return int.Parse(daten["alter"]);
    }
}
