public class ParallelPlinqTests
{
    static int[] ZufallsZahlen(int anzahl, int von, int bis)
    {
        var zufall = new Random(2024);   // feste Saat: bei jedem Lauf dieselben Zahlen
        return Enumerable.Range(0, anzahl).Select(_ => zufall.Next(von, bis)).ToArray();
    }

    // ---------- SummeQuadrate (Parallel.For + Interlocked)

    [Fact]
    public void SummeQuadrate_kleine_Beispiele()
    {
        Assert.Equal(0, ParallelRechner.SummeQuadrate([]));
        Assert.Equal(25, ParallelRechner.SummeQuadrate([5]));
        Assert.Equal(14, ParallelRechner.SummeQuadrate([1, 2, 3]));
        Assert.Equal(14, ParallelRechner.SummeQuadrate([-1, -2, -3]));
    }

    [Fact]
    public void SummeQuadrate_verliert_bei_vielen_Elementen_nichts()
    {
        int[] a = ZufallsZahlen(200_000, -1000, 1000);

        Assert.Equal(a.Sum(x => (long)x * x), ParallelRechner.SummeQuadrate(a));
    }

    [Fact]
    public void SummeQuadrate_rechnet_mit_long()
    {
        int[] a = [100_000, 100_000, 100_000];   // jedes Quadrat sprengt schon int (10^10)

        Assert.Equal(30_000_000_000L, ParallelRechner.SummeQuadrate(a));
    }

    // ---------- SammleGerade (Parallel.ForEach + lock)

    [Fact]
    public void SammleGerade_liefert_alle_geraden_Elemente()
    {
        int[] a = [7, 2, 4, 9, 4, 10, 1, 0];

        Assert.Equal(new[] { 0, 2, 4, 4, 10 }, ParallelRechner.SammleGerade(a).OrderBy(x => x));
    }

    [Fact]
    public void SammleGerade_verliert_bei_vielen_Elementen_nichts_und_verdoppelt_nichts()
    {
        int[] a = ZufallsZahlen(300_000, 0, 1_000);

        List<int> parallel = ParallelRechner.SammleGerade(a);

        Assert.Equal(a.Where(x => x % 2 == 0).OrderBy(x => x), parallel.OrderBy(x => x));
    }

    [Fact]
    public void SammleGerade_ohne_gerade_Elemente_ist_leer()
    {
        Assert.Empty(ParallelRechner.SammleGerade([1, 3, 5]));
        Assert.Empty(ParallelRechner.SammleGerade([]));
    }

    // ---------- Gleichzeitig (Parallel.Invoke)

    [Fact]
    public void Gleichzeitig_fuehrt_jede_Aktion_genau_einmal_aus_und_kehrt_erst_danach_zurueck()
    {
        int a = 0, b = 0, c = 0;

        ParallelRechner.Gleichzeitig(
            () => Interlocked.Increment(ref a),
            () => Interlocked.Increment(ref b),
            () => Interlocked.Increment(ref c));

        Assert.Equal((1, 1, 1), (a, b, c));
    }

    // ---------- WiederholeParallel (ParallelOptions)

    // Führt WiederholeParallel mit einem Körper aus, der misst, wie viele Iterationen sich überschneiden.
    static (int Gesamt, int MaxGleichzeitig) Messen(int anzahl, int maxGrad)
    {
        int aktiv = 0, maximum = 0, gesamt = 0;

        ParallelRechner.WiederholeParallel(anzahl, maxGrad, () =>
        {
            int jetzt = Interlocked.Increment(ref aktiv);
            int alt;
            do
            {
                alt = Volatile.Read(ref maximum);
            } while (jetzt > alt && Interlocked.CompareExchange(ref maximum, jetzt, alt) != alt);

            Thread.SpinWait(20_000);   // etwas Arbeit, damit sich Iterationen überlappen können (keine Zeitannahme)

            Interlocked.Decrement(ref aktiv);
            Interlocked.Increment(ref gesamt);
        });

        return (gesamt, maximum);
    }

    [Fact]
    public void WiederholeParallel_fuehrt_den_Koerper_genau_anzahl_Mal_aus()
    {
        Assert.Equal(200, Messen(200, 4).Gesamt);
        Assert.Equal(0, Messen(0, 4).Gesamt);
    }

    [Fact]
    public void WiederholeParallel_mit_Grad_1_laeuft_nacheinander()
    {
        Assert.Equal(1, Messen(100, 1).MaxGleichzeitig);
    }

    [Fact]
    public void WiederholeParallel_haelt_den_Parallelitaetsgrad_ein()
    {
        var (gesamt, maximum) = Messen(300, 2);

        Assert.Equal(300, gesamt);
        Assert.InRange(maximum, 1, 2);
    }

    // ---------- Primzahlen (PLINQ)

    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(5_000)]
    [InlineData(100_000)]
    public void Primzahlen_entsprechen_dem_sequenziellen_Ergebnis_in_derselben_Reihenfolge(int bis)
    {
        List<int> erwartet = Enumerable.Range(2, bis - 1).Where(ParallelRechner.IstPrim).ToList();

        List<int> ergebnis = ParallelRechner.Primzahlen(bis);

        Assert.Equal(erwartet, ergebnis);   // gleiche Elemente UND gleiche Reihenfolge
    }

    [Fact]
    public void Primzahlen_beginnen_mit_2_3_5_7()
    {
        Assert.Equal(new[] { 2, 3, 5, 7 }, ParallelRechner.Primzahlen(10));
        Assert.Equal(new[] { 2 }, ParallelRechner.Primzahlen(2));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-5)]
    public void Primzahlen_unterhalb_von_2_gibt_es_keine(int bis)
    {
        Assert.Empty(ParallelRechner.Primzahlen(bis));
    }
}
