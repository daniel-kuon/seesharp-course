Console.WriteLine($"Lagerregal ist ein Palindrom: {Wortspiele.IstPalindrom("Lagerregal")}");
Console.WriteLine($"Lampe/Palme sind Anagramme: {Wortspiele.IstAnagramm("Lampe", "Palme")}");

string code = Wortspiele.Kodiere("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWBWWWWWWWWWWWWWW");
Console.WriteLine($"Kodiert: {code}");
Console.WriteLine($"Dekodiert: {Wortspiele.Dekodiere(code)}");
