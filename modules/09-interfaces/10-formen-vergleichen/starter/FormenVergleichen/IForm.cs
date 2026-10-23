// Eine Form hat Fläche und Umfang und lässt sich nach der Fläche mit anderen Formen vergleichen.
// TODO: IForm soll IComparable<IForm> erweitern: public interface IForm : IComparable<IForm>
public interface IForm {
    double Flaeche { get; }

    // TODO: Eigenschaft Umfang (nur get)

    // TODO: CompareTo als konkretes Schnittstellenmitglied, vergleicht die Flächen; null ist kleiner:
    //       int IComparable<IForm>.CompareTo(IForm? other) => ...
}

public class Kreis(double radius) : IForm {
    public double Radius { get; } = radius;

    // TODO: PI * r * r
    public double Flaeche => throw new NotImplementedException();

    // TODO: 2 * PI * r
    public double Umfang => throw new NotImplementedException();
}

public class Rechteck(double breite, double hoehe) : IForm {
    public double Breite { get; } = breite;
    public double Hoehe { get; } = hoehe;

    // TODO: Breite * Hoehe
    public double Flaeche => throw new NotImplementedException();

    // TODO: 2 * (Breite + Hoehe)
    public double Umfang => throw new NotImplementedException();
}

public class Dreieck : IForm {
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Dreieck(double a, double b, double c) {
        // TODO: Ist eine Seite nicht kürzer als die beiden anderen zusammen -> ArgumentException
        throw new NotImplementedException();
    }

    // TODO: A + B + C
    public double Umfang => throw new NotImplementedException();

    // TODO: Formel von Heron: s = Umfang / 2, Fläche = Wurzel aus s(s-a)(s-b)(s-c)
    public double Flaeche => throw new NotImplementedException();
}

public static class Formen {
    // Neue, nach Fläche aufsteigend sortierte Kopie; das Original bleibt unverändert.
    public static IForm[] Sortiert(IForm[] formen) {
        // TODO: kopieren, dann Array.Sort
        throw new NotImplementedException();
    }

    // Form mit der größten Fläche oder null für ein leeres Array.
    public static IForm? Groesste(IForm[] formen) {
        // TODO: mit CompareTo vergleichen
        throw new NotImplementedException();
    }
}
