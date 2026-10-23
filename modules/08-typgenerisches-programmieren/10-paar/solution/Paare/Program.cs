var p = Paar.Von(1, "eins");
Console.WriteLine(p);                      // (1, eins)
Console.WriteLine(p.Getauscht());          // (eins, 1)
Console.WriteLine(p.MitErstem(2.5));       // (2,5, eins)
Console.WriteLine(Paar.Geordnet("Zoe", "Anna")); // (Anna, Zoe)
