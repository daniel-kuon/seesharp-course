public static class Mengenwerkzeuge
{
    // Werte, die mehr als einmal vorkommen, jeder nur einmal.
    public static HashSet<int> Duplikate(IEnumerable<int> zahlen)
    {
        var gesehen = new HashSet<int>();
        var doppelt = new HashSet<int>();
        foreach (int z in zahlen)
        {
            if (!gesehen.Add(z))
                doppelt.Add(z);
        }
        return doppelt;
    }

    // Schnittmenge als NEUE Menge; a und b bleiben unverändert.
    public static HashSet<string> GemeinsameFreunde(HashSet<string> a, HashSet<string> b)
    {
        var ergebnis = new HashSet<string>(a);
        ergebnis.IntersectWith(b);
        return ergebnis;
    }

    // Elemente von a, die nicht in b sind, als NEUE Menge.
    public static HashSet<string> NurLinks(HashSet<string> a, HashSet<string> b)
    {
        var ergebnis = new HashSet<string>(a);
        ergebnis.ExceptWith(b);
        return ergebnis;
    }

    // Vereinigung als NEUE Menge.
    public static HashSet<string> Alle(HashSet<string> a, HashSet<string> b)
    {
        var ergebnis = new HashSet<string>(a);
        ergebnis.UnionWith(b);
        return ergebnis;
    }

    // true, wenn jedes Element von a auch in b vorkommt.
    public static bool IstTeilmenge(HashSet<string> a, HashSet<string> b)
    {
        return a.IsSubsetOf(b);
    }

    // true, wenn jede Zahl aus gesucht in liste vorkommt. Variante mit Listen:
    // Contains() durchsucht die Liste Element für Element.
    public static bool ContainsAllListe(List<int> liste, List<int> gesucht)
    {
        foreach (int z in gesucht)
        {
            if (!liste.Contains(z))
                return false;
        }
        return true;
    }

    // Dasselbe Ergebnis, aber mit einer Menge als Nachschlagetabelle.
    public static bool ContainsAllMenge(List<int> liste, List<int> gesucht)
    {
        var menge = new HashSet<int>(liste);
        foreach (int z in gesucht)
        {
            if (!menge.Contains(z))
                return false;
        }
        return true;
    }
}
