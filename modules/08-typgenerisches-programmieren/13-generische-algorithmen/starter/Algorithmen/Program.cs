int[] a = [1, 4, 9], b = [2, 3, 10];
int[] alle = Algorithmen.Zusammenfuehren(a, b);
Console.WriteLine(string.Join(" ", alle));                     // 1 2 3 4 9 10
Console.WriteLine(Algorithmen.IstSortiert(alle));              // True
Console.WriteLine(Algorithmen.BinaereSuche(alle, 9));          // 4
var (min, max) = Algorithmen.MinMax("Otto", "Anna", "Zoe");
Console.WriteLine($"{min} .. {max}");                          // Anna .. Zoe
