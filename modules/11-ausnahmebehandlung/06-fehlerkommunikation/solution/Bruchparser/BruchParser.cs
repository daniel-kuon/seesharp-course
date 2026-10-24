public static class BruchParser
{
    // Wandelt "Zähler/Nenner" in einen Bruch um, z. B. "3/4" oder "-1/2".
    // - kein Schrägstrich, mehr als einer, Zähler oder Nenner keine Zahl ("3/", "a/b"): FormatException
    // - Nenner 0 ("1/0"): ArgumentException (kommt vom Bruch-Konstruktor)
    // - Zahl zu groß für int: OverflowException (kommt von int.Parse)
    public static Bruch Parse(string s)
    {
        string[] teile = s.Split('/');
        if (teile.Length != 2)
            throw new FormatException("Erwartet wird Zähler/Nenner: " + s);
        int zaehler = int.Parse(teile[0]);
        int nenner = int.Parse(teile[1]);
        return new Bruch(zaehler, nenner);
    }

    // Try-Muster: Liefert true und den Bruch, oder false (und ergebnis == null), statt zu werfen.
    // Wirft für keine Eingabe eine Ausnahme, auch nicht für null oder zu große Zahlen.
    public static bool TryParse(string? s, out Bruch? ergebnis)
    {
        ergebnis = null;
        if (s == null)
            return false;
        string[] teile = s.Split('/');
        if (teile.Length != 2
            || !int.TryParse(teile[0], out int zaehler)
            || !int.TryParse(teile[1], out int nenner)
            || nenner == 0)
            return false;
        ergebnis = new Bruch(zaehler, nenner);
        return true;
    }

    // Fehlerkommunikation per Rückgabecode: 0 = Erfolg, 1 = Division durch null.
    // Das Ergebnis kommt über den out-Parameter (bei Fehler 0).
    public static int TeileRc(int a, int b, out int ergebnis)
    {
        if (b == 0)
        {
            ergebnis = 0;
            return 1;
        }
        ergebnis = a / b;
        return 0;
    }

    // Dieselbe Rechnung mit Ausnahme: bei b == 0 löst a / b eine DivideByZeroException aus.
    public static int Teile(int a, int b)
    {
        return a / b;
    }

    // Wandelt alle Eingaben mit Parse() um und fängt die Ausnahmen ab.
    // Liefert (Anzahl gültiger, Anzahl ungültiger Eingaben).
    public static (int gueltig, int ungueltig) ParseAlleMitAusnahmen(string[] eingaben)
    {
        int gueltig = 0;
        int ungueltig = 0;
        foreach (string eingabe in eingaben)
        {
            try
            {
                Parse(eingabe);
                gueltig++;
            }
            catch (FormatException)
            {
                ungueltig++;
            }
            catch (ArgumentException)
            {
                ungueltig++;
            }
            catch (OverflowException)
            {
                ungueltig++;
            }
        }
        return (gueltig, ungueltig);
    }

    // Dasselbe Ergebnis mit TryParse(): keine Ausnahmen, kein try.
    public static (int gueltig, int ungueltig) ParseAlleMitTry(string[] eingaben)
    {
        int gueltig = 0;
        int ungueltig = 0;
        foreach (string eingabe in eingaben)
        {
            if (TryParse(eingabe, out _))
                gueltig++;
            else
                ungueltig++;
        }
        return (gueltig, ungueltig);
    }
}
