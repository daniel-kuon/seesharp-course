using System.Text;

public class FabrikTests
{
    [Fact]
    public void KleinerGleich_erzeugt_passende_Praedikate()
    {
        Predicate<int> bis3 = Fabrik.KleinerGleich(3);
        Predicate<int> bis7 = Fabrik.KleinerGleich(7);
        var werte = new List<int> { 1, 3, 4, 7, 9 };

        Assert.Equal([1, 3], werte.FindAll(bis3));
        Assert.Equal([1, 3, 4, 7], werte.FindAll(bis7));
        Assert.True(bis3(3));
        Assert.False(bis3(4));
    }

    [Fact]
    public void Zaehler_zaehlt_ab_eins()
    {
        Func<int> z = Fabrik.Zaehler();

        Assert.Equal(1, z());
        Assert.Equal(2, z());
        Assert.Equal(3, z());
    }

    [Fact]
    public void Zaehler_haben_getrennten_Zustand()
    {
        Func<int> a = Fabrik.Zaehler();
        Func<int> b = Fabrik.Zaehler();

        a(); a(); a();

        Assert.Equal(1, b());
        Assert.Equal(4, a());
    }

    [Fact]
    public void Addierer_addiert()
    {
        Assert.Equal(15, Fabrik.Addierer(5)(10));
        Assert.Equal(7, Fabrik.Addierer(-3)(10));
    }

    [Fact]
    public void Komponiere_wendet_erst_f_dann_g_an()
    {
        var f = Fabrik.Komponiere(x => x + 1, x => x * 2);
        var g = Fabrik.Komponiere(x => x * 2, x => x + 1);

        Assert.Equal(8, f(3));   // (3 + 1) * 2
        Assert.Equal(7, g(3));   // 3 * 2 + 1
    }

    [Fact]
    public void FuehreAus_ruft_alle_Aktionen_auf()
    {
        var log = new List<string>();
        var aktionen = new List<Action> { () => log.Add("a"), () => log.Add("b"), () => log.Add("c") };

        Fabrik.FuehreAus(aktionen);

        Assert.Equal(["a", "b", "c"], log);
    }

    [Fact]
    public void Aktionen_fangen_ihren_eigenen_Index_ein()
    {
        var sb = new StringBuilder();

        var aktionen = Fabrik.ErzeugeAktionen(sb, 4);
        Assert.Equal(4, aktionen.Count);
        Assert.Equal("", sb.ToString());   // erzeugen führt nichts aus

        for (int i = aktionen.Count - 1; i >= 0; i--)
            aktionen[i]();

        Assert.Equal("3210", sb.ToString());
    }

    [Fact]
    public void Merke_ruft_f_pro_Argument_einmal_auf()
    {
        int aufrufe = 0;
        Func<int, int> teuer = x => { aufrufe++; return x * x; };
        Func<int, int> schnell = Fabrik.Merke(teuer);

        Assert.Equal(0, aufrufe);
        Assert.Equal(25, schnell(5));
        Assert.Equal(25, schnell(5));
        Assert.Equal(9, schnell(3));
        Assert.Equal(25, schnell(5));
        Assert.Equal(2, aufrufe);
    }
}
