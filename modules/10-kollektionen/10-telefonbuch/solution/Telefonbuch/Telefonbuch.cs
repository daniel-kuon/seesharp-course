public class Telefonbuch
{
    readonly Dictionary<string, string> eintraege = new();

    // Trägt name mit nummer ein; ein vorhandener Eintrag wird überschrieben.
    public void Setze(string name, string nummer)
    {
        eintraege[name] = nummer;
    }

    // Die Nummer zum Namen oder null, wenn der Name unbekannt ist.
    public string? Suche(string name)
    {
        return eintraege.TryGetValue(name, out string? nummer) ? nummer : null;
    }

    // Alle Namen, alphabetisch sortiert.
    public List<string> Namen()
    {
        var namen = new List<string>(eintraege.Keys);
        namen.Sort(StringComparer.Ordinal);
        return namen;
    }

    // Alle Namen, deren Nummer mit vorwahl beginnt, alphabetisch sortiert.
    public List<string> MitVorwahl(string vorwahl)
    {
        var treffer = new List<string>();
        foreach (KeyValuePair<string, string> paar in eintraege)
        {
            if (paar.Value.StartsWith(vorwahl, StringComparison.Ordinal))
                treffer.Add(paar.Key);
        }
        treffer.Sort(StringComparer.Ordinal);
        return treffer;
    }

    // Entfernt den Eintrag. true, wenn es ihn gab.
    public bool Entferne(string name)
    {
        return eintraege.Remove(name);
    }
}
