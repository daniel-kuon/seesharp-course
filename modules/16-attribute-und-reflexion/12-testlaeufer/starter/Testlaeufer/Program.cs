foreach (var (name, bestanden) in Laeufer.Starte(typeof(RechnerTests)))
    Console.WriteLine($"{(bestanden ? "OK  " : "FAIL")} {name}");
