using Artikelverwaltung;
using Microsoft.Data.Sqlite;

public class ArtikelRepositoryTests : IDisposable
{
    // Jeder Test hat seine eigene Datenbank im Speicher.
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");

    public ArtikelRepositoryTests()
    {
        _verbindung.Open();
        Ausfuehren("""
            CREATE TABLE Kategorie (Id INTEGER PRIMARY KEY, Name TEXT NOT NULL);
            CREATE TABLE Artikel (
                Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Preis REAL NOT NULL, Bestand INTEGER NOT NULL,
                KategorieId INTEGER NULL REFERENCES Kategorie (Id));
            INSERT INTO Kategorie (Id, Name) VALUES (1, 'Werkzeug'), (2, 'Garten');
            INSERT INTO Artikel (Id, Name, Preis, Bestand, KategorieId) VALUES
                (1, 'Hammer',      12.50, 10, 1),
                (2, 'Zange',        9.90,  5, 1),
                (3, 'Spaten',      24.90,  3, 2),
                (4, 'Harke',       11.00,  0, 2),
                (5, 'Lupe',        15.00,  2, NULL),
                (6, 'Gummihammer',  8.00,  4, 1);
            """);
    }

    public void Dispose() => _verbindung.Dispose();

    private void Ausfuehren(string sql)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = sql;
        befehl.ExecuteNonQuery();
    }

    // Eine nicht freigegebene (nicht zu Ende gelesene) Abfrage sperrt die Tabelle für DROP TABLE.
    private void AssertLeserFreigegeben()
    {
        Ausfuehren("DROP TABLE Artikel");
    }

    [Fact]
    public void Alle_liefert_alle_Artikel_nach_Id()
    {
        var alle = new ArtikelRepository(_verbindung).Alle();
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, alle.Select(a => a.Id));
        Assert.Equal(new Artikel(1, "Hammer", 12.50m, 10, "Werkzeug"), alle[0]);
        Assert.Equal(new Artikel(3, "Spaten", 24.90m, 3, "Garten"), alle[2]);
    }

    [Fact]
    public void Alle_laesst_fehlende_Kategorie_null()
    {
        var lupe = new ArtikelRepository(_verbindung).Alle().Single(a => a.Name == "Lupe");
        Assert.Null(lupe.Kategorie);
        Assert.Equal(15.00m, lupe.Preis);
        Assert.Equal(2, lupe.Bestand);
    }

    [Fact]
    public void Alle_auf_leerer_Tabelle_liefert_leere_Liste()
    {
        Ausfuehren("DELETE FROM Artikel");
        Assert.Empty(new ArtikelRepository(_verbindung).Alle());
    }

    [Fact]
    public void Suche_findet_Teiltext_ohne_Beachtung_der_Gross_Kleinschreibung_und_sortiert_nach_Name()
    {
        var treffer = new ArtikelRepository(_verbindung).Suche("hammer");
        Assert.Equal(new[] { "Gummihammer", "Hammer" }, treffer.Select(a => a.Name));
    }

    [Fact]
    public void Suche_mit_leerem_Text_liefert_alle()
    {
        Assert.Equal(6, new ArtikelRepository(_verbindung).Suche("").Count);
    }

    [Fact]
    public void Suche_ist_gegen_SQL_Injection_sicher()
    {
        var repo = new ArtikelRepository(_verbindung);
        Assert.Empty(repo.Suche("x' OR '1'='1"));
        Assert.Empty(repo.Suche("'); DROP TABLE Artikel;--"));
        Assert.Equal(6, repo.Alle().Count);
    }

    [Fact]
    public void NachKategorie_gruppiert_und_sammelt_Artikel_ohne_Kategorie_unter_ohne()
    {
        var gruppen = new ArtikelRepository(_verbindung).NachKategorie();
        Assert.Equal(new[] { "(ohne)", "Garten", "Werkzeug" }, gruppen.Keys.OrderBy(k => k, StringComparer.Ordinal));
        Assert.Equal(new[] { "Hammer", "Zange", "Gummihammer" }, gruppen["Werkzeug"].Select(a => a.Name));
        Assert.Equal(new[] { "Spaten", "Harke" }, gruppen["Garten"].Select(a => a.Name));
        Assert.Equal(new[] { "Lupe" }, gruppen["(ohne)"].Select(a => a.Name));
    }

    [Fact]
    public void Lagerwert_per_SQL_und_per_Csharp_stimmen_ueberein()
    {
        var repo = new ArtikelRepository(_verbindung);
        // 12.50*10 + 9.90*5 + 24.90*3 + 11.00*0 + 15.00*2 + 8.00*4
        Assert.Equal(311.20m, repo.LagerwertPerSql(), 2);
        Assert.Equal(311.20m, repo.LagerwertPerCsharp(), 2);
    }

    [Fact]
    public void Lagerwert_einer_leeren_Tabelle_ist_null()
    {
        Ausfuehren("DELETE FROM Artikel");
        var repo = new ArtikelRepository(_verbindung);
        Assert.Equal(0m, repo.LagerwertPerSql()); // SUM liefert NULL (DBNull)
        Assert.Equal(0m, repo.LagerwertPerCsharp());
    }

    [Fact]
    public void Leser_werden_freigegeben_Alle()
    {
        new ArtikelRepository(_verbindung).Alle();
        AssertLeserFreigegeben();
    }

    [Fact]
    public void Leser_werden_freigegeben_Suche()
    {
        new ArtikelRepository(_verbindung).Suche("a");
        AssertLeserFreigegeben();
    }

    [Fact]
    public void Leser_werden_freigegeben_NachKategorie()
    {
        new ArtikelRepository(_verbindung).NachKategorie();
        AssertLeserFreigegeben();
    }
}
