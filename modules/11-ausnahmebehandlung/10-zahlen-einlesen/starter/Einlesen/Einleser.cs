// Vorgegeben, nicht ändern: das Ergebnis von LiesZahlen.
public class LeseErgebnis
{
    // Die gültigen Zahlen in der Reihenfolge des Texts.
    public List<int> Werte { get; } = new();

    // Je Fehler eine Zeile: "<Teil>: keine Zahl" oder "<Teil>: zu groß".
    public List<string> Fehler { get; } = new();
}

public static class Einleser
{
    // Zerlegt text an ';' (leere Teile werden übersprungen) und wandelt jeden Teil in ein int um.
    // Gültige Zahlen kommen in Werte. Für jeden Teil, der scheitert, steht ein Eintrag in Fehler:
    //   FormatException   -> "<Teil>: keine Zahl"
    //   OverflowException -> "<Teil>: zu groß"
    // Ein fehlerhafter Teil stoppt die übrigen nicht: das try gehört in die Schleife.
    public static LeseErgebnis LiesZahlen(string text)
    {
        // TODO: text.Split(';', StringSplitOptions.RemoveEmptyEntries), foreach, try/catch
        throw new NotImplementedException();
    }

    // Mittelwert der gültigen Zahlen; double.NaN, wenn es keine gibt.
    public static double Mittelwert(LeseErgebnis ergebnis)
    {
        // TODO
        throw new NotImplementedException();
    }
}
