public static class Dateien
{
    public static async Task<int> LiesLaengeAsync(string pfad)
    {
        string text = await File.ReadAllTextAsync(pfad);
        return text.Length;
    }

    // async Task statt async void: Der Aufrufer kann warten, und Ausnahmen landen in der zurückgegebenen Task.
    public static async Task SpeichereAsync(string pfad, string text)
    {
        await File.WriteAllTextAsync(pfad, text);
    }
}
