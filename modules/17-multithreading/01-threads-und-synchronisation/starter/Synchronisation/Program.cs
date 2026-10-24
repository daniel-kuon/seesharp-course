Console.WriteLine(string.Join(", ", Parallelrechner.Quadrate([1, 2, 3, 4, 5, 6, 7], 3)));

foreach (IZaehler zaehler in new IZaehler[] { new UnsichererZaehler(), new SichererZaehler(), new AtomarerZaehler() })
{
    var threads = Enumerable.Range(0, 4)
        .Select(_ => new Thread(() => { for (int i = 0; i < 100_000; i++) zaehler.Erhoehe(); }))
        .ToList();
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
    Console.WriteLine($"{zaehler.GetType().Name}: {zaehler.Wert} (erwartet 400000)");
}
