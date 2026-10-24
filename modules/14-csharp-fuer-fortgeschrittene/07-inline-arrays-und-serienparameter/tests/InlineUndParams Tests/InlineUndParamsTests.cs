using System.Reflection;
using System.Runtime.CompilerServices;
using InlineUndParams;

public class InlineUndParamsTests
{
    [Fact]
    public void Puffer8_ist_ein_Inline_Array_mit_32_Byte()
    {
        Assert.NotNull(typeof(Puffer8).GetCustomAttribute<InlineArrayAttribute>());
        Assert.Equal(8, typeof(Puffer8).GetCustomAttribute<InlineArrayAttribute>()!.Length);
        Assert.Equal(32, Unsafe.SizeOf<Puffer8>());
    }

    [Fact]
    public void Fuelle_schreibt_aufsteigende_Werte()
    {
        var p = new Puffer8();
        Puffer8Werkzeuge.Fuelle(ref p, 10);
        for (int i = 0; i < 8; i++)
            Assert.Equal(10 + i, Puffer8Werkzeuge.Lies(p, i));
    }

    [Fact]
    public void Summe_addiert_alle_acht_Werte()
    {
        var p = new Puffer8();
        Puffer8Werkzeuge.Fuelle(ref p, 1);
        Assert.Equal(36, Puffer8Werkzeuge.Summe(p));
        Puffer8Werkzeuge.Fuelle(ref p, 0);
        Assert.Equal(28, Puffer8Werkzeuge.Summe(p));
    }

    [Fact]
    public void Puffer8_hat_Wertsemantik()
    {
        var a = new Puffer8();
        Puffer8Werkzeuge.Fuelle(ref a, 0);
        var b = a;
        Puffer8Werkzeuge.Fuelle(ref a, 100);
        Assert.Equal(28, Puffer8Werkzeuge.Summe(b));
        Assert.Equal(828, Puffer8Werkzeuge.Summe(a));
    }

    [Fact]
    public void Lies_ausserhalb_wirft()
    {
        var p = new Puffer8();
        Assert.Throws<IndexOutOfRangeException>(() => Puffer8Werkzeuge.Lies(p, 8));
    }

    [Fact]
    public void Summe_mit_null_einem_und_vielen_Argumenten()
    {
        Assert.Equal(0, Serie.Summe());
        Assert.Equal(5, Serie.Summe(5));
        Assert.Equal(6, Serie.Summe(1, 2, 3));
    }

    [Fact]
    public void Summe_mit_Array_und_Kollektionsausdruck()
    {
        int[] vorhanden = [4, 5, 6];
        Assert.Equal(15, Serie.Summe(vorhanden));
        Assert.Equal(6, Serie.Summe([1, 2, 3]));
        Assert.Equal(0, Serie.Summe([]));
    }

    [Fact]
    public void Verbinde_mit_allen_Aufrufformen()
    {
        Assert.Equal("", Serie.Verbinde());
        Assert.Equal("a", Serie.Verbinde("a"));
        Assert.Equal("a-b-c", Serie.Verbinde("a", "b", "c"));
        Assert.Equal("x-y", Serie.Verbinde(["x", "y"]));
        Assert.Equal("1-2", Serie.Verbinde(new List<string> { "1", "2" }));
        Assert.Equal("p-q", Serie.Verbinde(new[] { "p", "q" }.Select(s => s)));
    }

    [Fact]
    public void Zaehle_mit_allen_Aufrufformen()
    {
        Assert.Equal(0, Serie.Zaehle<int>());
        Assert.Equal(1, Serie.Zaehle("a"));
        Assert.Equal(3, Serie.Zaehle(1, 2, 3));
        Assert.Equal(4, Serie.Zaehle(new List<int> { 1, 2, 3, 4 }));
    }

    [Fact]
    public void Serienparameter_haben_Kollektionstypen()
    {
        static bool IstParamsKollektion(MethodInfo m) =>
            m.GetParameters()[0].GetCustomAttributes().Any(a => a.GetType().Name == "ParamCollectionAttribute");

        var summe = typeof(Serie).GetMethod("Summe")!;
        Assert.Equal(typeof(ReadOnlySpan<int>), summe.GetParameters()[0].ParameterType);
        Assert.True(IstParamsKollektion(summe));

        var verbinde = typeof(Serie).GetMethod("Verbinde")!;
        Assert.Equal(typeof(IEnumerable<string>), verbinde.GetParameters()[0].ParameterType);
        Assert.True(IstParamsKollektion(verbinde));

        var zaehle = typeof(Serie).GetMethod("Zaehle")!;
        Assert.Equal(typeof(List<>), zaehle.GetParameters()[0].ParameterType.GetGenericTypeDefinition());
        Assert.True(IstParamsKollektion(zaehle));
    }
}
