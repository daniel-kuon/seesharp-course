public static class Werte {
    // "null" für Referenztypen und Nullable<T>, sonst default(T).ToString(), z. B. "0" für int, "False" für bool.
    public static string BeschreibeDefault<T>() {
        var def = default(T);
        return def == null ? "null" : def.ToString()!;
    }

    // Erstes Element oder der Standardwert des Typs, wenn das Array leer ist.
    public static T? ErstesOderDefault<T>(T[] arr) {
        return arr.Length > 0 ? arr[0] : default;
    }

    // Summe aller vorhandenen Werte; null-Einträge zählen nicht.
    public static int Summe(int?[] werte) {
        int summe = 0;
        foreach (int? w in werte)
            if (w.HasValue)
                summe += w.Value;
        return summe;
    }

    // Liefert wert, oder ersatz, wenn wert null ist.
    public static int OderErsatz(int? wert, int ersatz) => wert ?? ersatz;
}
