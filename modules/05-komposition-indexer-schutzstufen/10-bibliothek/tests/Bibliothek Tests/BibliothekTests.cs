public class BibliothekTests
{
    static Bibliothek Drei()
    {
        var bib = new Bibliothek();
        bib.Add(new Buch("Der Process", "Kafka", 1925));
        bib.Add(new Buch("Effi Briest", "Fontane", 1896));
        bib.Add(new Buch("Das Schloss", "Kafka", 1926));
        return bib;
    }

    [Fact]
    public void ToString_zeigt_Titel_Autor_und_Jahr()
    {
        Assert.Equal("Der Process (Kafka, 1925)", new Buch("Der Process", "Kafka", 1925).ToString());
    }

    [Fact]
    public void Add_erhoeht_Anzahl()
    {
        var bib = new Bibliothek();
        Assert.Equal(0, bib.Anzahl);

        bib.Add(new Buch("A", "X", 2000));
        bib.Add(new Buch("B", "Y", 2001));

        Assert.Equal(2, bib.Anzahl);
    }

    [Fact]
    public void Int_Indexer_liefert_Buecher_in_Einfuegereihenfolge()
    {
        var bib = Drei();

        Assert.Equal("Der Process", bib[0].Titel);
        Assert.Equal("Effi Briest", bib[1].Titel);
        Assert.Equal("Das Schloss", bib[2].Titel);
    }

    [Fact]
    public void Int_Indexer_wirft_bei_ungueltigem_Index()
    {
        var bib = Drei();

        Assert.Throws<ArgumentOutOfRangeException>(() => bib[3]);
        Assert.Throws<ArgumentOutOfRangeException>(() => bib[-1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => new Bibliothek()[0]);
    }

    [Fact]
    public void String_Indexer_findet_das_Buch_oder_liefert_null()
    {
        var bib = Drei();

        Assert.Same(bib[1], bib["Effi Briest"]);
        Assert.Null(bib["Faust"]);
    }

    [Fact]
    public void Ausleihen_nur_einmal()
    {
        var bib = Drei();

        Assert.True(bib.Ausleihen("Effi Briest"));
        Assert.True(bib[1].Ausgeliehen);
        Assert.False(bib.Ausleihen("Effi Briest"));
        Assert.False(bib.Ausleihen("Faust"));
    }

    [Fact]
    public void Zurueckgeben_nur_wenn_ausgeliehen()
    {
        var bib = Drei();

        Assert.False(bib.Zurueckgeben("Der Process"));
        bib.Ausleihen("Der Process");
        Assert.True(bib.Zurueckgeben("Der Process"));
        Assert.False(bib[0].Ausgeliehen);
        Assert.False(bib.Zurueckgeben("Faust"));
    }

    [Fact]
    public void Verfuegbar_zaehlt_nicht_ausgeliehene_Buecher()
    {
        var bib = Drei();
        Assert.Equal(3, bib.Verfuegbar);

        bib.Ausleihen("Der Process");
        bib.Ausleihen("Das Schloss");

        Assert.Equal(1, bib.Verfuegbar);
        Assert.Equal(0, new Bibliothek().Verfuegbar);
    }

    [Fact]
    public void VonAutor_listet_Titel_mit_Komma()
    {
        var bib = Drei();

        Assert.Equal("Der Process, Das Schloss", bib.VonAutor("Kafka"));
        Assert.Equal("Effi Briest", bib.VonAutor("Fontane"));
        Assert.Equal("", bib.VonAutor("Goethe"));
    }
}
