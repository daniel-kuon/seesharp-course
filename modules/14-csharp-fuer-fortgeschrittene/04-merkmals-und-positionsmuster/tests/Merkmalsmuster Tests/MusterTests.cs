using Merkmalsmuster;

public class MusterTests
{
    [Theory]
    [InlineData(1, false, false)]
    [InlineData(2, false, false)]
    [InlineData(3, false, true)]
    [InlineData(5, false, true)]
    [InlineData(1, true, true)]
    [InlineData(0, true, true)]
    public void Zugelassen_bei_drei_Passagieren_oder_Elektro(int passagiere, bool elektro, bool erwartet)
    {
        Assert.Equal(erwartet, Muster.Zugelassen(new PKW(passagiere, elektro)));
    }

    [Fact]
    public void Zugelassen_null_ist_false()
    {
        Assert.False(Muster.Zugelassen(null));
    }

    [Fact]
    public void Gebuehr_Elektro_aus_Deutschland_ist_frei()
    {
        Assert.Equal(0, Muster.Gebuehr(new Fahrzeug(new Halter("DE"), true, 2020), 2026));
        Assert.Equal(0, Muster.Gebuehr(new Fahrzeug(new Halter("DE"), true, 1990), 2026));
    }

    [Fact]
    public void Gebuehr_Deutschland_kostet_20_und_ab_ueber_20_Jahren_40()
    {
        Assert.Equal(20, Muster.Gebuehr(new Fahrzeug(new Halter("DE"), false, 2020), 2026));
        Assert.Equal(20, Muster.Gebuehr(new Fahrzeug(new Halter("DE"), false, 2006), 2026)); // genau 20 Jahre
        Assert.Equal(40, Muster.Gebuehr(new Fahrzeug(new Halter("DE"), false, 2005), 2026)); // 21 Jahre
    }

    [Fact]
    public void Gebuehr_andere_Laender_und_fehlender_Halter_kosten_50()
    {
        Assert.Equal(50, Muster.Gebuehr(new Fahrzeug(new Halter("FR"), true, 2020), 2026));
        Assert.Equal(50, Muster.Gebuehr(new Fahrzeug(new Halter("AT"), false, 1980), 2026));
        Assert.Equal(50, Muster.Gebuehr(new Fahrzeug(null, true, 2020), 2026));
    }

    [Theory]
    [InlineData(0, 0, "Ursprung")]
    [InlineData(3, 4, "I")]
    [InlineData(-3, 4, "II")]
    [InlineData(-3, -4, "III")]
    [InlineData(3, -4, "IV")]
    [InlineData(0, 5, "Achse")]
    [InlineData(-5, 0, "Achse")]
    public void Quadrant_nach_Positionsmuster(int x, int y, string erwartet)
    {
        Assert.Equal(erwartet, Muster.Quadrant(new Punkt(x, y)));
    }

    [Fact]
    public void Beschreibe_erkennt_die_Diagonale_mit_var_Muster()
    {
        Assert.Equal("Diagonale 3", Muster.Beschreibe(new Punkt(3, 3)));
        Assert.Equal("Diagonale -1", Muster.Beschreibe(new Punkt(-1, -1)));
        Assert.Equal("(2|5)", Muster.Beschreibe(new Punkt(2, 5)));
    }

    [Fact]
    public void AufYAchse_behandelt_null()
    {
        Assert.False(Muster.AufYAchse(null));
        Assert.True(Muster.AufYAchse(new Punkt(0, 7)));
        Assert.False(Muster.AufYAchse(new Punkt(1, 7)));
    }
}
