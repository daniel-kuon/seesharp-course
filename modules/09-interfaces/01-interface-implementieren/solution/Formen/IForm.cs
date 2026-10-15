// Ein Interface beschreibt Handlungskompetenzen ohne Implementierung.
// Mitglieder sind implizit public; Felder gibt es nicht.
public interface IForm {
    string Name { get; }
    double Inhalt { get; }
    double Umfang();
    void Skaliere(double faktor);
}

public class Kreis(double radius) : IForm {
    public double Radius { get; private set; } = radius;

    public string Name => "Kreis";
    public double Inhalt => Math.PI * Radius * Radius;
    public double Umfang() => 2.0 * Math.PI * Radius;
    public void Skaliere(double faktor) => Radius *= faktor;
}

public struct Quadrat(double seite) : IForm {
    public double Seite { get; private set; } = seite;

    public string Name => "Quadrat";
    public double Inhalt => Seite * Seite;
    public double Umfang() => 4.0 * Seite;
    public void Skaliere(double faktor) => Seite *= faktor;
}

public static class Formen {
    // Summe der Flächeninhalte; das Array enthält beliebige Formen.
    public static double Gesamt(IForm[] formen) {
        double summe = 0.0;
        foreach (IForm f in formen)
            summe += f.Inhalt;
        return summe;
    }

    // Name der Form mit dem größten Inhalt (leeres Array: "").
    public static string Groesste(IForm[] formen) {
        if (formen.Length == 0)
            return "";
        IForm max = formen[0];
        foreach (IForm f in formen)
            if (f.Inhalt > max.Inhalt)
                max = f;
        return max.Name;
    }
}
