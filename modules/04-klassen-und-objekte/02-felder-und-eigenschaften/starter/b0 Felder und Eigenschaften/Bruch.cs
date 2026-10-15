using System;

public class Bruch {
    int zaehler,            // wird automatisch mit 0 initialisiert
        nenner = 1;
    string etikett = "";

    public int Zaehler {
        // TODO: das Feld zaehler lesen und schreiben
        get {
            return 0;
        }
        set {
        }
    }

    public int Nenner {
        get {
            return nenner;
        }
        set {
            // TODO: den Wert 0 ignorieren
            nenner = value;
        }
    }

    public string Etikett {
        get {
            return etikett;
        }
        set {
            // TODO: höchstens 40 Zeichen übernehmen
            etikett = value;
        }
    }

    public void Kuerze() {
        // TODO: mit dem größten gemeinsamen Teiler (Euklid, Modulo) kürzen; 0/n wird zu 0/1
        throw new NotImplementedException();
    }

    public void Addiere(Bruch b) {
        // TODO: b addieren und anschließend kürzen
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
