public static class Dateien
{
    // Liefert die Länge des Dateiinhalts in Zeichen.
    // TODO: Mach daraus eine async-Methode (Schlüsselwort async) und lies mit
    //       await File.ReadAllTextAsync(pfad), ohne den Thread zu blockieren.
    //       Fehlt die Datei, kommt beim await die FileNotFoundException an.
    public static Task<int> LiesLaengeAsync(string pfad)
    {
        throw new NotImplementedException();
    }

    // Schreibt text in die Datei pfad.
    // TODO: Diese Methode ist "async void". Das ist ein Fehler: Der Aufrufer kann nicht auf das Ende warten
    //       und bekommt Ausnahmen nicht zu sehen (sie landen im Synchronisierungskontext oder beenden
    //       das Programm). Ändere den Rückgabetyp in Task: "async Task SpeichereAsync(...)".
    public static async void SpeichereAsync(string pfad, string text)
    {
        await File.WriteAllTextAsync(pfad, text);
    }
}
