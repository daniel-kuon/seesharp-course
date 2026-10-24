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
    // Das Dictionary vergleicht mit StringComparer.OrdinalIgnoreCase.
    public static Dictionary<string, int> Haeufigkeiten(string text)
    {
        var zaehler = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string wort in Woerter(text))
        {
            if (zaehler.TryGetValue(wort, out int bisher))
                zaehler[wort] = bisher + 1;
            else
                zaehler.Add(wort, 1);
        }
        return zaehler;
    }

    // Die Nummer zum Namen oder "unbekannt". Kein Zugriff auf einen fehlenden Schlüssel!
    public static string Nachschlagen(Dictionary<string, string> telefonbuch, string name)
    {
        return telefonbuch.TryGetValue(name, out string? nummer) ? nummer : "unbekannt";
    }

    // Trägt name ein. Gibt es ihn schon, gewinnt der neue Eintrag.
    public static void Eintragen(Dictionary<string, string> telefonbuch, string name, string nummer)
    {
        telefonbuch[name] = nummer;
    }

    // Vertauscht Rolle von Schlüssel und Wert: zu jeder Häufigkeit alle Wörter mit dieser Häufigkeit.
    public static Dictionary<int, List<string>> Umkehren(Dictionary<string, int> haeufigkeiten)
    {
        var ergebnis = new Dictionary<int, List<string>>();
        foreach (KeyValuePair<string, int> paar in haeufigkeiten)
        {
            if (!ergebnis.TryGetValue(paar.Value, out List<string>? woerter))
            {
                woerter = new List<string>();
                ergebnis.Add(paar.Value, woerter);
            }
            woerter.Add(paar.Key);
        }
        return ergebnis;
    }

    // Die n häufigsten Wörter: größte Anzahl zuerst, bei gleicher Anzahl alphabetisch.
    // Eintrag kennt diese Reihenfolge bereits (IComparable<Eintrag>), Sort() genügt.
    public static List<string> Haeufigste(Dictionary<string, int> haeufigkeiten, int n)
    {
        var eintraege = new List<Eintrag>();
        foreach (KeyValuePair<string, int> paar in haeufigkeiten)
            eintraege.Add(new Eintrag(paar.Key, paar.Value));
        eintraege.Sort();

        var ergebnis = new List<string>();
        for (int i = 0; i < eintraege.Count && i < n; i++)
            ergebnis.Add(eintraege[i].Wort);
        return ergebnis;
    }

    // Summe aller Häufigkeiten (aufzählen mit KeyValuePair).
    public static int Summe(Dictionary<string, int> haeufigkeiten)
    {
        int summe = 0;
        foreach (KeyValuePair<string, int> paar in haeufigkeiten)
            summe += paar.Value;
        return summe;
    }

    // Alle Schlüssel, alphabetisch sortiert.
    public static List<string> Schluessel(Dictionary<string, int> haeufigkeiten)
    {
        var liste = new List<string>(haeufigkeiten.Keys);
        liste.Sort(StringComparer.Ordinal);
        return liste;
    }
}
