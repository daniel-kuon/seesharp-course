public class MengenTests
{
    static HashSet<string> M(params string[] namen) => new(namen);

    // ---- Duplikate ----

    [Fact]
    public void Duplikate_meldet_jeden_doppelten_Wert_einmal()
    {
        var d = Mengenwerkzeuge.Duplikate(new[] { 1, 2, 3, 2, 4, 2, 3, 5 });

        Assert.True(d.SetEquals(new[] { 2, 3 }));
        Assert.Equal(2, d.Count);
    }

    [Fact]
    public void Duplikate_ohne_Wiederholung_und_leer()
    {
        Assert.Empty(Mengenwerkzeuge.Duplikate(new[] { 1, 2, 3 }));
        Assert.Empty(Mengenwerkzeuge.Duplikate(Array.Empty<int>()));
    }

    [Fact]
    public void Duplikate_funktioniert_mit_beliebiger_Folge()
    {
        static IEnumerable<int> Folge()
        {
            yield return 7;
            yield return 7;
            yield return 7;
        }

        Assert.True(Mengenwerkzeuge.Duplikate(Folge()).SetEquals(new[] { 7 }));
    }

    // ---- Mengenoperationen mit neuen Mengen ----

    [Fact]
    public void GemeinsameFreunde_liefert_die_Schnittmenge()
    {
        var r = Mengenwerkzeuge.GemeinsameFreunde(M("Ann", "Ben", "Cem"), M("Ben", "Cem", "Dora"));

        Assert.True(r.SetEquals(new[] { "Ben", "Cem" }));
    }

    [Fact]
    public void NurLinks_liefert_die_Differenz()
    {
        var r = Mengenwerkzeuge.NurLinks(M("Ann", "Ben", "Cem"), M("Ben", "Cem", "Dora"));

        Assert.True(r.SetEquals(new[] { "Ann" }));
    }

    [Fact]
    public void Alle_liefert_die_Vereinigung_ohne_Duplikate()
    {
        var r = Mengenwerkzeuge.Alle(M("Ann", "Ben"), M("Ben", "Dora"));

        Assert.True(r.SetEquals(new[] { "Ann", "Ben", "Dora" }));
        Assert.Equal(3, r.Count);
    }

    [Fact]
    public void Mengenoperationen_veraendern_die_Argumente_nicht()
    {
        var a = M("Ann", "Ben", "Cem");
        var b = M("Ben", "Cem", "Dora");

        Mengenwerkzeuge.GemeinsameFreunde(a, b);
        Mengenwerkzeuge.NurLinks(a, b);
        Mengenwerkzeuge.Alle(a, b);

        Assert.True(a.SetEquals(new[] { "Ann", "Ben", "Cem" }));
        Assert.True(b.SetEquals(new[] { "Ben", "Cem", "Dora" }));
    }

    [Fact]
    public void Ergebnis_ist_eine_neue_Menge()
    {
        var a = M("Ann");
        var b = M("Ann");

        var r = Mengenwerkzeuge.GemeinsameFreunde(a, b);
        r.Add("Zoe");

        Assert.NotSame(a, r);
        Assert.DoesNotContain("Zoe", a);
        Assert.DoesNotContain("Zoe", b);
    }

    [Fact]
    public void IstTeilmenge_prueft_die_Enthaltenseinsbeziehung()
    {
        Assert.True(Mengenwerkzeuge.IstTeilmenge(M("Ann"), M("Ann", "Ben")));
        Assert.True(Mengenwerkzeuge.IstTeilmenge(M(), M("Ann")));
        Assert.True(Mengenwerkzeuge.IstTeilmenge(M("Ann", "Ben"), M("Ben", "Ann")));
        Assert.False(Mengenwerkzeuge.IstTeilmenge(M("Ann", "Zoe"), M("Ann", "Ben")));
    }

    // ---- Punkt mit Equals und GetHashCode ----

    [Fact]
    public void HashSet_von_Punkten_erkennt_gleiche_Punkte()
    {
        var menge = new HashSet<Punkt>
        {
            new Punkt(1, 2),
            new Punkt(1, 2),
            new Punkt(1, 2),
            new Punkt(2, 1)
        };

        Assert.Equal(2, menge.Count);
        Assert.Contains(new Punkt(1, 2), menge);
        Assert.Contains(new Punkt(2, 1), menge);
        Assert.DoesNotContain(new Punkt(3, 3), menge);
    }

    [Fact]
    public void Punkt_Add_liefert_false_bei_gleichem_Punkt()
    {
        var menge = new HashSet<Punkt>();

        Assert.True(menge.Add(new Punkt(0, 0)));
        Assert.False(menge.Add(new Punkt(0, 0)));
    }

    [Fact]
    public void Gleiche_Punkte_haben_gleiche_Hashwerte()
    {
        Assert.Equal(new Punkt(4, 5).GetHashCode(), new Punkt(4, 5).GetHashCode());
    }

    [Fact]
    public void Equals_vergleicht_Werte_und_ist_symmetrisch()
    {
        var p = new Punkt(1, 2);
        var q = new Punkt(1, 2);

        Assert.True(p.Equals(q));
        Assert.True(q.Equals(p));
        Assert.True(p.Equals(p));
        Assert.False(p.Equals(new Punkt(2, 1)));
        Assert.False(p.Equals(new Punkt(1, 3)));
    }

    [Fact]
    public void Equals_ist_bei_null_und_fremden_Typen_false()
    {
        var p = new Punkt(1, 2);

        Assert.False(p.Equals(null));
        Assert.False(p.Equals("x"));
        Assert.False(p.Equals(42));
    }

    [Fact]
    public void Punkt_als_Dictionary_Schluessel()
    {
        var namen = new Dictionary<Punkt, string> { [new Punkt(0, 0)] = "Ursprung" };

        Assert.Equal("Ursprung", namen[new Punkt(0, 0)]);
    }

    // ---- ContainsAll: Liste und Menge müssen übereinstimmen ----

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 9 }, false)]
    [InlineData(new[] { 1, 2, 3 }, new int[0], true)]
    [InlineData(new int[0], new[] { 1 }, false)]
    [InlineData(new[] { 1, 1, 2 }, new[] { 2, 2, 1 }, true)]
    public void ContainsAll_Liste_und_Menge_stimmen_ueberein(int[] liste, int[] gesucht, bool erwartet)
    {
        var l = liste.ToList();
        var g = gesucht.ToList();

        Assert.Equal(erwartet, Mengenwerkzeuge.ContainsAllListe(l, g));
        Assert.Equal(erwartet, Mengenwerkzeuge.ContainsAllMenge(l, g));
    }

    [Fact]
    public void ContainsAll_veraendert_die_Listen_nicht()
    {
        var l = new List<int> { 3, 1, 2 };
        var g = new List<int> { 2, 3 };

        Mengenwerkzeuge.ContainsAllListe(l, g);
        Mengenwerkzeuge.ContainsAllMenge(l, g);

        Assert.Equal(new[] { 3, 1, 2 }, l);
        Assert.Equal(new[] { 2, 3 }, g);
    }
}
