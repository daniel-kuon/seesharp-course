var r = new Rechner();
r.Ausfuehren(new Addiere(5));
r.Ausfuehren(new Multipliziere(3));
r.Ausfuehren(new Makro(new Negiere(), new Addiere(1)));
Console.WriteLine($"{r.Wert}: {r.Protokoll()}");   // -14: Addiere 5, Multipliziere 3, Makro(Negiere, Addiere 1)
r.Rueckgaengig();
r.Rueckgaengig();
Console.WriteLine($"{r.Wert}: {r.Protokoll()}");   // 5: Addiere 5
r.Wiederholen();
Console.WriteLine($"{r.Wert}: {r.Protokoll()}");   // 15: Addiere 5, Multipliziere 3
