public enum Temperament { Cholerisch, Melancholisch, Sanguinisch, Phlegmatisch }

public class Person(string vorname, string name, int alter, Temperament temp) {
    public string Vorname { get; set; } = vorname;
    public string Name { get; set; } = name;
    public int Alter { get; set; } = alter;

    public Temperament Temp {
        get;
        set {
            if (Enum.IsDefined(value))
                field = value;
        }
    } = temp;

    // Dekonstruktion: var (vn, nn) = person;
    public void Deconstruct(out string vn, out string nn) {
        vn = Vorname;
        nn = Name;
    }
}

public static class Analyse {
    // "Sanguinisch" -> Temperament.Sanguinisch (Groß-/Kleinschreibung egal); unbekannt -> ArgumentException
    public static Temperament ParseTemperament(string text) {
        if (Enum.TryParse(text, ignoreCase: true, out Temperament t) && Enum.IsDefined(t))
            return t;
        throw new ArgumentException($"Unbekanntes Temperament: {text}");
    }

    // Die Zahl hinter dem Enum-Wert (Cholerisch = 0, ...).
    public static int Wert(Temperament t) => (int)t;

    // Zerlegt "Vorname Nachname" und prüft beide Teile auf Palindrom (Groß-/Kleinschreibung egal).
    public static (string First, string Last, bool FirstPalin, bool LastPalin) AnalyzeName(string name) {
        int posSpace = name.IndexOf(' ');
        string fn = name.Substring(0, posSpace);
        string ln = name.Substring(posSpace + 1);
        static bool CheckPalin(string ins) {
            int vorne = 0, hinten = ins.Length - 1;
            while (vorne < hinten) {
                if (char.ToUpper(ins[vorne]) != char.ToUpper(ins[hinten]))
                    return false;
                vorne++;
                hinten--;
            }
            return true;
        }
        return (fn, ln, CheckPalin(fn), CheckPalin(ln));
    }
}
