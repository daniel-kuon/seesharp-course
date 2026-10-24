public class KettenTests
{
    [Fact]
    public void Kette_liefert_das_Ergebnis_des_letzten_Schritts()
    {
        Schritt? k = Ketten.Kette(x => x + 1, x => x * 2, x => x - 3);

        Assert.NotNull(k);
        Assert.Equal(2, k(5));   // 5 - 3: jeder Schritt bekommt das Argument 5
    }

    [Fact]
    public void Kette_fuehrt_alle_Schritte_aus()
    {
        var log = new List<string>();
        Schritt? k = Ketten.Kette(
            x => { log.Add("a" + x); return 1; },
            x => { log.Add("b" + x); return 2; },
            x => { log.Add("c" + x); return 3; });

        int ergebnis = k!(7);

        Assert.Equal(3, ergebnis);
        Assert.Equal(["a7", "b7", "c7"], log);
        Assert.Equal(3, k.GetInvocationList().Length);
    }

    [Fact]
    public void Kette_ohne_Schritte_ist_null()
    {
        Assert.Null(Ketten.Kette());
    }

    [Fact]
    public void Kette_mit_einem_Schritt_ist_dieser_Schritt()
    {
        Schritt? k = Ketten.Kette(x => x * x);

        Assert.Equal(49, k!(7));
        Assert.Single(k.GetInvocationList());
    }
}
