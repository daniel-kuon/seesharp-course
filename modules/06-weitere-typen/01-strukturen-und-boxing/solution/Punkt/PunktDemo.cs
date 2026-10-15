var p1 = new Punkt(1, 2);
var p3 = p1;          // bei einer Struktur: Kopie, bei einer Klasse: zweite Referenz
p1.Bewegen(1, 0);
Console.WriteLine($"p1 = {p1.Pos()}, p3 = {p3.Pos()}");

var p2 = Punkt.Verschoben(p1, 1, 1);
Console.WriteLine($"p1 = {p1.Pos()}, p2 = {p2.Pos()}");
