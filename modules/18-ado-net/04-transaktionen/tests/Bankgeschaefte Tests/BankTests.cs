using System.Runtime.CompilerServices;
using Bankgeschaefte;
using Microsoft.Data.Sqlite;

public class BankTests : IDisposable
{
    // Jeder Test hat seine eigene Datenbank im Speicher.
    private readonly SqliteConnection _c = new("Data Source=:memory:");

    public BankTests()
    {
        _c.Open();
        using var befehl = _c.CreateCommand();
        befehl.CommandText = """
            CREATE TABLE Konto (Id INTEGER PRIMARY KEY, Inhaber TEXT NOT NULL, Saldo REAL NOT NULL);
            INSERT INTO Konto (Id, Inhaber, Saldo) VALUES (1, 'Anna', 100), (2, 'Berta', 50), (3, 'Carl', 0);
            """;
        befehl.ExecuteNonQuery();
    }

    public void Dispose() => _c.Dispose();

    private double Saldo(int id)
    {
        using var befehl = _c.CreateCommand();
        befehl.CommandText = "SELECT Saldo FROM Konto WHERE Id = @id";
        befehl.Parameters.AddWithValue("@id", id);
        return Convert.ToDouble(befehl.ExecuteScalar());
    }

    private void AssertSalden(double a, double b, double c)
    {
        Assert.Equal(a, Saldo(1), 2);
        Assert.Equal(b, Saldo(2), 2);
        Assert.Equal(c, Saldo(3), 2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WirfIoFehler() => throw new IOException("Fehler mitten in der Transaktion");

    [Fact]
    public void Ueberweise_bucht_ab_und_schreibt_gut()
    {
        Bank.Ueberweise(_c, 1, 2, 30.5m);
        AssertSalden(69.5, 80.5, 0);
    }

    [Fact]
    public void Ueberweise_erlaubt_genau_das_Guthaben()
    {
        Bank.Ueberweise(_c, 1, 3, 100m);
        AssertSalden(0, 50, 100);
    }

    [Fact]
    public void Ueberweise_ohne_Guthaben_nimmt_alles_zurueck()
    {
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 1, 2, 100.01m));
        AssertSalden(100, 50, 0);
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 3, 1, 1m));
        AssertSalden(100, 50, 0);
    }

    [Fact]
    public void Ueberweise_auf_fehlendes_Zielkonto_stellt_die_Abbuchung_wieder_her()
    {
        // Die Abbuchung ist schon ausgeführt, wenn das Gutschreiben scheitert.
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 1, 99, 10m));
        AssertSalden(100, 50, 0);
    }

    [Fact]
    public void Ueberweise_von_fehlendem_Quellkonto_aendert_nichts()
    {
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 99, 1, 10m));
        AssertSalden(100, 50, 0);
    }

    [Fact]
    public void Ausnahme_in_der_Transaktion_fuehrt_zum_Rollback_und_wird_mit_throw_weitergereicht()
    {
        var ex = Assert.Throws<IOException>(() => Bank.Ueberweise(_c, 1, 2, 40m, nachAbbuchung: WirfIoFehler));
        AssertSalden(100, 50, 0);
        // "throw;" behält den Stack Trace bis zur Stelle, an der die Ausnahme entstand; "throw ex;" würde ihn abschneiden.
        Assert.Contains(nameof(WirfIoFehler), ex.StackTrace);
    }

    [Fact]
    public void Nach_einem_Fehler_ist_die_Verbindung_wieder_frei_fuer_neue_Transaktionen()
    {
        Assert.Throws<InvalidOperationException>(() => Bank.Ueberweise(_c, 1, 99, 10m));
        Assert.Throws<IOException>(() => Bank.Ueberweise(_c, 1, 2, 10m, WirfIoFehler));
        Bank.Ueberweise(_c, 1, 2, 10m); // würde scheitern, wenn noch eine Transaktion offen wäre
        AssertSalden(90, 60, 0);
    }

    [Fact]
    public void Mehrfach_bucht_alle_Ueberweisungen()
    {
        Bank.Mehrfach(_c, new[] { (1, 2, 20m), (2, 3, 70m), (3, 1, 5m) });
        AssertSalden(85, 0, 65);
        Assert.Equal(150, Saldo(1) + Saldo(2) + Saldo(3), 2); // Summe bleibt erhalten
    }

    [Fact]
    public void Mehrfach_ist_alles_oder_nichts_bei_zu_wenig_Guthaben()
    {
        // Die erste Überweisung ist gültig, die zweite überzieht Konto 3.
        Assert.Throws<InvalidOperationException>(() =>
            Bank.Mehrfach(_c, new[] { (1, 3, 40m), (3, 2, 41m) }));
        AssertSalden(100, 50, 0);
    }

    [Fact]
    public void Mehrfach_ist_alles_oder_nichts_bei_fehlendem_Konto()
    {
        Assert.Throws<InvalidOperationException>(() =>
            Bank.Mehrfach(_c, new[] { (1, 2, 10m), (2, 3, 10m), (1, 42, 10m) }));
        AssertSalden(100, 50, 0);
    }

    [Fact]
    public void Mehrfach_ohne_Ueberweisungen_aendert_nichts()
    {
        Bank.Mehrfach(_c, Array.Empty<(int, int, decimal)>());
        AssertSalden(100, 50, 0);
    }
}
