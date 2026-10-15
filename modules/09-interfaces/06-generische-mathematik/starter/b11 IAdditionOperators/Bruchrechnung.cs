var b1 = new Bruch(int.MaxValue, 1, "");
var b2 = new Bruch(10, 1, "");

Console.WriteLine(b1 + b2); // unchecked: Überlauf, Unsinn ohne Fehlermeldung
try {
    Bruch summe;
    checked {
        summe = b1 + b2;  // ruft operator checked +
    }
    Console.WriteLine(summe);
} catch (OverflowException e) {
    Console.WriteLine("Überlauf erkannt: " + e.Message);
}

Console.WriteLine(Rechner.Summe(1, 2, 3));                                  // 6
Console.WriteLine(Rechner.Summe(new Bruch(1, 2, ""), new Bruch(1, 3, ""))); // 5/6
Console.WriteLine(Kombinierer.Combine(new Glas("One"), new Glas("Too"), new Glas("Tree")).Sticker);
