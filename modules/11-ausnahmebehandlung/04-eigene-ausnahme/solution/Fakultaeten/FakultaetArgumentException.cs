// Eine eigene Ausnahme: ein ArgumentException-Sonderfall mit dem ungültigen Argument als Zusatzinformation.
public class FakultaetArgumentException : ArgumentException
{
    // Das Argument, für das die Fakultät nicht berechnet werden konnte.
    public int Argument { get; }

    public FakultaetArgumentException(int argument)
        : base($"Fakultät nicht definiert für {argument}")
    {
        Argument = argument;
    }

    public FakultaetArgumentException(int argument, Exception innerException)
        : base($"Fakultät von {argument} ist zu groß", innerException)
    {
        Argument = argument;
    }
}
