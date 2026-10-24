// Eine eigene Ausnahme: ein ArgumentException-Sonderfall mit dem ungültigen Argument als Zusatzinformation.
//
// TODO: Die Klasse soll von ArgumentException erben (nicht von Exception).
// TODO: Der Konstruktor (int argument) setzt die Meldung "Fakultät nicht definiert für <argument>"
//       (Aufruf des Basiskonstruktors mit : base(...)) und speichert das Argument.
// TODO: Der Konstruktor (int argument, Exception innerException) setzt die Meldung
//       "Fakultät von <argument> ist zu groß", gibt die innerException an die Basisklasse weiter
//       und speichert das Argument.
public class FakultaetArgumentException : Exception
{
    // Das Argument, für das die Fakultät nicht berechnet werden konnte.
    public int Argument { get; }

    public FakultaetArgumentException(int argument)
    {
    }

    public FakultaetArgumentException(int argument, Exception innerException)
    {
    }
}
