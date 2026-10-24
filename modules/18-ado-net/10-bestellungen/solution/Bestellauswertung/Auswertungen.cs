namespace Bestellauswertung;

/// <summary>SQL-Abfragen (SQLite) für das Schema Kunde / Bestellung / Position.</summary>
public static class Auswertungen
{
    public const string UmsatzProKunde = """
        SELECT k.Name AS Kunde, SUM(p.Menge * p.Preis) AS Umsatz
        FROM Kunde k
        JOIN Bestellung b ON b.KundeId = k.Id
        JOIN Position p ON p.BestellungId = b.Id
        GROUP BY k.Id, k.Name
        ORDER BY Umsatz DESC
        """;

    public const string KundenOhneBestellung = """
        SELECT k.Name
        FROM Kunde k
        LEFT JOIN Bestellung b ON b.KundeId = k.Id
        WHERE b.Id IS NULL
        ORDER BY k.Name
        """;

    public const string Top3Produkte = """
        SELECT Produkt, SUM(Menge) AS Menge
        FROM Position
        GROUP BY Produkt
        ORDER BY Menge DESC, Produkt
        LIMIT 3
        """;
}
