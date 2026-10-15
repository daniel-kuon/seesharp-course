var si = new SimpleSortedList<int>(5);
si.Add(11);
si.Add(2);
si.Add(1);
si.Add(4);
for (int i = 0; i < si.Count; i++)
    Console.WriteLine(si[i]);
