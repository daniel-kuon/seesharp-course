public enum Temperament { Cholerisch, Melancholisch, Sanguinisch, Phlegmatisch }

public class Person(string vorname, string name, int alter, Temperament temp) {
    public string Vorname { get; set; } = vorname;
    public string Name { get; set; } = name;
    public int Alter { get; set; } = alter;

    public Temperament Temp {
        get;
        set {
            // TODO: nur definierte Enum-Werte übernehmen (Enum.IsDefined); ungültige Zahlen ignorieren
            field = value;
        }
    } = temp;

    // Dekonstruktion: var (vn, nn) = person;
    public void Deconstruct(out string vn, out string nn) {
        // TODO
        throw new NotImplementedException();
    }
}

public static class Analyse {
    // "Sanguinisch" -> Temperament.Sanguinisch (Groß-/Kleinschreibung egal); unbekannt -> ArgumentException
    public static Temperament ParseTemperament(string text) {
        // Deep Dive (optional, nicht im Buch): Enum.TryParse, siehe Anleitung
        throw new NotImplementedException();
    }

    // Die Zahl hinter dem Enum-Wert (Cholerisch = 0, ...).
    public static int Wert(Temperament t) {
        // TODO
        throw new NotImplementedException();
    }

    // Zerlegt "Vorname Nachname" und prüft beide Teile auf Palindrom (Groß-/Kleinschreibung egal).
    public static (string First, string Last, bool FirstPalin, bool LastPalin) AnalyzeName(string name) {
        // TODO: IndexOf(' ') und Substring; Palindrom-Prüfung als lokale Methode
        throw new NotImplementedException();
    }
}
