public class BruchTests
{
    [Fact]
    public void GgtRekursiv_von_10_und_6_ist_2() => Assert.Equal(2, Bruch.GgtRekursiv(10, 6));

    [Fact]
    public void GgtRekursiv_wenn_b_Teiler_ist() => Assert.Equal(6, Bruch.GgtRekursiv(18, 6));

    [Fact]
    public void Kuerze_nutzt_den_rekursiven_ggT()
    {
        var b = new Bruch(12, 18, "b");
        b.Kuerze();

        Assert.Equal((2, 3), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Fakultaet_von_0_ist_1() => Assert.Equal(1, Bruch.Fakultaet(0));

    [Fact]
    public void Fakultaet_von_5_ist_120() => Assert.Equal(120, Bruch.Fakultaet(5));

    [Fact]
    public void Fakultaet_von_20_passt_in_long() => Assert.Equal(2432902008176640000L, Bruch.Fakultaet(20));

    [Fact]
    public void Fibonacci_Anfangswerte()
    {
        Assert.Equal(0, Bruch.Fibonacci(0));
        Assert.Equal(1, Bruch.Fibonacci(1));
        Assert.Equal(55, Bruch.Fibonacci(10));
    }

    [Fact]
    public void Fibonacci_von_30() => Assert.Equal(832040, Bruch.Fibonacci(30));
}
