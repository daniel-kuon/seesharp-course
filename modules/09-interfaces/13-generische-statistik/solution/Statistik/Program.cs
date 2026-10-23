Console.WriteLine(Statistik.Summe(1, 2, 3));                // 6
Console.WriteLine(Statistik.Mittelwert(1, 2));              // 1 (ganzzahlig)
Console.WriteLine(Statistik.Mittelwert(1.0, 2.0));          // 1,5
Console.WriteLine(Statistik.Spannweite(19.99m, 4.50m));     // 15,49
Console.WriteLine(Statistik.Summe(int.MaxValue, 1));        // -2147483648 (Überlauf)
try {
    Statistik.SummeGeprueft(int.MaxValue, 1);
} catch (OverflowException) {
    Console.WriteLine("Überlauf erkannt");
}
