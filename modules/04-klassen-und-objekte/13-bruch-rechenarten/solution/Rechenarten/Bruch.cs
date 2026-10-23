using System;

public class Bruch {
    public int Zaehler { get; set; }

    public int Nenner {
        get;
        set {
            if (value != 0)
                field = value;
        }
    } = 1;

    public Bruch(int zpar, int npar) {
        Zaehler = zpar;
        Nenner = npar;
        Kuerze();
    }

    // Kürzt mit dem ggT und sorgt dafür, dass der Nenner positiv ist: 2/-4 -> -1/2.
    public void Kuerze() {
        if (Zaehler == 0) {
            Nenner = 1;
            return;
        }
        int a = Math.Abs(Zaehler), b = Math.Abs(Nenner), rest;
        do {
            rest = a % b;
            a = b;
            b = rest;
        } while (rest > 0);
        Zaehler /= a;
        Nenner /= a;
        if (Nenner < 0) {
            Zaehler = -Zaehler;
            Nenner = -Nenner;
        }
    }

    public Bruch Klone() {
        return new Bruch(Zaehler, Nenner);
    }

    // Fertiges Beispiel: liefert einen neuen, gekürzten Bruch.
    public static Bruch operator +(Bruch b1, Bruch b2) {
        return new Bruch(b1.Zaehler * b2.Nenner + b2.Zaehler * b1.Nenner, b1.Nenner * b2.Nenner);
    }

    // Vorzeichenwechsel (unärer Operator): -(3/4) -> -3/4.
    public static Bruch operator -(Bruch b) {
        return new Bruch(-b.Zaehler, b.Nenner);
    }

    public static Bruch operator -(Bruch b1, Bruch b2) {
        return b1 + -b2;
    }

    public static Bruch operator *(Bruch b1, Bruch b2) {
        return new Bruch(b1.Zaehler * b2.Zaehler, b1.Nenner * b2.Nenner);
    }

    // Kehrwert als neuer Bruch: 3/4 -> 4/3, -2/5 -> -5/2. Für den Zähler 0 gibt es keinen: null.
    public Bruch? Kehrwert() {
        if (Zaehler == 0)
            return null;
        return new Bruch(Nenner, Zaehler);
    }

    // Division: b1 mal Kehrwert von b2. Ist b2 gleich 0, liefert sie null.
    public static Bruch? operator /(Bruch b1, Bruch b2) {
        Bruch? kehrwert = b2.Kehrwert();
        if (kehrwert == null)
            return null;
        return b1 * kehrwert;
    }

    // Vergleicht die Werte: -1, wenn dieser Bruch kleiner ist als b, 0 bei gleichem Wert, sonst 1.
    public int Vergleiche(Bruch b) {
        int links = Zaehler * b.Nenner;
        int rechts = b.Zaehler * Nenner;
        if (links < rechts)
            return -1;
        if (links > rechts)
            return 1;
        return 0;
    }
}
