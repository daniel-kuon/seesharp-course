using System.Text;
using Ressourcenfreigabe;

public class FreigabeTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    static IEnumerable<string> ZeilenMitIoFehler()
    {
        yield return "erste";
        throw new IOException("Datenträger entfernt");
    }

    static IEnumerable<string> ZeilenMitLogikFehler()
    {
        yield return "erste";
        throw new InvalidOperationException("Programmfehler");
    }

    // ---------- SchreibeText: using-Anweisung ----------

    [Fact]
    public void SchreibeText_schreibt_und_gibt_einmal_frei()
    {
        var strom = new ZaehlenderStrom("ziel");
        Freigabe.SchreibeText(() => strom, "Grüße");
        Assert.Equal(Encoding.UTF8.GetBytes("Grüße"), strom.Inhalt);
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    [Fact]
    public void SchreibeText_gibt_auch_bei_einer_Ausnahme_frei()
    {
        var strom = new ZaehlenderStrom("ziel") { WerfeBeimSchreiben = true };
        Assert.Throws<IOException>(() => Freigabe.SchreibeText(() => strom, "x"));
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    // ---------- Kopiere: geschachtelte using-Anweisungen ----------

    [Fact]
    public void Kopiere_kopiert_und_gibt_zuerst_das_Ziel_dann_die_Quelle_frei()
    {
        var protokoll = new List<string>();
        var quelle = new ZaehlenderStrom("quelle", protokoll, [1, 2, 3, 4]);
        var ziel = new ZaehlenderStrom("ziel", protokoll);

        Freigabe.Kopiere(() => quelle, () => ziel);

        Assert.Equal(new byte[] { 1, 2, 3, 4 }, ziel.Inhalt);
        Assert.Equal(1, quelle.DisposeAufrufe);
        Assert.Equal(1, ziel.DisposeAufrufe);
        Assert.Equal(["dispose:ziel", "dispose:quelle"], protokoll);
    }

    [Fact]
    public void Kopiere_gibt_beide_Stroeme_frei_wenn_das_Kopieren_scheitert()
    {
        var protokoll = new List<string>();
        var quelle = new ZaehlenderStrom("quelle", protokoll, [1, 2, 3]) { WerfeBeimLesen = true };
        var ziel = new ZaehlenderStrom("ziel", protokoll);

        Assert.Throws<IOException>(() => Freigabe.Kopiere(() => quelle, () => ziel));

        Assert.Equal(1, quelle.DisposeAufrufe);
        Assert.Equal(1, ziel.DisposeAufrufe);
        Assert.Equal(["dispose:ziel", "dispose:quelle"], protokoll);
    }

    [Fact]
    public void Kopiere_gibt_die_Quelle_frei_wenn_das_Ziel_nicht_geoeffnet_werden_kann()
    {
        var quelle = new ZaehlenderStrom("quelle", null, [1]);
        Assert.Throws<UnauthorizedAccessException>(() =>
            Freigabe.Kopiere(() => quelle, () => throw new UnauthorizedAccessException("kein Zugriff")));
        Assert.Equal(1, quelle.DisposeAufrufe);
    }

    // ---------- ZaehleBytes: using-Deklaration ----------

    [Fact]
    public void ZaehleBytes_zaehlt_und_gibt_einmal_frei()
    {
        var strom = new ZaehlenderStrom("quelle", null, new byte[250]);
        Assert.Equal(250, Freigabe.ZaehleBytes(() => strom));
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    [Fact]
    public void ZaehleBytes_gibt_auch_bei_einer_Ausnahme_frei()
    {
        var strom = new ZaehlenderStrom("quelle", null, new byte[10]) { WerfeBeimLesen = true };
        Assert.Throws<IOException>(() => Freigabe.ZaehleBytes(() => strom));
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    // ---------- Verarbeite: Freigabe, wenn die Aktion wirft ----------

    [Fact]
    public void Verarbeite_ruft_die_Aktion_auf_und_gibt_einmal_frei()
    {
        var strom = new ZaehlenderStrom("quelle", null, [7]);
        int gelesen = -1;
        Freigabe.Verarbeite(() => strom, s => gelesen = s.ReadByte());
        Assert.Equal(7, gelesen);
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    [Fact]
    public void Verarbeite_gibt_frei_wenn_die_Aktion_wirft()
    {
        var strom = new ZaehlenderStrom("quelle");
        var fehler = Assert.Throws<InvalidOperationException>(() =>
            Freigabe.Verarbeite(() => strom, _ => throw new InvalidOperationException("Aktion kaputt")));
        Assert.Equal("Aktion kaputt", fehler.Message);
        Assert.Equal(1, strom.DisposeAufrufe);
    }

    // ---------- SchreibeSicher: using in try/catch ----------

    [Fact]
    public void SchreibeSicher_schreibt_und_liefert_true()
    {
        var pfad = _ordner.Datei("ok.txt");
        Assert.True(Freigabe.SchreibeSicher(pfad, ["a", "b"]));
        Assert.Equal(["a", "b"], File.ReadAllLines(pfad));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void SchreibeSicher_liefert_false_wenn_der_Ordner_fehlt()
    {
        var pfad = Path.Combine(_ordner.Pfad, "gibt es nicht", "x.txt");
        Assert.False(Freigabe.SchreibeSicher(pfad, ["a"]));
    }

    [Fact]
    public void SchreibeSicher_schliesst_die_Datei_nach_einem_IO_Fehler_beim_Schreiben()
    {
        var pfad = _ordner.Datei("teilweise.txt");
        Assert.False(Freigabe.SchreibeSicher(pfad, ZeilenMitIoFehler()));
        TestOrdner.PruefeDateiFrei(pfad);
        Assert.Equal(["erste"], File.ReadAllLines(pfad));
    }

    [Fact]
    public void SchreibeSicher_laesst_andere_Ausnahmen_durch_und_schliesst_trotzdem()
    {
        var pfad = _ordner.Datei("logik.txt");
        Assert.Throws<InvalidOperationException>(() => Freigabe.SchreibeSicher(pfad, ZeilenMitLogikFehler()));
        TestOrdner.PruefeDateiFrei(pfad);
    }

    // ---------- Logger: AutoFlush ----------

    [Fact]
    public void Logger_schaltet_AutoFlush_ein()
    {
        var logger = new Logger(new ZaehlenderStrom("log"));
        Assert.True(logger.AutoFlush);
    }

    [Fact]
    public void Logger_Zeile_ist_sofort_im_Strom_sichtbar()
    {
        var strom = new ZaehlenderStrom("log");
        var logger = new Logger(strom);
        logger.Log("hallo");
        Assert.Equal("hallo" + Environment.NewLine, Encoding.UTF8.GetString(strom.Inhalt));
        logger.Log("welt");
        Assert.Equal("hallo" + Environment.NewLine + "welt" + Environment.NewLine, Encoding.UTF8.GetString(strom.Inhalt));
    }

    [Fact]
    public void Logger_SchreibeViele_schreibt_alle_Zeilen_mit_hoechstens_wenigen_Flushes()
    {
        var strom = new ZaehlenderStrom("log");
        var logger = new Logger(strom);
        int vorher = strom.FlushAufrufe;

        logger.SchreibeViele(1000);

        var zeilen = Encoding.UTF8.GetString(strom.Inhalt).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal(1000, zeilen.Length);
        Assert.Equal("Eintrag 1", zeilen[0]);
        Assert.Equal("Eintrag 1000", zeilen[^1]);
        Assert.True(strom.FlushAufrufe - vorher <= 5,
            $"Zu viele Flush-Aufrufe: {strom.FlushAufrufe - vorher}. Schalte AutoFlush für die Schleife aus und leere den Puffer einmal.");
    }

    [Fact]
    public void Logger_hat_nach_SchreibeViele_wieder_AutoFlush()
    {
        var strom = new ZaehlenderStrom("log");
        var logger = new Logger(strom);
        logger.SchreibeViele(10);
        Assert.True(logger.AutoFlush);

        long laenge = strom.Length;
        logger.Log("danach");
        Assert.True(strom.Length > laenge, "Die Zeile nach SchreibeViele ist nicht sofort im Strom.");
    }
}
