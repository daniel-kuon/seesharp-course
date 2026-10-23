public class GehaltTests
{
    static Mitarbeiter[] Team() => [
        new Angestellter("Anna", 3200m),
        new Teamleiter("Tina", 4000m, 500m),
        new Freelancer("Fritz", 85m, 40),
    ];

    [Fact]
    public void Mitarbeiter_ist_abstrakt()
    {
        Assert.True(typeof(Mitarbeiter).IsAbstract, "Mitarbeiter muss abstract sein");
        Assert.True(typeof(Mitarbeiter).GetMethod("Gehalt")!.IsAbstract, "Gehalt() muss abstract sein");
    }

    [Fact]
    public void Angestellter_und_Freelancer_berechnen_ihr_Gehalt()
    {
        Mitarbeiter a = new Angestellter("Anna", 3200m);
        Mitarbeiter f = new Freelancer("Fritz", 85m, 40);

        Assert.Equal(3200m, a.Gehalt());
        Assert.Equal(3400m, f.Gehalt());
    }

    [Fact]
    public void Negative_Werte_werden_als_0_uebernommen()
    {
        Assert.Equal(0m, new Angestellter("A", -100m).Gehalt());
        Assert.Equal(3000m, new Teamleiter("T", 3000m, -50m).Gehalt());
        Assert.Equal(0m, new Freelancer("F", -10m, 5).Gehalt());
        Assert.Equal(0, new Freelancer("G", 10m, -5).Stunden);
    }

    [Fact]
    public void Teamleiter_rechnet_mit_dem_Gehalt_des_Angestellten()
    {
        Mitarbeiter t = new Teamleiter("Tina", 4000m, 500m);

        Assert.Equal(4500m, t.Gehalt());
        Assert.Equal(typeof(Angestellter), typeof(Teamleiter).BaseType);
    }

    [Fact]
    public void Beschreibung_nutzt_die_Art_der_Unterklasse()
    {
        var team = Team();

        Assert.Equal("Anna (Angestellt)", team[0].Beschreibung());
        Assert.Equal("Tina (Teamleitung)", team[1].Beschreibung());
        Assert.Equal("Fritz (Freelancer)", team[2].Beschreibung());
    }

    [Fact]
    public void Lohnliste_summiert_und_findet_den_Spitzenverdiener()
    {
        var team = Team();

        Assert.Equal(11100m, Lohnliste.Summe(team));
        Assert.Equal("Tina", Lohnliste.Spitzenverdiener(team));
        Assert.Equal("Fritz", Lohnliste.Spitzenverdiener([new Angestellter("Anna", 3200m), new Freelancer("Fritz", 100m, 40)]));
    }

    [Fact]
    public void Typtest_zaehlt_Teamleiter_als_Angestellte()
    {
        Mitarbeiter[] alle = [.. Team(), new Freelancer("Frida", 90m, 12)];

        Assert.Equal(2, Lohnliste.AnzahlAngestellte(alle));
        Assert.Equal(52, Lohnliste.FreelancerStunden(alle));
    }

    [Fact]
    public void Leere_Lohnliste()
    {
        Assert.Equal(0m, Lohnliste.Summe([]));
        Assert.Equal("", Lohnliste.Spitzenverdiener([]));
        Assert.Equal(0, Lohnliste.AnzahlAngestellte([]));
        Assert.Equal(0, Lohnliste.FreelancerStunden([]));
    }
}
