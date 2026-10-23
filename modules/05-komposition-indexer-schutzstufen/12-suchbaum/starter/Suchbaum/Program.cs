var baum = new Suchbaum();
foreach (int z in new[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 })
    baum.Einfuegen(z);

Console.WriteLine($"Sortiert: {baum}");
Console.WriteLine($"Anzahl {baum.Anzahl}, Höhe {baum.Hoehe}");
Console.WriteLine($"Enthält 6: {baum.Enthaelt(6)}, enthält 5: {baum.Enthaelt(5)}");
