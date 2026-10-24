// TODO: Aus der Aufzählung soll ein Bitfeld werden: Rechte lassen sich kombinieren
//       (Rechte.Lesen | Rechte.Schreiben) und werden dann als "Lesen, Schreiben" ausgegeben.
public enum Rechte
{
    Keine = 0,
    Lesen = 1,
    Schreiben = 2,
    Ausfuehren = 4,
}

public static class Rechtepruefung
{
    // true, wenn in 'vorhanden' ALLE Bits von 'gesucht' gesetzt sind.
    public static bool Hat(Rechte vorhanden, Rechte gesucht)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert 'vorhanden' ohne die Bits von 'entzogen'.
    public static Rechte Entziehe(Rechte vorhanden, Rechte entzogen)
    {
        // TODO
        throw new NotImplementedException();
    }
}
