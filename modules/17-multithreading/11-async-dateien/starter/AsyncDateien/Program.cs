string ordner = Path.Combine(Path.GetTempPath(), "async-dateien-demo");
Directory.CreateDirectory(ordner);
string datei = Path.Combine(ordner, "drei.txt");
File.WriteAllLines(datei, ["eins", "zwei", "drei"]);

var ergebnis = await Dateien.ZaehleZeilenAsync([datei, Path.Combine(ordner, "fehlt.txt")]);
foreach (var (pfad, anzahl) in ergebnis)
    Console.WriteLine($"{Path.GetFileName(pfad)}: {anzahl}");
