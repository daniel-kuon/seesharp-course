public class FehlerAbbruchTests
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(30);   // nur Schutz vor einem Hänger

    static TaskCompletionSource<int> NeueQuelle() => new(TaskCreationOptions.RunContinuationsAsynchronously);

    // ---------- Fehler.Sammle

    [Fact]
    public void Sammle_liefert_die_Meldungen_aller_Fehler_sortiert()
    {
        List<string> meldungen = Fehler.Sammle(
            () => 1,
            () => throw new InvalidOperationException("B: kaputt"),
            () => 2,
            () => throw new ArgumentException("A: ungueltig"));

        Assert.Equal(new[] { "A: ungueltig", "B: kaputt" }, meldungen);
    }

    [Fact]
    public void Sammle_ohne_Fehler_oder_ohne_Aufgaben_ist_leer()
    {
        Assert.Empty(Fehler.Sammle(() => 1, () => 2));
        Assert.Empty(Fehler.Sammle());
    }

    [Fact]
    public void Sammle_loest_verschachtelte_AggregateExceptions_auf()
    {
        List<string> meldungen = Fehler.Sammle(
            () => throw new AggregateException(new InvalidOperationException("C"), new ArgumentException("D")),
            () => throw new InvalidOperationException("E"));

        Assert.Equal(new[] { "C", "D", "E" }, meldungen);
    }

    [Fact]
    public void Sammle_wartet_auf_alle_Aufgaben_auch_wenn_eine_frueh_scheitert()
    {
        int fertig = 0;

        Fehler.Sammle(
            () => throw new InvalidOperationException("sofort"),
            () => { Interlocked.Increment(ref fertig); return 1; },
            () => { Interlocked.Increment(ref fertig); return 2; },
            () => { Interlocked.Increment(ref fertig); return 3; });

        Assert.Equal(3, fertig);
    }

    // ---------- Fehler.ErsteMeldung

    [Fact]
    public void ErsteMeldung_liefert_die_Meldung_der_Ausnahme()
    {
        var quelle = NeueQuelle();
        quelle.SetException(new InvalidOperationException("boom"));

        Assert.Equal("boom", Fehler.ErsteMeldung(quelle.Task));
    }

    [Fact]
    public void ErsteMeldung_ist_null_wenn_nichts_fehlgeschlagen_ist()
    {
        var fertig = NeueQuelle();
        fertig.SetResult(1);
        var abgebrochen = NeueQuelle();
        abgebrochen.SetCanceled();
        var offen = NeueQuelle();

        Assert.Null(Fehler.ErsteMeldung(fertig.Task));
        Assert.Null(Fehler.ErsteMeldung(abgebrochen.Task));
        Assert.Null(Fehler.ErsteMeldung(offen.Task));
    }

    // ---------- Zaehler.ZaehleHoch

    [Fact]
    public void ZaehleHoch_meldet_1000_und_endet_beim_Abbruch_als_abgebrochen()
    {
        using var cts = new CancellationTokenSource();
        using var erreicht = new ManualResetEventSlim();
        Task zaehlen = Task.Run(() => Zaehler.ZaehleHoch(cts.Token, erreicht), cts.Token);
        WaitHandle fertig = ((IAsyncResult)zaehlen).AsyncWaitHandle;

        // Index 0: 'erreicht' wurde gesetzt. Index 1 hieße: Die Aufgabe ist schon vorher zu Ende gegangen.
        int index = WaitHandle.WaitAny([erreicht.WaitHandle, fertig], Wartegrenze);
        Assert.Equal(0, index);

        cts.Cancel();
        Assert.True(fertig.WaitOne(Wartegrenze), "Die Aufgabe hat den Abbruch nicht bemerkt.");

        Assert.True(zaehlen.IsCanceled, $"Zustand: {zaehlen.Status}");
        Assert.False(zaehlen.IsFaulted);
    }

    [Fact]
    public void ZaehleHoch_zaehlt_nichts_wenn_das_Token_schon_abgebrochen_ist()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();
        using var erreicht = new ManualResetEventSlim();

        Assert.ThrowsAny<OperationCanceledException>(() => Zaehler.ZaehleHoch(cts.Token, erreicht));
        Assert.False(erreicht.IsSet);
    }

    // ---------- Suche.ErstenTreffer

    [Fact]
    public void ErstenTreffer_findet_das_erste_passende_Element_oder_null()
    {
        Assert.Equal(6, Suche.ErstenTreffer([1, 3, 6, 8, 10], x => x % 2 == 0, CancellationToken.None));
        Assert.Null(Suche.ErstenTreffer([1, 3, 5], x => x % 2 == 0, CancellationToken.None));
        Assert.Null(Suche.ErstenTreffer([], x => true, CancellationToken.None));
    }

    [Fact]
    public void ErstenTreffer_ruft_das_Praedikat_bei_abgebrochenem_Token_nie_auf()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();
        int aufrufe = 0;

        Assert.ThrowsAny<OperationCanceledException>(() =>
            Suche.ErstenTreffer([1, 2, 3], x => { aufrufe++; return true; }, cts.Token));

        Assert.Equal(0, aufrufe);
    }

    [Fact]
    public void ErstenTreffer_bemerkt_einen_Abbruch_mitten_in_der_Suche()
    {
        using var cts = new CancellationTokenSource();
        int aufrufe = 0;

        Assert.ThrowsAny<OperationCanceledException>(() =>
            Suche.ErstenTreffer(Enumerable.Range(1, 100), x =>
            {
                aufrufe++;
                if (x == 3)
                    cts.Cancel();   // Der Abbruch kommt beim dritten Element, während die Suche läuft.
                return false;
            }, cts.Token));

        Assert.Equal(3, aufrufe);
    }
}
