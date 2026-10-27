using System.Numerics;

public class GenerischeMathematikTests
{
    [Fact]
    public void Bruch_implementiert_IAdditionOperators()
    {
        // Ein Interface mit statischen abstrakten Mitgliedern taugt nicht als Typargument, daher über typeof.
        Assert.True(typeof(IAdditionOperators<Bruch, Bruch, Bruch>).IsAssignableFrom(typeof(Bruch)));
    }

    [Fact]
    public void Checked_Plus_wirft_bei_Ueberlauf()
    {
        var b1 = new Bruch(int.MaxValue, 1, "");
        var b2 = new Bruch(10, 1, "");

        Assert.Throws<OverflowException>(() => { checked { _ = b1 + b2; } });
    }

    [Fact]
    public void Unchecked_Plus_laeuft_still_ueber()
    {
        var b1 = new Bruch(int.MaxValue, 1, "");
        var b2 = new Bruch(10, 1, "");

        var summe = b1 + b2;

        Assert.True(summe.Zaehler < 0);
    }

    [Fact]
    public void Checked_Plus_rechnet_ohne_Ueberlauf_normal()
    {
        Bruch summe;
        checked {
            summe = new Bruch(1, 2, "a") + new Bruch(1, 4, "b");
        }

        Assert.Equal("3/4", summe.ToString());
        Assert.Equal("a + b", summe.Etikett);
    }

    [Fact]
    public void Checked_PlusGleich_wirft_bei_Ueberlauf()
    {
        var b1 = new Bruch(int.MaxValue, 1, "");

        Assert.Throws<OverflowException>(() => { checked { b1 += new Bruch(2, 1, ""); } });
    }

    [Fact]
    public void Summe_arbeitet_mit_eingebauten_Typen_und_mit_Bruch()
    {
        Assert.Equal(6, Rechner.Summe(1, 2, 3));
        Assert.Equal(4.0, Rechner.Summe(1.5, 2.5));
        Assert.Equal(7m, Rechner.Summe(7m));
        Assert.Equal("5/6", Rechner.Summe(new Bruch(1, 2, ""), new Bruch(1, 3, "")).ToString());
    }

    [Fact]
    public void Statischer_abstrakter_Operator_im_eigenen_Interface()
    {
        Assert.Equal("One Too Tree", Kombinierer.Combine(new Glas("One"), new Glas("Too"), new Glas("Tree")).Sticker);
        Assert.Equal(6, Kombinierer.Combine(new Gras(1), new Gras(2), new Gras(3)).Size);
        Assert.Equal(5, Kombinierer.Combine(new Gras(5)).Size);
    }
}
