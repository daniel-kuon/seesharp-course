using System;

// Eine Rechenaufgabe mit zwei Brüchen. Die Klasse Aufgabe besitzt ihre Bruch-Objekte
// (Aggregation): sie erzeugt sie im Konstruktor und delegiert das Rechnen an sie.
public class Aufgabe {
    readonly Bruch b1, b2, lsg;
    public char Op { get; private set; }

    /// <summary>Die (gekürzte) Lösung der Aufgabe.</summary>
    public Bruch Loesung => lsg;

    public Aufgabe(char op, int b1Z, int b1N, int b2Z, int b2N) {
        // TODO: Op setzen, b1 und b2 mit den Etiketten "1. Argument:" und "2. Argument:" erzeugen,
        //       lsg mit den Werten von b1 und dem Etikett "Resultat" erzeugen, dann Init() aufrufen
        throw new NotImplementedException();
    }

    private void Init() {
        // TODO: je nach Op ('+' oder '*') lsg um b2 erweitern (Addiere bzw. Multipliziere)
        throw new NotImplementedException();
    }

    /// <summary>Prüft eine Antwort; ungekürzte Antworten gelten als richtig.</summary>
    public bool Pruefe(int zaehler, int nenner) {
        // TODO: aus zaehler/nenner einen Bruch bauen, kürzen und mit lsg vergleichen
        throw new NotImplementedException();
    }

    public void NeueWerte(char op, int b1Z, int b1N, int b2Z, int b2N) {
        // TODO: Op und die Werte von b1, b2 und lsg ändern (keine neuen Objekte!), dann Init()
        throw new NotImplementedException();
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
