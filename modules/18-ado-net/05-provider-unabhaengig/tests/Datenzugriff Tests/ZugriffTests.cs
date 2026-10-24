using System.Data;
using System.Data.Common;
using Datenzugriff;
using Microsoft.Data.Sqlite;

public class ZugriffTests : IDisposable
{
    // Eigenes Temp-Verzeichnis je Test (Leerzeichen, Umlaut und Komma im Namen) mit einer Datenbankdatei.
    private readonly string _ordner =
        Path.Combine(Path.GetTempPath(), $"SeeSharp Datenzugriff Übung, {Guid.NewGuid():N}");
    private readonly string _datei;

    public ZugriffTests()
    {
        Directory.CreateDirectory(_ordner);
        _datei = Path.Combine(_ordner, "Läger, neu.db");
        using var c = new SqliteConnection($"Data Source={_datei}");
        c.Open();
        using var befehl = c.CreateCommand();
        befehl.CommandText = """
            CREATE TABLE Artikel (Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Preis REAL NOT NULL, Gewicht REAL NOT NULL);
            INSERT INTO Artikel (Id, Name, Preis, Gewicht) VALUES
                (1, 'Hammer', 12.5, 1.5),
                (2, 'Zange', 9.9, 0.5),
                (3, 'Spaten', 24.9, 2.25),
                (4, 'Harke', 11, 1.0);
            """;
        befehl.ExecuteNonQuery();
    }

    public void Dispose()
    {
        SqliteConnection.ClearAllPools(); // sonst bleibt die Datei durch gepoolte Verbindungen gesperrt
        Directory.Delete(_ordner, recursive: true);
    }

    private static DbProviderFactory Fabrik => SqliteFactory.Instance;

    private DataTable Tabelle()
    {
        using var verbindung = Zugriff.OeffneVerbindung(Fabrik, $"Data Source={_datei}");
        return Zugriff.LiesTabelle(verbindung, "SELECT Id, Name, Preis, Gewicht FROM Artikel ORDER BY Id");
    }

    [Fact]
    public void Der_Datenzugriffscode_kennt_keinen_Provider()
    {
        var verweise = typeof(Zugriff).Assembly.GetReferencedAssemblies().Select(a => a.Name);
        Assert.DoesNotContain("Microsoft.Data.Sqlite", verweise);
    }

    [Fact]
    public void OeffneVerbindung_liefert_eine_offene_DbConnection_des_Providers()
    {
        using DbConnection verbindung = Zugriff.OeffneVerbindung(Fabrik, $"Data Source={_datei}");
        Assert.Equal(ConnectionState.Open, verbindung.State);
        Assert.IsType<SqliteConnection>(verbindung);
    }

    [Fact]
    public void LiesTabelle_laedt_Zeilen_und_Spalten_in_eine_DataTable()
    {
        DataTable t = Tabelle();
        Assert.Equal(4, t.Rows.Count);
        Assert.Equal(new[] { "Id", "Name", "Preis", "Gewicht" }, t.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
        Assert.Equal("Spaten", t.Rows[2]["Name"]);
        Assert.Equal(24.9, t.Rows[2].Field<double>("Preis"), 6);
    }

    [Fact]
    public void LiesTabelle_mit_Filter_liefert_nur_passende_Zeilen()
    {
        using var verbindung = Zugriff.OeffneVerbindung(Fabrik, $"Data Source={_datei}");
        DataTable t = Zugriff.LiesTabelle(verbindung, "SELECT Name FROM Artikel WHERE Gewicht >= 1 ORDER BY Name");
        Assert.Equal(new[] { "Hammer", "Harke", "Spaten" }, t.Rows.Cast<DataRow>().Select(r => (string)r["Name"]));
    }

    [Fact]
    public void Verbindungsstring_wird_vom_Builder_der_Fabrik_gebaut()
    {
        string s = Zugriff.Verbindungsstring(Fabrik, _datei);
        var pruefung = new SqliteConnectionStringBuilder(s);
        Assert.Equal(_datei, pruefung.DataSource);
        Assert.Equal(SqliteOpenMode.ReadOnly, pruefung.Mode);
    }

    [Fact]
    public void Verbindungsstring_oeffnet_die_Datei_nur_lesend()
    {
        string s = Zugriff.Verbindungsstring(Fabrik, _datei);
        using var verbindung = Zugriff.OeffneVerbindung(Fabrik, s);
        Assert.Equal(4, Zugriff.LiesTabelle(verbindung, "SELECT * FROM Artikel").Rows.Count);
        using var befehl = verbindung.CreateCommand();
        befehl.CommandText = "DELETE FROM Artikel";
        Assert.ThrowsAny<DbException>(() => befehl.ExecuteNonQuery()); // schreibgeschützt geöffnet
    }

    [Fact]
    public void TeureArtikel_filtert_mit_LINQ_to_DataSet()
    {
        var teuer = Zugriff.TeureArtikel(Tabelle());
        Assert.Equal(new[] { "Hammer", "Spaten", "Harke" }, teuer.Select(r => r.Field<string>("Name")));
    }

    [Fact]
    public void Namen_projiziert_die_Spalte_Name()
    {
        Assert.Equal(new[] { "Hammer", "Zange", "Spaten", "Harke" }, Zugriff.Namen(Tabelle()));
    }

    [Fact]
    public void Summe_addiert_eine_Spalte()
    {
        Assert.Equal(5.25, Zugriff.Summe(Tabelle(), "Gewicht"), 6);
    }

    [Fact]
    public void Summe_einer_leeren_Tabelle_ist_null()
    {
        using var verbindung = Zugriff.OeffneVerbindung(Fabrik, $"Data Source={_datei}");
        DataTable leer = Zugriff.LiesTabelle(verbindung, "SELECT Gewicht FROM Artikel WHERE 0");
        Assert.Equal(0.0, Zugriff.Summe(leer, "Gewicht"));
    }
}
