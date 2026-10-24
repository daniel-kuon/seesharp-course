var person = new Person { Name = "", Alter = 150 };
foreach (string fehler in Validierer.Pruefe(person))
    Console.WriteLine(fehler);
