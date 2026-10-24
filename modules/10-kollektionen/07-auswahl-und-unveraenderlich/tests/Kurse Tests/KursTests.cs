using System.Collections.Immutable;

public class KursTests
{
    [Fact]
    public void Teilnehmer_zeigt_die_Angemeldeten_in_Reihenfolge()
    {
        var kurs = new Kurs();
        kurs.Anmelden("Ann");
        kurs.Anmelden("Ben");

        Assert.Equal(new[] { "Ann", "Ben" }, kurs.Teilnehmer);
    }

    [Fact]
    public void Teilnehmer_ist_eine_Sicht_und_sieht_spaetere_Anmeldungen()
    {
        var kurs = new Kurs();
        kurs.Anmelden("Ann");
        IReadOnlyList<string> sicht = kurs.Teilnehmer;

        kurs.Anmelden("Ben");

        Assert.Equal(2, sicht.Count);
        Assert.Equal("Ben", sicht[1]);
    }

    [Fact]
    public void Teilnehmer_gibt_nicht_die_List_selbst_heraus()
    {
        var kurs = new Kurs();
        kurs.Anmelden("Ann");

        object sicht = kurs.Teilnehmer;

        Assert.False(sicht is List<string>);
        Assert.False(sicht is ICollection<string> { IsReadOnly: false });
    }

    [Fact]
    public void Schnappschuss_enthaelt_die_Teilnehmer_zum_Zeitpunkt_des_Aufrufs()
    {
        var kurs = new Kurs();
        kurs.Anmelden("Ann");
        kurs.Anmelden("Ben");

        ImmutableList<string> foto = kurs.Schnappschuss();

        Assert.Equal(new[] { "Ann", "Ben" }, foto);
    }

    [Fact]
    public void Schnappschuss_sieht_spaetere_Anmeldungen_nicht()
    {
        var kurs = new Kurs();
        kurs.Anmelden("Ann");
        var foto = kurs.Schnappschuss();

        kurs.Anmelden("Ben");

        Assert.Single(foto);
        Assert.Equal(2, kurs.Teilnehmer.Count);
        Assert.Equal(2, kurs.Schnappschuss().Count);
    }

    [Fact]
    public void MitTeilnehmer_liefert_eine_neue_Liste_und_laesst_das_Original_unveraendert()
    {
        var alt = ImmutableList.Create("Ann");

        var neu = Kurs.MitTeilnehmer(alt, "Ben");

        Assert.Equal(new[] { "Ann" }, alt);
        Assert.Equal(new[] { "Ann", "Ben" }, neu);
        Assert.NotSame(alt, neu);
    }

    [Fact]
    public void MitTeilnehmer_auf_leerer_Liste()
    {
        var neu = Kurs.MitTeilnehmer(ImmutableList<string>.Empty, "Zoe");

        Assert.Equal(new[] { "Zoe" }, neu);
    }
}
