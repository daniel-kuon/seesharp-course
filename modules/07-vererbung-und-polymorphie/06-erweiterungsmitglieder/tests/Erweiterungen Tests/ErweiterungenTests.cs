public class ErweiterungenTests
{
    [Fact]
    public void High_potenziert()
    {
        Assert.Equal(9.0, 3.0.High(2));
        Assert.Equal(9.8596, 3.14.High(2), 9);
        Assert.Equal(9.0, DoubleExtensions.High(3.0, 2)); // auch als statische Methode aufrufbar
    }

    [Fact]
    public void NumEquals_und_EqualsPi_vergleichen_relativ()
    {
        Assert.True(Math.PI.EqualsPi);
        Assert.False(3.14.EqualsPi);
        Assert.True(1.0.NumEquals(1.0 + 1e-16));
        Assert.False(1.0.NumEquals(1.001));
    }

    [Fact]
    public void Statische_Erweiterungsmitglieder()
    {
        Assert.Equal(1.0e-14, double.DiffThreshold);
        Assert.True(double.NumEqualsPi(Math.PI));
        Assert.False(double.NumEqualsPi(3.14));
    }

    [Fact]
    public void Potenzoperator_ueber_Erweiterungsblock()
    {
        Assert.Equal(8.0, 2.0 ^ 3.0);
        Assert.Equal(1.0, 5.0 ^ 0.0);
    }

    [Fact]
    public void String_Erweiterungen_unterscheiden_null_und_leer()
    {
        string? s = null;

        Assert.False(s.Empty());
        Assert.True("".Empty());
        Assert.False("m".Empty());

        Assert.True(s.NullOrEmpty);
        Assert.True("".NullOrEmpty);
        Assert.False("m".NullOrEmpty);
    }
}
