[Flags]
public enum Rechte
{
    Keine = 0,
    Lesen = 1,
    Schreiben = 2,
    Ausfuehren = 4,
}

public static class Rechtepruefung
{
    public static bool Hat(Rechte vorhanden, Rechte gesucht) => (vorhanden & gesucht) == gesucht;

    public static Rechte Entziehe(Rechte vorhanden, Rechte entzogen) => vorhanden & ~entzogen;
}
