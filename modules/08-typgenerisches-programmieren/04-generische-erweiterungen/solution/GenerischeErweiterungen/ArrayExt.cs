public static class ArrayExt {
    // Generischer Erweiterungsblock: gilt für jedes T[], dessen T vergleichbar ist.
    extension<T>(T[] arr) where T : IComparable<T> {
        // null bei leerem Array; sonst true, wenn das kleinste Element an Position 0 steht.
        public bool? MinFirst {
            get {
                if (arr.Length == 0)
                    return null;
                foreach (T element in arr)
                    if (element.CompareTo(arr[0]) < 0)
                        return false;
                return true;
            }
        }

        // Das größte Element (leeres Array: InvalidOperationException).
        public T Groesstes() {
            if (arr.Length == 0)
                throw new InvalidOperationException("Leeres Array");
            T max = arr[0];
            foreach (T element in arr)
                if (element.CompareTo(max) > 0)
                    max = element;
            return max;
        }
    }

    // Klassische generische Erweiterungsmethode mit derselben Aufgabe wie MinFirst.
    public static bool? LeadingMin<T>(this T[] arr) where T : IComparable<T> {
        if (arr.Length == 0)
            return null;
        foreach (T element in arr)
            if (element.CompareTo(arr[0]) < 0)
                return false;
        return true;
    }

    // Neues Array in umgekehrter Reihenfolge; das Original bleibt unverändert. Keine Einschränkung nötig.
    public static T[] Umgekehrt<T>(this T[] arr) {
        T[] ergebnis = new T[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            ergebnis[i] = arr[arr.Length - 1 - i];
        return ergebnis;
    }
}
