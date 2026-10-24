public record Kunde(int Id, string Name);

public record Bestellung(int Id, int KundeId, decimal Betrag);

public static class Verknuepfungen
{
    public static List<(string Name, decimal Betrag)> KundenMitBestellung(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        kunden
            .Join(bestellungen, k => k.Id, b => b.KundeId, (k, b) => (k.Name, b.Betrag))
            .ToList();

    public static List<(string Name, int Anzahl, decimal Summe)> BestellungenProKunde(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        kunden
            .GroupJoin(bestellungen, k => k.Id, b => b.KundeId,
                (k, bs) => (k.Name, bs.Count(), bs.Sum(b => b.Betrag)))
            .ToList();

    public static Kunde? TopKunde(IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        kunden
            .GroupJoin(bestellungen, k => k.Id, b => b.KundeId,
                (k, bs) => (Kunde: k, Summe: bs.Sum(b => b.Betrag)))
            .OrderByDescending(x => x.Summe)
            .Select(x => x.Kunde)
            .FirstOrDefault();

    public static List<string> Paare(IEnumerable<string> namen, IEnumerable<int> zahlen) =>
        namen.Zip(zahlen, (n, z) => $"{n}:{z}").ToList();
}
