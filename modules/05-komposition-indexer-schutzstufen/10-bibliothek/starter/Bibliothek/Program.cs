var bib = new Bibliothek();
bib.Add(new Buch("Der Process", "Kafka", 1925));
bib.Add(new Buch("Effi Briest", "Fontane", 1896));
bib.Add(new Buch("Das Schloss", "Kafka", 1926));

Console.WriteLine($"Erstes Buch: {bib[0]}");
Console.WriteLine($"Ausleihen: {bib.Ausleihen("Effi Briest")}, noch einmal: {bib.Ausleihen("Effi Briest")}");
Console.WriteLine($"Verfügbar: {bib.Verfuegbar} von {bib.Anzahl}");
Console.WriteLine($"Von Kafka: {bib.VonAutor("Kafka")}");
