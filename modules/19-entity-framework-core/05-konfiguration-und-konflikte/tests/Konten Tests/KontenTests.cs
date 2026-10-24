using Konten;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class KontenTests : IDisposable
{
    private readonly SqliteConnection _verbindung = new("Data Source=:memory:");
    private readonly DbContextOptions<KontoContext> _optionen;
    private readonly Kontodienst _dienst;

    public KontenTests()
    {
        _verbindung.Open();
        _optionen = new DbContextOptionsBuilder<KontoContext>().UseSqlite(_verbindung).Options;
        _dienst = new Kontodienst(_optionen);
    }

    public void Dispose() => _verbindung.Dispose();

    private Konto Lade(int id)
    {
        using var kontext = new KontoContext(_optionen);
        return kontext.Konten.AsNoTracking().Single(k => k.Id == id);
    }

    private object? Roh(string sql)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = sql;
        return befehl.ExecuteScalar();
    }

    // ---------- Wertkonverter ----------

    [Fact]
    public void Status_wird_als_Text_gespeichert()
    {
        int id = _dienst.Anlegen("Anna", 100m, Status.Aktiv);
        Assert.Equal("Aktiv", Roh($"SELECT Status FROM Konten WHERE Id = {id}"));
    }

    [Fact]
    public void Status_wird_beim_Lesen_wieder_zum_Enum()
    {
        int a = _dienst.Anlegen("Anna", 1m, Status.Gesperrt);
        _dienst.Anlegen("Bert", 1m, Status.Aktiv);
        Assert.Equal(Status.Gesperrt, Lade(a).Status);

        using var kontext = new KontoContext(_optionen);
        Assert.Equal(new[] { "Anna" }, kontext.Konten.Where(k => k.Status == Status.Gesperrt).Select(k => k.Inhaber));
    }

    // ---------- Concurrency Token ----------

    [Fact]
    public void Zwei_Kontexte_aendern_dieselbe_Zeile_der_zweite_SaveChanges_scheitert()
    {
        int id = _dienst.Anlegen("Anna", 100m);
        using var a = new KontoContext(_optionen);
        using var b = new KontoContext(_optionen);
        var ka = a.Konten.Find(id)!;
        var kb = b.Konten.Find(id)!;

        ka.Saldo += 10; ka.Version++;
        a.SaveChanges();

        kb.Saldo += 5; kb.Version++;
        Assert.Throws<DbUpdateConcurrencyException>(() => b.SaveChanges());

        Assert.Equal(110m, Lade(id).Saldo); // die Änderung von b ging nicht verloren, sie wurde nie gespeichert
    }

    [Fact]
    public void Konfliktloeser_ohne_Konflikt_speichert_beim_ersten_Versuch()
    {
        int id = _dienst.Anlegen("Anna", 100m);
        using var kontext = new KontoContext(_optionen);
        var konto = kontext.Konten.Find(id)!;

        int versuche = Konfliktloeser.Speichere(kontext, konto, k => k.Saldo += 5);

        Assert.Equal(1, versuche);
        Assert.Equal(105m, Lade(id).Saldo);
        Assert.Equal(2, Lade(id).Version);
    }

    [Fact]
    public void Konfliktloeser_laedt_bei_Konflikt_neu_und_wiederholt_einmal()
    {
        int id = _dienst.Anlegen("Anna", 100m);
        using var a = new KontoContext(_optionen);
        var ka = a.Konten.Find(id)!;

        using (var b = new KontoContext(_optionen)) // jemand anderes ist schneller
        {
            var kb = b.Konten.Find(id)!;
            kb.Saldo += 10;
            kb.Version++;
            b.SaveChanges();
        }

        int versuche = Konfliktloeser.Speichere(a, ka, k => k.Saldo += 5);

        Assert.Equal(2, versuche);
        var gespeichert = Lade(id);
        Assert.Equal(115m, gespeichert.Saldo); // beide Änderungen sind enthalten
        Assert.Equal(3, gespeichert.Version);
    }

    [Fact]
    public void Konfliktloeser_gibt_nach_dem_zweiten_Konflikt_auf()
    {
        int id = _dienst.Anlegen("Anna", 100m);
        using var a = new KontoContext(_optionen);
        var ka = a.Konten.Find(id)!;

        // Bei jedem Anwenden der Änderung schreibt ein anderer Kontext dazwischen: Beide Versuche scheitern.
        void StoerendeAenderung(Konto k)
        {
            using var fremd = new KontoContext(_optionen);
            var f = fremd.Konten.Find(id)!;
            f.Saldo += 1;
            f.Version++;
            fremd.SaveChanges();
            k.Saldo += 5;
        }

        Assert.Throws<DbUpdateConcurrencyException>(() => Konfliktloeser.Speichere(a, ka, StoerendeAenderung));
        Assert.Equal(102m, Lade(id).Saldo); // nur die beiden fremden Änderungen
    }

    // ---------- Transaktion ----------

    [Fact]
    public void Ueberweisung_bucht_um_und_zaehlt_die_Versionen_hoch()
    {
        int von = _dienst.Anlegen("Anna", 100m);
        int nach = _dienst.Anlegen("Bert", 20m);
        _dienst.Ueberweisung(von, nach, 30m);
        Assert.Equal(70m, Lade(von).Saldo);
        Assert.Equal(50m, Lade(nach).Saldo);
        Assert.Equal(2, Lade(von).Version);
        Assert.Equal(2, Lade(nach).Version);
    }

    [Fact]
    public void Ueberweisung_ohne_Guthaben_aendert_nichts()
    {
        int von = _dienst.Anlegen("Anna", 100m);
        int nach = _dienst.Anlegen("Bert", 20m);
        Assert.Throws<InvalidOperationException>(() => _dienst.Ueberweisung(von, nach, 100.01m));
        Assert.Equal(100m, Lade(von).Saldo);
        Assert.Equal(20m, Lade(nach).Saldo);
    }

    [Fact]
    public void Ueberweisung_auf_fehlendes_Konto_nimmt_die_Abbuchung_zurueck()
    {
        int von = _dienst.Anlegen("Anna", 100m);
        // Das Abbuchen ist bereits mit SaveChanges gespeichert, wenn das Zielkonto nicht gefunden wird.
        Assert.Throws<InvalidOperationException>(() => _dienst.Ueberweisung(von, 999, 30m));
        Assert.Equal(100m, Lade(von).Saldo);
        Assert.Equal(1, Lade(von).Version);
    }

    [Fact]
    public void Ueberweisung_von_fehlendem_Konto_wirft()
    {
        int nach = _dienst.Anlegen("Bert", 20m);
        Assert.Throws<InvalidOperationException>(() => _dienst.Ueberweisung(999, nach, 1m));
        Assert.Equal(20m, Lade(nach).Saldo);
    }
}
