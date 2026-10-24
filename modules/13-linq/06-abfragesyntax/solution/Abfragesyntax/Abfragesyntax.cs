public static class Abfragesyntax
{
    public static List<string> TeuerQ(IEnumerable<Produkt> produkte, decimal grenze) =>
        (from p in produkte
         where p.Preis > grenze
         orderby p.Name
         select p.Name).ToList();

    public static List<(string Name, decimal Brutto)> MitMehrwertsteuerQ(IEnumerable<Produkt> produkte) =>
        (from p in produkte
         let brutto = p.Preis * 1.19m
         where brutto > 20m
         select (p.Name, brutto)).ToList();

    public static List<(string Kategorie, int Anzahl)> GroessteKategorienQ(IEnumerable<Produkt> produkte) =>
        (from p in produkte
         group p by p.Kategorie into g
         where g.Count() > 1
         orderby g.Count() descending, g.Key
         select (g.Key, g.Count())).ToList();

    public static List<(string Name, decimal Betrag)> KundenMitBestellungQ(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        (from k in kunden
         join b in bestellungen on k.Id equals b.KundeId
         select (k.Name, b.Betrag)).ToList();

    public static List<(string Name, decimal Summe)> KundenSummenQ(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        (from k in kunden
         join b in bestellungen on k.Id equals b.KundeId into bs
         select (k.Name, bs.Sum(b => b.Betrag))).ToList();
}
