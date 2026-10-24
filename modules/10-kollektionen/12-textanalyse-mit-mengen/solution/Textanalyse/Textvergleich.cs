public static class Textvergleich
{
    // Die verschiedenen Wörter eines Texts, klein geschrieben.
    // Trennzeichen: Leerzeichen und , . ; : ! ? -
    public static HashSet<string> Woerter(string text)
    {
        char[] trenner = { ' ', ',', '.', ';', ':', '!', '?', '-' };
        var menge = new HashSet<string>();
        foreach (string wort in text.Split(trenner, StringSplitOptions.RemoveEmptyEntries))
            menge.Add(wort.ToLowerInvariant());
        return menge;
    }

    // Wörter, die in beiden Mengen vorkommen, alphabetisch sortiert.
    public static List<string> Gemeinsam(HashSet<string> a, HashSet<string> b)
    {
        var schnitt = new HashSet<string>(a);
        schnitt.IntersectWith(b);
        var liste = new List<string>(schnitt);
        liste.Sort(StringComparer.Ordinal);
        return liste;
    }

    // Wörter, die nur in a vorkommen, alphabetisch sortiert.
    public static List<string> NurInA(HashSet<string> a, HashSet<string> b)
    {
        var rest = new HashSet<string>(a);
        rest.ExceptWith(b);
        var liste = new List<string>(rest);
        liste.Sort(StringComparer.Ordinal);
        return liste;
    }

    // Jaccard-Ähnlichkeit |A ∩ B| / |A ∪ B|. Sind beide Mengen leer, ist das Ergebnis 0.
    public static double Aehnlichkeit(HashSet<string> a, HashSet<string> b)
    {
        var schnitt = new HashSet<string>(a);
        schnitt.IntersectWith(b);
        var vereinigung = new HashSet<string>(a);
        vereinigung.UnionWith(b);
        if (vereinigung.Count == 0)
            return 0.0;
        return (double)schnitt.Count / vereinigung.Count;
    }
}
