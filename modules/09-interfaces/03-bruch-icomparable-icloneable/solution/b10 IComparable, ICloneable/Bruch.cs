using System;

public class Bruch : IComparable<Bruch>, ICloneable {
    public int Zaehler { get; set; }

    public int Nenner {
        get;
        set {
            if (value != 0)
                field = value;
        }
    } = 1;

    public string Etikett {
        get;
        set {
            if (value.Length <= 40)
                field = value;
            else
                field = value.Substring(0, 40);
        }
    } = "";

    public static int Anzahl { get; private set; }

    public Bruch(int zpar, int npar, string epar) {
        Zaehler = zpar;
        Nenner = npar;
        Etikett = epar;
        Anzahl++;
    }

    public Bruch() {
        Anzahl++;
    }

    public override string ToString() => $"{Zaehler}/{Nenner}";

    public void Kuerze() {
        // größten gemeinsamen Teiler mit Euklids Algorithmus bestimmen
        if (Zaehler != 0) {
            int rest;
            int ggt = Math.Abs(Zaehler);
            int divisor = Math.Abs(Nenner);
            do {
                rest = ggt % divisor;
                ggt = divisor;
                divisor = rest;
            } while (rest > 0);
            Zaehler /= ggt;
            Nenner /= ggt;
        } else
            Nenner = 1;
    }

    public void Addiere(Bruch b) {
        Zaehler = Zaehler * b.Nenner + b.Zaehler * Nenner;
        Nenner = Nenner * b.Nenner;
        Kuerze();
    }

    public bool Addiere(int zpar, int npar, bool autokurz) {
        if (npar != 0) {
            Zaehler = Zaehler * npar + zpar * Nenner;
            Nenner = Nenner * npar;
            if (autokurz)
                Kuerze();
            return true;
        } else
            return false;
    }

    public static Bruch operator +(Bruch b1, Bruch b2) {
        Bruch tmp = b1.Klone();
        tmp.Addiere(b2);
        tmp.Etikett = $"{b1.Etikett} + {b2.Etikett}";
        return tmp;
    }

    public void operator +=(Bruch b) {
        Zaehler = Zaehler * b.Nenner + b.Zaehler * Nenner;
        Nenner = Nenner * b.Nenner;
        Etikett = $"{Etikett} + {b.Etikett}";
        Kuerze();
    }

    public void Multipliziere(Bruch b) {
        Zaehler *= b.Zaehler;
        Nenner *= b.Nenner;
        Kuerze();
    }

    // Vergleicht die Werte beider Brüche per Kreuzmultiplikation (long, damit nichts überläuft):
    // negativ, wenn dieser Bruch kleiner ist; 0 bei Gleichheit; positiv, wenn er größer ist.
    // Die Kreuzmultiplikation multipliziert beide Seiten mit Nenner · b.Nenner; ist dieses Produkt
    // negativ (genau ein Nenner negativ), kehrt sich der Vergleich um.
    public int CompareTo(Bruch? b) {
        if (b is null)
            return 1;
        long z1hn = (long)Zaehler * b.Nenner;
        long z2hn = (long)b.Zaehler * Nenner;
        int vergleich = z1hn.CompareTo(z2hn);
        return (Nenner < 0) != (b.Nenner < 0) ? -vergleich : vergleich;
    }

    // ICloneable verlangt object Clone(); MemberwiseClone() liefert eine flache Kopie.
    public object Clone() {
        return MemberwiseClone();
    }

    public bool Frage() {
        try {
            Console.Write("Zähler: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nenner: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Zaehler = z;
            Nenner = n;
            return true;
        } catch {
            return false;
        }
    }

    public void Zeige() {
        string luecke = "  ";
        string glz;
        for (int i = 1; i <= Etikett.Length; i++)
            luecke += " ";
        if (Etikett.Length == 0)
            glz = "";
        else {
            glz = " = ";
            luecke += "   ";
        }
        Console.WriteLine($" {luecke}{Zaehler}\n {Etikett}{glz}-----\n {luecke}{Nenner}\n");
    }

    public void DuplWerte(Bruch bc) {
        bc.Zaehler = Zaehler;
        bc.Nenner = Nenner;
    }

    public Bruch Klone() {
        return new Bruch(Zaehler, Nenner, Etikett);
    }

    public static Bruch? BenDef(string e) {
        var b = new Bruch(0, 1, e);
        if (b.Frage()) {
            b.Kuerze();
            return b;
        } else
            return null;
    }
}
