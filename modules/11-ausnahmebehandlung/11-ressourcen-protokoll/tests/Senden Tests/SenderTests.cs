// Eine Testverbindung, die mitzählt und auf Wunsch Fehler auslöst.
class ProbeVerbindung : IVerbindung
{
    public Exception? OeffnenFehler { get; init; }
    public int? SendenFehlerBeiNummer { get; init; }   // 1 = erste Nachricht
    public Exception SendenFehler { get; init; } = new IOException("Senden gescheitert");

    public int OeffnenAufrufe { get; private set; }
    public int SchliessenAufrufe { get; private set; }
    public List<string> Gesendet { get; } = new();

    public void Oeffnen()
    {
        OeffnenAufrufe++;
        if (OeffnenFehler != null)
            throw OeffnenFehler;
    }

    public void Senden(string nachricht)
    {
        if (SendenFehlerBeiNummer == Gesendet.Count + 1)
            throw SendenFehler;
        Gesendet.Add(nachricht);
    }

    public void Schliessen()
    {
        SchliessenAufrufe++;
    }
}

public class SenderTests
{
    [Fact]
    public void Erfolg_sendet_alles_und_schliesst_genau_einmal()
    {
        var v = new ProbeVerbindung();
        var sender = new Sender();

        sender.SendeAlle(v, new[] { "a", "b", "c" });

        Assert.Equal(1, v.OeffnenAufrufe);
        Assert.Equal(new[] { "a", "b", "c" }, v.Gesendet);
        Assert.Equal(1, v.SchliessenAufrufe);
        Assert.Equal(0, sender.Fehlschlaege);
    }

    [Fact]
    public void Ohne_Nachrichten_wird_trotzdem_geoeffnet_und_geschlossen()
    {
        var v = new ProbeVerbindung();

        new Sender().SendeAlle(v, Array.Empty<string>());

        Assert.Equal(1, v.OeffnenAufrufe);
        Assert.Equal(1, v.SchliessenAufrufe);
    }

    [Fact]
    public void Sendefehler_wird_unveraendert_weitergereicht_und_die_Verbindung_geschlossen()
    {
        var fehler = new IOException("Leitung unterbrochen");
        var v = new ProbeVerbindung { SendenFehlerBeiNummer = 2, SendenFehler = fehler };
        var sender = new Sender();

        var ex = Assert.Throws<IOException>(() => sender.SendeAlle(v, new[] { "a", "b", "c" }));

        Assert.Same(fehler, ex);
        Assert.Equal(new[] { "a" }, v.Gesendet);
        Assert.Equal(1, v.SchliessenAufrufe);
        Assert.Equal(1, sender.Fehlschlaege);
    }

    [Fact]
    public void Sendefehler_bleibt_ein_Fehler_jeden_Typs()
    {
        var fehler = new TimeoutException("zu langsam");
        var v = new ProbeVerbindung { SendenFehlerBeiNummer = 1, SendenFehler = fehler };

        var ex = Assert.Throws<TimeoutException>(() => new Sender().SendeAlle(v, new[] { "a" }));

        Assert.Same(fehler, ex);
        Assert.Equal(1, v.SchliessenAufrufe);
    }

    [Fact]
    public void Fehler_beim_Oeffnen_wird_verpackt_und_die_Ursache_bleibt_InnerException()
    {
        var ursache = new IOException("Server nicht erreichbar");
        var v = new ProbeVerbindung { OeffnenFehler = ursache };
        var sender = new Sender();

        var ex = Assert.Throws<InvalidOperationException>(() => sender.SendeAlle(v, new[] { "a" }));

        Assert.Equal("Verbindung konnte nicht geöffnet werden", ex.Message);
        Assert.Same(ursache, ex.InnerException);
        Assert.Empty(v.Gesendet);
        Assert.Equal(1, v.SchliessenAufrufe);
        Assert.Equal(0, sender.Fehlschlaege);
    }

    [Fact]
    public void Fehlschlaege_zaehlen_ueber_mehrere_Aufrufe()
    {
        var sender = new Sender();

        for (int i = 0; i < 3; i++)
        {
            var v = new ProbeVerbindung { SendenFehlerBeiNummer = 1 };
            Assert.Throws<IOException>(() => sender.SendeAlle(v, new[] { "x" }));
            Assert.Equal(1, v.SchliessenAufrufe);
        }

        Assert.Equal(3, sender.Fehlschlaege);
    }
}
