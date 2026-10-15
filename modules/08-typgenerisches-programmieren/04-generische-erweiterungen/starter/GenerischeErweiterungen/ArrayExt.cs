public static class ArrayExt {
    // Generischer Erweiterungsblock: gilt für jedes T[], dessen T vergleichbar ist.
    extension<T>(T[] arr) where T : IComparable<T> {
        // null bei leerem Array; sonst true, wenn das kleinste Element an Position 0 steht.
        public bool? MinFirst {
            get {
                // TODO
                throw new NotImplementedException();
            }
        }

        // Das größte Element (leeres Array: InvalidOperationException).
        public T Groesstes() {
            // TODO: mit CompareTo durchlaufen, kein Array.Sort
            throw new NotImplementedException();
        }
    }

    // Klassische generische Erweiterungsmethode mit derselben Aufgabe wie MinFirst.
    public static bool? LeadingMin<T>(this T[] arr) where T : IComparable<T> {
        // TODO
        throw new NotImplementedException();
    }

    // Neues Array in umgekehrter Reihenfolge; das Original bleibt unverändert. Keine Einschränkung nötig.
    public static T[] Umgekehrt<T>(this T[] arr) {
        // TODO
        throw new NotImplementedException();
    }
}
