var letzte = new Ringpuffer<double>(3);
foreach (double messwert in new[] { 20.5, 21.0, 21.5, 22.0, 22.5 })
    letzte.Hinzufuegen(messwert);
Console.WriteLine(string.Join(" ", letzte.AlsArray()));   // 21,5 22 22,5
Console.WriteLine(letzte.Entnehmen());                     // 21,5

var namen = new Ringpuffer<string>(2);
Console.WriteLine(namen.EntnehmenOderDefault() ?? "(leer)"); // (leer)
