using Microsoft.Data.Sqlite;

namespace Artikelverwaltung;

/// <summary>
/// Liest Artikel aus der Datenbank. Die Verbindung gehört dem Aufrufer und ist offen; jeder Leser
/// und jeder Befehl wird nach Gebrauch freigegeben, damit die Verbindung sofort wieder frei ist.
/// </summary>
public class ArtikelRepository
{
    private const string Auswahl =
        "SELECT a.Id, a.Name, a.Preis, a.Bestand, k.Name AS Kategorie " +
        "FROM Artikel a LEFT JOIN Kategorie k ON k.Id = a.KategorieId";

    private readonly SqliteConnection _verbindung;

    public ArtikelRepository(SqliteConnection verbindung)
    {
        _verbindung = verbindung;
    }

    private static List<Artikel> LiesAlle(SqliteCommand befehl)
    {
        var artikel = new List<Artikel>();
        using var leser = befehl.ExecuteReader();
        int id = leser.GetOrdinal("Id");
        int name = leser.GetOrdinal("Name");
        int preis = leser.GetOrdinal("Preis");
        int bestand = leser.GetOrdinal("Bestand");
        int kategorie = leser.GetOrdinal("Kategorie");
        while (leser.Read())
        {
            artikel.Add(new Artikel(
                leser.GetInt32(id),
                leser.GetString(name),
                leser.GetDecimal(preis),
                leser.GetInt32(bestand),
                leser.IsDBNull(kategorie) ? null : leser.GetString(kategorie)));
        }
        return artikel;
    }

    /// <summary>Alle Artikel, sortiert nach Id.</summary>
    public List<Artikel> Alle()
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = Auswahl + " ORDER BY a.Id";
        return LiesAlle(befehl);
    }

    /// <summary>Artikel, deren Name den Text teil enthält (sortiert nach Name).</summary>
    public List<Artikel> Suche(string teil)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = Auswahl + " WHERE a.Name LIKE @muster ORDER BY a.Name";
        befehl.Parameters.AddWithValue("@muster", "%" + teil + "%");
        return LiesAlle(befehl);
    }

    /// <summary>Artikel nach Kategoriename gruppiert; Artikel ohne Kategorie stehen unter "(ohne)".</summary>
    public Dictionary<string, List<Artikel>> NachKategorie()
    {
        var ergebnis = new Dictionary<string, List<Artikel>>();
        foreach (var artikel in Alle())
        {
            string schluessel = artikel.Kategorie ?? "(ohne)";
            if (!ergebnis.TryGetValue(schluessel, out var liste))
            {
                liste = new List<Artikel>();
                ergebnis[schluessel] = liste;
            }
            liste.Add(artikel);
        }
        return ergebnis;
    }

    /// <summary>Summe aus Preis * Bestand, von der Datenbank berechnet.</summary>
    public decimal LagerwertPerSql()
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "SELECT SUM(Preis * Bestand) FROM Artikel";
        object? summe = befehl.ExecuteScalar();
        return summe is null or DBNull ? 0m : Convert.ToDecimal(summe);
    }

    /// <summary>Dieselbe Summe, aber in C# über die Artikel aus Alle() berechnet.</summary>
    public decimal LagerwertPerCsharp()
    {
        decimal summe = 0;
        foreach (var artikel in Alle())
            summe += artikel.Preis * artikel.Bestand;
        return summe;
    }
}
