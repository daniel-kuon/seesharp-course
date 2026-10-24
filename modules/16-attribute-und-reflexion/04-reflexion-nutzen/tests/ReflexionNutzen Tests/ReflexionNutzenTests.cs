using System.Globalization;

public class Zaehler
{
    public int Stand;

    public void Erhoehe() => Stand++;

    public int Zwei() => 2;

    public string Gruss() => "Hallo";

    public string Gruss(string wer) => "Hallo " + wer;   // zweite Überladung: GetMethod("Gruss") wäre mehrdeutig

    public int Addiere(int a, int b) => a + b;           // hat Parameter: wird nicht gefunden

    string Privat() => "geheim";
}

public class GrossPlugin : IPlugin
{
    public string Name => "Gross";
    public string Ausfuehren(string eingabe) => eingabe.ToUpperInvariant();
}

public class UmkehrPlugin : IPlugin
{
    public string Name => "Umkehr";
    public string Ausfuehren(string eingabe) => new string(eingabe.Reverse().ToArray());
}

public abstract class AbstraktesPlugin : IPlugin
{
    public abstract string Name { get; }
    public abstract string Ausfuehren(string eingabe);
}

public class KeinPlugin { }

public class ReflexionNutzenTests
{
    static void MitKultur(string name, Action aktion)
    {
        CultureInfo alt = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo(name);
            aktion();
        }
        finally
        {
            CultureInfo.CurrentCulture = alt;
        }
    }

    // ---------- Mapper.NachZeilen

    [Fact]
    public void NachZeilen_schreibt_nur_Spalten_in_Deklarationsreihenfolge()
    {
        var k = new Kunde { Name = "Anna", Notiz = "geheim", Alter = 30, Rabatt = 2.5, Aktiv = true };

        Assert.Equal(new[] { "name=Anna", "alter=30", "rabatt=2.5", "aktiv=True" }, Mapper.NachZeilen(k));
    }

    [Fact]
    public void NachZeilen_funktioniert_fuer_jeden_Typ_und_macht_null_zum_leeren_Text()
    {
        var k = new Kunde { Name = null! };

        Assert.Equal("name=", Mapper.NachZeilen(k)[0]);
        Assert.Empty(Mapper.NachZeilen(new KeinPlugin()));
    }

    [Fact]
    public void NachZeilen_formatiert_unabhaengig_von_der_Spracheinstellung()
    {
        MitKultur("de-DE", () =>
            Assert.Contains("rabatt=2.5", Mapper.NachZeilen(new Kunde { Rabatt = 2.5 })));
    }

    // ---------- Mapper.VonZeilen

    [Fact]
    public void VonZeilen_setzt_die_Eigenschaften_mit_umgewandelten_Werten()
    {
        Kunde k = Mapper.VonZeilen<Kunde>(["name=Bob", "alter=41", "rabatt=1.25", "aktiv=true"]);

        Assert.Equal("Bob", k.Name);
        Assert.Equal(41, k.Alter);
        Assert.Equal(1.25, k.Rabatt);
        Assert.True(k.Aktiv);
        Assert.Equal("", k.Notiz);
    }

    [Fact]
    public void VonZeilen_ignoriert_unbekannte_Schluessel_und_Zeilen_ohne_Gleichheitszeichen()
    {
        Kunde k = Mapper.VonZeilen<Kunde>(["unbekannt=1", "ohne gleichheitszeichen", "notiz=nicht erlaubt", "name=Eva"]);

        Assert.Equal("Eva", k.Name);
        Assert.Equal("", k.Notiz);   // Notiz hat kein [Spalte]
    }

    [Fact]
    public void VonZeilen_teilt_am_ersten_Gleichheitszeichen()
    {
        Kunde k = Mapper.VonZeilen<Kunde>(["name=a=b"]);
        Assert.Equal("a=b", k.Name);
    }

    [Fact]
    public void VonZeilen_laesst_unlesbare_Werte_unveraendert_und_liest_den_Rest()
    {
        Kunde k = Mapper.VonZeilen<Kunde>(["alter=abc", "rabatt=1.5", "aktiv=vielleicht", "name=Ute"]);

        Assert.Equal(0, k.Alter);
        Assert.Equal(1.5, k.Rabatt);
        Assert.False(k.Aktiv);
        Assert.Equal("Ute", k.Name);
    }

    [Fact]
    public void VonZeilen_liest_unabhaengig_von_der_Spracheinstellung()
    {
        MitKultur("de-DE", () =>
            Assert.Equal(1.5, Mapper.VonZeilen<Kunde>(["rabatt=1.5"]).Rabatt));
    }

    [Fact]
    public void Hin_und_zurueck_ergibt_dieselben_Werte()
    {
        var original = new Kunde { Name = "Clara", Alter = 7, Rabatt = 0.125, Aktiv = true };

        Kunde kopie = Mapper.VonZeilen<Kunde>(Mapper.NachZeilen(original).ToArray());

        Assert.Equal(original.Name, kopie.Name);
        Assert.Equal(original.Alter, kopie.Alter);
        Assert.Equal(original.Rabatt, kopie.Rabatt);
        Assert.Equal(original.Aktiv, kopie.Aktiv);
    }

    // ---------- Aufrufer

    [Fact]
    public void Starte_liefert_das_Ergebnis_der_Methode()
    {
        Assert.Equal(2, Aufrufer.Starte(new Zaehler(), "Zwei"));
    }

    [Fact]
    public void Starte_waehlt_die_parameterlose_Ueberladung()
    {
        Assert.Equal("Hallo", Aufrufer.Starte(new Zaehler(), "Gruss"));
    }

    [Fact]
    public void Starte_fuehrt_void_Methoden_aus_und_liefert_null()
    {
        var z = new Zaehler();

        Assert.Null(Aufrufer.Starte(z, "Erhoehe"));
        Assert.Null(Aufrufer.Starte(z, "Erhoehe"));
        Assert.Equal(2, z.Stand);
    }

    [Theory]
    [InlineData("GibtEsNicht")]
    [InlineData("Addiere")]   // verlangt Parameter
    [InlineData("Privat")]    // nicht öffentlich
    public void Starte_liefert_ein_Fragezeichen_wenn_es_keine_passende_Methode_gibt(string name)
    {
        Assert.Equal("?", Aufrufer.Starte(new Zaehler(), name));
    }

    // ---------- PluginFabrik

    [Fact]
    public void Erzeuge_instanziiert_ein_Plugin_aus_dem_Typnamen()
    {
        IPlugin? p = PluginFabrik.Erzeuge(typeof(GrossPlugin).AssemblyQualifiedName!);

        Assert.IsType<GrossPlugin>(p);
        Assert.Equal("ABC", p!.Ausfuehren("abc"));
    }

    [Fact]
    public void Erzeuge_liefert_bei_jedem_Aufruf_ein_neues_Objekt()
    {
        string name = typeof(UmkehrPlugin).AssemblyQualifiedName!;

        Assert.NotSame(PluginFabrik.Erzeuge(name), PluginFabrik.Erzeuge(name));
        Assert.Equal("cba", PluginFabrik.Erzeuge(name)!.Ausfuehren("abc"));
    }

    [Fact]
    public void Erzeuge_liefert_null_fuer_unbekannte_Typen()
    {
        Assert.Null(PluginFabrik.Erzeuge("Gibt.Es.Nicht, KeineAssembly"));
    }

    [Fact]
    public void Erzeuge_liefert_null_fuer_Typen_ohne_IPlugin()
    {
        Assert.Null(PluginFabrik.Erzeuge(typeof(KeinPlugin).AssemblyQualifiedName!));
        Assert.Null(PluginFabrik.Erzeuge(typeof(string).AssemblyQualifiedName!));
    }

    [Fact]
    public void Erzeuge_liefert_null_fuer_abstrakte_Typen_und_Interfaces()
    {
        Assert.Null(PluginFabrik.Erzeuge(typeof(AbstraktesPlugin).AssemblyQualifiedName!));
        Assert.Null(PluginFabrik.Erzeuge(typeof(IPlugin).AssemblyQualifiedName!));
    }
}
