using System.Reflection;
using SichereEingaben;

public class EingabenTests
{
    static NullabilityState Zustand(string methode) =>
        new NullabilityInfoContext().Create(typeof(Eingaben).GetMethod(methode)!.GetParameters()[0]).WriteState;

    [Fact]
    public void Parameter_sind_als_nullable_markiert()
    {
        Assert.Equal(NullabilityState.Nullable, Zustand("Bereinige"));
        Assert.Equal(NullabilityState.Nullable, Zustand("ErstesWort"));
        Assert.Equal(NullabilityState.Nullable, Zustand("Alter"));
    }

    [Theory]
    [InlineData("  hallo  ", "hallo")]
    [InlineData("x", "x")]
    [InlineData("", "(leer)")]
    [InlineData("   ", "(leer)")]
    [InlineData("\t\n", "(leer)")]
    public void Bereinige_trimmt_und_ersetzt_Leeres(string eingabe, string erwartet)
    {
        Assert.Equal(erwartet, Eingaben.Bereinige(eingabe));
    }

    [Fact]
    public void Bereinige_null_ist_leer()
    {
        Assert.Equal("(leer)", Eingaben.Bereinige(null));
    }

    [Theory]
    [InlineData("hallo welt", "hallo")]
    [InlineData("  hallo   welt ", "hallo")]
    [InlineData("eins", "eins")]
    [InlineData("", "")]
    [InlineData("    ", "")]
    public void ErstesWort_findet_das_erste_Wort(string eingabe, string erwartet)
    {
        Assert.Equal(erwartet, Eingaben.ErstesWort(eingabe));
    }

    [Fact]
    public void ErstesWort_null_ist_leer()
    {
        Assert.Equal("", Eingaben.ErstesWort(null));
    }

    [Fact]
    public void Alter_liest_den_Eintrag()
    {
        Assert.Equal(42, Eingaben.Alter(new Dictionary<string, string> { ["alter"] = "42" }));
    }

    [Fact]
    public void Alter_hat_den_Vorgabewert_null()
    {
        Assert.Equal(0, Eingaben.Alter(null));
        Assert.Equal(0, Eingaben.Alter(new Dictionary<string, string>()));
        Assert.Equal(0, Eingaben.Alter(new Dictionary<string, string> { ["name"] = "Anna" }));
        Assert.Equal(0, Eingaben.Alter(new Dictionary<string, string> { ["alter"] = "viel" }));
    }
}
