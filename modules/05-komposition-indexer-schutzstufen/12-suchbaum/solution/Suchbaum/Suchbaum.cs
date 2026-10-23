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
        if (wurzel == null) {
            wurzel = new Knoten(wert);
            return true;
        }
        Knoten k = wurzel;
        while (true) {
            if (wert == k.Wert)
                return false;
            if (wert < k.Wert) {
                if (k.Links == null) {
                    k.Links = new Knoten(wert);
                    return true;
                }
                k = k.Links;
            } else {
                if (k.Rechts == null) {
                    k.Rechts = new Knoten(wert);
                    return true;
                }
                k = k.Rechts;
            }
        }
    }

    public bool Enthaelt(int wert) {
        Knoten? k = wurzel;
        while (k != null) {
            if (wert == k.Wert)
                return true;
            k = wert < k.Wert ? k.Links : k.Rechts;
        }
        return false;
    }

    // Anzahl der Knoten, rekursiv gezählt.
    public int Anzahl {
        get { return Zaehle(wurzel); }
    }

    static int Zaehle(Knoten? k) {
        if (k == null)
            return 0;
        return 1 + Zaehle(k.Links) + Zaehle(k.Rechts);
    }

    // Höhe: leerer Baum 0, nur Wurzel 1, sonst 1 + die größere Höhe der beiden Teilbäume.
    public int Hoehe {
        get { return HoeheVon(wurzel); }
    }

    static int HoeheVon(Knoten? k) {
        if (k == null)
            return 0;
        return 1 + Math.Max(HoeheVon(k.Links), HoeheVon(k.Rechts));
    }

    // Alle Werte aufsteigend, durch Leerzeichen getrennt: "1 3 5 8". Leerer Baum: "".
    public override string ToString() {
        return InOrder(wurzel);
    }

    static string InOrder(Knoten? k) {
        if (k == null)
            return "";
        string links = InOrder(k.Links);
        string rechts = InOrder(k.Rechts);
        string text = links;
        if (text.Length > 0)
            text += " ";
        text += k.Wert;
        if (rechts.Length > 0)
            text += " " + rechts;
        return text;
    }
}
