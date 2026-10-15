public class PolymorphieTests
{
    [Fact]
    public void Ueber_eine_Basisklassenreferenz_laeuft_die_ueberschriebene_Methode()
    {
        Figur f = new Kreis(150.0, 200.0, 50.0);

        Assert.Equal("Kreis", f.Name);
        Assert.Equal("Oben Links: (150; 200)\nUnten Rechts: (250; 300)", f.Wo());
    }

    [Fact]
    public void Rechteck_ueberschreibt_Name_Wo_und_Skaliere()
    {
        Figur r = new Rechteck(20.0, 20.0, 20.0, 30.0);

        r.Skaliere(2.0);

        Assert.Equal("Rechteck", r.Name);
        Assert.Equal("Oben Links: (20; 20)\nUnten Rechts: (60; 80)", r.Wo());
    }

    [Fact]
    public void Skaliere_ueber_Basisreferenz_wirkt_auf_den_Kreis()
    {
        var k = new Kreis(0.0, 0.0, 5.0);
        Figur f = k;

        f.Skaliere(3.0);

        Assert.Equal(15.0, k.Radius);
    }

    [Fact]
    public void Nicht_virtuelle_Methode_nutzt_die_virtuellen_Mitglieder()
    {
        Figur[] fa = [new Figur(1.0, 1.0), new Kreis(2.0, 2.0, 1.0), new Rechteck()];

        Assert.StartsWith("Figur: Oben Links: (1; 1)", fa[0].Beschreibe());
        Assert.StartsWith("Kreis: Oben Links: (2; 2)\nUnten Rechts: (4; 4)", fa[1].Beschreibe());
        Assert.StartsWith("Rechteck: ", fa[2].Beschreibe());
    }

    [Fact]
    public void Wo_ist_in_Figur_virtuell_und_in_Rechteck_versiegelt()
    {
        var basis = typeof(Figur).GetMethod("Wo")!;
        var rechteck = typeof(Rechteck).GetMethod("Wo")!;

        Assert.True(basis.IsVirtual);
        Assert.Equal(typeof(Rechteck), rechteck.DeclaringType);
        Assert.True(rechteck.IsFinal, "Rechteck.Wo muss sealed override sein");
    }
}
