#pragma warning disable CS0618 // typeof(Veraltet) verwendet absichtlich einen veralteten Typ

[Autor("Clara")]
[Autor("Anton")]
public class Mitarbeiter
{
    [Autor("Zoe")]
    public void Berechne() { }

    public void Ohne() { }

    [Autor("Max")]
    public int Summe(int a, int b) => a + b;

    [Autor("Privat")]
    void Versteckt() { }

    [Autor("Statisch")]
    public static void Hilfe() { }

    public int Alter { get; set; }
    public string Name { get; set; } = "";
    public DateTime Eintritt { get; private set; }
    int Geheim { get; set; }
}

public class OhneAttribute
{
    public int X { get; set; }
    public void Tu() { }
}

[Obsolete("Bitte NeueKlasse verwenden")]
public class Veraltet { }

public class DokumentationTests
{
    [Fact]
    public void AutorenVon_liefert_alle_Autoren_sortiert()
    {
        Assert.Equal(new[] { "Anton", "Clara" }, Dokumentation.AutorenVon(typeof(Mitarbeiter)));
    }

    [Fact]
    public void AutorenVon_ohne_Attribute_ist_leer()
    {
        Assert.Empty(Dokumentation.AutorenVon(typeof(OhneAttribute)));
    }

    [Fact]
    public void MethodenMitAutor_liefert_nur_oeffentliche_Instanzmethoden_mit_Autor()
    {
        Assert.Equal(new[] { "Berechne", "Summe" }, Dokumentation.MethodenMitAutor(typeof(Mitarbeiter)));
    }

    [Fact]
    public void MethodenMitAutor_ohne_Attribute_ist_leer()
    {
        Assert.Empty(Dokumentation.MethodenMitAutor(typeof(OhneAttribute)));
    }

    [Fact]
    public void Eigenschaften_liefert_Name_und_Typ_sortiert()
    {
        Assert.Equal(new[] { "Alter:Int32", "Eintritt:DateTime", "Name:String" },
            Dokumentation.Eigenschaften(typeof(Mitarbeiter)));
        Assert.Equal(new[] { "X:Int32" }, Dokumentation.Eigenschaften(typeof(OhneAttribute)));
    }

    [Fact]
    public void TypName_verwendet_den_Laufzeittyp()
    {
        object text = "Hallo";
        Assert.Equal("String", Dokumentation.TypName(text));
        Assert.Equal("Int32", Dokumentation.TypName(42));
        Assert.Equal("Mitarbeiter", Dokumentation.TypName(new Mitarbeiter()));
    }

    [Fact]
    public void TypNameStatisch_verwendet_den_Typparameter()
    {
        Assert.Equal("Object", Dokumentation.TypNameStatisch<object>());
        Assert.Equal("Int32", Dokumentation.TypNameStatisch<int>());
        Assert.Equal("Mitarbeiter", Dokumentation.TypNameStatisch<Mitarbeiter>());
    }

    [Fact]
    public void Laufzeittyp_und_statischer_Typ_koennen_sich_unterscheiden()
    {
        IEnumerable<int> folge = new List<int>();

        Assert.Equal("List`1", Dokumentation.TypName(folge));
        Assert.Equal("IEnumerable`1", Dokumentation.TypNameStatisch<IEnumerable<int>>());
    }

    [Fact]
    public void Veraltet_liefert_die_Meldung_des_Obsolete_Attributs()
    {
        Assert.Equal("Bitte NeueKlasse verwenden", Dokumentation.Veraltet(typeof(Veraltet)));
    }

    [Fact]
    public void Veraltet_liefert_null_ohne_das_Attribut()
    {
        Assert.Null(Dokumentation.Veraltet(typeof(OhneAttribute)));
    }
}
