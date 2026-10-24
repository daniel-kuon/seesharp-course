/// <summary>
/// Eigener Temp-Ordner pro Test. Der Name enthält Leerzeichen, Komma und Umlaut,
/// weil Pfade in der Praxis so aussehen. Dispose räumt alles weg.
/// </summary>
public sealed class TestOrdner : IDisposable
{
    readonly string _wurzel = Path.Combine(Path.GetTempPath(), "SeeSharpTests", Guid.NewGuid().ToString("N"));

    public string Pfad { get; }

    public TestOrdner()
    {
        Pfad = Path.Combine(_wurzel, "Schere, Stein, Prüfung");
        Directory.CreateDirectory(Pfad);
    }

    public string Datei(string name) => Path.Combine(Pfad, name);

    /// <summary>Wirft, wenn jemand die Datei noch offen hat (Öffnen ohne Mitbenutzung schlägt dann fehl).</summary>
    public static void PruefeDateiFrei(string pfad)
    {
        using var s = new FileStream(pfad, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    }

    public void Dispose()
    {
        try { Directory.Delete(_wurzel, recursive: true); }
        catch (IOException) { }
        catch (UnauthorizedAccessException) { }
    }
}
