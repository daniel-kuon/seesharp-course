public class FormenTests
{
    [Fact]
    public void Kreis_und_Quadrat_implementieren_IForm()
    {
        Assert.True(typeof(IForm).IsInterface);
        Assert.True(typeof(IForm).IsAssignableFrom(typeof(Kreis)));
        Assert.True(typeof(IForm).IsAssignableFrom(typeof(Quadrat)));
        Assert.True(typeof(Quadrat).IsValueType);
    }

    [Fact]
    public void Kreis_rechnet_richtig()
    {
        IForm k = new Kreis(2.0);

        Assert.Equal("Kreis", k.Name);
        Assert.Equal(Math.PI * 4.0, k.Inhalt, 9);
        Assert.Equal(Math.PI * 4.0, k.Umfang(), 9);
    }

    [Fact]
    public void Quadrat_rechnet_richtig()
    {
        IForm q = new Quadrat(3.0);

        Assert.Equal("Quadrat", q.Name);
        Assert.Equal(9.0, q.Inhalt);
        Assert.Equal(12.0, q.Umfang());
    }

    [Fact]
    public void Interface_als_Typ_fuer_gemischte_Arrays()
    {
        IForm[] formen = [new Kreis(1.0), new Quadrat(2.0), new Quadrat(1.0)];

        Assert.Equal(Math.PI + 5.0, Formen.Gesamt(formen), 9);
        Assert.Equal("Quadrat", Formen.Groesste(formen));
        Assert.Equal("Kreis", Formen.Groesste([new Quadrat(1.0), new Kreis(1.0)]));
        Assert.Equal("", Formen.Groesste([]));
    }

    [Fact]
    public void Skaliere_ueber_die_Schnittstelle()
    {
        var k = new Kreis(1.0);
        IForm f = k;

        f.Skaliere(2.0);

        Assert.Equal(2.0, k.Radius);
    }

    [Fact]
    public void Struktur_wird_beim_Zuweisen_an_das_Interface_geboxt()
    {
        var q = new Quadrat(1.0);
        IForm f = q;          // Kopie auf dem Heap

        q.Skaliere(3.0);      // ändert nur die Struktur in q

        Assert.Equal(9.0, q.Inhalt);
        Assert.Equal(1.0, f.Inhalt);
    }
}
