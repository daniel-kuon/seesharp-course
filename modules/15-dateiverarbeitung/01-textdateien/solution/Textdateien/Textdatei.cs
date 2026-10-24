using System.Text;

namespace Textdateien;

public static class Textdatei
{
    static Textdatei()
    {
        // Windows-1252 ist keine Standardcodierung in .NET; der Provider macht sie verfügbar.
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    /// <summary>Schreibt jede Zeile in die Datei (überschreibt sie). Die Datei wird in jedem Fall geschlossen.</summary>
    public static void Schreibe(string pfad, IEnumerable<string> zeilen)
    {
        var schreiber = new StreamWriter(pfad);
        try
        {
            foreach (var zeile in zeilen)
                schreiber.WriteLine(zeile);
        }
        finally
        {
            schreiber.Close();
        }
    }

    /// <summary>Liest alle Zeilen der Datei, mit ReadLine bis null.</summary>
    public static List<string> LiesZeilen(string pfad)
    {
        var ergebnis = new List<string>();
        var leser = new StreamReader(pfad);
        try
        {
            string? zeile;
            while ((zeile = leser.ReadLine()) != null)
                ergebnis.Add(zeile);
        }
        finally
        {
            leser.Close();
        }
        return ergebnis;
    }

    /// <summary>Wie LiesZeilen, aber eine fehlende Datei oder ein fehlender Ordner ergibt eine leere Liste.</summary>
    public static List<string> LiesOderLeer(string pfad)
    {
        try
        {
            return LiesZeilen(pfad);
        }
        catch (FileNotFoundException)
        {
            return new List<string>();
        }
        catch (DirectoryNotFoundException)
        {
            return new List<string>();
        }
    }

    /// <summary>Hängt eine Zeile an das Dateiende an (legt die Datei an, falls sie fehlt).</summary>
    public static void Anhaengen(string pfad, string zeile)
    {
        var schreiber = new StreamWriter(pfad, append: true);
        try
        {
            schreiber.WriteLine(zeile);
        }
        finally
        {
            schreiber.Close();
        }
    }

    /// <summary>Liest eine Windows-1252-Datei zeilenweise.</summary>
    public static List<string> LiesAnsi(string pfad)
    {
        var ergebnis = new List<string>();
        var leser = new StreamReader(pfad, Encoding.GetEncoding(1252));
        try
        {
            string? zeile;
            while ((zeile = leser.ReadLine()) != null)
                ergebnis.Add(zeile);
        }
        finally
        {
            leser.Close();
        }
        return ergebnis;
    }

    /// <summary>Schreibt den Text als Windows-1252 (ä wird zum Byte 0xE4).</summary>
    public static void SchreibeAnsi(string pfad, string text)
    {
        var schreiber = new StreamWriter(pfad, false, Encoding.GetEncoding(1252));
        try
        {
            schreiber.Write(text);
        }
        finally
        {
            schreiber.Close();
        }
    }

    /// <summary>Schreibt den Text als UTF-8 ohne Byte-Order-Mark.</summary>
    public static void SchreibeUtf8(string pfad, string text)
    {
        var schreiber = new StreamWriter(pfad, false, new UTF8Encoding(false));
        try
        {
            schreiber.Write(text);
        }
        finally
        {
            schreiber.Close();
        }
    }
}
