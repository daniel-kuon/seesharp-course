public static class Taschenrechner
{
    // Rechnet a op b mit ganzen Zahlen und liefert das Ergebnis als Text.
    // Fehler werden zu Meldungen:
    //   keine Zahl            -> "Keine Zahl: <Text>"
    //   Überlauf              -> "Zahl zu groß"
    //   Division durch null   -> "Division durch null"
    //   anderer Rechenfehler  -> "Rechenfehler"
    // Ein unbekannter Operator ist ein Programmierfehler des Aufrufers und wird
    // als ArgumentException nach außen gemeldet (sie darf nicht verschluckt werden).
    //
    // Dieser Code kompiliert nicht. Lies die Fehlermeldung des Compilers und repariere
    // die catch-Blöcke: Reihenfolge, Verschlucken von ArgumentException und der
    // fehlende Block für ArithmeticException (OverflowException und DivideByZeroException
    // sind davon abgeleitet).
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
        catch (Exception ex)
        {
            return "Fehler: " + ex.Message;
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
    }

    // Zerlegt text an ';' (leere Teile werden übersprungen) und addiert die Zahlen.
    // Pro Teil gibt es ein eigenes try/catch: Ein fehlerhafter Teil stoppt die anderen nicht.
    // Rückgabe: Summe der gültigen Zahlen, Anzahl der Fehler und die Typnamen der Ausnahmen
    // in der Reihenfolge ihres Auftretens, z. B. "FormatException" (ex.GetType().Name).
    // Fehler sind FormatException und OverflowException (zu große Zahl).
    public static (int summe, int fehler, List<string> arten) SummeAusText(string text)
    {
        // TODO: text.Split(';', StringSplitOptions.RemoveEmptyEntries), foreach, try/catch
        throw new NotImplementedException();
    }
}
