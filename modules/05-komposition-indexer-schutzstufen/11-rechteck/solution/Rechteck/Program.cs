var r = new Rechteck(new Punkt(4, 6), new Punkt(1, 2));
var s = new Rechteck(new Punkt(3, 0), new Punkt(8, 4));

Console.WriteLine($"r = {r}, Fläche {r.Flaeche}, Umfang {r.Umfang}");
Console.WriteLine($"s = {s}");
Console.WriteLine($"Schnitt: {r.Schnitt(s)}");
Console.WriteLine($"(2; 3) in r: {r.Enthaelt(new Punkt(2, 3))}");

r.Verschiebe(10, 0);
Console.WriteLine($"r verschoben: {r}");
