using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Nullsicherheit;

public class NullsicherheitTests
{
    static NullabilityState Schreibzustand(ParameterInfo p) => new NullabilityInfoContext().Create(p).WriteState;

    [Fact]
    public void Reverse_kehrt_um()
    {
        Assert.Equal("cba", PalindromReverse.Reverse("abc"));
        Assert.Equal("", PalindromReverse.Reverse(""));
    }

    [Fact]
    public void Reverse_null_liefert_null()
    {
        Assert.Null(PalindromReverse.Reverse(null));
    }

    [Fact]
    public void Reverse_Parameter_ist_als_nullable_markiert()
    {
        var p = typeof(PalindromReverse).GetMethod("Reverse")!.GetParameters()[0];
        Assert.Equal(NullabilityState.Nullable, Schreibzustand(p));
    }

    [Fact]
    public void Reverse_hat_NotNullIfNotNull()
    {
        var ruckgabe = typeof(PalindromReverse).GetMethod("Reverse")!.ReturnParameter;
        var attribut = ruckgabe.GetCustomAttribute<NotNullIfNotNullAttribute>();
        Assert.NotNull(attribut);
        Assert.Equal("s", attribut!.ParameterName);
    }

    [Fact]
    public void TryFinde_findet_den_ersten_Treffer()
    {
        string[] daten = ["Birne", "Apfel", "Ananas"];
        Assert.True(PalindromReverse.TryFinde(daten, "A", out var treffer));
        Assert.Equal("Apfel", treffer);
    }

    [Fact]
    public void TryFinde_ohne_Treffer_liefert_false_und_null()
    {
        Assert.False(PalindromReverse.TryFinde(["Birne"], "A", out var treffer));
        Assert.Null(treffer);
    }

    [Fact]
    public void TryFinde_hat_NotNullWhen_true()
    {
        var p = typeof(PalindromReverse).GetMethod("TryFinde")!.GetParameters()[2];
        var attribut = p.GetCustomAttribute<NotNullWhenAttribute>();
        Assert.NotNull(attribut);
        Assert.True(attribut!.ReturnValue);
        Assert.Equal(NullabilityState.Nullable, Schreibzustand(p));
    }

    [Fact]
    public void ErstesVorhandenes_ueberspringt_null()
    {
        Assert.Equal("x", PalindromReverse.ErstesVorhandenes([null, null, "x", "y"]));
    }

    [Fact]
    public void ErstesVorhandenes_wirft_wenn_alles_null_ist()
    {
        Assert.Throws<InvalidOperationException>(() => PalindromReverse.ErstesVorhandenes([null, null]));
        Assert.Throws<InvalidOperationException>(() => PalindromReverse.ErstesVorhandenes([]));
    }

    [Fact]
    public void Kunde_Name_ist_nicht_nullable_Spitzname_schon()
    {
        var ctx = new NullabilityInfoContext();
        Assert.Equal(NullabilityState.NotNull, ctx.Create(typeof(Kunde).GetProperty("Name")!).ReadState);
        Assert.Equal(NullabilityState.Nullable, ctx.Create(typeof(Kunde).GetProperty("Spitzname")!).ReadState);
    }

    [Fact]
    public void Anzeige_mit_Spitzname()
    {
        var k = new Kunde("Anna") { Spitzname = "Annchen" };
        Assert.Equal("Anna (Annchen)", k.Anzeige());
    }

    [Fact]
    public void Anzeige_ohne_Spitzname()
    {
        var k = new Kunde("Anna");
        Assert.Null(k.Spitzname);
        Assert.Equal("Anna", k.Anzeige());
        k.Spitzname = null;
        Assert.Equal("Anna", k.Anzeige());
    }
}
