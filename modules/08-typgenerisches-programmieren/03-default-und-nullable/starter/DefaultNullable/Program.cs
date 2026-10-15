Console.WriteLine($"int: {Werte.BeschreibeDefault<int>()}");
Console.WriteLine($"string: {Werte.BeschreibeDefault<string>()}");
Console.WriteLine($"int?: {Werte.BeschreibeDefault<int?>()}");
Console.WriteLine($"bool: {Werte.BeschreibeDefault<bool>()}");

int?[] messwerte = [3, null, 4, null, 5];
Console.WriteLine($"Summe: {Werte.Summe(messwerte)}");
Console.WriteLine($"Ersatz: {Werte.OderErsatz(null, -1)}");
