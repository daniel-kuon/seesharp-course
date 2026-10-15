var si = new SimpleSortedList<int>(5) { 11, 2, 1, 4, 7 }; // Kollektionsinitialisierer: IEnumerable + Add

foreach (int i in si)
    Console.Write(i + " ");
Console.WriteLine();

// Das macht foreach im Hintergrund:
using var e = si.GetEnumerator();
while (e.MoveNext())
    Console.Write(e.Current + " ");
Console.WriteLine();
