// Eine Uhrzeit im 24-Stunden-Format, intern als Minuten seit Mitternacht (0 bis 1439).
public class Uhrzeit {
    const int MinutenProTag = 24 * 60;

    // Minuten seit Mitternacht, immer im Bereich 0 bis 1439.
    int minuten;

    // Bringt eine beliebige Minutenzahl (auch negativ oder größer als ein Tag)
    // in den Bereich 0 bis 1439: 1440 -> 0, -1 -> 1439, 1500 -> 60.
    static int Normiere(int m) {
        int rest = m % MinutenProTag;
        if (rest < 0)
            rest += MinutenProTag;
        return rest;
    }

    public Uhrzeit(int stunde, int minute) {
        minuten = Normiere(stunde * 60 + minute);
    }

    public Uhrzeit(int minutenSeitMitternacht) {
        minuten = Normiere(minutenSeitMitternacht);
    }

    public int Stunde {
        get { return minuten / 60; }
    }

    public int Minute {
        get { return minuten % 60; }
    }

    // Verschiebt diese Uhrzeit um die angegebenen Minuten (auch negativ).
    public void Addiere(int minuten) {
        this.minuten = Normiere(this.minuten + minuten);
    }

    // Verschiebt diese Uhrzeit um Stunden und Minuten.
    public void Addiere(int stunden, int minuten) {
        Addiere(stunden * 60 + minuten);
    }

    // Liefert die Uhrzeit als "hh:mm", z. B. "07:05".
    public string Text() {
        return $"{Stunde:D2}:{Minute:D2}";
    }

    // Liefert eine NEUE Uhrzeit, u bleibt unverändert.
    public static Uhrzeit operator +(Uhrzeit u, int minuten) {
        return new Uhrzeit(u.minuten + minuten);
    }

    // Wie viele Minuten vergehen von b bis a (vorwärts, über Mitternacht hinweg): 0 bis 1439.
    public static int operator -(Uhrzeit a, Uhrzeit b) {
        return Normiere(a.minuten - b.minuten);
    }
}
