public class SimpleStackTests
{
    // ---- Konstruktor ----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Konstruktor_wirft_bei_nicht_positiver_Kapazitaet(int kapazitaet)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new SimpleStack<int>(kapazitaet));

        Assert.Equal("kapazitaet", ex.ParamName);
    }

    [Fact]
    public void Konstruktor_akzeptiert_Kapazitaet_1()
    {
        var s = new SimpleStack<string>(1);

        Assert.Equal(0, s.Count);
    }

    // ---- Push, Pop, Peek ----

    [Fact]
    public void Push_und_Pop_arbeiten_nach_dem_LIFO_Prinzip()
    {
        var s = new SimpleStack<int>(3);
        s.Push(1);
        s.Push(2);
        s.Push(3);

        Assert.Equal(3, s.Count);
        Assert.Equal(3, s.Pop());
        Assert.Equal(2, s.Pop());
        Assert.Equal(1, s.Pop());
        Assert.Equal(0, s.Count);
    }

    [Fact]
    public void Push_auf_vollem_Stapel_wirft_InvalidOperationException()
    {
        var s = new SimpleStack<int>(2);
        s.Push(1);
        s.Push(2);

        var ex = Assert.Throws<InvalidOperationException>(() => s.Push(3));

        Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        Assert.Equal(2, s.Count);
        Assert.Equal(2, s.Peek());
    }

    [Fact]
    public void Pop_auf_leerem_Stapel_wirft_InvalidOperationException_und_ueberlebt()
    {
        var s = new SimpleStack<int>(2);

        Assert.Throws<InvalidOperationException>(() => s.Pop());

        Assert.Equal(0, s.Count);
        s.Push(7);
        Assert.Equal(7, s.Pop());
    }

    [Fact]
    public void Peek_zeigt_das_oberste_Element_ohne_es_zu_entfernen()
    {
        var s = new SimpleStack<string>(3);
        s.Push("a");
        s.Push("b");

        Assert.Equal("b", s.Peek());
        Assert.Equal("b", s.Peek());
        Assert.Equal(2, s.Count);
    }

    [Fact]
    public void Peek_auf_leerem_Stapel_wirft_InvalidOperationException()
    {
        var s = new SimpleStack<int>(2);

        var ex = Assert.Throws<InvalidOperationException>(() => s.Peek());

        Assert.False(string.IsNullOrWhiteSpace(ex.Message));
    }

    [Fact]
    public void Peek_nach_dem_Leeren_wirft_wieder()
    {
        var s = new SimpleStack<int>(2);
        s.Push(1);
        s.Pop();

        Assert.Throws<InvalidOperationException>(() => s.Peek());
    }

    // ---- Name ----

    [Fact]
    public void Name_hat_einen_Standardwert_und_laesst_sich_aendern()
    {
        var s = new SimpleStack<int>(1);
        Assert.False(string.IsNullOrEmpty(s.Name));

        s.Name = "Mein Stapel";

        Assert.Equal("Mein Stapel", s.Name);
    }

    [Fact]
    public void Name_null_wirft_ArgumentNullException_und_laesst_den_Namen_unveraendert()
    {
        var s = new SimpleStack<int>(1);
        s.Name = "Alt";

        var ex = Assert.Throws<ArgumentNullException>(() => s.Name = null!);

        Assert.Equal("value", ex.ParamName);
        Assert.Equal("Alt", s.Name);
    }

    // ---- Fuelle ----

    [Fact]
    public void Fuelle_legt_alle_Elemente_auf_den_Stapel()
    {
        var s = new SimpleStack<int>(5);

        s.Fuelle(new[] { 1, 2, 3 });

        Assert.Equal(3, s.Count);
        Assert.Equal(3, s.Peek());
    }

    [Fact]
    public void Fuelle_mit_null_wirft_ArgumentNullException_mit_Parametername()
    {
        var s = new SimpleStack<int>(5);

        var ex = Assert.Throws<ArgumentNullException>(() => s.Fuelle(null!));

        Assert.Equal("quelle", ex.ParamName);
        Assert.Equal(0, s.Count);
    }

    [Fact]
    public void Fuelle_mit_zu_vielen_Elementen_wirft_InvalidOperationException()
    {
        var s = new SimpleStack<int>(2);

        Assert.Throws<InvalidOperationException>(() => s.Fuelle(new[] { 1, 2, 3 }));
    }
}
