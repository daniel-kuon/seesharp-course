using System.Runtime.CompilerServices;

// Testdoubles: Arbeitsschritte, die tun, was der Test braucht.
class ErfolgreicherSchritt : IArbeitsschritt
{
    public int Aufrufe { get; private set; }

    public void Ausfuehren() => Aufrufe++;
}

class WirftSchritt(Exception fehler) : IArbeitsschritt
{
    public void Ausfuehren() => throw fehler;
}

class DefekterSchritt : IArbeitsschritt
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Ausfuehren()
    {
        throw new IOException("Platte voll");
    }
}

public class AblaufTests
{
    [Fact]
    public void Verarbeite_ohne_Fehler_schreibt_start_und_ende()
    {
        var schritt = new ErfolgreicherSchritt();
        var protokoll = new Protokoll();

        bool ok = Ablauf.Verarbeite(schritt, protokoll);

        Assert.True(ok);
        Assert.Equal(1, schritt.Aufrufe);
        Assert.Equal(new[] { "start", "ende" }, protokoll.Zeilen);
    }

    [Fact]
    public void Voruebergehende_IOException_wird_ignoriert()
    {
        var protokoll = new Protokoll();
        var schritt = new WirftSchritt(new IOException("temporär: Datei gesperrt"));

        bool ok = Ablauf.Verarbeite(schritt, protokoll);

        Assert.False(ok);
        Assert.Equal(new[] { "start", "ignoriert", "ende" }, protokoll.Zeilen);
    }

    [Fact]
    public void Andere_IOException_wird_verpackt_und_die_Ursache_bleibt_InnerException()
    {
        var protokoll = new Protokoll();
        var original = new IOException("Platte voll");

        var ex = Assert.Throws<InvalidOperationException>(
            () => Ablauf.Verarbeite(new WirftSchritt(original), protokoll));

        Assert.Equal("Verarbeitung fehlgeschlagen", ex.Message);
        Assert.Same(original, ex.InnerException);
        Assert.Equal(new[] { "start", "ende" }, protokoll.Zeilen);
    }

    [Fact]
    public void IOException_deren_Meldung_nur_irgendwo_temporaer_enthaelt_wird_nicht_ignoriert()
    {
        var protokoll = new Protokoll();

        Assert.Throws<InvalidOperationException>(
            () => Ablauf.Verarbeite(new WirftSchritt(new IOException("kein temporär")), protokoll));
    }

    [Fact]
    public void Andere_Ausnahmen_laufen_unveraendert_nach_oben_und_ende_wird_trotzdem_geschrieben()
    {
        var protokoll = new Protokoll();
        var original = new ArgumentException("falsch");

        var ex = Assert.Throws<ArgumentException>(
            () => Ablauf.Verarbeite(new WirftSchritt(original), protokoll));

        Assert.Same(original, ex);
        Assert.Equal(new[] { "start", "ende" }, protokoll.Zeilen);
    }

    [Fact]
    public void Ende_wird_in_jedem_Fall_genau_einmal_geschrieben()
    {
        Exception?[] fehler =
        {
            null,
            new IOException("temporär"),
            new IOException("kaputt"),
            new InvalidOperationException()
        };

        foreach (Exception? f in fehler)
        {
            var protokoll = new Protokoll();
            IArbeitsschritt schritt = f is null ? new ErfolgreicherSchritt() : new WirftSchritt(f);
            try
            {
                Ablauf.Verarbeite(schritt, protokoll);
            }
            catch (Exception)
            {
                // Ob die Ausnahme ankommt, prüfen andere Tests.
            }

            Assert.Equal(1, protokoll.Zeilen.Count(z => z == "ende"));
            Assert.Equal("ende", protokoll.Zeilen[^1]);
        }
    }

    [Fact]
    public void ProtokolliereUndWirfWeiter_ohne_Fehler_laesst_das_Protokoll_leer()
    {
        var protokoll = new Protokoll();

        Ablauf.ProtokolliereUndWirfWeiter(new ErfolgreicherSchritt(), protokoll);

        Assert.Empty(protokoll.Zeilen);
    }

    [Fact]
    public void ProtokolliereUndWirfWeiter_reicht_dieselbe_Ausnahme_weiter()
    {
        var protokoll = new Protokoll();
        var original = new IOException("Platte voll");

        var ex = Assert.Throws<IOException>(
            () => Ablauf.ProtokolliereUndWirfWeiter(new WirftSchritt(original), protokoll));

        Assert.Same(original, ex);
        Assert.Equal(new[] { "fehler: IOException" }, protokoll.Zeilen);
    }

    [Fact]
    public void ProtokolliereUndWirfWeiter_erhaelt_die_Stapelueberwachung_des_Ursprungs()
    {
        var protokoll = new Protokoll();

        var ex = Assert.Throws<IOException>(
            () => Ablauf.ProtokolliereUndWirfWeiter(new DefekterSchritt(), protokoll));

        // Mit "throw ex;" fehlte der Eintrag des Schritts, der den Fehler ausgelöst hat.
        Assert.Contains("DefekterSchritt.Ausfuehren", ex.StackTrace);
        Assert.Contains("ProtokolliereUndWirfWeiter", ex.StackTrace);
    }
}
