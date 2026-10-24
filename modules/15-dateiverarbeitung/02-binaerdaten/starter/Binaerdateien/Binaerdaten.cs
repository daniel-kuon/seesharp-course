namespace Binaerdateien;

// Wie in Aufgabe 1 schließt du Dateien mit Close() in einem finally-Block.
public static class Binaerdaten
{
    // TODO: Kopiere die Datei byteweise: Quelle mit FileMode.Open und FileAccess.Read (und
    //       FileShare.Read) öffnen, Ziel mit FileMode.Create. Lies mit Read in einen
    //       byte[4096]-Puffer und schreibe genau so viele Bytes, wie Read geliefert hat.
    //       Rückgabe: Zahl der kopierten Bytes.
    public static long Kopiere(string quelle, string ziel)
    {
        throw new NotImplementedException();
    }

    // TODO: Schreibe mit einem BinaryWriter zuerst die Anzahl (int), dann jeden Wert (double).
    //       Die Datei ist danach 4 + 8 * Anzahl Bytes groß.
    public static void SchreibeMesswerte(string pfad, double[] werte)
    {
        throw new NotImplementedException();
    }

    // TODO: Lies das Format von SchreibeMesswerte mit einem BinaryReader zurück.
    public static double[] LiesMesswerte(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Hänge die Bytes ans Dateiende an: FileMode.Append (legt die Datei bei Bedarf an).
    public static void HaengeAn(string pfad, byte[] daten)
    {
        throw new NotImplementedException();
    }

    // TODO: Springe mit Seek an die Position offset und lies bis zu anzahl Bytes.
    //       Gibt es am Dateiende weniger, kommt ein kürzeres Array zurück (Read liefert die
    //       tatsächliche Zahl); hinter dem Ende ein leeres Array.
    public static byte[] LiesAb(string pfad, long offset, int anzahl)
    {
        throw new NotImplementedException();
    }

    // TODO: Lege eine neue, leere Datei an (FileMode.CreateNew). Existiert sie schon, darf keine
    //       Ausnahme fliegen: Prüfe vorher mit File.Exists und liefere false.
    public static bool Erzeuge(string pfad)
    {
        throw new NotImplementedException();
    }
}
