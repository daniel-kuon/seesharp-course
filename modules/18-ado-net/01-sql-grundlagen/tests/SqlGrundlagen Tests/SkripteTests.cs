using System.Globalization;
using Microsoft.Data.Sqlite;
using SqlGrundlagen;

public class SkripteTests
{
    // Jeder Test bekommt seine eigene Datenbank im Speicher; sie lebt, solange die Verbindung offen ist.
    static SqliteConnection Oeffne(bool mitDaten)
    {
        var verbindung = new SqliteConnection("Data Source=:memory:");
        verbindung.Open();
        Ausfuehren(verbindung, "PRAGMA foreign_keys = ON;");
        Ausfuehren(verbindung, Skripte.Schema);
        if (mitDaten) Ausfuehren(verbindung, Skripte.Daten);
        return verbindung;
    }

    static int Ausfuehren(SqliteConnection verbindung, string sql)
    {
        using var befehl = verbindung.CreateCommand();
        befehl.CommandText = sql;
        return befehl.ExecuteNonQuery();
    }

    static string Text(object? wert) => wert switch
    {
        null or DBNull => "NULL",
        double d => d.ToString("0.00", CultureInfo.InvariantCulture),
        _ => Convert.ToString(wert, CultureInfo.InvariantCulture) ?? "NULL"
    };

    // Jede Ergebniszeile wird zu "Spalte1|Spalte2|...", Zahlen mit zwei Nachkommastellen.
    static List<string> Zeilen(SqliteConnection verbindung, string sql)
    {
        using var befehl = verbindung.CreateCommand();
        befehl.CommandText = sql;
        using var leser = befehl.ExecuteReader();
        var ergebnis = new List<string>();
        while (leser.Read())
        {
            var teile = new string[leser.FieldCount];
            for (int i = 0; i < teile.Length; i++) teile[i] = Text(leser.GetValue(i));
            ergebnis.Add(string.Join("|", teile));
        }
        return ergebnis;
    }

    static long Zahl(SqliteConnection verbindung, string sql)
    {
        using var befehl = verbindung.CreateCommand();
        befehl.CommandText = sql;
        return Convert.ToInt64(befehl.ExecuteScalar());
    }

    [Fact]
    public void Schema_legt_beide_Tabellen_an()
    {
        using var db = Oeffne(mitDaten: false);
        var tabellen = Zeilen(db, "SELECT name FROM sqlite_master WHERE type = 'table' AND name IN ('Kategorie', 'Artikel') ORDER BY name");
        Assert.Equal(new[] { "Artikel", "Kategorie" }, tabellen);
    }

    [Fact]
    public void Schema_deklariert_Primaerschluessel_und_Fremdschluessel()
    {
        using var db = Oeffne(mitDaten: false);
        Assert.Equal(1, Zahl(db, "SELECT pk FROM pragma_table_info('Kategorie') WHERE name = 'Id'"));
        Assert.Equal(1, Zahl(db, "SELECT pk FROM pragma_table_info('Artikel') WHERE name = 'Id'"));
        var fremd = Zeilen(db, "SELECT \"table\" FROM pragma_foreign_key_list('Artikel')");
        Assert.Equal(new[] { "Kategorie" }, fremd);
    }

    [Fact]
    public void Schema_weist_Artikel_mit_unbekannter_Kategorie_ab()
    {
        using var db = Oeffne(mitDaten: false);
        Ausfuehren(db, "INSERT INTO Kategorie (Id, Name) VALUES (1, 'A')");
        Assert.Throws<SqliteException>(() =>
            Ausfuehren(db, "INSERT INTO Artikel (Name, Preis, KategorieId) VALUES ('X', 1.0, 99)"));
        Ausfuehren(db, "INSERT INTO Artikel (Name, Preis, KategorieId) VALUES ('X', 1.0, 1)");
    }

    [Fact]
    public void Schema_weist_negative_Preise_ab()
    {
        using var db = Oeffne(mitDaten: false);
        Ausfuehren(db, "INSERT INTO Kategorie (Id, Name) VALUES (1, 'A')");
        Assert.Throws<SqliteException>(() =>
            Ausfuehren(db, "INSERT INTO Artikel (Name, Preis, KategorieId) VALUES ('X', -0.5, 1)"));
        Ausfuehren(db, "INSERT INTO Artikel (Name, Preis, KategorieId) VALUES ('X', 0, 1)");
    }

    [Fact]
    public void Schema_verlangt_Namen_und_eindeutige_Kategorienamen()
    {
        using var db = Oeffne(mitDaten: false);
        Ausfuehren(db, "INSERT INTO Kategorie (Id, Name) VALUES (1, 'A')");
        Assert.Throws<SqliteException>(() => Ausfuehren(db, "INSERT INTO Kategorie (Id, Name) VALUES (2, 'A')"));
        Assert.Throws<SqliteException>(() => Ausfuehren(db, "INSERT INTO Kategorie (Id, Name) VALUES (3, NULL)"));
        Assert.Throws<SqliteException>(() =>
            Ausfuehren(db, "INSERT INTO Artikel (Name, Preis, KategorieId) VALUES (NULL, 1.0, 1)"));
    }

    [Fact]
    public void Daten_fuegt_Kategorien_und_Artikel_ein()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(4, Zahl(db, "SELECT COUNT(*) FROM Kategorie"));
        Assert.Equal(8, Zahl(db, "SELECT COUNT(*) FROM Artikel"));
        Assert.Equal(new[] { "1|Werkzeug", "2|Garten", "3|Buero", "4|Reserve" },
            Zeilen(db, "SELECT Id, Name FROM Kategorie ORDER BY Id"));
        Assert.Equal(new[] { "4|Spaten|24.90|2", "8|Locher|4.20|3" },
            Zeilen(db, "SELECT Id, Name, Preis, KategorieId FROM Artikel WHERE Id IN (4, 8) ORDER BY Id"));
    }

    [Fact]
    public void TeureArtikel_liefert_Artikel_ueber_10_absteigend()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(new[] { "Spaten|24.90", "Saege|18.00", "Hammer|12.50", "Harke|11.00" },
            Zeilen(db, Skripte.TeureArtikel));
    }

    [Fact]
    public void ArtikelMitKategorie_verknuepft_und_sortiert()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(new[]
        {
            "Buero|Locher",
            "Garten|Giesskanne", "Garten|Handschuhe", "Garten|Harke", "Garten|Spaten",
            "Werkzeug|Hammer", "Werkzeug|Saege", "Werkzeug|Zange"
        }, Zeilen(db, Skripte.ArtikelMitKategorie));
    }

    [Fact]
    public void AnzahlProKategorie_gruppiert_und_filtert_mit_HAVING()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(new[] { "Garten|4", "Werkzeug|3" }, Zeilen(db, Skripte.AnzahlProKategorie));
    }

    [Fact]
    public void Preiserhoehung_erhoeht_nur_die_Kategorie_Garten()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(4, Ausfuehren(db, Skripte.Preiserhoehung));
        Assert.Equal(new[] { "Spaten|27.39", "Harke|12.10", "Giesskanne|8.25", "Handschuhe|6.49" },
            Zeilen(db, "SELECT Name, Preis FROM Artikel WHERE KategorieId = 2 ORDER BY Id"));
        Assert.Equal(new[] { "Hammer|12.50", "Zange|9.90", "Saege|18.00", "Locher|4.20" },
            Zeilen(db, "SELECT Name, Preis FROM Artikel WHERE KategorieId IN (1, 3) ORDER BY Id"));
    }

    [Fact]
    public void LoescheLeereKategorien_entfernt_nur_Kategorien_ohne_Artikel()
    {
        using var db = Oeffne(mitDaten: true);
        Assert.Equal(1, Ausfuehren(db, Skripte.LoescheLeereKategorien));
        Assert.Equal(new[] { "Buero", "Garten", "Werkzeug" }, Zeilen(db, "SELECT Name FROM Kategorie ORDER BY Name"));
        Assert.Equal(8, Zahl(db, "SELECT COUNT(*) FROM Artikel"));
        // zweiter Lauf: nichts mehr zu löschen
        Assert.Equal(0, Ausfuehren(db, Skripte.LoescheLeereKategorien));
    }
}
