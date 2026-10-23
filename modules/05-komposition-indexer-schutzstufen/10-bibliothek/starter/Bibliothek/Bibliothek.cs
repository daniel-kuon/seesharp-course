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
            // TODO: die Liste durchlaufen und zählen
            throw new NotImplementedException();
        }
    }

    public void Add(Buch buch) {
        // TODO: einen neuen Knoten anhängen, Anzahl erhöhen
        throw new NotImplementedException();
    }

    // Das Buch an Position i; bei ungültigem Index ArgumentOutOfRangeException.
    public Buch this[int i] {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Das erste Buch mit genau diesem Titel, sonst null.
    public Buch? this[string titel] {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Leiht das Buch mit diesem Titel aus; false, wenn es fehlt oder schon ausgeliehen ist.
    public bool Ausleihen(string titel) {
        // TODO: den string-Indexer wiederverwenden
        throw new NotImplementedException();
    }

    // Nimmt das Buch zurück; false, wenn es fehlt oder gar nicht ausgeliehen war.
    public bool Zurueckgeben(string titel) {
        // TODO
        throw new NotImplementedException();
    }

    // Die Titel aller Bücher dieses Autors in Einfügereihenfolge, getrennt durch ", ".
    // Keine Treffer: leerer String.
    public string VonAutor(string autor) {
        // TODO
        throw new NotImplementedException();
    }
}
