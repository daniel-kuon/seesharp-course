public class WoerterbuecherTests
{
    static Dictionary<string, int> Zaehler(params (string wort, int anzahl)[] paare)
    {
        var d = new Dictionary<string, int>();
        foreach (var (wort, anzahl) in paare)
            d[wort] = anzahl;
        return d;
    }

    // ---- Haeufigkeiten ----

    [Fact]
    public void Haeufigkeiten_zaehlt_Woerter_ohne_Beachtung_der_Schreibweise()
    {
        var d = Woerterbuecher.Haeufigkeiten("Der Hund und der Hase. DER hund!");

        Assert.Equal(4, d.Count);
        Assert.Equal(3, d["der"]);
        Assert.Equal(2, d["hund"]);
        Assert.Equal(1, d["und"]);
        Assert.Equal(1, d["hase"]);
    }

    [Fact]
    public void Haeufigkeiten_findet_Schluessel_in_jeder_Schreibweise()
    {
        var d = Woerterbuecher.Haeufigkeiten("der Der DER");

        Assert.Equal(3, d["DER"]);
        Assert.Equal(3, d["Der"]);
        Assert.True(d.ContainsKey("dEr"));
    }

    [Fact]
    public void Haeufigkeiten_trennt_an_allem_was_kein_Buchstabe_ist()
    {
        var d = Woerterbuecher.Haeufigkeiten("eins,zwei;drei--eins 2024 zwei...");

        Assert.Equal(3, d.Count);
        Assert.Equal(2, d["eins"]);
        Assert.Equal(2, d["zwei"]);
        Assert.Equal(1, d["drei"]);
    }

    [Fact]
    public void Haeufigkeiten_kennt_Umlaute_und_leere_Texte()
    {
        var d = Woerterbuecher.Haeufigkeiten("Äpfel äpfel ÄPFEL");

        Assert.Single(d);
        Assert.Equal(3, d["äpfel"]);
        Assert.Empty(Woerterbuecher.Haeufigkeiten(""));
        Assert.Empty(Woerterbuecher.Haeufigkeiten("  ... 123 "));
    }

    // ---- Nachschlagen und Eintragen ----

    [Fact]
    public void Nachschlagen_liefert_Nummer_oder_unbekannt()
    {
        var buch = new Dictionary<string, string> { ["Ann"] = "123", ["Ben"] = "456" };

        Assert.Equal("123", Woerterbuecher.Nachschlagen(buch, "Ann"));
        Assert.Equal("456", Woerterbuecher.Nachschlagen(buch, "Ben"));
        Assert.Equal("unbekannt", Woerterbuecher.Nachschlagen(buch, "Cem"));
        Assert.Equal("unbekannt", Woerterbuecher.Nachschlagen(new Dictionary<string, string>(), "Ann"));
    }

    [Fact]
    public void Nachschlagen_veraendert_das_Buch_nicht()
    {
        var buch = new Dictionary<string, string> { ["Ann"] = "123" };

        Woerterbuecher.Nachschlagen(buch, "Zoe");

        Assert.Single(buch);
    }

    [Fact]
    public void Eintragen_legt_an_und_ueberschreibt_beim_zweiten_Mal()
    {
        var buch = new Dictionary<string, string>();

        Woerterbuecher.Eintragen(buch, "Ann", "111");
        Woerterbuecher.Eintragen(buch, "Ben", "222");
        Woerterbuecher.Eintragen(buch, "Ann", "999");

        Assert.Equal(2, buch.Count);
        Assert.Equal("999", buch["Ann"]);
        Assert.Equal("222", buch["Ben"]);
    }

    // ---- Umkehren ----

    [Fact]
    public void Umkehren_gruppiert_Woerter_nach_Haeufigkeit()
    {
        var umgekehrt = Woerterbuecher.Umkehren(Zaehler(("a", 2), ("b", 1), ("c", 2), ("d", 3), ("e", 1)));

        Assert.Equal(3, umgekehrt.Count);
        Assert.Equal(new[] { "a", "c" }, umgekehrt[2].OrderBy(w => w));
        Assert.Equal(new[] { "b", "e" }, umgekehrt[1].OrderBy(w => w));
        Assert.Equal(new[] { "d" }, umgekehrt[3]);
    }

    [Fact]
    public void Umkehren_leeres_Dictionary()
    {
        Assert.Empty(Woerterbuecher.Umkehren(new Dictionary<string, int>()));
    }

    // ---- Haeufigste ----

    [Fact]
    public void Haeufigste_sortiert_nach_Anzahl_dann_alphabetisch()
    {
        var d = Zaehler(("d", 1), ("b", 3), ("c", 5), ("a", 3));

        Assert.Equal(new[] { "c", "a" }, Woerterbuecher.Haeufigste(d, 2));
        Assert.Equal(new[] { "c", "a", "b" }, Woerterbuecher.Haeufigste(d, 3));
    }

    [Fact]
    public void Haeufigste_mit_zu_grossem_oder_null_n()
    {
        var d = Zaehler(("x", 2), ("y", 1));

        Assert.Equal(new[] { "x", "y" }, Woerterbuecher.Haeufigste(d, 10));
        Assert.Empty(Woerterbuecher.Haeufigste(d, 0));
        Assert.Empty(Woerterbuecher.Haeufigste(new Dictionary<string, int>(), 3));
    }

    [Fact]
    public void Haeufigste_aus_einem_Text()
    {
        var d = Woerterbuecher.Haeufigkeiten("zu zu zu und und der die das");

        Assert.Equal(new[] { "zu", "und", "das" }, Woerterbuecher.Haeufigste(d, 3));
    }

    // ---- Summe und Schluessel ----

    [Fact]
    public void Summe_addiert_alle_Haeufigkeiten()
    {
        Assert.Equal(11, Woerterbuecher.Summe(Zaehler(("a", 5), ("b", 4), ("c", 2))));
        Assert.Equal(0, Woerterbuecher.Summe(new Dictionary<string, int>()));
    }

    [Fact]
    public void Summe_entspricht_der_Anzahl_der_Woerter_im_Text()
    {
        var d = Woerterbuecher.Haeufigkeiten("a b a c b a");

        Assert.Equal(6, Woerterbuecher.Summe(d));
    }

    [Fact]
    public void Schluessel_sind_alphabetisch_sortiert()
    {
        var d = Zaehler(("zebra", 1), ("apfel", 2), ("maus", 3));

        Assert.Equal(new[] { "apfel", "maus", "zebra" }, Woerterbuecher.Schluessel(d));
        Assert.Empty(Woerterbuecher.Schluessel(new Dictionary<string, int>()));
    }
}
