string s = "Dieser  Satz - bitte beachten - passt nicht in eine Schmal-Zeile, die nur wenige Spalten umfasst.";
foreach (var zeile in StringUtil.WrapLine(s, 30, true))
    Console.WriteLine(zeile);
Console.WriteLine();
Console.WriteLine($"Glückszahl: {StringUtil.Glueckszahl("Otto", "Meier")}");
Console.WriteLine($"Vokale: {StringUtil.ZaehleVokale(s)}, umgekehrt: {StringUtil.Umkehren("Otto")}");
