public static class Mengenwerkzeuge
{
    // Werte, die mehr als einmal vorkommen, jeder nur einmal.
    // Tipp: HashSet<T>.Add() liefert false, wenn das Element schon da war.
    public static HashSet<int> Duplikate(IEnumerable<int> zahlen)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Schnittmenge als NEUE Menge; a und b bleiben unverändert (erst kopieren).
    public static HashSet<string> GemeinsameFreunde(HashSet<string> a, HashSet<string> b)
    {
        // TODO: IntersectWith auf einer Kopie
        throw new NotImplementedException();
    }

    // Elemente von a, die nicht in b sind, als NEUE Menge.
    public static HashSet<string> NurLinks(HashSet<string> a, HashSet<string> b)
    {
        // TODO: ExceptWith auf einer Kopie
        throw new NotImplementedException();
    }

    // Vereinigung als NEUE Menge.
    public static HashSet<string> Alle(HashSet<string> a, HashSet<string> b)
    {
        // TODO: UnionWith auf einer Kopie
        throw new NotImplementedException();
    }

    // true, wenn jedes Element von a auch in b vorkommt.
    public static bool IstTeilmenge(HashSet<string> a, HashSet<string> b)
    {
        // TODO
        throw new NotImplementedException();
    }

    // true, wenn jede Zahl aus gesucht in liste vorkommt. Variante mit Listen:
    // Contains() auf der Liste.
    public static bool ContainsAllListe(List<int> liste, List<int> gesucht)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Dasselbe Ergebnis, aber kopiere liste zuerst in ein HashSet<int> und
    // frage dort mit Contains() ab.
    public static bool ContainsAllMenge(List<int> liste, List<int> gesucht)
    {
        // TODO
        throw new NotImplementedException();
    }
}
