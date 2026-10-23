Mitarbeiter[] team = [
    new Angestellter("Anna", 3200m),
    new Teamleiter("Tina", 4000m, 500m),
    new Freelancer("Fritz", 85m, 40),
];
foreach (Mitarbeiter m in team)
    Console.WriteLine($"{m.Beschreibung()}: {m.Gehalt():0.00} €");
Console.WriteLine($"Summe: {Lohnliste.Summe(team):0.00} €, Spitzenverdiener: {Lohnliste.Spitzenverdiener(team)}");
