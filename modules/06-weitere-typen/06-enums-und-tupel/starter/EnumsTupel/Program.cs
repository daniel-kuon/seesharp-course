var otto = new Person("Otto", "Hummer", 35, Temperament.Sanguinisch);
if (otto.Temp == Temperament.Sanguinisch)
    Console.WriteLine("Lustiger Typ!");

otto.Temp = (Temperament)13; // wird vom Setter verhindert
Console.WriteLine(otto.Temp);

var (vn, nn) = otto;
Console.WriteLine($"{vn} {nn}");

var an = Analyse.AnalyzeName("Otto Rentner");
Console.WriteLine($"{an.First} ist Palindrom: {an.FirstPalin}, {an.Last} ist Palindrom: {an.LastPalin}");
