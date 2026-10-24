using System.Globalization;
using Bestellauswertung;
using Microsoft.Data.Sqlite;

public class AuswertungenTests : IDisposable
{
    private readonly SqliteConnection _c = new("Data Source=:memory:");

    public AuswertungenTests()
    {
        _c.Open();
        using var befehl = _c.CreateCommand();
        befehl.CommandText = """
            CREATE TABLE Kunde (Id INTEGER PRIMARY KEY, Name TEXT NOT NULL);
            CREATE TABLE Bestellung (Id INTEGER PRIMARY KEY, KundeId INTEGER NOT NULL REFERENCES Kunde (Id), Datum TEXT NOT NULL);
            CREATE TABLE Position (Id INTEGER PRIMARY KEY, BestellungId INTEGER NOT NULL REFERENCES Bestellung (Id),
                                   Produkt TEXT NOT NULL, Menge INTEGER NOT NULL, Preis REAL NOT NULL);
            INSERT INTO Kunde (Id, Name) VALUES (1, 'Anna'), (2, 'Berta'), (3, 'Carl'), (4, 'Dora');
            INSERT INTO Bestellung (Id, KundeId, Datum) VALUES (1, 1, '2025-01-10'), (2, 1, '2025-02-03'), (3, 2, '2025-02-04');
            INSERT INTO Position (Id, BestellungId, Produkt, Menge, Preis) VALUES
                (1, 1, 'Hammer', 2, 12.50),
                (2, 1, 'Zange',  1,  9.90),
                (3, 2, 'Hammer', 3, 12.50),
                (4, 2, 'Spaten', 1, 24.90),
                (5, 3, 'Harke',  5, 11.00),
                (6, 3, 'Zange',  3,  9.90);
            """;
        befehl.ExecuteNonQuery();
    }

    public void Dispose() => _c.Dispose();

    private List<string> Zeilen(string sql)
    {
        using var befehl = _c.CreateCommand();
        befehl.CommandText = sql;
        using var leser = befehl.ExecuteReader();
        var ergebnis = new List<string>();
        while (leser.Read())
        {
            var teile = new string[leser.FieldCount];
            for (int i = 0; i < teile.Length; i++)
                teile[i] = leser.GetValue(i) is double d
                    ? d.ToString("0.00", CultureInfo.InvariantCulture)
                    : Convert.ToString(leser.GetValue(i), CultureInfo.InvariantCulture)!;
            ergebnis.Add(string.Join("|", teile));
        }
        return ergebnis;
    }

    [Fact]
    public void UmsatzProKunde_summiert_Menge_mal_Preis_und_sortiert_absteigend()
    {
        // Anna: 2*12.50 + 9.90 + 3*12.50 + 24.90 = 97.30; Berta: 5*11.00 + 3*9.90 = 84.70
        Assert.Equal(new[] { "Anna|97.30", "Berta|84.70" }, Zeilen(Auswertungen.UmsatzProKunde));
    }

    [Fact]
    public void KundenOhneBestellung_findet_Carl_und_Dora()
    {
        Assert.Equal(new[] { "Carl", "Dora" }, Zeilen(Auswertungen.KundenOhneBestellung));
    }

    [Fact]
    public void KundenOhneBestellung_aendert_sich_mit_neuen_Bestellungen()
    {
        using (var befehl = _c.CreateCommand())
        {
            befehl.CommandText = "INSERT INTO Bestellung (Id, KundeId, Datum) VALUES (9, 3, '2025-03-01')";
            befehl.ExecuteNonQuery();
        }
        Assert.Equal(new[] { "Dora" }, Zeilen(Auswertungen.KundenOhneBestellung));
    }

    [Fact]
    public void Top3Produkte_liefert_die_drei_meistbestellten_Produkte()
    {
        // Hammer 5, Harke 5 (Gleichstand: nach Name), Zange 4, Spaten 1
        Assert.Equal(new[] { "Hammer|5", "Harke|5", "Zange|4" }, Zeilen(Auswertungen.Top3Produkte));
    }
}
