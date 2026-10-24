var schlange = new SichereWarteschlange<string>();
schlange.Einreihen("eins");
schlange.Einreihen("zwei");

while (schlange.TryNaechster(out string? text))
    Console.WriteLine(text);
