// Die Klasse Bruch aus Kapitel 1 des Buchs. Nicht verändern.
public class Bruch {
    int zaehler,    // wird automatisch mit 0 initialisiert
        nenner = 1;

    public int Zaehler {
        get {
            return zaehler;
        }
        set {
            zaehler = value;
        }
    }

    public int Nenner {
        get {
            return nenner;
        }
        set {
            if (value != 0)
                nenner = value;
        }
    }

    public string Text() {
        return zaehler + "/" + nenner;
    }

    public void Kuerze() {
        // größten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen
        if (zaehler != 0) {
            int az = Math.Abs(zaehler);
            int an = Math.Abs(nenner);
            while (az != an)
                if (az > an)
                    az = az - an;
                else
                    an = an - az;
            zaehler = zaehler / az;
            nenner = nenner / az;
        } else
            nenner = 1;
    }

    public void Addiere(Bruch b) {
        zaehler = zaehler * b.nenner + b.zaehler * nenner;
        nenner = nenner * b.nenner;
        Kuerze();
    }
}
