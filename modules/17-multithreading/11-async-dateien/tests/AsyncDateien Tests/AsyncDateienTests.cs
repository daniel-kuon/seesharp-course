public class AsyncDateienTests : IDisposable
{
    static readonly TimeSpan Wartegrenze = TimeSpan.FromSeconds(30);   // nur Schutz vor einem Hänger

    // Jeder Test bekommt einen eigenen, einmaligen Ordner (die Testklasse wird pro Test neu erzeugt).
    readonly string _ordner = Path.Combine(Path.GetTempPath(), "seesharp-dateien-" + Guid.NewGuid().ToString("N"));

    public AsyncDateienTests() => Directory.CreateDirectory(_ordner);

    public void Dispose() => Directory.Delete(_ordner, recursive: true);

    string Neu(string name, params string[] zeilen)
    {
        string pfad = Path.Combine(_ordner, name);
        File.WriteAllLines(pfad, zeilen);
        return pfad;
    }

    static async Task<T> MitGrenze<T>(Task<T> aufgabe)
    {
        Task fertig = await Task.WhenAny(aufgabe, Task.Delay(Wartegrenze));
        Assert.True(ReferenceEquals(fertig, aufgabe), "Die Aufgabe wurde nicht rechtzeitig fertig.");
        return await aufgabe;
    }

    [Fact]
    public async Task Zaehlt_die_Zeilen_jeder_Datei()
    {
        string a = Neu("a.txt", "x");
        string b = Neu("b.txt", "1", "2", "3");
        string c = Neu("c.txt");   // leere Datei

        Dictionary<string, int> ergebnis = await MitGrenze(Dateien.ZaehleZeilenAsync([a, b, c]));

        Assert.Equal(3, ergebnis.Count);
        Assert.Equal(1, ergebnis[a]);
        Assert.Equal(3, ergebnis[b]);
        Assert.Equal(0, ergebnis[c]);
    }

    [Fact]
    public async Task Fehlende_Dateien_werden_mit_minus_eins_gemeldet_ohne_zu_werfen()
    {
        string vorhanden = Neu("da.txt", "a", "b");
        string fehlt = Path.Combine(_ordner, "fehlt.txt");
        string fehlenderOrdner = Path.Combine(_ordner, "gibt-es-nicht", "x.txt");

        Dictionary<string, int> ergebnis = await MitGrenze(Dateien.ZaehleZeilenAsync([vorhanden, fehlt, fehlenderOrdner]));

        Assert.Equal(2, ergebnis[vorhanden]);
        Assert.Equal(-1, ergebnis[fehlt]);
        Assert.Equal(-1, ergebnis[fehlenderOrdner]);
    }

    [Fact]
    public async Task Mehrfach_genannte_Pfade_stehen_nur_einmal_im_Ergebnis()
    {
        string a = Neu("a.txt", "1", "2");

        Dictionary<string, int> ergebnis = await MitGrenze(Dateien.ZaehleZeilenAsync([a, a, a]));

        Assert.Single(ergebnis);
        Assert.Equal(2, ergebnis[a]);
    }

    [Fact]
    public async Task Eine_leere_Folge_liefert_ein_leeres_Woerterbuch()
    {
        Assert.Empty(await MitGrenze(Dateien.ZaehleZeilenAsync([])));
    }

    [Fact]
    public async Task Viele_Dateien_auf_einmal()
    {
        string[] pfade = Enumerable.Range(1, 40)
            .Select(i => Neu($"datei{i}.txt", Enumerable.Range(0, i).Select(z => $"Zeile {z}").ToArray()))
            .ToArray();

        Dictionary<string, int> ergebnis = await MitGrenze(Dateien.ZaehleZeilenAsync(pfade));

        for (int i = 1; i <= 40; i++)
            Assert.Equal(i, ergebnis[pfade[i - 1]]);
    }
}
