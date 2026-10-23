Medium[] bestand = [
    new Buch("Faust", "Goethe"),
    new Bestseller("Der Schwarm", "Schätzing"),
    new Film("Metropolis", 153),
];
foreach (Medium m in bestand)
    Console.WriteLine($"{m.Info()} — 5 Tage zu spät: {m.Mahngebuehr(5):0.00} €");
