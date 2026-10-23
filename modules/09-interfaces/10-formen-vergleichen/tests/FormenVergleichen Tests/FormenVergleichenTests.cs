public class FormenVergleichenTests
{
    static IComparable<IForm> Vergleichbar(IForm f) => (IComparable<IForm>)f;

    [Fact]
    public void IForm_erweitert_IComparable()
    {
        Assert.True(typeof(IForm).IsInterface);
        Assert.Contains(typeof(IComparable<IForm>), typeof(IForm).GetInterfaces());
        Assert.NotNull(typeof(IForm).GetProperty("Umfang"));
    }

    [Fact]
    public void Flaeche_und_Umfang()
    {
        var k = new Kreis(2);
        var r = new Rechteck(2, 5);
        var d = new Dreieck(3, 4, 5);

        Assert.Equal(4 * Math.PI, k.Flaeche, 9);
        Assert.Equal(4 * Math.PI, k.Umfang, 9);
        Assert.Equal(10.0, r.Flaeche, 9);
        Assert.Equal(14.0, r.Umfang, 9);
        Assert.Equal(6.0, d.Flaeche, 9);
        Assert.Equal(12.0, d.Umfang, 9);
    }

    [Fact]
    public void Ungueltiges_Dreieck_wirft()
    {
        Assert.Throws<ArgumentException>(() => new Dreieck(1, 2, 3));
        Assert.Throws<ArgumentException>(() => new Dreieck(10, 2, 3));
        Assert.Equal(Math.Sqrt(3) / 4, new Dreieck(1, 1, 1).Flaeche, 9);
    }

    [Fact]
    public void CompareTo_vergleicht_die_Flaechen()
    {
        IForm klein = new Kreis(1);        // ~3,14
        IForm mittel = new Dreieck(3, 4, 5); // 6
        IForm gross = new Rechteck(2, 5);  // 10

        Assert.True(Vergleichbar(klein).CompareTo(mittel) < 0);
        Assert.True(Vergleichbar(gross).CompareTo(mittel) > 0);
        Assert.Equal(0, Vergleichbar(new Rechteck(2, 3)).CompareTo(new Rechteck(3, 2)));
        Assert.True(Vergleichbar(klein).CompareTo(null) > 0);
    }

    [Fact]
    public void CompareTo_steckt_im_Interface()
    {
        foreach (var typ in new[] { typeof(Kreis), typeof(Rechteck), typeof(Dreieck) })
        {
            var map = typ.GetInterfaceMap(typeof(IComparable<IForm>));
            Assert.Equal(typeof(IForm), map.TargetMethods[0].DeclaringType);
        }
    }

    [Fact]
    public void Sortiert_liefert_eine_sortierte_Kopie()
    {
        IForm r = new Rechteck(2, 5), k = new Kreis(1), d = new Dreieck(3, 4, 5);
        IForm[] formen = [r, k, d];

        var sortiert = Formen.Sortiert(formen);

        Assert.Equal([k, d, r], sortiert);
        Assert.Equal([r, k, d], formen);
    }

    [Fact]
    public void Groesste_findet_die_groesste_Form()
    {
        IForm r = new Rechteck(2, 5);

        Assert.Same(r, Formen.Groesste([new Kreis(1), r, new Dreieck(3, 4, 5)]));
        Assert.Null(Formen.Groesste([]));
    }
}
