using System;

public class Bruch {
    public int Zaehler { get; set; }

    // TODO: Setter mit Validierung (0 ignorieren) über das Schlüsselwort field
    public int Nenner { get; set; } = 1;

    // TODO: Setter mit Validierung (höchstens 40 Zeichen) über das Schlüsselwort field
    public string Etikett { get; set; } = "";

    public static int Anzahl { get; private set; }

    static int ZaehlerVoreinst { get; }
    static int NennerVoreinst { get; }

    public Bruch(int zpar, int npar, string epar) {
        Zaehler = zpar;
        Nenner = npar;
        Etikett = epar;
        // TODO: Anzahl erhöhen
    }

    public Bruch() {
        Zaehler = ZaehlerVoreinst;
        Nenner = NennerVoreinst;
        // TODO: Anzahl erhöhen
    }

    // TODO: statischer Konstruktor, der ZaehlerVoreinst (1..6) und NennerVoreinst (ZaehlerVoreinst..8) zufällig setzt

    public void Kuerze() {
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

    // Fabrikmethode: Bruch 0/1 mit Etikett e anlegen, per Frage() füllen lassen, kürzen; bei Fehlschlag null
    public static Bruch? BenDef(string e) {
        throw new NotImplementedException();
    }
}
