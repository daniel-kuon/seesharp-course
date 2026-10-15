using de.bebagoe.fraction;

var summe = Rechner.Summe(new Bruch(1, 2, "a"), new Bruch(1, 3, "b"), new Bruch(1, 6, "c"));
Console.WriteLine($"{summe.Etikett} = {summe}");
var mittel = Rechner.Mittel(new Bruch(1, 2, "a"), new Bruch(1, 4, "b"));
Console.WriteLine($"{mittel.Etikett} = {mittel}");
