Figur[] fa = [
    new Kreis(50.0, 50.0, 5.0),
    new Rechteck(10.0, 10.0, 5.0, 5.0)
];

foreach (var f in fa)
    f.Skaliere(2.0);
for (int i = 0; i < fa.Length; i++)
    Console.WriteLine($"Fläche Figur {i}: {fa[i].Inhalt,10:f2}");
Console.WriteLine($"\nGesamtfläche:   {Figur.Gesamtflaeche(fa),10:f2}");
