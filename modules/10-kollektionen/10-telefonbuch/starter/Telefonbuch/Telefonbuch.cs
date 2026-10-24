public class Telefonbuch
{
    readonly Dictionary<string, string> eintraege = new();

    // Trägt name mit nummer ein; ein vorhandener Eintrag wird überschrieben.
    public void Setze(string name, string nummer)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Nummer zum Namen oder null, wenn der Name unbekannt ist (TryGetValue).
    public string? Suche(string name)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Alle Namen, alphabetisch sortiert.
    public List<string> Namen()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Alle Namen, deren Nummer mit vorwahl beginnt, alphabetisch sortiert.
    // Zähle dazu die Paare (KeyValuePair) auf.
    public List<string> MitVorwahl(string vorwahl)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Entfernt den Eintrag. true, wenn es ihn gab, sonst false.
    public bool Entferne(string name)
    {
        // TODO
        throw new NotImplementedException();
    }
}
