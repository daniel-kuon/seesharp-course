public record Produkt(string Name, string Kategorie, decimal Preis, int Lager);

public record Kunde(int Id, string Name);

public record Bestellung(int Id, int KundeId, decimal Betrag);
