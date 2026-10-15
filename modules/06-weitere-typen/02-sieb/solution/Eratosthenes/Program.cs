Console.Write("Suchen bis: ");
int grenze = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(string.Join(" ", Primzahlen.BisZu(grenze)));
Console.WriteLine($"{Primzahlen.Anzahl(grenze)} Primzahlen");
