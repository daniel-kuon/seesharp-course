Artikel[] bestand = [
    new("Apfel", 0.40m, 120),
    new("Birne", 0.55m, 3),
    new("Kiwi", 0.35m, 0),
];

var (min, max, schnitt) = Lager.Preisstatistik(bestand);
Console.WriteLine($"Preise von {min} bis {max}, im Schnitt {schnitt}");
Console.WriteLine($"Gesamtwert: {Lager.Gesamtwert(bestand)}");

foreach (Artikel a in Lager.Nachbestellen(bestand, 10))
    Console.WriteLine(a);

Console.WriteLine(Lager.Reduziere(bestand[0], 25));
