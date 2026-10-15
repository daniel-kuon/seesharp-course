public static class Werte {
    // "null" für Referenztypen und Nullable<T>, sonst default(T).ToString(), z. B. "0" für int, "False" für bool.
    public static string BeschreibeDefault<T>() {
        // TODO: var def = default(T); ...
        throw new NotImplementedException();
    }

    // Erstes Element oder der Standardwert des Typs, wenn das Array leer ist.
    public static T? ErstesOderDefault<T>(T[] arr) {
        // TODO
        throw new NotImplementedException();
    }

    // Summe aller vorhandenen Werte; null-Einträge zählen nicht.
    public static int Summe(int?[] werte) {
        // TODO: HasValue/Value oder ?? verwenden
        throw new NotImplementedException();
    }

    // Liefert wert, oder ersatz, wenn wert null ist.
    public static int OderErsatz(int? wert, int ersatz) {
        // TODO: null-Koaleszenzoperator ??
        throw new NotImplementedException();
    }
}
