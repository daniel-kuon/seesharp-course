using System.Text;

namespace Ressourcenfreigabe;

/// <summary>Schreibt Protokollzeilen in einen Strom.</summary>
public class Logger
{
    readonly StreamWriter _schreiber;

    public Logger(Stream ziel)
    {
        // TODO: Setze AutoFlush = true, damit jede Zeile sofort im Strom ankommt,
        //       und lösche dafür das manuelle Flush() in Log.
        _schreiber = new StreamWriter(ziel, new UTF8Encoding(false));
    }

    public bool AutoFlush => _schreiber.AutoFlush;

    public void Log(string zeile)
    {
        _schreiber.WriteLine(zeile);
        _schreiber.Flush();
    }

    // TODO: Schreibe n Zeilen "Eintrag 1" bis "Eintrag n" am Stück. Das ist die Aufgabe 2 aus dem
    //       Buch (16.7): Ein Flush pro Zeile macht das langsam. Schalte AutoFlush für die Schleife
    //       aus, rufe danach EINMAL Flush() und stelle AutoFlush im finally wieder auf true.
    public void SchreibeViele(int n)
    {
        for (int i = 1; i <= n; i++)
            Log($"Eintrag {i}");
    }
}
