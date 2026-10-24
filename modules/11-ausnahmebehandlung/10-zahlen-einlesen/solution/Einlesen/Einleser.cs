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
    // Ein fehlerhafter Teil stoppt die übrigen nicht.
    public static LeseErgebnis LiesZahlen(string text)
    {
        var ergebnis = new LeseErgebnis();
        foreach (string teil in text.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            try
            {
                ergebnis.Werte.Add(int.Parse(teil));
            }
            catch (FormatException)
            {
                ergebnis.Fehler.Add(teil + ": keine Zahl");
            }
            catch (OverflowException)
            {
                ergebnis.Fehler.Add(teil + ": zu groß");
            }
        }
        return ergebnis;
    }

    // Mittelwert der gültigen Zahlen; double.NaN, wenn es keine gibt.
    public static double Mittelwert(LeseErgebnis ergebnis)
    {
        if (ergebnis.Werte.Count == 0)
            return double.NaN;
        double summe = 0;
        foreach (int wert in ergebnis.Werte)
            summe += wert;
        return summe / ergebnis.Werte.Count;
    }
}
