public class ParalleleSummeTests
{
    // 100000 Zufallszahlen zwischen 0 und 99 mit fester Saat: jeder Lauf dieselben Daten.
    static readonly int[] Daten = MacheDaten();

    static int[] MacheDaten()
    {
        var zufall = new Random(12345);
        return Enumerable.Range(0, 100_000).Select(_ => zufall.Next(0, 100)).ToArray();
    }

    // ---------- Summe

    [Fact]
    public void Summe_entspricht_der_sequenziellen_Summe()
    {
        Assert.Equal(Daten.Sum(x => (long)x), Statistik.Summe(Daten));
    }

    [Fact]
    public void Summe_kleiner_und_leerer_Arrays_und_langer_Zahlen()
    {
        Assert.Equal(0, Statistik.Summe([]));
        Assert.Equal(6, Statistik.Summe([1, 2, 3]));
        Assert.Equal(3L * int.MaxValue, Statistik.Summe([int.MaxValue, int.MaxValue, int.MaxValue]));
    }

    // ---------- Maximum

    [Fact]
    public void Maximum_entspricht_dem_sequenziellen_Maximum()
    {
        Assert.Equal(Daten.Max(), Statistik.Maximum(Daten));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(7)]
    public void Maximum_findet_den_Wert_in_jedem_Abschnitt_auch_bei_kurzen_Arrays(int laenge)
    {
        for (int position = 0; position < laenge; position++)
        {
            int[] a = new int[laenge];
            Array.Fill(a, -5);
            a[position] = 42;   // das Maximum steht einmal an jeder Stelle

            Assert.Equal(42, Statistik.Maximum(a));
        }
    }

    [Fact]
    public void Maximum_negativer_Zahlen()
    {
        Assert.Equal(-3, Statistik.Maximum([-10, -3, -7, -20]));
    }

    [Fact]
    public void Maximum_eines_leeren_Arrays_ist_ein_Fehler()
    {
        Assert.Throws<InvalidOperationException>(() => Statistik.Maximum([]));
    }

    // ---------- Histogramm

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(10)]
    [InlineData(100)]
    public void Histogramm_entspricht_dem_sequenziellen_Ergebnis(int klassen)
    {
        int[] erwartet = new int[klassen];
        foreach (int w in Daten)
            erwartet[w * klassen / 100]++;

        int[] ergebnis = Statistik.Histogramm(Daten, klassen);

        Assert.Equal(erwartet, ergebnis);
        Assert.Equal(Daten.Length, ergebnis.Sum());
    }

    [Fact]
    public void Histogramm_kleines_Beispiel()
    {
        Assert.Equal(new[] { 3, 1, 0, 2, 1 }, Statistik.Histogramm([0, 5, 19, 20, 60, 61, 99], 5));
        Assert.Equal(new[] { 0, 0 }, Statistik.Histogramm([], 2));
    }

    [Fact]
    public void Histogramm_verlangt_mindestens_eine_Klasse()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Statistik.Histogramm([1, 2], 0));
    }
}
