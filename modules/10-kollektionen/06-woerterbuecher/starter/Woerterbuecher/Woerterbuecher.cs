public static class Woerterbuecher
{
    // Vorgegeben: zerlegt einen Text in Wörter (Folgen von Buchstaben), alles klein geschrieben.
    // "Der Hund, der Hase." -> der, hund, der, hase
    public static List<string> Woerter(string text)
    {
        var ergebnis = new List<string>();
        var aktuell = new System.Text.StringBuilder();
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                aktuell.Append(char.ToLowerInvariant(c));
            }
            else if (aktuell.Length > 0)
            {
                ergebnis.Add(aktuell.ToString());
                aktuell.Clear();
            }
        }
        if (aktuell.Length > 0)
            ergebnis.Add(aktuell.ToString());
        return ergebnis;
    }

    // Wie oft kommt jedes Wort vor? Groß- und Kleinschreibung ist egal:
    // Erzeuge das Dictionary mit StringComparer.OrdinalIgnoreCase als Vergleicher,
    // damit auch Nachschlagen mit "DER" oder "der" dasselbe findet.
    // Tipp: TryGetValue(wort, out int bisher), dann den Zähler erhöhen oder mit 1 anlegen.
    public static Dictionary<string, int> Haeufigkeiten(string text)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Nummer zum Namen oder "unbekannt". Greife nicht mit dem Indexer auf einen
    // fehlenden Schlüssel zu, das löst eine Ausnahme aus: TryGetValue oder ContainsKey.
    public static string Nachschlagen(Dictionary<string, string> telefonbuch, string name)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Trägt name ein. Gibt es ihn schon, gewinnt der neue Eintrag (Indexer statt Add).
    public static void Eintragen(Dictionary<string, string> telefonbuch, string name, string nummer)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Vertauscht Rolle von Schlüssel und Wert: zu jeder Häufigkeit alle Wörter mit dieser
    // Häufigkeit. Ergebnistyp ist ein Dictionary<int, List<string>> (Gruppieren).
    public static Dictionary<int, List<string>> Umkehren(Dictionary<string, int> haeufigkeiten)
    {
        // TODO: Pro Paar die Liste zum Wert holen (oder neu anlegen) und das Wort anhängen.
        throw new NotImplementedException();
    }

    // Die n häufigsten Wörter: größte Anzahl zuerst, bei gleicher Anzahl alphabetisch.
    // Die Klasse Eintrag (Eintrag.cs) kennt diese Reihenfolge schon (IComparable<Eintrag>):
    // Baue eine List<Eintrag> aus den Paaren und rufe Sort() auf.
    public static List<string> Haeufigste(Dictionary<string, int> haeufigkeiten, int n)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Summe aller Häufigkeiten (aufzählen mit KeyValuePair).
    public static int Summe(Dictionary<string, int> haeufigkeiten)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Alle Schlüssel (Keys), alphabetisch sortiert.
    public static List<string> Schluessel(Dictionary<string, int> haeufigkeiten)
    {
        // TODO
        throw new NotImplementedException();
    }
}
