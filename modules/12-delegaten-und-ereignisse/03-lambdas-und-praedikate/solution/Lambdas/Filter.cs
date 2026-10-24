public static class Filter
{
    public static List<string> LangeWoerter(List<string> woerter) =>
        woerter.FindAll(w => w.Length > 5);

    public static int OhneLeere(List<string?> woerter) =>
        woerter.RemoveAll(w => string.IsNullOrWhiteSpace(w));

    public static bool Existiert(List<int> werte, int wert) =>
        werte.Exists(w => w == wert);

    public static string? ErstesMit(List<string> woerter, char anfang) =>
        woerter.Find(w => w.Length > 0 && w[0] == anfang);

    public static void SortiereNachLaenge(List<string> woerter) =>
        woerter.Sort((a, b) =>
        {
            int vergleich = a.Length.CompareTo(b.Length);
            return vergleich != 0 ? vergleich : string.CompareOrdinal(a, b);
        });

    public static int Summe(List<int> werte)
    {
        int summe = 0;
        werte.ForEach(w => summe += w);
        return summe;
    }
}
