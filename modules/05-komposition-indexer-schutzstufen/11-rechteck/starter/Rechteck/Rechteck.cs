// Ein achsenparalleles Rechteck, beschrieben durch zwei Eckpunkte.
// Das Rechteck BESITZT seine Punkte: Niemand außerhalb darf sie verändern können.
public class Rechteck {
    readonly Punkt linksUnten;
    readonly Punkt rechtsOben;

    // a und b sind zwei beliebige gegenüberliegende Ecken.
    public Rechteck(Punkt a, Punkt b) {
        // TODO: eigene Punkte anlegen: links unten die kleineren Koordinaten, rechts oben die größeren (Math.Min, Math.Max)
        throw new NotImplementedException();
    }

    // Liefert eine Kopie, damit der Aufrufer das Rechteck nicht über den Punkt verändern kann.
    public Punkt LinksUnten {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public Punkt RechtsOben {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public double Breite {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public double Hoehe {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public double Flaeche {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public double Umfang {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Liegt p im Rechteck? Punkte auf dem Rand zählen dazu.
    public bool Enthaelt(Punkt p) {
        // TODO
        throw new NotImplementedException();
    }

    // Verschiebt das ganze Rechteck; die Punkte erledigen das selbst.
    public void Verschiebe(double dx, double dy) {
        // TODO
        throw new NotImplementedException();
    }

    // Die Schnittfläche als NEUES Rechteck; null, wenn sich die Rechtecke nicht
    // mit positiver Fläche überlappen (bloßes Berühren zählt nicht).
    public Rechteck? Schnitt(Rechteck r) {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert z. B. "[(1; 2), (4; 6)]".
    public override string ToString() {
        // TODO
        throw new NotImplementedException();
    }
}
