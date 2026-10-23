var quadrate = new Cache<int, long>(3);
for (int i = 1; i <= 4; i++)
    quadrate.Setze(i, (long)i * i);
Console.WriteLine(string.Join(" ", quadrate.Schluessel()));  // 2 3 4
Console.WriteLine(quadrate.HoleOderDefault(2));               // 4
Console.WriteLine(quadrate.HoleOderDefault(1));               // 0 (verdrängt)
Console.WriteLine(string.Join(" ", quadrate.Schluessel()));  // 3 4 2
