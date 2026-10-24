using Kontakte;
using Microsoft.Data.Sqlite;

public class AdressbuchTests : IDisposable
{
    // Jeder Test bekommt eine eigene Datenbank im Speicher und ein eigenes Temp-Verzeichnis
    // (mit Leerzeichen, Umlaut und Komma im Namen).
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly string _ordner =
        Path.Combine(Path.GetTempPath(), $"SeeSharp Ädressbuch, {Guid.NewGuid():N}");

    public AdressbuchTests()
    {
        _verbindung.Open();
        Directory.CreateDirectory(_ordner);
    }

    public void Dispose()
    {
        _verbindung.Dispose();
        SqliteConnection.ClearAllPools(); // gepoolte Dateiverbindungen freigeben, sonst bleibt die Datei gesperrt
        if (Directory.Exists(_ordner)) Directory.Delete(_ordner, recursive: true);
    }

    private Adressbuch NeuesAdressbuch()
    {
        var buch = new Adressbuch(_verbindung);
        buch.Erzeuge();
        return buch;
    }

    private long Zahl(string sql)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = sql;
        return Convert.ToInt64(befehl.ExecuteScalar());
    }

    [Fact]
    public void Erzeuge_legt_die_Tabelle_an_und_ist_wiederholbar()
    {
        var buch = new Adressbuch(_verbindung);
        buch.Erzeuge();
        buch.Erzeuge();
        Assert.Equal(1, Zahl("SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'Kontakt'"));
        Assert.Equal(0, buch.Anzahl());
    }

    [Fact]
    public void Hinzufuegen_und_Anzahl_zaehlen_die_Kontakte()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "0711 123");
        buch.Hinzufuegen("Berta", "0711 456");
        buch.Hinzufuegen("Carl", null);
        Assert.Equal(3L, buch.Anzahl());
    }

    [Fact]
    public void Telefon_liefert_die_gespeicherte_Nummer()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "0711 123");
        Assert.Equal("0711 123", buch.Telefon("Anna"));
    }

    [Fact]
    public void Fehlende_Nummer_wird_als_NULL_gespeichert_und_als_null_gelesen()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Carl", null);
        Assert.Equal(1, Zahl("SELECT COUNT(*) FROM Kontakt WHERE Telefon IS NULL"));
        Assert.Null(buch.Telefon("Carl"));
    }

    [Fact]
    public void Telefon_eines_unbekannten_Kontakts_ist_null()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "1");
        Assert.Null(buch.Telefon("Nobody"));
    }

    [Fact]
    public void Aendere_liefert_die_Zahl_der_geaenderten_Zeilen()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "1");
        buch.Hinzufuegen("Anna", "2");
        buch.Hinzufuegen("Berta", "3");
        Assert.Equal(2, buch.Aendere("Anna", "999"));
        Assert.Equal(0, buch.Aendere("Nobody", "999"));
        Assert.Equal("999", buch.Telefon("Anna"));
        Assert.Equal("3", buch.Telefon("Berta"));
        Assert.Equal(1, buch.Aendere("Berta", null));
        Assert.Null(buch.Telefon("Berta"));
    }

    [Fact]
    public void Entferne_liefert_die_Zahl_der_geloeschten_Zeilen()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "1");
        buch.Hinzufuegen("Anna", "2");
        buch.Hinzufuegen("Berta", "3");
        Assert.Equal(2, buch.Entferne("Anna"));
        Assert.Equal(0, buch.Entferne("Anna"));
        Assert.Equal(1L, buch.Anzahl());
    }

    [Fact]
    public void Hinzufuegen_ist_gegen_SQL_Injection_sicher()
    {
        var buch = NeuesAdressbuch();
        const string boese = "Robert'); DROP TABLE Kontakt;--";
        buch.Hinzufuegen(boese, "1");
        buch.Hinzufuegen("O'Brien", "2");

        Assert.Equal(2L, buch.Anzahl()); // Tabelle gibt es noch
        Assert.Equal("1", buch.Telefon(boese));
        Assert.Equal("2", buch.Telefon("O'Brien"));
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "SELECT Name FROM Kontakt ORDER BY Id LIMIT 1";
        Assert.Equal(boese, (string?)befehl.ExecuteScalar()); // wörtlich gespeichert
    }

    [Fact]
    public void Aendere_und_Entferne_sind_gegen_SQL_Injection_sicher()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "1");
        buch.Hinzufuegen("Berta", "2");
        Assert.Equal(0, buch.Entferne("x' OR '1'='1"));
        Assert.Equal(0, buch.Aendere("x' OR '1'='1", "0"));
        Assert.Equal(2L, buch.Anzahl());
    }

    [Fact]
    public void Adressbuch_schliesst_die_Verbindung_des_Aufrufers_nicht()
    {
        var buch = NeuesAdressbuch();
        buch.Hinzufuegen("Anna", "1");
        buch.Telefon("Anna");
        buch.Entferne("Anna");
        Assert.Equal(System.Data.ConnectionState.Open, _verbindung.State);
    }

    [Fact]
    public void ZaehleInDatei_oeffnet_eine_eigene_Verbindung_zu_einem_Pfad_mit_Sonderzeichen()
    {
        string datei = Path.Combine(_ordner, "Büro Adressen, Stand 1.db");
        using (var eigene = new SqliteConnection($"Data Source={datei}"))
        {
            eigene.Open();
            var buch = new Adressbuch(eigene);
            buch.Erzeuge();
            buch.Hinzufuegen("Anna", "1");
            buch.Hinzufuegen("Berta", null);
        }

        Assert.Equal(2, Adressbuch.ZaehleInDatei(datei));
        Assert.Equal(2, Adressbuch.ZaehleInDatei(datei)); // wiederholbar: keine offene Sperre
    }
}
