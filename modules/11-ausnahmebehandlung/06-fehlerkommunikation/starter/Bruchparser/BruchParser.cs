public static class BruchParser
{
    // Wandelt "Zähler/Nenner" in einen Bruch um, z. B. "3/4" oder "-1/2". Fehler werden geworfen:
    // - kein Schrägstrich, mehr als einer, Zähler oder Nenner keine Zahl ("3/", "a/b"): FormatException
    // - Nenner 0 ("1/0"): ArgumentException (kommt vom Bruch-Konstruktor)
    // - Zahl zu groß für int: OverflowException (kommt von int.Parse)
    // Tipp: s.Split('/') und int.Parse()
    public static Bruch Parse(string s)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Try-Muster: Liefert true und den Bruch, oder false (und ergebnis == null), statt zu werfen.
    // Wirft für keine Eingabe eine Ausnahme, auch nicht für null, zu große Zahlen oder "1/0".
    // Tipp: int.TryParse() statt int.Parse().
    public static bool TryParse(string? s, out Bruch? ergebnis)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Fehlerkommunikation per Rückgabecode: 0 = Erfolg, 1 = Division durch null.
    // Das Ergebnis kommt über den out-Parameter (bei einem Fehler 0).
    public static int TeileRc(int a, int b, out int ergebnis)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Dieselbe Rechnung mit Ausnahme: bei b == 0 löst a / b eine DivideByZeroException aus.
    public static int Teile(int a, int b)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Wandelt alle Eingaben mit Parse() um und fängt die Ausnahmen (FormatException,
    // ArgumentException, OverflowException) ab. Liefert (Anzahl gültiger, Anzahl ungültiger Eingaben).
    public static (int gueltig, int ungueltig) ParseAlleMitAusnahmen(string[] eingaben)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Dasselbe Ergebnis mit TryParse(): keine Ausnahmen, kein try.
    public static (int gueltig, int ungueltig) ParseAlleMitTry(string[] eingaben)
    {
        // TODO
        throw new NotImplementedException();
    }
}
