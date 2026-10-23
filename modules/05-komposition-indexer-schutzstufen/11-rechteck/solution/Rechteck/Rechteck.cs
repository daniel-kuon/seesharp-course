// Ein achsenparalleles Rechteck, beschrieben durch zwei Eckpunkte.
// Das Rechteck BESITZT seine Punkte: Niemand außerhalb darf sie verändern können.
public class Rechteck {
    readonly Punkt linksUnten;
    readonly Punkt rechtsOben;

    // a und b sind zwei beliebige gegenüberliegende Ecken.
    public Rechteck(Punkt a, Punkt b) {
        linksUnten = new Punkt(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
        rechtsOben = new Punkt(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
    }

    // Liefert eine Kopie, damit der Aufrufer das Rechteck nicht über den Punkt verändern kann.
    public Punkt LinksUnten {
        get { return linksUnten.Klone(); }
    }

    public Punkt RechtsOben {
        get { return rechtsOben.Klone(); }
    }

    public double Breite {
        get { return rechtsOben.X - linksUnten.X; }
    }

    public double Hoehe {
        get { return rechtsOben.Y - linksUnten.Y; }
    }

    public double Flaeche {
        get { return Breite * Hoehe; }
    }

    public double Umfang {
        get { return 2 * (Breite + Hoehe); }
    }

    // Liegt p im Rechteck? Punkte auf dem Rand zählen dazu.
    public bool Enthaelt(Punkt p) {
        return p.X >= linksUnten.X && p.X <= rechtsOben.X
            && p.Y >= linksUnten.Y && p.Y <= rechtsOben.Y;
    }

    // Verschiebt das ganze Rechteck; die Punkte erledigen das selbst.
    public void Verschiebe(double dx, double dy) {
        linksUnten.Verschiebe(dx, dy);
        rechtsOben.Verschiebe(dx, dy);
    }

    // Die Schnittfläche als NEUES Rechteck; null, wenn sich die Rechtecke nicht
    // mit positiver Fläche überlappen (bloßes Berühren zählt nicht).
    public Rechteck? Schnitt(Rechteck r) {
        double links = Math.Max(linksUnten.X, r.linksUnten.X);
        double unten = Math.Max(linksUnten.Y, r.linksUnten.Y);
        double rechts = Math.Min(rechtsOben.X, r.rechtsOben.X);
        double oben = Math.Min(rechtsOben.Y, r.rechtsOben.Y);
        if (links >= rechts || unten >= oben)
            return null;
        return new Rechteck(new Punkt(links, unten), new Punkt(rechts, oben));
    }

    // Liefert z. B. "[(1; 2), (4; 6)]".
    public override string ToString() {
        return $"[{linksUnten}, {rechtsOben}]";
    }
}
