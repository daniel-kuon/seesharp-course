var otto = new Konto("Otto", 100m);
var ilse = new Konto("Ilse");
otto.Dispo = 50m;

Console.WriteLine($"Abheben 120: {otto.Abheben(120m)}");
Console.WriteLine($"Überweisung 20 an Ilse: {otto.Ueberweise(ilse, 20m)}");
Console.WriteLine($"Konto {otto.Nummer} ({otto.Inhaber}): {otto.Kontostand}");
Console.WriteLine($"Konto {ilse.Nummer} ({ilse.Inhaber}): {ilse.Kontostand}");
Console.WriteLine($"Konten insgesamt: {Konto.Anzahl}");
