using System.Text;

namespace Textdateien;

public static class Textdatei
{
    static Textdatei()
    {
        // Windows-1252 ist keine Standardcodierung in .NET; der Provider macht sie verfügbar.
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    // TODO: Schreibe jede Zeile mit einem StreamWriter in die Datei (überschreibt sie).
    //       Schließe den Schreiber in einem finally-Block, damit die Datei auch bei einer
    //       Ausnahme in der Schleife freigegeben wird (die using-Anweisung kommt erst in Aufgabe 4).
    public static void Schreibe(string pfad, IEnumerable<string> zeilen)
    {
        throw new NotImplementedException();
    }

    // TODO: Lies alle Zeilen mit einem StreamReader: ReadLine() liefert null am Dateiende.
    //       Auch hier schließt ein finally den Leser.
    public static List<string> LiesZeilen(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Wie LiesZeilen, aber eine fehlende Datei (FileNotFoundException) oder ein fehlender
    //       Ordner (DirectoryNotFoundException) ergibt eine leere Liste. Fange genau diese
    //       beiden Ausnahmetypen.
    public static List<string> LiesOderLeer(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Hänge die Zeile an das Dateiende an: new StreamWriter(pfad, append: true).
    public static void Anhaengen(string pfad, string zeile)
    {
        throw new NotImplementedException();
    }

    // TODO: Lies eine Windows-1252-Datei zeilenweise (Encoding.GetEncoding(1252)).
    public static List<string> LiesAnsi(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Schreibe den Text als Windows-1252.
    public static void SchreibeAnsi(string pfad, string text)
    {
        throw new NotImplementedException();
    }

    // TODO: Schreibe den Text als UTF-8 OHNE Byte-Order-Mark (new UTF8Encoding(false));
    //       Encoding.UTF8 würde die drei BOM-Bytes EF BB BF an den Dateianfang setzen.
    public static void SchreibeUtf8(string pfad, string text)
    {
        throw new NotImplementedException();
    }
}
