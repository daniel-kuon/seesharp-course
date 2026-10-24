using Microsoft.Data.Sqlite;

namespace Artikelverwaltung;

/// <summary>
/// Liest Artikel aus der Datenbank. Tabellen (legen die Tests an):
///   Kategorie(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL)
///   Artikel(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Preis REAL NOT NULL, Bestand INTEGER NOT NULL,
///           KategorieId INTEGER NULL REFERENCES Kategorie(Id))
/// Die Verbindung gehört dem Aufrufer und ist offen; jeder Leser (und jeder Befehl) wird
/// nach Gebrauch freigegeben, damit die Verbindung sofort wieder frei ist.
/// </summary>
public class ArtikelRepository
{
    // Diese Abfrage liefert die Spalten Id, Name, Preis, Bestand und Kategorie (Name der Kategorie
    // oder NULL, weil es ein LEFT JOIN ist). Du darfst sie in den Methoden weiterverwenden.
    private const string Auswahl =
        "SELECT a.Id, a.Name, a.Preis, a.Bestand, k.Name AS Kategorie " +
        "FROM Artikel a LEFT JOIN Kategorie k ON k.Id = a.KategorieId";

    private readonly SqliteConnection _verbindung;

    public ArtikelRepository(SqliteConnection verbindung)
    {
        _verbindung = verbindung;
    }

    /// <summary>Alle Artikel, sortiert nach Id.</summary>
    public List<Artikel> Alle()
    {
        // TODO: ExecuteReader (using!), Spaltennummern mit GetOrdinal, Werte mit GetInt32/GetString/GetDecimal.
        // Die Kategorie kann NULL sein: erst IsDBNull fragen, dann GetString.
        throw new NotImplementedException();
    }

    /// <summary>Artikel, deren Name den Text teil enthält (Groß-/Kleinschreibung egal, sortiert nach Name).
    /// Der Suchtext kommt als Parameter in den Befehl; die Zeichen % gehören zum Parameterwert, nicht zum SQL-Text.</summary>
    public List<Artikel> Suche(string teil)
    {
        // TODO: ... WHERE a.Name LIKE @muster ORDER BY a.Name; @muster = "%" + teil + "%".
        throw new NotImplementedException();
    }

    /// <summary>Artikel nach Kategoriename gruppiert; Artikel ohne Kategorie stehen unter "(ohne)".</summary>
    public Dictionary<string, List<Artikel>> NachKategorie()
    {
        // TODO: Alle() durchlaufen und jeden Artikel in die Liste seiner Kategorie einsortieren.
        throw new NotImplementedException();
    }

    /// <summary>Summe aus Preis * Bestand, von der Datenbank berechnet (SUM + ExecuteScalar).
    /// Bei einer leeren Tabelle liefert SUM NULL (DBNull); das Ergebnis soll dann 0 sein.</summary>
    public decimal LagerwertPerSql()
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Dieselbe Summe, aber in C# über die Artikel aus Alle() berechnet.</summary>
    public decimal LagerwertPerCsharp()
    {
        // TODO
        throw new NotImplementedException();
    }
}
