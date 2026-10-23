using System.Numerics;

public class StatistikTests
{
    [Fact]
    public void Alle_Methoden_sind_auf_INumber_eingeschraenkt()
    {
        foreach (var m in typeof(Statistik).GetMethods().Where(m => m.IsStatic && m.IsGenericMethodDefinition))
        {
            var t = m.GetGenericArguments()[0];
            Assert.True(t.GetGenericParameterConstraints().Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(INumber<>)),
                $"{m.Name} braucht where T : INumber<T>");
        }
    }

    [Fact]
    public void Summe_fuer_verschiedene_Zahltypen()
    {
        Assert.Equal(6, Statistik.Summe(1, 2, 3));
        Assert.Equal(4.0, Statistik.Summe(1.5, 2.5));
        Assert.Equal(0.3m, Statistik.Summe(0.1m, 0.2m));
        Assert.Equal(0L, Statistik.Summe<long>());
    }

    [Fact]
    public void SummeGeprueft_erkennt_Ueberlauf()
    {
        Assert.Equal(int.MinValue, Statistik.Summe(int.MaxValue, 1));   // ungeprüft: schlägt um
        Assert.Throws<OverflowException>(() => Statistik.SummeGeprueft(int.MaxValue, 1));
        Assert.Throws<OverflowException>(() => Statistik.SummeGeprueft<byte>(200, 100));
        Assert.Equal(6, Statistik.SummeGeprueft(1, 2, 3));
    }

    [Fact]
    public void Produkt_beginnt_bei_Eins()
    {
        Assert.Equal(24, Statistik.Produkt(2, 3, 4));
        Assert.Equal(2.0, Statistik.Produkt(0.5, 4.0));
        Assert.Equal(1, Statistik.Produkt<int>());
    }

    [Fact]
    public void Mittelwert_teilt_im_Zahltyp()
    {
        Assert.Equal(1, Statistik.Mittelwert(1, 2));
        Assert.Equal(1.5, Statistik.Mittelwert(1.0, 2.0));
        Assert.Equal(1.5m, Statistik.Mittelwert(1m, 2m));
        Assert.Equal(5L, Statistik.Mittelwert(5L));
    }

    [Fact]
    public void Minimum_Maximum_und_Spannweite()
    {
        Assert.Equal(-2, Statistik.Minimum(3, -2, 7));
        Assert.Equal(7, Statistik.Maximum(3, -2, 7));
        Assert.Equal(9, Statistik.Spannweite(3, -2, 7));
        Assert.Equal(15.49m, Statistik.Spannweite(19.99m, 4.50m, 10m));
        Assert.Equal(0.0, Statistik.Spannweite(2.5));
    }

    [Fact]
    public void Leere_Serie_wirft_wo_es_kein_Ergebnis_gibt()
    {
        Assert.Throws<ArgumentException>(() => Statistik.Mittelwert<int>());
        Assert.Throws<ArgumentException>(() => Statistik.Minimum<double>());
        Assert.Throws<ArgumentException>(() => Statistik.Maximum<decimal>());
        Assert.Throws<ArgumentException>(() => Statistik.Spannweite<int>());
    }
}
