// Eine Form hat Fläche und Umfang und lässt sich nach der Fläche mit anderen Formen vergleichen.
public interface IForm : IComparable<IForm> {
    double Flaeche { get; }
    double Umfang { get; }

    // Konkretes Schnittstellenmitglied: Alle Formen vergleichen sich gleich, nach der Fläche.
    int IComparable<IForm>.CompareTo(IForm? other) => other is null ? 1 : Flaeche.CompareTo(other.Flaeche);
}

public class Kreis(double radius) : IForm {
    public double Radius { get; } = radius;
    public double Flaeche => Math.PI * Radius * Radius;
    public double Umfang => 2 * Math.PI * Radius;
}

public class Rechteck(double breite, double hoehe) : IForm {
    public double Breite { get; } = breite;
    public double Hoehe { get; } = hoehe;
    public double Flaeche => Breite * Hoehe;
    public double Umfang => 2 * (Breite + Hoehe);
}

public class Dreieck : IForm {
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Dreieck(double a, double b, double c) {
        if (a >= b + c || b >= a + c || c >= a + b)
            throw new ArgumentException("Diese Seiten ergeben kein Dreieck.");
        A = a;
        B = b;
        C = c;
    }

    public double Umfang => A + B + C;

    // Formel von Heron
    public double Flaeche {
        get {
            double s = Umfang / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}

public static class Formen {
    // Neue, nach Fläche aufsteigend sortierte Kopie; das Original bleibt unverändert.
    public static IForm[] Sortiert(IForm[] formen) {
        var kopie = (IForm[])formen.Clone();
        Array.Sort(kopie);
        return kopie;
    }

    // Form mit der größten Fläche oder null für ein leeres Array.
    public static IForm? Groesste(IForm[] formen) {
        IForm? groesste = null;
        foreach (IForm f in formen)
            if (groesste is null || f.CompareTo(groesste) > 0)
                groesste = f;
        return groesste;
    }
}
