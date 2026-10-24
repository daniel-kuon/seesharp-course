string pfad = Path.Combine(Path.GetTempPath(), "async-demo.txt");
File.WriteAllText(pfad, "Hallo Welt");

Console.WriteLine(await Dateien.LiesLaengeAsync(pfad));
Console.WriteLine(await Asynchron.SummeAsync([Task.FromResult(1), Task.FromResult(2)]));
