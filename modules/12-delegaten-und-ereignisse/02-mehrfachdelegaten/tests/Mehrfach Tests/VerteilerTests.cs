public class VerteilerTests
{
    [Fact]
    public void Ohne_Ziele_passiert_nichts()
    {
        var v = new Verteiler();

        v.Sende("hallo");

        Assert.Equal(0, v.AnzahlZiele());
    }

    [Fact]
    public void Sende_ruft_in_Anmeldereihenfolge_auf()
    {
        var log = new List<string>();
        var v = new Verteiler();
        v.Anmelden(t => log.Add("A:" + t));
        v.Anmelden(t => log.Add("B:" + t));

        v.Sende("x");

        Assert.Equal(["A:x", "B:x"], log);
        Assert.Equal(2, v.AnzahlZiele());
    }

    [Fact]
    public void Zweimal_angemeldet_wird_zweimal_aufgerufen()
    {
        var log = new List<string>();
        Meldung m = t => log.Add(t);
        var v = new Verteiler();
        v.Anmelden(m);
        v.Anmelden(m);

        v.Sende("x");

        Assert.Equal(["x", "x"], log);
        Assert.Equal(2, v.AnzahlZiele());
    }

    [Fact]
    public void Abmelden_entfernt_nur_einen_Eintrag()
    {
        var log = new List<string>();
        Meldung m = t => log.Add(t);
        var v = new Verteiler();
        v.Anmelden(m);
        v.Anmelden(m);

        v.Abmelden(m);
        v.Sende("x");

        Assert.Equal(["x"], log);
        Assert.Equal(1, v.AnzahlZiele());
    }

    [Fact]
    public void Abmelden_ohne_Anmeldung_aendert_nichts()
    {
        var log = new List<string>();
        var v = new Verteiler();
        v.Anmelden(t => log.Add(t));
        Meldung fremd = t => log.Add("fremd");

        v.Abmelden(fremd);
        v.Sende("x");

        Assert.Equal(["x"], log);
        Assert.Equal(1, v.AnzahlZiele());
    }

    [Fact]
    public void Letztes_Ziel_abmelden_leert_die_Liste()
    {
        var log = new List<string>();
        Meldung m = t => log.Add(t);
        var v = new Verteiler();
        v.Anmelden(m);

        v.Abmelden(m);
        v.Sende("x");   // darf nicht abstürzen

        Assert.Empty(log);
        Assert.Equal(0, v.AnzahlZiele());
    }
}
