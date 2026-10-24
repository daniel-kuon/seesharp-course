public class NotenstatistikTests
{
    private static Notenstatistik Statistik() => new(
    [
        new("Mathe", "Anna", 1.0), new("Mathe", "Bert", 2.3), new("Mathe", "Clara", 4.7), new("Mathe", "Dora", 3.0),
        new("Info", "Anna", 1.3), new("Info", "Bert", 5.0), new("Info", "Clara", 2.0), new("Info", "Emil", 1.7),
        new("Physik", "Dora", 2.7), new("Physik", "Emil", 4.0), new("Physik", "Bert", 3.7), new("Physik", "Anna", 1.0),
    ]);

    [Fact]
    public void Durchschnitt_pro_Fach()
    {
        Assert.Equal(2.75, Statistik().Durchschnitt("Mathe")!.Value, 6);
        Assert.Equal(2.5, Statistik().Durchschnitt("Info")!.Value, 6);
        Assert.Equal(2.85, Statistik().Durchschnitt("Physik")!.Value, 6);
    }

    [Fact]
    public void Durchschnitt_ohne_Pruefung_ist_null()
    {
        Assert.Null(Statistik().Durchschnitt("Chemie"));
        Assert.Null(new Notenstatistik([]).Durchschnitt("Mathe"));
    }

    [Fact]
    public void Bestenliste_ordnet_nach_Note_Student_und_Fach()
    {
        var beste = Statistik().Bestenliste(4);

        Assert.Equal(
            [new Pruefung("Mathe", "Anna", 1.0), new Pruefung("Physik", "Anna", 1.0),
             new Pruefung("Info", "Anna", 1.3), new Pruefung("Info", "Emil", 1.7)],
            beste);
        Assert.Equal(12, Statistik().Bestenliste(100).Count);
        Assert.Empty(Statistik().Bestenliste(0));
    }

    [Fact]
    public void DurchschnittProFach_ist_nach_Fach_sortiert()
    {
        var schnitt = Statistik().DurchschnittProFach();

        Assert.Equal(["Info", "Mathe", "Physik"], schnitt.Select(x => x.Fach));
        Assert.Equal([2.5, 2.75, 2.85], schnitt.Select(x => Math.Round(x.Durchschnitt, 6)));
    }

    [Fact]
    public void Durchgefallene_haben_eine_Note_ueber_4()
    {
        var durchgefallen = Statistik().Durchgefallene();

        Assert.Equal(
            [new Pruefung("Mathe", "Clara", 4.7), new Pruefung("Info", "Bert", 5.0)],
            durchgefallen);   // 4,0 (Emil, Physik) ist noch bestanden
    }

    [Fact]
    public void Leere_Statistik()
    {
        var leer = new Notenstatistik([]);

        Assert.Empty(leer.Bestenliste(3));
        Assert.Empty(leer.DurchschnittProFach());
        Assert.Empty(leer.Durchgefallene());
    }
}
