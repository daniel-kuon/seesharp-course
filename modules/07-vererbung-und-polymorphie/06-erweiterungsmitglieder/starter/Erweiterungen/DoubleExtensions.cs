public static class DoubleExtensions {
    // Erweiterungsblock (C# 14) für Instanzmitglieder von double
    extension(double arg) {
        // arg hoch expo
        public double High(double expo) {
            // TODO
            throw new NotImplementedException();
        }

        // Liegt arg relativ näher als DiffThreshold an Math.PI?
        public bool EqualsPi {
            get {
                // TODO: NumEquals verwenden
                throw new NotImplementedException();
            }
        }

        // Relative Abweichung |arg - other| / |arg| kleiner als DiffThreshold?
        public bool NumEquals(double other) {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Erweiterungsblock für statische Mitglieder von double
    extension(double) {
        public static double DiffThreshold {
            get {
                // TODO: 1.0e-14
                throw new NotImplementedException();
            }
        }

        public static bool NumEqualsPi(double arg) {
            // TODO
            throw new NotImplementedException();
        }

        // Potenzoperator: 2.0 ^ 3.0 == 8.0
        public static double operator ^(double arg, double expo) {
            // TODO
            throw new NotImplementedException();
        }
    }
}

public static class StringExtensions {
    // Klassische Erweiterungsmethode mit this-Parameter: true, wenn arg nicht null und leer ist.
    public static bool Empty(this string? arg) {
        // TODO
        throw new NotImplementedException();
    }

    // Erweiterungsblock: true, wenn arg null oder leer ist.
    extension(string? arg) {
        public bool NullOrEmpty {
            get {
                // TODO
                throw new NotImplementedException();
            }
        }
    }
}
