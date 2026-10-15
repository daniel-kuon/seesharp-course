public class EnumsTupelTests
{
    [Fact]
    public void Enum_hat_die_vier_Temperamente_in_dieser_Reihenfolge()
    {
        Assert.Equal(["Cholerisch", "Melancholisch", "Sanguinisch", "Phlegmatisch"], Enum.GetNames<Temperament>());
        Assert.Equal(2, Analyse.Wert(Temperament.Sanguinisch));
    }

    [Fact]
    public void Setter_ignoriert_undefinierte_Werte()
    {
        var otto = new Person("Otto", "Hummer", 35, Temperament.Sanguinisch);

        otto.Temp = (Temperament)13;

        Assert.Equal(Temperament.Sanguinisch, otto.Temp);

        otto.Temp = Temperament.Phlegmatisch;
        Assert.Equal(Temperament.Phlegmatisch, otto.Temp);
    }

    [Fact]
    public void ParseTemperament_ignoriert_die_Schreibweise()
    {
        Assert.Equal(Temperament.Melancholisch, Analyse.ParseTemperament("melancholisch"));
        Assert.Equal("Cholerisch", Analyse.ParseTemperament("CHOLERISCH").ToString());
        Assert.Throws<ArgumentException>(() => Analyse.ParseTemperament("Lustig"));
        Assert.Throws<ArgumentException>(() => Analyse.ParseTemperament("7"));
    }

    [Fact]
    public void AnalyzeName_liefert_ein_benanntes_Tupel()
    {
        var an = Analyse.AnalyzeName("Otto Rentner");

        Assert.Equal("Otto", an.First);
        Assert.Equal("Rentner", an.Last);
        Assert.True(an.FirstPalin);
        Assert.True(an.LastPalin); // R-e-n-t-n-e-R

        var mm = Analyse.AnalyzeName("Anna Meier");
        Assert.True(mm.FirstPalin);
        Assert.False(mm.LastPalin);
    }

    [Fact]
    public void AnalyzeName_laesst_sich_dekonstruieren()
    {
        var (_, last, _, lastPal) = Analyse.AnalyzeName("Anna Retter");

        Assert.Equal("Retter", last);
        Assert.True(lastPal);
    }

    [Fact]
    public void Person_laesst_sich_in_Vorname_und_Name_dekonstruieren()
    {
        var p = new Person("Ursula", "Meyer", 40, Temperament.Cholerisch);

        var (vn, nn) = p;

        Assert.Equal(("Ursula", "Meyer"), (vn, nn));
    }
}
