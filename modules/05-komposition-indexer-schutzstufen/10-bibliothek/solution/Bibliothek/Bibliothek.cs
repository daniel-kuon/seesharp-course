// Eine Bibliothek verwaltet ihre Bücher in einer einfach verketteten Liste.
public class Bibliothek {
    Knoten? erster, letzter;

    // Ein Listenknoten: geschachtelt und privat, nur die Bibliothek kennt ihn.
    class Knoten(Buch buch) {
        public Buch Buch { get; } = buch;
        public Knoten? Next { get; set; }
    }

    public int Anzahl { get; private set; }

    // Wie viele Bücher gerade nicht ausgeliehen sind (berechnet, kein Feld).
    public int Verfuegbar {
        get {
            int n = 0;
            for (Knoten? k = erster; k != null; k = k.Next)
                if (!k.Buch.Ausgeliehen)
                    n++;
            return n;
        }
    }

    public void Add(Buch buch) {
        var neu = new Knoten(buch);
        if (letzter == null)
            erster = neu;
        else
            letzter.Next = neu;
        letzter = neu;
        Anzahl++;
    }

    // Das Buch an Position i; bei ungültigem Index ArgumentOutOfRangeException.
    public Buch this[int i] {
        get {
            if (i < 0 || i >= Anzahl)
                throw new ArgumentOutOfRangeException(nameof(i));
            Knoten k = erster!;
            for (int j = 0; j < i; j++)
                k = k.Next!;
            return k.Buch;
        }
    }

    // Das erste Buch mit genau diesem Titel, sonst null.
    public Buch? this[string titel] {
        get {
            for (Knoten? k = erster; k != null; k = k.Next)
                if (k.Buch.Titel == titel)
                    return k.Buch;
            return null;
        }
    }

    // Leiht das Buch mit diesem Titel aus; false, wenn es fehlt oder schon ausgeliehen ist.
    public bool Ausleihen(string titel) {
        Buch? b = this[titel];
        if (b == null || b.Ausgeliehen)
            return false;
        b.Ausgeliehen = true;
        return true;
    }

    // Nimmt das Buch zurück; false, wenn es fehlt oder gar nicht ausgeliehen war.
    public bool Zurueckgeben(string titel) {
        Buch? b = this[titel];
        if (b == null || !b.Ausgeliehen)
            return false;
        b.Ausgeliehen = false;
        return true;
    }

    // Die Titel aller Bücher dieses Autors in Einfügereihenfolge, getrennt durch ", ".
    // Keine Treffer: leerer String.
    public string VonAutor(string autor) {
        string ergebnis = "";
        for (Knoten? k = erster; k != null; k = k.Next) {
            if (k.Buch.Autor != autor)
                continue;
            if (ergebnis.Length > 0)
                ergebnis += ", ";
            ergebnis += k.Buch.Titel;
        }
        return ergebnis;
    }
}
