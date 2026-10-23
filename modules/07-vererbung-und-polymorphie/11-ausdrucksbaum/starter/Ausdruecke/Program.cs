Ausdruck a = new Mal(new Plus(new Zahl(2), new Zahl(3)), new Zahl(4));
Console.WriteLine($"{a} = {a.Auswerten()}");      // ((2 + 3) * 4) = 20
Console.WriteLine($"{a.Knoten} Knoten");            // 5 Knoten

Ausdruck b = new Mal(new Zahl(1), new Minus(new Zahl(10), new Zahl(4)));
Console.WriteLine($"{b} vereinfacht: {b.Vereinfache()}");   // (10 - 4)
