namespace Bestellauswertung;

/// <summary>
/// SQL-Abfragen (SQLite) für dieses Schema, das die Tests anlegen und füllen:
///   Kunde(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL)
///   Bestellung(Id INTEGER PRIMARY KEY, KundeId INTEGER NOT NULL REFERENCES Kunde(Id), Datum TEXT NOT NULL)
///   Position(Id INTEGER PRIMARY KEY, BestellungId INTEGER NOT NULL REFERENCES Bestellung(Id),
///            Produkt TEXT NOT NULL, Menge INTEGER NOT NULL, Preis REAL NOT NULL)
/// </summary>
public static class Auswertungen
{
    // TODO: Spalten Kunde (Name) und Umsatz (Summe aus Menge * Preis über alle Positionen aller Bestellungen
    // des Kunden); nur Kunden mit Bestellungen; höchster Umsatz zuerst.
    public const string UmsatzProKunde = "-- TODO";

    // TODO: Spalte Name der Kunden ohne jede Bestellung, nach Name sortiert (LEFT JOIN ... IS NULL).
    public const string KundenOhneBestellung = "-- TODO";

    // TODO: Spalten Produkt und Menge (Summe der bestellten Menge); die drei meistbestellten Produkte:
    // Menge absteigend, bei Gleichstand nach Produkt aufsteigend; LIMIT 3.
    public const string Top3Produkte = "-- TODO";
}
