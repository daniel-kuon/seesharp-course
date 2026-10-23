// Eine Uhrzeit im 24-Stunden-Format, intern als Minuten seit Mitternacht (0 bis 1439).
public class Uhrzeit {
    const int MinutenProTag = 24 * 60;

    // Minuten seit Mitternacht, immer im Bereich 0 bis 1439.
    int minuten;

    // Bringt eine beliebige Minutenzahl (auch negativ oder größer als ein Tag)
    // in den Bereich 0 bis 1439: 1440 -> 0, -1 -> 1439, 1500 -> 60.
    static int Normiere(int m) {
        // TODO: Rest der Division durch MinutenProTag; ein negativer Rest braucht noch einen Tag dazu
        throw new NotImplementedException();
    }

    public Uhrzeit(int stunde, int minute) {
        // TODO: aus Stunde und Minute die Minuten seit Mitternacht berechnen und normieren
        throw new NotImplementedException();
    }

    public Uhrzeit(int minutenSeitMitternacht) {
        // TODO
        throw new NotImplementedException();
    }

    public int Stunde {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public int Minute {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Verschiebt diese Uhrzeit um die angegebenen Minuten (auch negativ).
    public void Addiere(int minuten) {
        // TODO
        throw new NotImplementedException();
    }

    // Verschiebt diese Uhrzeit um Stunden und Minuten.
    public void Addiere(int stunden, int minuten) {
        // TODO: die andere Überladung wiederverwenden
        throw new NotImplementedException();
    }

    // Liefert die Uhrzeit als "hh:mm", z. B. "07:05".
    public string Text() {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert eine NEUE Uhrzeit, u bleibt unverändert.
    public static Uhrzeit operator +(Uhrzeit u, int minuten) {
        // TODO
        throw new NotImplementedException();
    }

    // Wie viele Minuten vergehen von b bis a (vorwärts, über Mitternacht hinweg): 0 bis 1439.
    public static int operator -(Uhrzeit a, Uhrzeit b) {
        // TODO
        throw new NotImplementedException();
    }
}
