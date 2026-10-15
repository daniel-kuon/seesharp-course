using System;

// Eine Rechenaufgabe mit zwei Brüchen. Die Klasse Aufgabe besitzt ihre Bruch-Objekte
// (Aggregation): sie erzeugt sie im Konstruktor und delegiert das Rechnen an sie.
public class Aufgabe {
    readonly Bruch b1, b2, lsg;
    public char Op { get; private set; }

    /// <summary>Die (gekürzte) Lösung der Aufgabe.</summary>
    public Bruch Loesung => lsg;

    public Aufgabe(char op, int b1Z, int b1N, int b2Z, int b2N) {
        Op = op;
        b1 = new Bruch(b1Z, b1N, "1. Argument:");
        b2 = new Bruch(b2Z, b2N, "2. Argument:");
        lsg = new Bruch(b1Z, b1N, "Resultat");
        Init();
    }

    private void Init() {
        switch (Op) {
            case '+':
                lsg.Addiere(b2);
                break;
            case '*':
                lsg.Multipliziere(b2);
                break;
        }
    }

    /// <summary>Prüft eine Antwort; ungekürzte Antworten gelten als richtig.</summary>
    public bool Pruefe(int zaehler, int nenner) {
        var antwort = new Bruch(zaehler, nenner, "");
        antwort.Kuerze();
        return lsg.Zaehler == antwort.Zaehler && lsg.Nenner == antwort.Nenner;
    }

    public void NeueWerte(char op, int b1Z, int b1N, int b2Z, int b2N) {
        Op = op;
        b1.Zaehler = b1Z; b1.Nenner = b1N;
        b2.Zaehler = b2Z; b2.Nenner = b2N;
        lsg.Zaehler = b1Z; lsg.Nenner = b1N;
        Init();
    }

    public void Zeige() {
        Console.WriteLine($"   {b1.Zaehler}                {b2.Zaehler}");
        Console.WriteLine($" ------     {Op}     -----");
        Console.WriteLine($"   {b1.Nenner}                {b2.Nenner}");
    }

    public void Frage() {
        try {
            Console.WriteLine("\nBerechne bitte:\n");
            Zeige();
            Console.Write("\nWelchen Zähler hat Dein Ergebnis:      ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("Welchen Nenner hat Dein Ergebnis:      ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (Pruefe(z, n))
                Console.WriteLine("\n Gut!");
            else {
                Console.WriteLine("\n Leider falsch!\n");
                lsg.Zeige();
            }
        } catch {
            Console.WriteLine("\n Das war keine Zahl.");
        }
    }
}
