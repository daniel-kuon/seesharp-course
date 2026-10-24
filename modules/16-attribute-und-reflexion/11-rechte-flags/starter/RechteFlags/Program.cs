var b = new Benutzer();
b.Vergib(Rolle.Leser | Rolle.Autor);
Console.WriteLine(b.Beschreibung());
Console.WriteLine(b.Darf(Rolle.Admin));
