using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class BclAttributeTests
{
    static int Zeile([CallerLineNumber] int z = 0) => z;

    [Fact]
    public void Log_beginnt_mit_dem_Namen_der_aufrufenden_Methode()
    {
        string s = Protokoll.Log("hallo");

        Assert.StartsWith(nameof(Log_beginnt_mit_dem_Namen_der_aufrufenden_Methode) + ":", s);
        Assert.EndsWith(": hallo", s);
    }

    [Fact]
    public void Log_liefert_die_Zeilennummer_der_Aufrufstelle()
    {
        string s = Protokoll.Log("x"); int erwartet = Zeile();

        Match m = Regex.Match(s, @"^.+:(\d+): x$");
        Assert.True(m.Success, s);
        Assert.Equal(erwartet, int.Parse(m.Groups[1].Value));
    }

    [Fact]
    public void Log_nimmt_explizite_Angaben_unveraendert_entgegen()
    {
        Assert.Equal("Manuell:7: t", Protokoll.Log("t", "Manuell", 7));
    }

    [Fact]
    public void Alt_ist_als_Obsolete_markiert()
    {
        MethodInfo alt = typeof(Berechnung).GetMethod("Alt")!;
        var attribut = alt.GetCustomAttribute<ObsoleteAttribute>();

        Assert.NotNull(attribut);
        Assert.Equal("Bitte Neu(...) verwenden", attribut!.Message);
        Assert.False(attribut.IsError);
    }

    [Fact]
    public void Neu_ist_nicht_veraltet()
    {
        Assert.Null(typeof(Berechnung).GetMethod("Neu")!.GetCustomAttribute<ObsoleteAttribute>());
        Assert.Equal(5, Berechnung.Neu(2, 3));
    }

    [Fact]
    public void Alt_rechnet_weiter_wie_Neu()
    {
        object? ergebnis = typeof(Berechnung).GetMethod("Alt")!.Invoke(null, [2, 3]);
        Assert.Equal(5, ergebnis);
    }

    [Fact]
    public void Rechte_ist_ein_Bitfeld()
    {
        Assert.True(typeof(Rechte).IsDefined(typeof(FlagsAttribute), false));
    }

    [Fact]
    public void Kombinierte_Rechte_werden_lesbar_ausgegeben()
    {
        Assert.Equal("Lesen, Schreiben", (Rechte.Lesen | Rechte.Schreiben).ToString());
        Assert.Equal("Lesen, Ausfuehren", ((Rechte)5).ToString());
    }

    [Fact]
    public void Hat_prueft_ob_alle_gesuchten_Rechte_vorhanden_sind()
    {
        Assert.True(Rechtepruefung.Hat(Rechte.Lesen | Rechte.Schreiben, Rechte.Lesen));
        Assert.True(Rechtepruefung.Hat(Rechte.Lesen | Rechte.Schreiben, Rechte.Lesen | Rechte.Schreiben));
        Assert.False(Rechtepruefung.Hat(Rechte.Lesen, Rechte.Lesen | Rechte.Schreiben));
        Assert.False(Rechtepruefung.Hat(Rechte.Keine, Rechte.Ausfuehren));
        Assert.True(Rechtepruefung.Hat(Rechte.Keine, Rechte.Keine));
    }

    [Fact]
    public void Entziehe_entfernt_nur_die_genannten_Bits()
    {
        Rechte alle = Rechte.Lesen | Rechte.Schreiben | Rechte.Ausfuehren;

        Assert.Equal(Rechte.Lesen | Rechte.Ausfuehren, Rechtepruefung.Entziehe(alle, Rechte.Schreiben));
        Assert.Equal(Rechte.Keine, Rechtepruefung.Entziehe(alle, alle));
        Assert.Equal(Rechte.Lesen, Rechtepruefung.Entziehe(Rechte.Lesen, Rechte.Ausfuehren));
    }

    [Fact]
    public void Pruefe_akzeptiert_einen_Namen()
    {
        Pruefung.Pruefe("Anna");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Pruefe_wirft_bei_fehlendem_Namen(string? name)
    {
        var ex = Assert.Throws<ArgumentException>(() => Pruefung.Pruefe(name));
        Assert.Equal("Parameter 'name' fehlt", ex.Message);
    }
}
