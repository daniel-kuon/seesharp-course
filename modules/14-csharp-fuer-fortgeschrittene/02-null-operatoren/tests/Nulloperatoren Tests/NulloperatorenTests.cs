using Nulloperatoren;

public class NulloperatorenTests
{
    [Fact]
    public void Ortsname_mit_vollstaendiger_Kette()
    {
        var k = new Kunde { Adresse = new Adresse { Ort = "Köln" } };
        Assert.Equal("KÖLN", Auskunft.Ortsname(k));
    }

    [Fact]
    public void Ortsname_mit_null_auf_jeder_Ebene()
    {
        Assert.Equal("unbekannt", Auskunft.Ortsname(null));
        Assert.Equal("unbekannt", Auskunft.Ortsname(new Kunde()));
        Assert.Equal("unbekannt", Auskunft.Ortsname(new Kunde { Adresse = new Adresse() }));
    }

    [Fact]
    public void Laenge_von_Array_und_null()
    {
        Assert.Equal(3, Auskunft.Laenge(["a", "b", "c"]));
        Assert.Equal(0, Auskunft.Laenge([]));
        Assert.Equal(0, Auskunft.Laenge(null));
    }

    [Fact]
    public void Erstes_liefert_Element_oder_null()
    {
        Assert.Equal("x", Auskunft.Erstes(["x", "y"]));
        Assert.Null(Auskunft.Erstes(null));
    }

    [Fact]
    public void Nachschlagen_findet_oder_liefert_Vorgabe()
    {
        var d = new Dictionary<string, string> { ["a"] = "Apfel" };
        Assert.Equal("Apfel", Auskunft.Nachschlagen(d, "a"));
        Assert.Equal("(kein Eintrag)", Auskunft.Nachschlagen(d, "b"));
        Assert.Equal("(kein Eintrag)", Auskunft.Nachschlagen(null, "a"));
    }

    [Fact]
    public void Zaehler_legt_die_Liste_erst_beim_ersten_Eintrag_an()
    {
        var z = new Zaehler();
        Assert.Null(z.Eintraege);
        z.Fuege("a");
        var liste = z.Eintraege;
        Assert.NotNull(liste);
        z.Fuege("b");
        Assert.Same(liste, z.Eintraege);
        Assert.Equal(["a", "b"], z.Eintraege);
    }

    [Fact]
    public void SetzeAlter_ohne_Kunde_tut_nichts()
    {
        Assert.False(Auskunft.SetzeAlter(null, 30));
    }

    [Fact]
    public void SetzeAlter_setzt_das_Alter()
    {
        var k = new Kunde { Alter = 5 };
        Assert.True(Auskunft.SetzeAlter(k, 30));
        Assert.Equal(30, k.Alter);
    }

    [Fact]
    public void SetzeAlterBerechnet_wertet_die_rechte_Seite_nur_bei_Kunde_aus()
    {
        int aufrufe = 0;
        Func<int> berechne = () => { aufrufe++; return 42; };

        Assert.False(Auskunft.SetzeAlterBerechnet(null, berechne));
        Assert.Equal(0, aufrufe);

        var k = new Kunde();
        Assert.True(Auskunft.SetzeAlterBerechnet(k, berechne));
        Assert.Equal(1, aufrufe);
        Assert.Equal(42, k.Alter);
    }

    [Fact]
    public void Erhoehe_addiert_nur_bei_vorhandenem_Kunde()
    {
        Assert.False(Auskunft.Erhoehe(null, 1));
        var k = new Kunde { Alter = 10 };
        Assert.True(Auskunft.Erhoehe(k, 3));
        Assert.Equal(13, k.Alter);
    }
}
