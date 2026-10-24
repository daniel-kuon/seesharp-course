public class Rechner
{
    public double Exponent { get; set; } = 2;

    // TODO: Die vier statischen Methoden müssen zum Delegatentyp Operation passen
    // (zwei double-Parameter, Rückgabetyp double).
    public static double Addiere(double a, double b) => throw new NotImplementedException();
    public static double Subtrahiere(double a, double b) => throw new NotImplementedException();
    public static double Multipliziere(double a, double b) => throw new NotImplementedException();
    public static double Dividiere(double a, double b) => throw new NotImplementedException();

    // TODO: (a + b) hoch Exponent; Instanzmethode, braucht also das Zielobjekt
    public double Potenz(double a, double b) => throw new NotImplementedException();

    // TODO: den Delegaten aufrufen
    public static double Anwenden(Operation op, double a, double b) => throw new NotImplementedException();

    // TODO: von links nach rechts falten; leeres Array: ArgumentException
    public static double Reduziere(Operation op, double[] werte) => throw new NotImplementedException();

    // TODO: switch-Ausdruck mit Methodengruppen; unbekanntes Zeichen: null
    public static Operation? Waehle(char zeichen) => throw new NotImplementedException();

    // TODO: Delegat auf die Instanzmethode Potenz dieses Objekts
    public Operation PotenzDelegat() => throw new NotImplementedException();

    // Review-Aufgabe: Zaehle(double[] werte, Bedingung b) und eine passende Methode hier ergänzen.
}
