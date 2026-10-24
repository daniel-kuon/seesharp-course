var kunde = new Kunde { Name = "Anna", Alter = 30, Rabatt = 2.5, Aktiv = true, Notiz = "geheim" };

string[] zeilen = Mapper.NachZeilen(kunde).ToArray();
Console.WriteLine(string.Join(Environment.NewLine, zeilen));

Kunde kopie = Mapper.VonZeilen<Kunde>(zeilen);
Console.WriteLine($"Zurückgelesen: {kopie.Name}, {kopie.Alter}, {kopie.Rabatt}, {kopie.Aktiv}");
