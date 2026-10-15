public class GleitkommaTests
{
    [Fact]
    public void Double_Summe_ist_nicht_0_3() => Assert.NotEqual(0.3, Gleitkomma.SummeDouble());

    [Fact]
    public void Decimal_Summe_ist_0_3() => Assert.Equal(0.3m, Gleitkomma.SummeDecimal());

    [Fact]
    public void Eins_plus_2_hoch_minus_52_ist_groesser_als_eins() => Assert.True(Gleitkomma.EinsPlusZweiHochMinus(52) > 1.0);

    [Fact]
    public void Eins_plus_2_hoch_minus_53_ist_eins() => Assert.Equal(1.0, Gleitkomma.EinsPlusZweiHochMinus(53));

    [Fact]
    public void Ungefaehr_gleich_mit_Toleranz() => Assert.True(Gleitkomma.IstUngefaehrGleich(0.1 + 0.2, 0.3, 1e-9));

    [Fact]
    public void Ungefaehr_gleich_erkennt_Unterschied() => Assert.False(Gleitkomma.IstUngefaehrGleich(1.0, 1.1, 1e-9));

    [Fact]
    public void Kaufmaennisch_runden()
    {
        Assert.Equal(2.35m, Gleitkomma.RundeKaufmaennisch(2.345m));
        Assert.Equal(2.34m, Gleitkomma.RundeKaufmaennisch(2.344m));
    }
}
