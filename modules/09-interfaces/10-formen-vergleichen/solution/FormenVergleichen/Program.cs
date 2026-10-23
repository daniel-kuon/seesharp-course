IForm[] formen = [new Rechteck(2, 5), new Kreis(1), new Dreieck(3, 4, 5)];
foreach (IForm f in Formen.Sortiert(formen))
    Console.WriteLine($"{f.GetType().Name}: Fläche {f.Flaeche:f2}, Umfang {f.Umfang:f2}");
Console.WriteLine($"Größte Form: {Formen.Groesste(formen)?.GetType().Name}");   // Rechteck
