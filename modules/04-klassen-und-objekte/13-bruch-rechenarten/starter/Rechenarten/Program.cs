var a = new Bruch(3, 4);
var b = new Bruch(1, 6);

Console.WriteLine($"a - b = {(a - b).Zaehler}/{(a - b).Nenner}");
Console.WriteLine($"a * b = {(a * b).Zaehler}/{(a * b).Nenner}");

Bruch? q = a / b;
if (q != null)
    Console.WriteLine($"a / b = {q.Zaehler}/{q.Nenner}");

Console.WriteLine($"a im Vergleich zu b: {a.Vergleiche(b)}");
