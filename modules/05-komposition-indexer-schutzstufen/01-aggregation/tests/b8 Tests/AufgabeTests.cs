public class AufgabeTests
{
    [Fact]
    public void Multipliziere_kuerzt_das_Produkt()
    {
        var b = new Bruch(3, 4, "");
        b.Multipliziere(new Bruch(2, 3, ""));

        Assert.Equal((1, 2), (b.Zaehler, b.Nenner));
    }

    [Fact]
    public void Aufgabe_mit_Mal_berechnet_die_Loesung()
    {
        var aufgabe = new Aufgabe('*', 3, 4, 2, 3);

        Assert.Equal((1, 2, "Resultat"), (aufgabe.Loesung.Zaehler, aufgabe.Loesung.Nenner, aufgabe.Loesung.Etikett));
    }

    [Fact]
    public void Aufgabe_mit_Plus_berechnet_die_Loesung()
    {
        var aufgabe = new Aufgabe('+', 1, 2, 2, 5);

        Assert.Equal((9, 10), (aufgabe.Loesung.Zaehler, aufgabe.Loesung.Nenner));
    }

    [Fact]
    public void Pruefe_akzeptiert_auch_ungekuerzte_Antworten()
    {
        var aufgabe = new Aufgabe('*', 3, 4, 2, 3);

        Assert.True(aufgabe.Pruefe(1, 2));
        Assert.True(aufgabe.Pruefe(2, 4));
        Assert.False(aufgabe.Pruefe(1, 3));
    }

    [Fact]
    public void NeueWerte_rechnet_neu_ohne_neue_Bruch_Objekte()
    {
        var aufgabe = new Aufgabe('*', 3, 4, 2, 3);
        var loesung = aufgabe.Loesung;
        var vorher = Bruch.Anzahl;

        aufgabe.NeueWerte('+', 1, 2, 2, 5);

        Assert.Same(loesung, aufgabe.Loesung);
        Assert.Equal((9, 10), (aufgabe.Loesung.Zaehler, aufgabe.Loesung.Nenner));
        Assert.Equal('+', aufgabe.Op);
        Assert.Equal(vorher, Bruch.Anzahl);
    }
}
