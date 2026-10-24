public static class Taschenrechner
{
    // Rechnet a op b mit ganzen Zahlen und liefert das Ergebnis als Text.
    // Fehler werden zu Meldungen:
    //   keine Zahl            -> "Keine Zahl: <Text>"
    //   Überlauf              -> "Zahl zu groß"
    //   Division durch null   -> "Division durch null"
    //   anderer Rechenfehler  -> "Rechenfehler"
    // Ein unbekannter Operator ist ein Programmierfehler des Aufrufers und wird
    // als ArgumentException nach außen gemeldet.
    public static string Berechne(string a, string op, string b)
    {
        string token = a;   // der Text, der gerade umgewandelt wird
        try
        {
            int x = int.Parse(a);
            token = b;
            int y = int.Parse(b);

            int ergebnis;
            switch (op)
            {
                case "+": ergebnis = checked(x + y); break;
                case "-": ergebnis = checked(x - y); break;
                case "*": ergebnis = checked(x * y); break;
                case "/": ergebnis = checked(x / y); break;
                case "%": ergebnis = checked(x % y); break;
                default: throw new ArgumentException("Unbekannter Operator: " + op, nameof(op));
            }
            return ergebnis.ToString();
        }
        catch (FormatException)
        {
            return "Keine Zahl: " + token;
        }
        catch (OverflowException)
        {
            return "Zahl zu groß";
        }
        catch (DivideByZeroException)
        {
            return "Division durch null";
        }
        catch (ArithmeticException)
        {
            return "Rechenfehler";
        }
    }

    // Zerlegt text an ';' (leere Teile werden übersprungen) und addiert die Zahlen.
    // Pro Teil gibt es ein eigenes try/catch: Ein fehlerhafter Teil stoppt die anderen nicht.
    // Rückgabe: Summe der gültigen Zahlen, Anzahl der Fehler und die Typnamen der Ausnahmen
    // in der Reihenfolge ihres Auftretens, z. B. "FormatException".
    public static (int summe, int fehler, List<string> arten) SummeAusText(string text)
    {
        int summe = 0;
        int fehler = 0;
        var arten = new List<string>();

        foreach (string teil in text.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            try
            {
                summe += int.Parse(teil);
            }
            catch (FormatException ex)
            {
                fehler++;
                arten.Add(ex.GetType().Name);
            }
            catch (OverflowException ex)
            {
                fehler++;
                arten.Add(ex.GetType().Name);
            }
        }
        return (summe, fehler, arten);
    }
}
