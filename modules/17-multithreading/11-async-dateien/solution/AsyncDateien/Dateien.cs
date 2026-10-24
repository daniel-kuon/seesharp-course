public static class Dateien
{
    public static async Task<Dictionary<string, int>> ZaehleZeilenAsync(IEnumerable<string> pfade)
    {
        List<string> einzigartig = pfade.Distinct().ToList();

        // Alle Lesevorgänge starten, bevor auf einen gewartet wird: So laufen sie gleichzeitig.
        Task<int>[] aufgaben = einzigartig.Select(ZaehleEine).ToArray();
        int[] anzahlen = await Task.WhenAll(aufgaben);

        var ergebnis = new Dictionary<string, int>();
        for (int i = 0; i < einzigartig.Count; i++)
            ergebnis[einzigartig[i]] = anzahlen[i];
        return ergebnis;
    }

    static async Task<int> ZaehleEine(string pfad)
    {
        try
        {
            string[] zeilen = await File.ReadAllLinesAsync(pfad);
            return zeilen.Length;
        }
        catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
        {
            return -1;
        }
    }
}
