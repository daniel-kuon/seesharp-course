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

    // ggT rekursiv: ist a % b == 0, dann b; sonst ggT(b, a % b)
    public static int GgtRekursiv(int a, int b) {
        throw new NotImplementedException();
    }

    // n! rekursiv; 0! = 1
    public static long Fakultaet(int n) {
        throw new NotImplementedException();
    }

    // F(0) = 0, F(1) = 1, F(n) = F(n-1) + F(n-2)
    public static long Fibonacci(int n) {
        throw new NotImplementedException();
    }

    public void Kuerze() {
        if (Zaehler != 0) {
            int teiler = GgtRekursiv(Math.Abs(Zaehler), Math.Abs(Nenner));
            Zaehler /= teiler;
            Nenner /= teiler;
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
}
