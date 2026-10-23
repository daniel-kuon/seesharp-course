var b = new Bereich(1, 10, 3);
Console.WriteLine(string.Join(" ", b));                 // 1 4 7 10
Console.WriteLine(string.Join(" ", b.Rueckwaerts));     // 10 7 4 1
Console.WriteLine(string.Join(" ", new Bereich(1, 20).Vielfache(6)));  // 6 12 18
Console.WriteLine($"{b.Count} Werte, enthält 7: {b.Enthaelt(7)}");
Console.WriteLine(string.Join(" ", Folgen.Erste(Folgen.Quadratzahlen(), 6)));  // 1 4 9 16 25 36
