public static class Abfragesyntax
{
    // TODO: from p in produkte where ... orderby ... select ...  (in Klammern, dann .ToList())
    public static List<string> TeuerQ(IEnumerable<Produkt> produkte, decimal grenze) => throw new NotImplementedException();

    // TODO: let brutto = p.Preis * 1.19m  und brutto in where und select verwenden
    public static List<(string Name, decimal Brutto)> MitMehrwertsteuerQ(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: group p by p.Kategorie into g  where g.Count() > 1  orderby g.Count() descending, g.Key  select ...
    public static List<(string Kategorie, int Anzahl)> GroessteKategorienQ(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: from k in kunden join b in bestellungen on k.Id equals b.KundeId select ...
    public static List<(string Name, decimal Betrag)> KundenMitBestellungQ(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) => throw new NotImplementedException();

    // TODO: join ... on ... equals ... into bs  (Gruppenverknüpfung), dann bs.Sum(...)
    public static List<(string Name, decimal Summe)> KundenSummenQ(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) => throw new NotImplementedException();
}
