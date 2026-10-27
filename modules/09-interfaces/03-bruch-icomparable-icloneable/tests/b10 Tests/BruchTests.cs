public class BruchTests
{
    [Fact]
    public void Bruch_implementiert_beide_Interfaces()
    {
        var b = new Bruch(1, 2, "");

        Assert.IsAssignableFrom<IComparable<Bruch>>(b);
        Assert.IsAssignableFrom<ICloneable>(b);
    }

    [Fact]
    public void CompareTo_vergleicht_die_Werte_nicht_die_Darstellung()
    {
        Assert.True(new Bruch(1, 2, "").CompareTo(new Bruch(2, 3, "")) < 0);
        Assert.True(new Bruch(3, 5, "").CompareTo(new Bruch(1, 2, "")) > 0);
        Assert.Equal(0, new Bruch(2, 4, "").CompareTo(new Bruch(1, 2, "")));
    }

    [Fact]
    public void CompareTo_ueberlaeuft_nicht_bei_grossen_Werten()
    {
        Assert.True(new Bruch(int.MaxValue, 2, "").CompareTo(new Bruch(1, 2, "")) > 0);
        Assert.True(new Bruch(1, int.MaxValue, "").CompareTo(new Bruch(1, 2, "")) < 0);
    }

    [Fact]
    public void CompareTo_beachtet_negative_Nenner()
    {
        Assert.True(new Bruch(1, -2, "").CompareTo(new Bruch(1, 3, "")) < 0);
        Assert.True(new Bruch(1, 3, "").CompareTo(new Bruch(1, -2, "")) > 0);
        Assert.True(new Bruch(-1, -2, "").CompareTo(new Bruch(1, 3, "")) > 0);
        Assert.Equal(0, new Bruch(-1, -2, "").CompareTo(new Bruch(1, 2, "")));
        Assert.Equal(0, new Bruch(1, -2, "").CompareTo(new Bruch(-1, 2, "")));
    }

    [Fact]
    public void Array_Sort_nutzt_CompareTo()
    {
        Bruch[] b = [new Bruch(3, 5, "c"), new Bruch(1, 3, "a"), new Bruch(1, 2, "b")];

        Array.Sort(b);

        Assert.Equal(["a", "b", "c"], b.Select(x => x.Etikett));
    }

    [Fact]
    public void Clone_liefert_eine_unabhaengige_Kopie()
    {
        var original = new Bruch(2, 3, "o");

        var kopie = (Bruch)original.Clone();
        kopie.Zaehler = 9;
        kopie.Etikett = "k";

        Assert.NotSame(original, kopie);
        Assert.Equal((2, 3, "o"), (original.Zaehler, original.Nenner, original.Etikett));
        Assert.Equal((9, 3, "k"), (kopie.Zaehler, kopie.Nenner, kopie.Etikett));
    }

    [Fact]
    public void Klone_bleibt_als_typsichere_Variante_erhalten()
    {
        Bruch k = new Bruch(2, 3, "o").Klone();

        Assert.Equal("2/3", k.ToString());
    }
}
