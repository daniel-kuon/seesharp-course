public class LichtschalterTests
{
    [Fact]
    public void Umschalten_kehrt_IstAn_um()
    {
        var s = new Lichtschalter();
        Assert.False(s.IstAn);

        s.Umschalten();
        Assert.True(s.IstAn);

        s.Umschalten();
        Assert.False(s.IstAn);
    }

    [Fact]
    public void Ohne_Abonnenten_passiert_nichts()
    {
        var s = new Lichtschalter();

        s.Umschalten();
        s.Umschalten();

        Assert.False(s.IstAn);
    }

    [Fact]
    public void Ereignis_sieht_den_neuen_Zustand()
    {
        var s = new Lichtschalter();
        var zustaende = new List<bool>();
        s.Eingeschaltet += (sender, e) => zustaende.Add(((Lichtschalter)sender!).IstAn);
        s.Ausgeschaltet += (sender, e) => zustaende.Add(((Lichtschalter)sender!).IstAn);

        s.Umschalten();
        s.Umschalten();

        Assert.Equal([true, false], zustaende);
    }

    [Fact]
    public void Zehnmal_umschalten_zaehlt_fuenf_und_fuenf()
    {
        var s = new Lichtschalter();
        var lampe = new Lampe(s);

        for (int i = 0; i < 10; i++) s.Umschalten();

        Assert.Equal(5, lampe.Einschaltungen);
        Assert.Equal(5, lampe.Ausschaltungen);
    }

    [Fact]
    public void Nach_Abkoppeln_wird_nicht_mehr_gezaehlt()
    {
        var s = new Lichtschalter();
        var lampe = new Lampe(s);
        for (int i = 0; i < 10; i++) s.Umschalten();

        lampe.Abkoppeln();
        for (int i = 0; i < 10; i++) s.Umschalten();

        Assert.Equal(5, lampe.Einschaltungen);
        Assert.Equal(5, lampe.Ausschaltungen);
    }

    [Fact]
    public void Zwei_Lampen_sind_unabhaengig()
    {
        var s = new Lichtschalter();
        var a = new Lampe(s);
        var b = new Lampe(s);

        s.Umschalten();
        a.Abkoppeln();
        s.Umschalten();
        s.Umschalten();

        Assert.Equal(1, a.Einschaltungen);
        Assert.Equal(0, a.Ausschaltungen);
        Assert.Equal(2, b.Einschaltungen);
        Assert.Equal(1, b.Ausschaltungen);
    }

    [Fact]
    public void Ereignisse_sind_echte_Ereignisse()
    {
        Assert.NotNull(typeof(Lichtschalter).GetEvent(nameof(Lichtschalter.Eingeschaltet)));
        Assert.NotNull(typeof(Lichtschalter).GetEvent(nameof(Lichtschalter.Ausgeschaltet)));
        Assert.Null(typeof(Lichtschalter).GetField(nameof(Lichtschalter.Eingeschaltet)));
        Assert.Null(typeof(Lichtschalter).GetField(nameof(Lichtschalter.Ausgeschaltet)));
    }
}
