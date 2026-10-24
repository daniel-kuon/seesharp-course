Console.WriteLine("Autoren: " + string.Join(", ", Dokumentation.AutorenVon(typeof(Dummy))));
Console.WriteLine("Methoden mit Autor: " + string.Join(", ", Dokumentation.MethodenMitAutor(typeof(Dummy))));
Console.WriteLine("Eigenschaften: " + string.Join(", ", Dokumentation.Eigenschaften(typeof(Dummy))));
Console.WriteLine("Veraltet: " + Dokumentation.Veraltet(typeof(Dummy)));
