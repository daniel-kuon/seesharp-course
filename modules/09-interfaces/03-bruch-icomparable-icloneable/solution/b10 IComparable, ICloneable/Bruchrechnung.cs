Bruch[] b = new Bruch[3];
b[0] = new Bruch(2, 3, "b[0]");
b[1] = (Bruch)b[0].Clone();
b[1].Etikett = "Klon";
b[2] = new Bruch(3, 5, "b[2]");
Array.Sort(b); // braucht IComparable<Bruch>
foreach (Bruch br in b)
    Console.WriteLine($"{br.Etikett}: {br}");
