// Ein Interface beschreibt Handlungskompetenzen ohne Implementierung.
// Mitglieder sind implizit public; Instanzfelder gibt es nicht.
public interface IForm {
    string Name { get; }
    double Inhalt { get; }
    double Umfang();
    void Skaliere(double faktor);
}

// TODO: Kreis implementiert IForm (Klasse).
public class Kreis(double radius) : IForm {
    public double Radius { get; private set; } = radius;

    public string Name => throw new NotImplementedException();          // "Kreis"
    public double Inhalt => throw new NotImplementedException();        // PI * r * r
    public double Umfang() => throw new NotImplementedException();      // 2 * PI * r
    public void Skaliere(double faktor) => throw new NotImplementedException();
}

// TODO: Quadrat implementiert IForm (Struktur!).
public struct Quadrat(double seite) : IForm {
    public double Seite { get; private set; } = seite;

    public string Name => throw new NotImplementedException();          // "Quadrat"
    public double Inhalt => throw new NotImplementedException();        // seite * seite
    public double Umfang() => throw new NotImplementedException();      // 4 * seite
    public void Skaliere(double faktor) => throw new NotImplementedException();
}

public static class Formen {
    // Summe der Flächeninhalte; das Array enthält beliebige Formen.
    public static double Gesamt(IForm[] formen) {
        // TODO
        throw new NotImplementedException();
    }

    // Name der Form mit dem größten Inhalt (leeres Array: "").
    public static string Groesste(IForm[] formen) {
        // TODO
        throw new NotImplementedException();
    }
}
