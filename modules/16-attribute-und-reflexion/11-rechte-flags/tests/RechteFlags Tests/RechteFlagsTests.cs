public class RechteFlagsTests
{
    [Fact]
    public void Rolle_ist_ein_Bitfeld()
    {
        Assert.True(typeof(Rolle).IsDefined(typeof(FlagsAttribute), false));
    }

    [Fact]
    public void Neuer_Benutzer_hat_keine_Rolle()
    {
        var b = new Benutzer();

        Assert.Equal(Rolle.Keine, b.Rollen);
        Assert.Equal("Keine", b.Beschreibung());
    }

    [Fact]
    public void Vergib_fuegt_Rollen_hinzu_und_behaelt_die_vorhandenen()
    {
        var b = new Benutzer();
        b.Vergib(Rolle.Leser);
        b.Vergib(Rolle.Autor);
        b.Vergib(Rolle.Leser);   // doppelt vergeben ändert nichts

        Assert.Equal(Rolle.Leser | Rolle.Autor, b.Rollen);
    }

    [Fact]
    public void Entziehe_nimmt_nur_die_genannten_Rollen_weg()
    {
        var b = new Benutzer();
        b.Vergib(Rolle.Leser | Rolle.Autor | Rolle.Pruefer);

        b.Entziehe(Rolle.Autor);
        b.Entziehe(Rolle.Admin);   // nicht vorhanden: keine Wirkung

        Assert.Equal(Rolle.Leser | Rolle.Pruefer, b.Rollen);
    }

    [Fact]
    public void Darf_verlangt_alle_benoetigten_Rollen()
    {
        var b = new Benutzer();
        b.Vergib(Rolle.Leser | Rolle.Autor);

        Assert.True(b.Darf(Rolle.Leser));
        Assert.True(b.Darf(Rolle.Leser | Rolle.Autor));
        Assert.False(b.Darf(Rolle.Leser | Rolle.Admin));
        Assert.False(b.Darf(Rolle.Admin));
        Assert.True(b.Darf(Rolle.Keine));
    }

    [Fact]
    public void Beschreibung_zaehlt_die_Rollen_auf()
    {
        var b = new Benutzer();
        b.Vergib(Rolle.Leser | Rolle.Autor);
        Assert.Equal("Leser, Autor", b.Beschreibung());

        b.Vergib(Rolle.Pruefer | Rolle.Admin);
        Assert.Equal("Leser, Autor, Pruefer, Admin", b.Beschreibung());
    }

    [Fact]
    public void Parse_liest_einzelne_und_kombinierte_Rollen()
    {
        Assert.Equal(Rolle.Admin, Benutzer.Parse("Admin"));
        Assert.Equal(Rolle.Leser | Rolle.Autor, Benutzer.Parse("Leser, Autor"));
        Assert.Equal(Rolle.Leser | Rolle.Pruefer, Benutzer.Parse("leser,PRUEFER"));
    }

    [Fact]
    public void Parse_wirft_bei_unbekanntem_Namen()
    {
        Assert.Throws<ArgumentException>(() => Benutzer.Parse("Zauberer"));
    }

    [Fact]
    public void Beschreibung_und_Parse_sind_umkehrbar_fuer_alle_16_Kombinationen()
    {
        for (int bits = 0; bits < 16; bits++)
        {
            var b = new Benutzer();
            b.Vergib((Rolle)bits);

            Assert.Equal((Rolle)bits, Benutzer.Parse(b.Beschreibung()));
            if (bits == 3)
                Assert.Equal("Leser, Autor", b.Beschreibung());   // nicht "3"
        }
    }
}
