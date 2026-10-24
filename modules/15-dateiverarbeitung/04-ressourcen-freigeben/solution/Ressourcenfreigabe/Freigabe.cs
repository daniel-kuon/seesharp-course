using System.Text;

namespace Ressourcenfreigabe;

public static class Freigabe
{
    /// <summary>Schreibt den Text als UTF-8 in den Strom, den die Fabrik liefert. Der Strom wird in jedem Fall freigegeben.</summary>
    public static void SchreibeText(Func<Stream> ziel, string text)
    {
        using (var s = ziel())
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            s.Write(bytes, 0, bytes.Length);
        }
    }

    /// <summary>Kopiert von der Quelle ins Ziel. Zuerst wird das Ziel freigegeben, dann die Quelle.</summary>
    public static void Kopiere(Func<Stream> quelle, Func<Stream> ziel)
    {
        using (var q = quelle())
        using (var z = ziel())
        {
            q.CopyTo(z);
        }
    }

    /// <summary>Zählt die Bytes des Stroms (ReadByte bis -1) mit einer using-Deklaration.</summary>
    public static int ZaehleBytes(Func<Stream> quelle)
    {
        using var s = quelle();
        int anzahl = 0;
        while (s.ReadByte() != -1)
            anzahl++;
        return anzahl;
    }

    /// <summary>Öffnet den Strom, ruft die Aktion auf und gibt ihn danach frei, auch wenn die Aktion wirft.</summary>
    public static void Verarbeite(Func<Stream> quelle, Action<Stream> aktion)
    {
        using (var s = quelle())
        {
            aktion(s);
        }
    }

    /// <summary>
    /// Schreibt die Zeilen in die Datei. Liefert false, wenn dabei eine IOException auftritt
    /// (zum Beispiel weil der Ordner fehlt); die Datei ist dann trotzdem geschlossen.
    /// </summary>
    public static bool SchreibeSicher(string pfad, IEnumerable<string> zeilen)
    {
        try
        {
            using var schreiber = new StreamWriter(pfad);
            foreach (var zeile in zeilen)
                schreiber.WriteLine(zeile);
            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }
}
