public record Kunde(int Id, string Name);

public record Bestellung(int Id, int KundeId, decimal Betrag);

public static class Verknuepfungen
{
    // TODO: Join(bestellungen, k => k.Id, b => b.KundeId, (k, b) => ...) und ToList()
    public static List<(string Name, decimal Betrag)> KundenMitBestellung(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) => throw new NotImplementedException();

    // TODO: GroupJoin; das Ergebnis je Kunde bekommt die Gruppe bs seiner Bestellungen (Count und Sum)
    public static List<(string Name, int Anzahl, decimal Summe)> BestellungenProKunde(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) => throw new NotImplementedException();

    // TODO: GroupJoin, nach Summe absteigend sortieren, ersten Kunden nehmen (FirstOrDefault)
    public static Kunde? TopKunde(IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) => throw new NotImplementedException();

    // TODO: Zip mit Ergebnisfunktion
    public static List<string> Paare(IEnumerable<string> namen, IEnumerable<int> zahlen) => throw new NotImplementedException();
}
