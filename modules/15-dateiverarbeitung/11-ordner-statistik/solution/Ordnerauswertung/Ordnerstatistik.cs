namespace Ordnerauswertung;

public static class Ordnerstatistik
{
    /// <summary>Anzahl aller Dateien im Ordner und in allen Unterordnern.</summary>
    public static int AnzahlDateien(string ordner) =>
        Directory.EnumerateFiles(ordner, "*", SearchOption.AllDirectories).Count();

    /// <summary>Relativer Pfad der größten Datei (bei Gleichstand der ordinal kleinste Pfad); null, wenn es keine Datei gibt.</summary>
    public static string? GroessteDatei(string ordner)
    {
        string? beste = null;
        long groesse = -1;
        foreach (string datei in Directory.EnumerateFiles(ordner, "*", SearchOption.AllDirectories))
        {
            string relativ = Path.GetRelativePath(ordner, datei);
            long laenge = new FileInfo(datei).Length;
            if (laenge > groesse || (laenge == groesse && string.CompareOrdinal(relativ, beste) < 0))
            {
                beste = relativ;
                groesse = laenge;
            }
        }
        return beste;
    }

    /// <summary>Zählt die Dateien je Endung (klein geschrieben, mit Punkt, z. B. ".txt"); Dateien ohne Endung zählen unter "(keine)".</summary>
    public static Dictionary<string, int> ProEndung(string ordner)
    {
        var ergebnis = new Dictionary<string, int>();
        foreach (string datei in Directory.EnumerateFiles(ordner, "*", SearchOption.AllDirectories))
        {
            string endung = Path.GetExtension(datei).ToLowerInvariant();
            if (endung == "") endung = "(keine)";
            ergebnis[endung] = ergebnis.GetValueOrDefault(endung) + 1;
        }
        return ergebnis;
    }

    /// <summary>Kopiert alle .txt-Dateien (Groß-/Kleinschreibung der Endung egal) samt Unterordnerstruktur von quelle nach ziel und liefert ihre Anzahl.</summary>
    public static int KopiereAlleTxt(string quelle, string ziel)
    {
        int anzahl = 0;
        foreach (string datei in Directory.EnumerateFiles(quelle, "*", SearchOption.AllDirectories))
        {
            if (!Path.GetExtension(datei).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                continue;
            string zielDatei = Path.Combine(ziel, Path.GetRelativePath(quelle, datei));
            Directory.CreateDirectory(Path.GetDirectoryName(zielDatei)!);
            File.Copy(datei, zielDatei, overwrite: true);
            anzahl++;
        }
        return anzahl;
    }
}
