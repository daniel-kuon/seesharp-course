namespace Dateiverwaltung;

public static class Dateien
{
    /// <summary>Kopiert die Datei als &lt;name&gt;_backup&lt;endung&gt; in den Zielordner (wird bei Bedarf angelegt) und liefert den neuen Pfad.</summary>
    public static string Sichere(string datei, string zielOrdner)
    {
        Directory.CreateDirectory(zielOrdner);
        string name = Path.GetFileNameWithoutExtension(datei);
        string endung = Path.GetExtension(datei);
        string ziel = Path.Combine(zielOrdner, name + "_backup" + endung);
        File.Copy(datei, ziel, overwrite: true);
        return ziel;
    }

    /// <summary>Alle Dateien unterhalb des Ordners, die zum Muster passen, als relative Pfade, ordinal sortiert.</summary>
    public static List<string> ListeRekursiv(string ordner, string muster)
    {
        var ergebnis = new List<string>();
        foreach (string datei in Directory.EnumerateFiles(ordner, muster, SearchOption.AllDirectories))
            ergebnis.Add(Path.GetRelativePath(ordner, datei));
        ergebnis.Sort(StringComparer.Ordinal);
        return ergebnis;
    }

    /// <summary>Verschiebt die Datei (der Zielordner wird bei Bedarf angelegt). false, wenn die Quelle fehlt.</summary>
    public static bool Verschiebe(string von, string nach)
    {
        if (!File.Exists(von))
            return false;
        string? ordner = Path.GetDirectoryName(nach);
        if (!string.IsNullOrEmpty(ordner))
            Directory.CreateDirectory(ordner);
        File.Move(von, nach, overwrite: true);
        return true;
    }

    /// <summary>Löscht alle leeren Ordner unterhalb der Wurzel von unten nach oben; die Wurzel bleibt. Liefert die Zahl der gelöschten Ordner.</summary>
    public static int LoescheLeereOrdner(string wurzel)
    {
        int geloescht = 0;
        foreach (string unterordner in Directory.GetDirectories(wurzel))
        {
            geloescht += LoescheLeereOrdner(unterordner);
            if (!Directory.EnumerateFileSystemEntries(unterordner).Any())
            {
                Directory.Delete(unterordner);
                geloescht++;
            }
        }
        return geloescht;
    }

    /// <summary>Tauscht die Dateiendung (neu ohne Punkt, z. B. "csv").</summary>
    public static string ErsetzeEndung(string pfad, string neu) => Path.ChangeExtension(pfad, neu);

    /// <summary>Legt einen neuen, eindeutigen Ordner unterhalb des Temp-Ordners an.</summary>
    public static string NeuerArbeitsordner()
    {
        string pfad = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(pfad);
        return pfad;
    }

    /// <summary>Ordner der Anwendung im lokalen Anwendungsdaten-Ordner des Benutzers (wird nicht angelegt).</summary>
    public static string AppOrdner(string appName) =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), appName);
}
