using System.Text;

namespace Ressourcenfreigabe;

/// <summary>Schreibt Protokollzeilen in einen Strom.</summary>
public class Logger
{
    readonly StreamWriter _schreiber;

    public Logger(Stream ziel)
    {
        // AutoFlush: Jede Zeile landet sofort im Strom und ist für andere Leser sichtbar.
        _schreiber = new StreamWriter(ziel, new UTF8Encoding(false)) { AutoFlush = true };
    }

    public bool AutoFlush => _schreiber.AutoFlush;

    public void Log(string zeile) => _schreiber.WriteLine(zeile);

    /// <summary>Schreibt n Zeilen am Stück: Mit ausgeschaltetem AutoFlush und nur einem Flush am Ende.</summary>
    public void SchreibeViele(int n)
    {
        _schreiber.AutoFlush = false;
        try
        {
            for (int i = 1; i <= n; i++)
                _schreiber.WriteLine($"Eintrag {i}");
            _schreiber.Flush();
        }
        finally
        {
            _schreiber.AutoFlush = true;
        }
    }
}
