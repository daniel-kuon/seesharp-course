using System.Reflection;

public class AsyncAwaitTests : IDisposable
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(30);   // nur Schutz vor einem Hänger

    readonly string _ordner = Path.Combine(Path.GetTempPath(), "seesharp-async-" + Guid.NewGuid().ToString("N"));

    public AsyncAwaitTests() => Directory.CreateDirectory(_ordner);

    public void Dispose() => Directory.Delete(_ordner, recursive: true);

    // Wartet ohne zu blockieren, höchstens bis zur Wartegrenze; ein Hänger wird so zu einem Testfehler.
    static async Task<T> MitGrenze<T>(Task<T> aufgabe)
    {
        Task fertig = await Task.WhenAny(aufgabe, Task.Delay(Wartegrenze));
        Assert.True(ReferenceEquals(fertig, aufgabe), "Die Aufgabe wurde nicht rechtzeitig fertig (blockiert oder hängt).");
        return await aufgabe;
    }

    static TaskCompletionSource<int> NeueQuelle() => new(TaskCreationOptions.RunContinuationsAsynchronously);

    // ---------- Dateien

    [Fact]
    public async Task LiesLaengeAsync_liefert_die_Anzahl_der_Zeichen()
    {
        string pfad = Path.Combine(_ordner, "a.txt");
        File.WriteAllText(pfad, "Hallo Welt");
        string umlaute = Path.Combine(_ordner, "b.txt");
        File.WriteAllText(umlaute, "äöü");
        string leer = Path.Combine(_ordner, "c.txt");
        File.WriteAllText(leer, "");

        Assert.Equal(10, await MitGrenze(Dateien.LiesLaengeAsync(pfad)));
        Assert.Equal(3, await MitGrenze(Dateien.LiesLaengeAsync(umlaute)));
        Assert.Equal(0, await MitGrenze(Dateien.LiesLaengeAsync(leer)));
    }

    [Fact]
    public async Task LiesLaengeAsync_gibt_beim_await_die_urspruengliche_Ausnahme_weiter()
    {
        await Assert.ThrowsAsync<FileNotFoundException>(
            () => Dateien.LiesLaengeAsync(Path.Combine(_ordner, "gibt-es-nicht.txt")));
    }

    // Die Methode wird per Reflexion aufgerufen, damit das Testprojekt auch mit "async void" übersetzt.
    static Task SpeichereAufrufen(string pfad, string text)
    {
        MethodInfo methode = typeof(Dateien).GetMethod(nameof(Dateien.SpeichereAsync))!;
        Assert.True(methode.ReturnType == typeof(Task),
            $"SpeichereAsync liefert {methode.ReturnType.Name}. Eine async-Methode gehört auf Task (oder Task<T>), nicht auf void.");
        return (Task)methode.Invoke(null, [pfad, text])!;
    }

    [Fact]
    public async Task SpeichereAsync_liefert_eine_Task_auf_die_man_warten_kann()
    {
        string pfad = Path.Combine(_ordner, "ziel.txt");

        await SpeichereAufrufen(pfad, "gespeichert");

        Assert.Equal("gespeichert", File.ReadAllText(pfad));
    }

    [Fact]
    public async Task SpeichereAsync_meldet_Fehler_ueber_die_Task()
    {
        string pfad = Path.Combine(_ordner, "gibt-es-nicht", "ziel.txt");

        await Assert.ThrowsAsync<DirectoryNotFoundException>(() => SpeichereAufrufen(pfad, "x"));
    }

    // ---------- SummeAsync

    [Fact]
    public async Task SummeAsync_wartet_auf_alle_und_summiert()
    {
        var q1 = NeueQuelle();
        var q2 = NeueQuelle();
        var q3 = NeueQuelle();

        Task<int> summe = Asynchron.SummeAsync([q1.Task, q2.Task, q3.Task]);
        Assert.False(summe.IsCompleted);

        q3.SetResult(30);
        q1.SetResult(10);
        Assert.False(summe.IsCompleted);   // q2 fehlt noch
        q2.SetResult(2);

        Assert.Equal(42, await MitGrenze(summe));
    }

    [Fact]
    public async Task SummeAsync_blockiert_den_Aufrufer_nicht()
    {
        var q1 = NeueQuelle();
        var q2 = NeueQuelle();

        // Auf einem eigenen Thread aufgerufen: Blockiert SummeAsync (.Result, WaitAll ...), kehrt der Aufruf nie zurück.
        Task<Task<int>> aufruf = Task.Run<Task<int>>(() => Asynchron.SummeAsync([q1.Task, q2.Task]));
        Task<int> summe = await MitGrenze(aufruf);

        Assert.False(summe.IsCompleted);
        q1.SetResult(40);
        q2.SetResult(2);
        Assert.Equal(42, await MitGrenze(summe));
    }

    [Fact]
    public async Task SummeAsync_gibt_die_urspruengliche_Ausnahme_weiter()
    {
        Task<int> ok = Task.FromResult(1);
        Task<int> kaputt = Task.FromException<int>(new InvalidOperationException("kaputt"));

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => Asynchron.SummeAsync([ok, kaputt]));
        Assert.Equal("kaputt", ex.Message);
    }

    // ---------- MitWiederholung

    [Fact]
    public async Task MitWiederholung_versucht_es_erneut_bis_es_klappt()
    {
        int aufrufe = 0;

        int ergebnis = await MitGrenze(Asynchron.MitWiederholung(async () =>
        {
            int nr = ++aufrufe;
            await Task.CompletedTask;
            if (nr < 3)
                throw new InvalidOperationException($"Versuch {nr}");
            return nr * 10;
        }, 5));

        Assert.Equal(30, ergebnis);
        Assert.Equal(3, aufrufe);
    }

    [Fact]
    public async Task MitWiederholung_gibt_nach_dem_letzten_Versuch_dessen_Ausnahme_weiter()
    {
        int aufrufe = 0;

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => Asynchron.MitWiederholung(async () =>
        {
            int nr = ++aufrufe;
            await Task.CompletedTask;
            throw new InvalidOperationException($"Versuch {nr}");
        }, 3));

        Assert.Equal("Versuch 3", ex.Message);
        Assert.Equal(3, aufrufe);
    }

    [Fact]
    public async Task MitWiederholung_ruft_bei_Erfolg_nur_einmal_auf()
    {
        int aufrufe = 0;

        int ergebnis = await MitGrenze(Asynchron.MitWiederholung(() => { aufrufe++; return Task.FromResult(7); }, 4));

        Assert.Equal(7, ergebnis);
        Assert.Equal(1, aufrufe);
    }

    [Fact]
    public async Task MitWiederholung_verlangt_mindestens_einen_Versuch()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => Asynchron.MitWiederholung(() => Task.FromResult(1), 0));
    }

    // ---------- VerarbeiteAsync

    [Fact]
    public async Task VerarbeiteAsync_liefert_die_Summe_der_Daten()
    {
        Assert.Equal(55, await MitGrenze(Asynchron.VerarbeiteAsync(Enumerable.Range(1, 10), CancellationToken.None)));
        Assert.Equal(0, await MitGrenze(Asynchron.VerarbeiteAsync([], CancellationToken.None)));
    }

    [Fact]
    public async Task VerarbeiteAsync_endet_bei_vorab_abgebrochenem_Token_als_abgebrochen()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        Task<int> aufgabe = Asynchron.VerarbeiteAsync([1, 2, 3], cts.Token);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => aufgabe);
        Assert.True(aufgabe.IsCanceled);
    }

    [Fact]
    public async Task VerarbeiteAsync_bemerkt_einen_Abbruch_mitten_in_der_Verarbeitung()
    {
        using var cts = new CancellationTokenSource();

        // Die Datenquelle löst den Abbruch aus, sobald das vierte Element geliefert wird.
        IEnumerable<int> Quelle()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i == 4)
                    cts.Cancel();
                yield return i;
            }
        }

        Task<int> aufgabe = Asynchron.VerarbeiteAsync(Quelle(), cts.Token);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => aufgabe);
        Assert.True(aufgabe.IsCanceled, $"Zustand: {aufgabe.Status}");
    }

    // ---------- await und Wait bei Ausnahmen

    [Fact]
    public async Task Await_wirft_den_Originaltyp_Wait_wirft_eine_AggregateException()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(() => Asynchron.FehlerAsync());

        var ex = Assert.Throws<AggregateException>(() => Asynchron.FehlerAsync().Wait());
        Assert.IsType<InvalidOperationException>(ex.InnerException);
    }

    [Fact]
    public async Task MeldungMitAwait_faengt_die_Originalausnahme()
    {
        Assert.Equal("Kaputt", await MitGrenze(Asynchron.MeldungMitAwait()));
    }

    [Fact]
    public void MeldungMitWait_faengt_die_AggregateException_und_liefert_die_innere_Meldung()
    {
        Assert.Equal("Kaputt", Asynchron.MeldungMitWait());
    }
}
