R2Vek v1 = new(), v2 = new(1.0, 1.0);

Console.WriteLine($"Vektor 1: ({v1.X:f2}; {v1.Y:f2}), Länge {v1.Laenge:f2}");
Console.WriteLine($"Vektor 2: ({v2.X:f2}; {v2.Y:f2}), Länge {v2.Laenge:f2}");
Console.WriteLine($"Winkel: {v1.Winkel(v2):f2} Grad");

v2.Drehe(90);
Console.WriteLine($"Vektor 2 gedreht: ({v2.X:f2}; {v2.Y:f2})");
v2.Normiere();
Console.WriteLine($"Vektor 2 normiert: ({v2.X:f2}; {v2.Y:f2})");
var summe = v1.Plus(v2);
Console.WriteLine($"Summe: ({summe.X:f2}; {summe.Y:f2})");
