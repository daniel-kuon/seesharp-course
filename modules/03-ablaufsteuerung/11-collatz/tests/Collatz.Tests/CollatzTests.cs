public class CollatzTests
{
    [Fact]
    public void Von_1_aus_null_Schritte() => Assert.Equal(0, Collatz.Schritte(1));

    [Fact]
    public void Von_6_aus_acht_Schritte() => Assert.Equal(8, Collatz.Schritte(6));

    [Fact]
    public void Von_27_aus_111_Schritte() => Assert.Equal(111, Collatz.Schritte(27));

    [Fact]
    public void Hoechstwert_von_6_ist_16() => Assert.Equal(16, Collatz.Hoechstwert(6));

    [Fact]
    public void Hoechstwert_von_27_ist_9232() => Assert.Equal(9232, Collatz.Hoechstwert(27));

    [Fact]
    public void Hoechstwert_einer_Zweierpotenz_ist_der_Start()
    {
        Assert.Equal(64, Collatz.Hoechstwert(64));
        Assert.Equal(1, Collatz.Hoechstwert(1));
    }

    [Fact]
    public void Laengster_Start_bis_10_ist_9() => Assert.Equal(9, Collatz.LaengsterStartBis(10));

    [Fact]
    public void Laengster_Start_bis_100_ist_97() => Assert.Equal(97, Collatz.LaengsterStartBis(100));
}
