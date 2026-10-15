var si = new SimpleSortedList<int>(5) { 11, 2, 1, 4, 7 };

Console.WriteLine("Standard: " + string.Join(" ", si));
Console.WriteLine("RangeIt(1, 3): " + string.Join(" ", si.RangeIt(1, 3)));
Console.WriteLine("RangeIt(1, 14): " + string.Join(" ", si.RangeIt(1, 14)));
Console.WriteLine("DownIt: " + string.Join(" ", si.DownIt));
Console.WriteLine("RangeItUpDown(4, 1): " + string.Join(" ", si.RangeItUpDown(4, 1)));
