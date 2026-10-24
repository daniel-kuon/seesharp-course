using TupelListeMaut;

public class TupelListeMautTests
{
    [Theory]
    [InlineData(Geste.Schere, Geste.Papier, Ergebnis.Erster)]
    [InlineData(Geste.Papier, Geste.Stein, Ergebnis.Erster)]
    [InlineData(Geste.Stein, Geste.Schere, Ergebnis.Erster)]
    [InlineData(Geste.Papier, Geste.Schere, Ergebnis.Zweiter)]
    [InlineData(Geste.Stein, Geste.Papier, Ergebnis.Zweiter)]
    [InlineData(Geste.Schere, Geste.Stein, Ergebnis.Zweiter)]
    [InlineData(Geste.Schere, Geste.Schere, Ergebnis.Unentschieden)]
    [InlineData(Geste.Stein, Geste.Stein, Ergebnis.Unentschieden)]
    [InlineData(Geste.Papier, Geste.Papier, Ergebnis.Unentschieden)]
    public void Sieger_in_allen_neun_Faellen(Geste a, Geste b, Ergebnis erwartet)
    {
        Assert.Equal(erwartet, SchereSteinPapier.Sieger(a, b));
    }

    [Theory]
    [InlineData(25, true, "Spitze")]
    [InlineData(29, true, "Spitze")]
    [InlineData(30, true, "Gut")]
    [InlineData(54, true, "Durchschnitt")]
    [InlineData(55, true, "Genießer")]
    [InlineData(34, false, "Spitze")]
    [InlineData(35, false, "Gut")]
    [InlineData(64, false, "Durchschnitt")]
    [InlineData(65, false, "Genießer")]
    public void Langstrecke_unterscheidet_Geschlecht_und_Zeit(int minuten, bool maenner, string erwartet)
    {
        Assert.Equal(erwartet, Lauf.Langstrecke(minuten, maenner));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Langstrecke_lehnt_unsinnige_Zeiten_ab(int minuten)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Lauf.Langstrecke(minuten, true));
    }

    [Fact]
    public void Listenmuster_Beschreibe()
    {
        Assert.Equal("leer", Listen.Beschreibe([]));
        Assert.Equal("ein Element: 7", Listen.Beschreibe([7]));
        Assert.Equal("von 1 bis 9", Listen.Beschreibe([1, 5, 9]));
        Assert.Equal("von 1 bis 9", Listen.Beschreibe([1, 9]));
        Assert.Equal("zwei Elemente", Listen.Beschreibe([4, 5]));
        Assert.Equal("mehr als zwei, Rest: 1", Listen.Beschreibe([4, 5, 6]));
        Assert.Equal("mehr als zwei, Rest: 3", Listen.Beschreibe([1, 2, 3, 4, 5]));
    }

    [Theory]
    [InlineData(5, Zeitband.Nacht)]
    [InlineData(6, Zeitband.Morgen)]
    [InlineData(9, Zeitband.Morgen)]
    [InlineData(10, Zeitband.Tag)]
    [InlineData(15, Zeitband.Tag)]
    [InlineData(16, Zeitband.Abend)]
    [InlineData(19, Zeitband.Abend)]
    [InlineData(20, Zeitband.Nacht)]
    [InlineData(0, Zeitband.Nacht)]
    public void Band_teilt_den_Tag_ein(int stunde, Zeitband erwartet)
    {
        Assert.Equal(erwartet, MautRechner.Band(new DateTime(2025, 6, 4, stunde, 30, 0)));
    }

    [Fact]
    public void FahrzeugZuschlag_fuer_Auto_und_Taxi()
    {
        Assert.Equal(0.50m, MautRechner.FahrzeugZuschlag(new Auto(0)));
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Auto(1)));
        Assert.Equal(-0.50m, MautRechner.FahrzeugZuschlag(new Auto(2)));
        Assert.Equal(-1.00m, MautRechner.FahrzeugZuschlag(new Auto(4)));
        Assert.Equal(3.50m, MautRechner.FahrzeugZuschlag(new Taxi(0)));
        Assert.Equal(1.00m, MautRechner.FahrzeugZuschlag(new Taxi(1)));
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Taxi(2)));
        Assert.Equal(-0.50m, MautRechner.FahrzeugZuschlag(new Taxi(3)));
    }

    [Fact]
    public void FahrzeugZuschlag_fuer_Bus_und_Lieferwagen()
    {
        Assert.Equal(2.00m, MautRechner.FahrzeugZuschlag(new Bus(10, 40)));
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Bus(20, 40)));   // genau 50 %
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Bus(36, 40)));   // genau 90 %
        Assert.Equal(-1.00m, MautRechner.FahrzeugZuschlag(new Bus(37, 40)));
        Assert.Equal(10.00m, MautRechner.FahrzeugZuschlag(new Lieferwagen(5001)));
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Lieferwagen(5000)));
        Assert.Equal(0m, MautRechner.FahrzeugZuschlag(new Lieferwagen(3000)));
        Assert.Equal(-2.00m, MautRechner.FahrzeugZuschlag(new Lieferwagen(2999)));
    }

    [Fact]
    public void FahrzeugZuschlag_Fehlerfaelle()
    {
        Assert.Throws<ArgumentNullException>(() => MautRechner.FahrzeugZuschlag(null!));
        Assert.Throws<ArgumentException>(() => MautRechner.FahrzeugZuschlag(new Auto(-1)));
    }

    // 2025-06-04 ist ein Mittwoch, 2025-06-07 ein Samstag, 2025-06-08 ein Sonntag.
    [Theory]
    [InlineData(2025, 6, 4, 8, true, 2.00)]    // Mittwoch Morgen ein
    [InlineData(2025, 6, 4, 8, false, 0.50)]   // Mittwoch Morgen aus
    [InlineData(2025, 6, 4, 12, true, 1.50)]   // Mittwoch Tag
    [InlineData(2025, 6, 4, 12, false, 1.50)]
    [InlineData(2025, 6, 4, 17, true, 0.50)]   // Mittwoch Abend ein
    [InlineData(2025, 6, 4, 17, false, 2.00)]  // Mittwoch Abend aus
    [InlineData(2025, 6, 4, 23, true, 0.75)]   // Mittwoch Nacht
    [InlineData(2025, 6, 4, 3, false, 0.75)]
    [InlineData(2025, 6, 7, 8, true, 1.00)]    // Samstag
    [InlineData(2025, 6, 7, 17, false, 1.00)]
    [InlineData(2025, 6, 8, 12, true, 1.00)]   // Sonntag
    [InlineData(2025, 6, 8, 2, false, 1.00)]
    public void ZeitZuschlag_Tabelle_mit_zwoelf_Faellen(int j, int m, int t, int stunde, bool ein, double erwartet)
    {
        Assert.Equal((decimal)erwartet, MautRechner.ZeitZuschlag(new DateTime(j, m, t, stunde, 0, 0), ein));
    }

    [Fact]
    public void Berechne_addiert_Grundgebuehr_Fahrzeug_und_Zeit()
    {
        var mittwochMorgen = new DateTime(2025, 6, 4, 8, 0, 0);
        var samstag = new DateTime(2025, 6, 7, 12, 0, 0);

        // 2,00 + 0 + 2,00
        Assert.Equal(4.00m, MautRechner.Berechne(new Auto(1), mittwochMorgen, true));
        // 2,00 - 1,00 + 2,00
        Assert.Equal(3.00m, MautRechner.Berechne(new Auto(3), mittwochMorgen, true));
        // 2,00 + 3,50 + 1,00
        Assert.Equal(6.50m, MautRechner.Berechne(new Taxi(0), samstag, false));
        // 2,00 + 10,00 + 0,50
        Assert.Equal(12.50m, MautRechner.Berechne(new Lieferwagen(8000), mittwochMorgen, false));
        // 2,00 + 2,00 + 1,00
        Assert.Equal(5.00m, MautRechner.Berechne(new Bus(5, 50), samstag, true));
    }
}
