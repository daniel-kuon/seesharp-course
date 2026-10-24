namespace Ordnerauswertung;

public static class Ordnerstatistik
{
    // TODO: Anzahl aller Dateien im Ordner und in allen Unterordnern
    //       (Directory.EnumerateFiles mit SearchOption.AllDirectories).
    public static int AnzahlDateien(string ordner)
    {
        throw new NotImplementedException();
    }

    // TODO: Relativer Pfad der größten Datei (Path.GetRelativePath, FileInfo.Length). Bei gleich großen
    //       Dateien gewinnt der ordinal kleinere Pfad (string.CompareOrdinal). Ohne Datei: null.
    public static string? GroessteDatei(string ordner)
    {
        throw new NotImplementedException();
    }

    // TODO: Zähle die Dateien je Endung: Schlüssel ist die Endung klein geschrieben und mit Punkt
    //       (".txt"); Dateien ohne Endung zählen unter "(keine)". Path.GetExtension und ToLowerInvariant.
    public static Dictionary<string, int> ProEndung(string ordner)
    {
        throw new NotImplementedException();
    }

    // TODO: Kopiere alle .txt-Dateien (auch ".TXT": vergleiche die Endung mit StringComparison.OrdinalIgnoreCase)
    //       samt Unterordnerstruktur von quelle nach ziel (fehlende Ordner
    //       anlegen, Vorhandenes überschreiben) und liefere die Anzahl der kopierten Dateien.
    public static int KopiereAlleTxt(string quelle, string ziel)
    {
        throw new NotImplementedException();
    }
}
