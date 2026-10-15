var pl = new PersList();
pl.Add(new Person("Otto", "Kolbe"));
pl.Add(new Person("Kurt", "Saar"));
pl.Add(new Person("Theo", "Müller"));
for (int i = 0; i < pl.Count; i++)
    Console.WriteLine($"Nummer {i}: {pl[i].Vorname} {pl[i].Name}");

pl[1] = new Person("Ilse", "Golter");
Console.WriteLine($"\nName der ersten Person mit dem Vornamen Ilse: {pl["Ilse"].Name}");
