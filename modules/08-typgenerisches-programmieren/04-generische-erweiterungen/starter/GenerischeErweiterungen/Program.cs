int[] zahlen = [3, 1, 4, 1, 5];
Console.WriteLine(zahlen.MinFirst);              // False
Console.WriteLine(zahlen.LeadingMin());          // False
Console.WriteLine(zahlen.Groesstes());           // 5
string[] woerter = ["abc", "def"];
Console.WriteLine(woerter.MinFirst);             // True
Console.WriteLine(string.Join(" ", woerter.Umgekehrt()));
