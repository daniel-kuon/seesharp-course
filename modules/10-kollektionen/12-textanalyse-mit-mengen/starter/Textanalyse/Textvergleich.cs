public static class Textvergleich
{
    // Die verschiedenen Wörter eines Texts, klein geschrieben.
    // Trennzeichen: Leerzeichen und , . ; : ! ? -
    // Tipp: text.Split(trennerArray, StringSplitOptions.RemoveEmptyEntries), ToLower()
    public static HashSet<string> Woerter(string text)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Wörter, die in beiden Mengen vorkommen, alphabetisch sortiert.
    // a und b dürfen sich nicht ändern: arbeite auf einer Kopie.
    public static List<string> Gemeinsam(HashSet<string> a, HashSet<string> b)
    {
        // TODO: Kopie von a, IntersectWith(b), in eine List<string> übertragen, Sort()
        throw new NotImplementedException();
    }

    // Wörter, die nur in a vorkommen, alphabetisch sortiert.
    public static List<string> NurInA(HashSet<string> a, HashSet<string> b)
    {
        // TODO: ExceptWith auf einer Kopie
        throw new NotImplementedException();
    }

    // Jaccard-Ähnlichkeit |A ∩ B| / |A ∪ B| als double (0 bis 1).
    // Sind beide Mengen leer, ist das Ergebnis 0.
    public static double Aehnlichkeit(HashSet<string> a, HashSet<string> b)
    {
        // TODO: Schnittmenge und Vereinigung auf Kopien bilden; Achtung vor ganzzahliger Division.
        throw new NotImplementedException();
    }
}
