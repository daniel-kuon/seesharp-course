var abfahrt = new Uhrzeit(22, 45);
var ankunft = abfahrt + 150;
Console.WriteLine($"Abfahrt {abfahrt.Text()}, Ankunft {ankunft.Text()}");
Console.WriteLine($"Fahrzeit: {ankunft - abfahrt} Minuten");

var wecker = new Uhrzeit(25, 70);
Console.WriteLine($"25:70 wird zu {wecker.Text()}");
wecker.Addiere(-2, 0);
Console.WriteLine($"zwei Stunden früher: {wecker.Text()}");
