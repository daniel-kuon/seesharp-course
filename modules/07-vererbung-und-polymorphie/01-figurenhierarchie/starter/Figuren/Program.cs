Figur[] fa = [
    new Figur(10.0, 10.0),
    new Rechteck(20.0, 20.0, 20.0, 20.0),
    new Kreis(30.0, 30.0, 30.0),
    new Kreis(40.0, 40.0, 30.0),
];

foreach (Figur e in fa) {
    Console.Write($"{e.GetType().Name}: oben links {e.Wo}");
    if (e is Kreis kr)
        Console.Write($", Radius {kr.Radius}");
    Console.WriteLine();
}
Console.WriteLine($"Summe der Radien: {Figur.SummeRadien(fa)}");
