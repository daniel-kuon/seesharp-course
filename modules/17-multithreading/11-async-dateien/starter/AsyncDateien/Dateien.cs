public static class Dateien
{
    // Zählt die Zeilen jeder Datei und liefert ein Wörterbuch Pfad -> Zeilenzahl.
    // - Alle Dateien werden GLEICHZEITIG gelesen: erst alle Lesevorgänge starten (File.ReadAllLinesAsync),
    //   dann gemeinsam mit Task.WhenAll auf alle warten. Nicht eine Datei nach der anderen mit await lesen.
    // - Eine Datei, die es nicht gibt (FileNotFoundException oder DirectoryNotFoundException), wird mit -1
    //   gemeldet und wirft NICHT: Fang den Fehler um das await der einzelnen Datei.
    // - Kommt ein Pfad mehrfach vor, steht er nur einmal im Ergebnis.
    // - Eine leere Folge liefert ein leeres Wörterbuch.
    // Tipp: Eine kleine private async-Methode "ZaehleEine(pfad)" macht try/catch und await übersichtlich.
    public static Task<Dictionary<string, int>> ZaehleZeilenAsync(IEnumerable<string> pfade)
    {
        // TODO: Mach daraus eine async-Methode.
        throw new NotImplementedException();
    }
}
