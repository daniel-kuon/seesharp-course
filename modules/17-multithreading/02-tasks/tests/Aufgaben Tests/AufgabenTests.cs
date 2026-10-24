public class AufgabenTests
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(30);   // nur Schutz vor einem Hänger

    // Wartet (mit Zeitgrenze) auf das Ergebnis; ein Hänger wird so zu einem Testfehler statt zu einem Dauerlauf.
    static T Hole<T>(Task<T> task)
    {
        Assert.True(task.Wait(Wartegrenze), "Die Aufgabe wurde nicht rechtzeitig fertig (blockiert oder hängt).");
        return task.Result;
    }

    static TaskCompletionSource<T> NeueQuelle<T>() => new(TaskCreationOptions.RunContinuationsAsynchronously);

    // ---------- SummeParallel

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(1000)]
    public void SummeParallel_summiert_Arrays_jeder_Groesse(int laenge)
    {
        int[] a = Enumerable.Range(1, laenge).ToArray();

        Assert.Equal(a.Sum(x => (long)x), Berechnungen.SummeParallel(a));
    }

    [Fact]
    public void SummeParallel_rechnet_mit_long_und_ueberlaeuft_nicht()
    {
        int[] a = [int.MaxValue, int.MaxValue, int.MaxValue, 1, 1];

        Assert.Equal(3L * int.MaxValue + 2, Berechnungen.SummeParallel(a));
    }

    [Fact]
    public void SummeParallel_summiert_viele_Elemente()
    {
        var zufall = new Random(42);
        int[] a = Enumerable.Range(0, 200_000).Select(_ => zufall.Next(-1000, 1000)).ToArray();

        Assert.Equal(a.Sum(x => (long)x), Berechnungen.SummeParallel(a));
    }

    // ---------- AlleFertig

    [Fact]
    public void AlleFertig_wird_erst_fertig_wenn_alle_fertig_sind_und_sortiert()
    {
        var q1 = NeueQuelle<int>();
        var q2 = NeueQuelle<int>();
        var q3 = NeueQuelle<int>();

        Task<int[]> alle = Berechnungen.AlleFertig([q1.Task, q2.Task, q3.Task]);
        Assert.False(alle.IsCompleted);

        q2.SetResult(1);
        q3.SetResult(3);
        Assert.False(alle.IsCompleted);   // q1 fehlt noch

        q1.SetResult(2);
        Assert.Equal(new[] { 1, 2, 3 }, Hole(alle));
    }

    [Fact]
    public void AlleFertig_mit_leerer_Folge_liefert_ein_leeres_Array()
    {
        Assert.Empty(Hole(Berechnungen.AlleFertig([])));
    }

    // ---------- ErsterFertiger

    [Fact]
    public void ErsterFertiger_nimmt_die_fertige_Aufgabe_auch_wenn_die_andere_nie_fertig_wird()
    {
        Task<string> niemals = NeueQuelle<string>().Task;
        Task<string> fertig = Task.FromResult("fertig");

        // Auf einem eigenen Thread ausgeführt, damit ein blockierender Versuch (z. B. WaitAll) nicht den Test festhält.
        Assert.Equal("fertig", Hole(Task.Run(() => Berechnungen.ErsterFertiger(niemals, fertig))));
        Assert.Equal("fertig", Hole(Task.Run(() => Berechnungen.ErsterFertiger(fertig, niemals))));
    }

    // ---------- Verdopple

    [Fact]
    public void Verdopple_wartet_nicht_und_setzt_nach_dem_Ende_fort()
    {
        var quelle = NeueQuelle<int>();

        Task<int> doppelt = Berechnungen.Verdopple(quelle.Task);
        Assert.False(doppelt.IsCompleted);

        quelle.SetResult(21);
        Assert.Equal(42, Hole(doppelt));
    }

    [Fact]
    public void Verdopple_funktioniert_auch_fuer_eine_schon_fertige_Aufgabe()
    {
        Assert.Equal(-14, Hole(Berechnungen.Verdopple(Task.FromResult(-7))));
    }

    // ---------- WartenAufMesswert

    [Fact]
    public void WartenAufMesswert_ist_erst_nach_dem_Ereignis_fertig()
    {
        var sensor = new Sensor();

        Task<double> messung = Berechnungen.WartenAufMesswert(sensor);
        Assert.False(messung.IsCompleted);

        sensor.Melde(23.5);
        Assert.Equal(23.5, Hole(messung));
    }

    [Fact]
    public void WartenAufMesswert_nimmt_nur_den_ersten_Wert_und_meldet_sich_ab()
    {
        var sensor = new Sensor();
        Task<double> messung = Berechnungen.WartenAufMesswert(sensor);

        sensor.Melde(1.5);
        sensor.Melde(2.5);   // darf keine Ausnahme auslösen

        Assert.Equal(1.5, Hole(messung));
        Assert.Equal(0, sensor.Abonnenten);
    }

    [Fact]
    public void WartenAufMesswert_kann_mehrfach_hintereinander_benutzt_werden()
    {
        var sensor = new Sensor();

        Task<double> erste = Berechnungen.WartenAufMesswert(sensor);
        sensor.Melde(10);
        Task<double> zweite = Berechnungen.WartenAufMesswert(sensor);
        sensor.Melde(20);

        Assert.Equal(10, Hole(erste));
        Assert.Equal(20, Hole(zweite));
    }
}
