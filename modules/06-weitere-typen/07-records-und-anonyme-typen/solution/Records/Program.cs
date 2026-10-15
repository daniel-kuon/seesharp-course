var a = new Artikel("Apfel", 3);
var b = new Artikel("Apfel", 3);
Console.WriteLine(a == b);          // Record: True (Wertgleichheit)
Console.WriteLine(a);               // Record: Artikel { Name = Apfel, Menge = 3 }
var c = a.MitMenge(10);
Console.WriteLine($"{a.Menge} -> {c.Menge}");
