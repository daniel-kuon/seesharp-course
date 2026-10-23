public class SpielfeldTests
{
    [Fact]
    public void Neues_Spielfeld_ist_leer_und_X_beginnt()
    {
        var sf = new Spielfeld();

        for (int z = 0; z < 3; z++)
            for (int s = 0; s < 3; s++)
                Assert.Equal(Feld.Leer, sf[z, s]);
        Assert.Equal(Feld.X, sf.AmZug);
        Assert.Equal(Status.Laeuft, sf.Spielstand());
    }

    [Fact]
    public void Indexer_liest_Zeile_und_Spalte()
    {
        var sf = Spielfeld.AusText("XO.", "...", "..O");

        Assert.Equal(Feld.X, sf[0, 0]);
        Assert.Equal(Feld.O, sf[0, 1]);
        Assert.Equal(Feld.O, sf[2, 2]);
        Assert.Equal(Feld.Leer, sf[1, 1]);
    }

    [Fact]
    public void Setze_wechselt_die_Spieler_ab()
    {
        var sf = new Spielfeld();

        Assert.True(sf.Setze(1, 1));
        Assert.Equal(Feld.O, sf.AmZug);
        Assert.True(sf.Setze(0, 0));

        Assert.Equal(Feld.X, sf[1, 1]);
        Assert.Equal(Feld.O, sf[0, 0]);
        Assert.Equal(Feld.X, sf.AmZug);
    }

    [Fact]
    public void Setze_lehnt_belegte_Felder_und_ungueltige_Positionen_ab()
    {
        var sf = new Spielfeld();
        sf.Setze(1, 1);

        Assert.False(sf.Setze(1, 1));
        Assert.False(sf.Setze(3, 0));
        Assert.False(sf.Setze(0, -1));
        Assert.Equal(Feld.O, sf.AmZug);
    }

    [Theory]
    [InlineData("XXX", "OO.", "...")]
    [InlineData("OO.", "...", "XXX")]
    [InlineData("XO.", "XO.", "X..")]
    [InlineData("O.X", "O.X", "..X")]
    [InlineData("XO.", "OX.", "..X")]
    [InlineData("O.X", ".XO", "X..")]
    public void Gewinner_in_Zeile_Spalte_und_Diagonale(string z0, string z1, string z2)
    {
        var sf = Spielfeld.AusText(z0, z1, z2);

        Assert.Equal(Feld.X, sf.Gewinner());
        Assert.Equal(Status.GewonnenX, sf.Spielstand());
    }

    [Fact]
    public void O_kann_auch_gewinnen()
    {
        var sf = Spielfeld.AusText("XXO", "XO.", "O..");

        Assert.Equal(Feld.O, sf.Gewinner());
        Assert.Equal(Status.GewonnenO, sf.Spielstand());
    }

    [Fact]
    public void Kein_Gewinner_bei_gemischten_Reihen()
    {
        var sf = Spielfeld.AusText("XOX", "...", "OXO");

        Assert.Equal(Feld.Leer, sf.Gewinner());
        Assert.Equal(Status.Laeuft, sf.Spielstand());
    }

    [Fact]
    public void Volles_Feld_ohne_Gewinner_ist_unentschieden()
    {
        var sf = Spielfeld.AusText("XOX", "XOO", "OXX");

        Assert.Equal(Feld.Leer, sf.Gewinner());
        Assert.Equal(Status.Unentschieden, sf.Spielstand());
    }

    [Fact]
    public void Nach_dem_Sieg_ist_kein_Zug_mehr_erlaubt()
    {
        var sf = new Spielfeld();
        sf.Setze(0, 0); // X
        sf.Setze(1, 0); // O
        sf.Setze(0, 1); // X
        sf.Setze(1, 1); // O
        sf.Setze(0, 2); // X gewinnt

        Assert.Equal(Status.GewonnenX, sf.Spielstand());
        Assert.False(sf.Setze(2, 2));
        Assert.Equal(Feld.Leer, sf[2, 2]);
    }
}
