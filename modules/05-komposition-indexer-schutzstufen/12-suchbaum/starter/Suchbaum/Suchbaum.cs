// Ein binärer Suchbaum für ganze Zahlen: Links von einem Knoten stehen nur
// kleinere Werte, rechts nur größere. Jeder Wert kommt höchstens einmal vor.
public class Suchbaum {
    Knoten? wurzel;

    // Ein Baumknoten: geschachtelt und privat.
    class Knoten(int wert) {
        public int Wert { get; } = wert;
        public Knoten? Links { get; set; }
        public Knoten? Rechts { get; set; }
    }

    // Fügt den Wert ein; false, wenn er schon im Baum steht.
    public bool Einfuegen(int wert) {
        // TODO: leerer Baum -> neue Wurzel; sonst von der Wurzel aus links oder rechts absteigen,
        // bis ein freier Platz (null) gefunden ist
        throw new NotImplementedException();
    }

    public bool Enthaelt(int wert) {
        // TODO
        throw new NotImplementedException();
    }

    // Anzahl der Knoten, rekursiv gezählt.
    public int Anzahl {
        get {
            // TODO: Hilfsmethode Zaehle(wurzel) schreiben und aufrufen
            throw new NotImplementedException();
        }
    }

    // Höhe: leerer Baum 0, nur Wurzel 1, sonst 1 + die größere Höhe der beiden Teilbäume.
    public int Hoehe {
        get {
            // TODO: rekursive Hilfsmethode
            throw new NotImplementedException();
        }
    }

    // Alle Werte aufsteigend, durch Leerzeichen getrennt: "1 3 5 8". Leerer Baum: "".
    public override string ToString() {
        // TODO: rekursiv erst links, dann der Knoten, dann rechts (In-Order)
        throw new NotImplementedException();
    }
}
