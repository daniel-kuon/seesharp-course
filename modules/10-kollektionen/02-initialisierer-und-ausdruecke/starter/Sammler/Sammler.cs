public static class Sammler
{
    // Montag bis Sonntag, aufgebaut mit einem Kollektionsinitialisierer:
    // new List<string> { ..., ... }
    public static List<string> Wochentage()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Erst alle Elemente von a, dann alle von b. Nimm einen Kollektionsausdruck
    // mit Spread-Elementen: [..a, ..b]
    public static List<int> Zusammen(IEnumerable<int> a, IEnumerable<int> b)
    {
        // TODO
        throw new NotImplementedException();
    }

    // {rand, mitte..., rand} als Array, wieder mit Kollektionsausdruck und Spread.
    public static int[] MitRand(int[] mitte, int rand)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Eine leere, schreibgeschützte Liste. Der Kollektionsausdruck [] findet seinen
    // Zieltyp im Rückgabetyp.
    public static IReadOnlyList<T> Leer<T>()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Lager "Hauptlager" mit den Artikeln Schraube, Mutter, Dichtung.
    // Objektinitialisierer mit verschachteltem Kollektionsinitialisierer:
    // Artikel = { "...", "..." }
    public static Lager NeuesLager()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Trägt von..bis (beide eingeschlossen) in ziel ein.
    // Muss für List<int> und HashSet<int> gleichermaßen funktionieren.
    public static void FuelleAuf(ICollection<int> ziel, int von, int bis)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Anzahl der Elemente. ICollection<T> kennt sie schon.
    public static int Zaehle<T>(ICollection<T> sammlung)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Summe einer beliebigen Folge. IEnumerable<int> hat kein Count und keine Summe:
    // Du musst aufzählen.
    public static int Gesamt(IEnumerable<int> folge)
    {
        // TODO
        throw new NotImplementedException();
    }
}
