using System;
using System.Numerics;

// Bruch erfüllt IAdditionOperators bereits durch operator + aus Level 4.
public class Bruch : IComparable<Bruch>, ICloneable, IAdditionOperators<Bruch, Bruch, Bruch> {
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

    // TODO: checked-Variante des Plusoperators: rechnet mit checked(...) und wirft bei Überlauf OverflowException.
    //       public static Bruch operator checked +(Bruch b1, Bruch b2)

    // TODO: checked-Variante des Instanzoperators += (public void operator checked +=(Bruch b))

    public void Multipliziere(Bruch b) {
        Zaehler *= b.Zaehler;
        Nenner *= b.Nenner;
        Kuerze();
    }

    public int CompareTo(Bruch? b) {
        if (b is null)
            return 1;
        int vergleich = ((long)Zaehler * b.Nenner).CompareTo((long)b.Zaehler * Nenner);
        return (Nenner < 0) != (b.Nenner < 0) ? -vergleich : vergleich; // genau ein Nenner negativ: umdrehen
    }

    public object Clone() => MemberwiseClone();

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
