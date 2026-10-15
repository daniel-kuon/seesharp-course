using System;
class Bruchrechnung {
    static void Main() {
        Bruch b = new();
        Console.WriteLine("Kürze Deinen Bruch:\n");
        b.Frage();
        b.Kuerze();
        b.Etikett = "Gekürzt";
        b.Zeige();

        // beide Überladungen ausprobieren
        b.Addiere(new Bruch { Zaehler = 1, Nenner = 4 });
        b.Addiere(1, 4, autokurz: true);
        b.Zeige();
    }
}
