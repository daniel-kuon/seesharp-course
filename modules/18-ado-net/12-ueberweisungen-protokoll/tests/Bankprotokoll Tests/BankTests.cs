using Bankprotokoll;
using Microsoft.Data.Sqlite;

public class BankTests : IDisposable
{
    private readonly SqliteConnection _c = new("Data Source=:memory:");

    public BankTests()
    {
        _c.Open();
        Ausfuehren("""
            CREATE TABLE Konto (Id INTEGER PRIMARY KEY, Inhaber TEXT NOT NULL, Saldo REAL NOT NULL);
            CREATE TABLE Protokoll (Id INTEGER PRIMARY KEY, Von INTEGER NOT NULL, Nach INTEGER NOT NULL,
                                    Betrag REAL NOT NULL CHECK (Betrag <= 1000));
            INSERT INTO Konto (Id, Inhaber, Saldo) VALUES (1, 'Anna', 5000), (2, 'Berta', 50);
            """);
    }

    public void Dispose() => _c.Dispose();

    private void Ausfuehren(string sql)
    {
        using var befehl = _c.CreateCommand();
        befehl.CommandText = sql;
        befehl.ExecuteNonQuery();
    }

    private double Saldo(int id)
    {
        using var befehl = _c.CreateCommand();
        befehl.CommandText = $"SELECT Saldo FROM Konto WHERE Id = {id}";
        return Convert.ToDouble(befehl.ExecuteScalar());
    }

    [Fact]
    public void Erfolgreiche_Ueberweisung_wird_gebucht_und_protokolliert()
    {
        Bank.Ueberweise(_c, 1, 2, 200m);
        Assert.Equal(4800, Saldo(1), 2);
        Assert.Equal(250, Saldo(2), 2);
        Assert.Equal(new[] { (1, 2, 200m) }, Bank.Protokoll(_c));
    }

    [Fact]
    public void Mehrere_Ueberweisungen_werden_in_Reihenfolge_protokolliert()
    {
        Bank.Ueberweise(_c, 1, 2, 10m);
        Bank.Ueberweise(_c, 2, 1, 5m);
        Assert.Equal(new[] { (1, 2, 10m), (2, 1, 5m) }, Bank.Protokoll(_c));
    }

    [Fact]
    public void Ueberweisung_ohne_Guthaben_hinterlaesst_keine_Protokollzeile()
    {
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 2, 1, 80m));
        Assert.Equal(50, Saldo(2), 2);
        Assert.Equal(5000, Saldo(1), 2);
        Assert.Empty(Bank.Protokoll(_c));
    }

    [Fact]
    public void Ueberweisung_an_fehlendes_Konto_stellt_die_Abbuchung_wieder_her()
    {
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 1, 99, 100m));
        Assert.Equal(5000, Saldo(1), 2);
        Assert.Empty(Bank.Protokoll(_c));
    }

    [Fact]
    public void Scheitert_das_Protokollieren_wird_auch_die_Buchung_zurueckgenommen()
    {
        // Betrag 2000 verletzt die CHECK-Regel der Protokolltabelle (<= 1000): Abbuchen und Gutschreiben
        // sind da schon ausgeführt und müssen mit zurückgerollt werden.
        Assert.Throws<SqliteException>(() => Bank.Ueberweise(_c, 1, 2, 2000m));
        Assert.Equal(5000, Saldo(1), 2);
        Assert.Equal(50, Saldo(2), 2);
        Assert.Empty(Bank.Protokoll(_c));
    }

    [Fact]
    public void Nach_einem_Fehler_funktionieren_weitere_Ueberweisungen()
    {
        Assert.Throws<SqliteException>(() => Bank.Ueberweise(_c, 1, 2, 2000m));
        Bank.Ueberweise(_c, 1, 2, 100m);
        Assert.Equal(4900, Saldo(1), 2);
        Assert.Single(Bank.Protokoll(_c));
    }
}
