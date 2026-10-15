public static class DoubleExtensions {
    // Erweiterungsblock (C# 14) für Instanzmitglieder von double
    extension(double arg) {
        // arg hoch expo
        public double High(double expo) => Math.Pow(arg, expo);

        // Liegt arg relativ näher als DiffThreshold an Math.PI?
        public bool EqualsPi => arg.NumEquals(Math.PI);

        // Relative Abweichung |arg - other| / |arg| kleiner als DiffThreshold?
        public bool NumEquals(double other) => Math.Abs((arg - other) / arg) < double.DiffThreshold;
    }

    // Erweiterungsblock für statische Mitglieder von double
    extension(double) {
        public static double DiffThreshold => 1.0e-14;

        public static bool NumEqualsPi(double arg) => arg.NumEquals(Math.PI);

        // Potenzoperator: 2.0 ^ 3.0 == 8.0
        public static double operator ^(double arg, double expo) => Math.Pow(arg, expo);
    }
}

public static class StringExtensions {
    // Klassische Erweiterungsmethode mit this-Parameter: true, wenn arg nicht null und leer ist.
    public static bool Empty(this string? arg) => arg != null && arg.Length == 0;

    // Erweiterungsblock: true, wenn arg null oder leer ist.
    extension(string? arg) {
        public bool NullOrEmpty => arg == null || arg.Length == 0;
    }
}
