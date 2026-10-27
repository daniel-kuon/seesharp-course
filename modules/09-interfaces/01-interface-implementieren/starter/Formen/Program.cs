IForm[] formen = [new Kreis(1.0), new Quadrat(2.0)];
foreach (var f in formen)
    Console.WriteLine($"{f.Name}: Inhalt {f.Inhalt:f2}, Umfang {f.Umfang():f2}");
Console.WriteLine($"Gesamt: {Formen.Gesamt(formen):f2}, größte Form: {Formen.Groesste(formen)}");

// Tückisches Boxing (9.3.2): q ist eine Struktur, geboxt eine geboxte Kopie davon.
var q = new Quadrat(1.0);
IForm geboxt = q;
q.Skaliere(3.0);
Console.WriteLine($"q.Inhalt = {q.Inhalt}, geboxt.Inhalt = {geboxt.Inhalt}");
