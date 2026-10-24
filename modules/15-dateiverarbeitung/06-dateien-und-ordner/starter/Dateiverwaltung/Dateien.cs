namespace Dateiverwaltung;

public static class Dateien
{
    // TODO: Lege den Zielordner an, falls er fehlt (Directory.CreateDirectory), und kopiere die Datei
    //       dorthin unter dem Namen <name>_backup<endung>: aus "C:\x\bericht.txt" und dem Zielordner "D"
    //       wird "D\bericht_backup.txt". Nimm Path.GetFileNameWithoutExtension, Path.GetExtension und
    //       Path.Combine (kein "\\" von Hand). Ein vorhandenes Backup wird überschrieben.
    //       Rückgabe: der neue Pfad.
    public static string Sichere(string datei, string zielOrdner)
    {
        throw new NotImplementedException();
    }

    // TODO: Liefere alle Dateien unterhalb des Ordners, die zum Muster passen (z. B. "*.txt"), auch in
    //       Unterordnern (Directory.EnumerateFiles mit SearchOption.AllDirectories), als Pfade RELATIV zum
    //       Ordner (Path.GetRelativePath), ordinal sortiert (Sort(StringComparer.Ordinal)).
    public static List<string> ListeRekursiv(string ordner, string muster)
    {
        throw new NotImplementedException();
    }

    // TODO: Verschiebe die Datei (File.Move). Fehlt die Quelle, kommt false zurück. Der Ordner des Ziels
    //       wird bei Bedarf angelegt; eine vorhandene Zieldatei wird überschrieben.
    public static bool Verschiebe(string von, string nach)
    {
        throw new NotImplementedException();
    }

    // TODO: Lösche alle leeren Ordner unterhalb der Wurzel, von unten nach oben: Ein Ordner, der erst
    //       durch das Löschen seiner leeren Unterordner leer wird, zählt mit. Die Wurzel selbst bleibt.
    //       Rückgabe: Zahl der gelöschten Ordner. (Rekursion über Directory.GetDirectories.)
    public static int LoescheLeereOrdner(string wurzel)
    {
        throw new NotImplementedException();
    }

    // TODO: Tausche die Endung (Path.ChangeExtension): "daten.txt" und "csv" ergibt "daten.csv".
    public static string ErsetzeEndung(string pfad, string neu)
    {
        throw new NotImplementedException();
    }

    // TODO: Lege einen neuen, eindeutigen Ordner unterhalb des Temp-Ordners an
    //       (Path.GetTempPath, Path.GetRandomFileName) und liefere seinen Pfad.
    public static string NeuerArbeitsordner()
    {
        throw new NotImplementedException();
    }

    // TODO: Pfad <lokaler Anwendungsdatenordner des Benutzers>/<appName>, aus
    //       Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData). Nicht anlegen.
    public static string AppOrdner(string appName)
    {
        throw new NotImplementedException();
    }
}
