public class AuskunftTests
{
    private static Auskunft Bibliothek() => new(
        [
            new Buch(10, "Der Process", 1), new Buch(11, "Die Verwandlung", 1), new Buch(12, "Der Zauberberg", 2),
            new Buch(13, "Siddhartha", 3), new Buch(14, "Unbekannt", 99),
        ],
        [new Autor(1, "Kafka"), new Autor(2, "Mann"), new Autor(3, "Hesse")],
        [
            new Ausleihe(10, "Eva"), new Ausleihe(12, "Eva"), new Ausleihe(10, "Tom"), new Ausleihe(13, "Tom"),
            new Ausleihe(99, "Tom"),   // Buch 99 gibt es nicht
        ]);

    [Fact]
    public void BuecherMitAutor_laesst_Buecher_ohne_bekannten_Autor_weg()
    {
        Assert.Equal(
            [("Der Process", "Kafka"), ("Der Zauberberg", "Mann"), ("Die Verwandlung", "Kafka"), ("Siddhartha", "Hesse")],
            Bibliothek().BuecherMitAutor());
    }

    [Fact]
    public void Ausleihen_eines_Lesers()
    {
        Assert.Equal(["Der Process", "Der Zauberberg"], Bibliothek().Ausleihen("Eva"));
        Assert.Equal(["Der Process", "Siddhartha"], Bibliothek().Ausleihen("Tom"));   // Buch 99 fehlt
        Assert.Empty(Bibliothek().Ausleihen("Niemand"));
    }

    [Fact]
    public void NieAusgeliehen_findet_Buecher_ohne_Ausleihe()
    {
        Assert.Equal(["Die Verwandlung", "Unbekannt"], Bibliothek().NieAusgeliehen());
    }

    [Fact]
    public void Ohne_Ausleihen_sind_alle_Buecher_nie_ausgeliehen()
    {
        var a = new Auskunft([new Buch(1, "B", 1), new Buch(2, "A", 1)], [new Autor(1, "X")], []);

        Assert.Equal(["A", "B"], a.NieAusgeliehen());
        Assert.Equal([("A", "X"), ("B", "X")], a.BuecherMitAutor());
    }
}
