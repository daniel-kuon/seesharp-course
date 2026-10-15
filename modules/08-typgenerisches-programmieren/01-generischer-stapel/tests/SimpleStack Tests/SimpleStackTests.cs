public class SimpleStackTests
{
    [Fact]
    public void Push_und_Pop_arbeiten_LIFO()
    {
        var s = new SimpleStack<double>(10);
        s.Push(3.141);
        s.Push(2.718);

        Assert.Equal(2, s.Count);
        Assert.Equal(2.718, s.Pop());
        Assert.Equal(3.141, s.Pop());
        Assert.Equal(0, s.Count);
    }

    [Fact]
    public void Peek_liefert_ohne_zu_entfernen()
    {
        var s = new SimpleStack<string>();
        s.Push("eins");

        Assert.Equal("eins", s.Peek());
        Assert.Equal(1, s.Count);
    }

    [Fact]
    public void Leerer_Stapel_wirft_bei_Pop_und_Peek()
    {
        var s = new SimpleStack<int>();

        Assert.Throws<InvalidOperationException>(() => s.Pop());
        Assert.Throws<InvalidOperationException>(() => s.Peek());
    }

    [Fact]
    public void Kapazitaet_wird_eingehalten()
    {
        var s = new SimpleStack<int>(2);
        s.Push(1);
        s.Push(2);

        Assert.Throws<InvalidOperationException>(() => s.Push(3));
        Assert.Equal(2, s.Count);
    }

    [Fact]
    public void Ungueltige_Kapazitaet_ergibt_die_Standardkapazitaet_5()
    {
        var s = new SimpleStack<int>(0);
        for (int i = 0; i < 5; i++)
            s.Push(i);

        Assert.Throws<InvalidOperationException>(() => s.Push(5));
    }

    [Fact]
    public void Jede_Konkretisierung_ist_ein_eigener_Typ()
    {
        Assert.NotEqual(typeof(SimpleStack<int>), typeof(SimpleStack<string>));
        Assert.True(typeof(SimpleStack<>).IsGenericTypeDefinition);
    }
}
