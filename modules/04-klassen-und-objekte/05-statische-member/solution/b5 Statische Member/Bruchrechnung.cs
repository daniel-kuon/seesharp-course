var b = Bruch.BenDef("Anteil");
if (b != null)
    b.Zeige();
else
    Console.WriteLine("Ungültige Antwort");

var b1 = new Bruch();
var b2 = new Bruch();
b1.Zeige();
b2.Zeige();
Console.WriteLine($"Erzeugte Brüche: {Bruch.Anzahl}");
