int[] zahlen = Enumerable.Range(1, 20).ToArray();

Console.WriteLine(ParallelRechner.SummeQuadrate(zahlen));
Console.WriteLine(string.Join(", ", ParallelRechner.SammleGerade(zahlen).OrderBy(x => x)));
Console.WriteLine(string.Join(", ", ParallelRechner.Primzahlen(50)));
