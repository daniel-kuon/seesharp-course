var s = new Sensor();
Console.WriteLine(((IZaehler)s).Wert()); // 1
Console.WriteLine(((IMesser)s).Wert());  // 2
// Console.WriteLine(s.Wert());          // kompiliert nach der expliziten Implementation nicht mehr

var g = new Geraet();
Console.WriteLine(g.Wert());             // 1
Console.WriteLine(((IMesser)g).Wert());  // 2
