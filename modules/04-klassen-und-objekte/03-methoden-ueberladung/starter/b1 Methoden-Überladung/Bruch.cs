using System;

public class Bruch {
    int zaehler,            // wird automatisch mit 0 initialisiert
        nenner = 1;
    string etikett = "";

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

    public string Etikett {
        get {
            return etikett;
        }
        set {
            if (value.Length <= 40)
                etikett = value;
            else
                etikett = value.Substring(0, 40);
        }
    }

    public void Kuerze() {
        // größten gemeinsamen Teiler mit Euklids Algorithmus bestimmen
        // (performante Variante mit Modulo-Operator)
        if (zaehler != 0) {
            int rest;
            int ggt = Math.Abs(zaehler);
            int divisor = Math.Abs(nenner);
            do {
                rest = ggt % divisor;
                ggt = divisor;
                divisor = rest;
            } while (rest > 0);
            zaehler /= ggt;
            nenner /= ggt;
        } else
            nenner = 1;
    }

    public void Addiere(Bruch b) {
        // TODO: b addieren und anschließend kürzen
        throw new NotImplementedException();
    }

    public bool Addiere(int zpar, int npar, bool autokurz) {
        // TODO: zpar/npar addieren; bei npar == 0 nichts tun und false liefern; bei autokurz kürzen
        throw new NotImplementedException();
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
}
