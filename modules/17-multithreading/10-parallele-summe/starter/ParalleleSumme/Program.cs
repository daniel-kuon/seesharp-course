var zufall = new Random(1);
int[] daten = Enumerable.Range(0, 100_000).Select(_ => zufall.Next(0, 100)).ToArray();

Console.WriteLine($"Summe: {Statistik.Summe(daten)} (sequenziell {daten.Sum(x => (long)x)})");
Console.WriteLine($"Maximum: {Statistik.Maximum(daten)}");
Console.WriteLine("Histogramm: " + string.Join(", ", Statistik.Histogramm(daten, 5)));
