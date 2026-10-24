public class SynchronisationTests
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(60);   // nur Schutz vor Hängern

    // Startet 8 Threads, die gleichzeitig je 100000 Mal erhöhen. Ausnahmen aus den Threads werden
    // eingesammelt und im Testthread erneut geworfen (ein unbehandelter Fehler im Thread würde den Testlauf beenden).
    static int Lauf(IZaehler zaehler)
    {
        const int Threads = 8, Schritte = 100_000;
        var start = new Barrier(Threads);
        Exception? fehler = null;

        var arbeiter = Enumerable.Range(0, Threads).Select(_ => new Thread(() =>
        {
            try
            {
                start.SignalAndWait();   // alle fangen im selben Moment an: maximale Überschneidung
                for (int i = 0; i < Schritte; i++)
                    zaehler.Erhoehe();
            }
            catch (Exception ex)
            {
                fehler = ex;
            }
        })).ToList();

        arbeiter.ForEach(t => t.Start());
        foreach (Thread t in arbeiter)
            Assert.True(t.Join(Wartegrenze), "Thread wurde nicht fertig");

        if (fehler != null)
            throw fehler;
        return zaehler.Wert;
    }

    // ---------- Zähler

    [Fact]
    public void SichererZaehler_verliert_keine_Updates()
    {
        Assert.Equal(800_000, Lauf(new SichererZaehler()));
    }

    [Fact]
    public void AtomarerZaehler_verliert_keine_Updates()
    {
        Assert.Equal(800_000, Lauf(new AtomarerZaehler()));
    }

    [Fact]
    public void Zaehler_beginnen_bei_null_und_zaehlen_einzeln()
    {
        foreach (IZaehler z in new IZaehler[] { new SichererZaehler(), new AtomarerZaehler() })
        {
            Assert.Equal(0, z.Wert);
            z.Erhoehe();
            z.Erhoehe();
            Assert.Equal(2, z.Wert);
        }
    }

    // ---------- Parallelrechner

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(8)]
    public void Quadrate_liefert_alle_Quadrate_in_der_richtigen_Reihenfolge(int threads)
    {
        int[] eingabe = Enumerable.Range(-5, 40).ToArray();   // 40 Elemente, nicht durch 3 teilbar

        int[] ergebnis = Parallelrechner.Quadrate(eingabe, threads);

        Assert.Equal(eingabe.Select(x => x * x), ergebnis);
    }

    [Theory]
    [InlineData(0, 4)]
    [InlineData(1, 4)]
    [InlineData(5, 8)]    // mehr Threads als Elemente
    [InlineData(7, 3)]    // ungerade Größe
    public void Quadrate_funktioniert_auch_fuer_leere_kleine_und_ungerade_Arrays(int laenge, int threads)
    {
        int[] eingabe = Enumerable.Range(1, laenge).ToArray();

        Assert.Equal(eingabe.Select(x => x * x), Parallelrechner.Quadrate(eingabe, threads));
    }

    [Fact]
    public void Quadrate_veraendert_die_Eingabe_nicht()
    {
        int[] eingabe = [1, 2, 3];
        _ = Parallelrechner.Quadrate(eingabe, 2);
        Assert.Equal(new[] { 1, 2, 3 }, eingabe);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Weniger_als_ein_Thread_ist_ein_Fehler(int threads)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Parallelrechner.Quadrate([1, 2, 3], threads));
    }

    [Fact]
    public void Die_Bloecke_laufen_wirklich_gleichzeitig_auf_eigenen_Threads()
    {
        // 3 Elemente, 3 Threads: Jedes f wartet am Treffpunkt auf die beiden anderen. Das gelingt nur, wenn
        // alle drei Threads gleichzeitig laufen. Wer die Threads nacheinander startet und jeweils sofort
        // mit Join() wartet, läuft in die Zeitüberschreitung.
        using var treffpunkt = new Barrier(3);
        int verpasst = 0;
        var threadIds = new System.Collections.Concurrent.ConcurrentBag<int>();

        int[] ergebnis = Parallelrechner.Berechne([1, 2, 3], 3, x =>
        {
            threadIds.Add(Environment.CurrentManagedThreadId);
            if (!treffpunkt.SignalAndWait(TimeSpan.FromSeconds(10)))
                Interlocked.Increment(ref verpasst);
            return x * 10;
        });

        Assert.Equal(0, verpasst);
        Assert.Equal(new[] { 10, 20, 30 }, ergebnis);
        Assert.Equal(3, threadIds.Distinct().Count());
        Assert.DoesNotContain(Environment.CurrentManagedThreadId, threadIds);
    }
}
