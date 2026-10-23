// Ein arithmetischer Ausdruck als Baum: (2 + 3) * 4 ist ein Mal-Knoten mit einem
// Plus-Knoten links und der Zahl 4 rechts.
public abstract class Ausdruck {
    // Wert des Ausdrucks.
    public abstract double Auswerten();

    // Anzahl der Knoten im Baum (jede Zahl und jeder Operator zählt 1).
    public abstract int Knoten { get; }

    // Liefert einen gleichwertigen, möglichst einfachen Ausdruck; ohne Regel der Ausdruck selbst.
    public virtual Ausdruck Vereinfache() => this;
}

public class Zahl : Ausdruck {
    public double Wert { get; }

    public Zahl(double wert) {
        Wert = wert;
    }

    public override double Auswerten() => Wert;

    public override int Knoten => 1;

    public override string ToString() => $"{Wert}";
}

// Gemeinsame Basis aller Operatoren mit zwei Operanden.
public abstract class BinaererAusdruck : Ausdruck {
    public Ausdruck Links { get; }
    public Ausdruck Rechts { get; }

    protected BinaererAusdruck(Ausdruck links, Ausdruck rechts) {
        Links = links;
        Rechts = rechts;
    }

    // Operatorzeichen für ToString, z. B. "+".
    protected abstract string Symbol { get; }

    // Verknüpft die beiden ausgewerteten Operanden, z. B. a + b.
    protected abstract double Verknuepfe(double a, double b);

    public sealed override double Auswerten() => Verknuepfe(Links.Auswerten(), Rechts.Auswerten());

    public sealed override int Knoten => 1 + Links.Knoten + Rechts.Knoten;

    public override string ToString() => $"({Links} {Symbol} {Rechts})";

    // Zwei Zahlen werden zu einer Zahl zusammengefasst.
    public override Ausdruck Vereinfache() {
        if (Links is Zahl && Rechts is Zahl)
            return new Zahl(Auswerten());
        return this;
    }
}

public class Plus : BinaererAusdruck {
    public Plus(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    protected override string Symbol => "+";

    protected override double Verknuepfe(double a, double b) => a + b;
}

public class Minus : BinaererAusdruck {
    public Minus(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    protected override string Symbol => "-";

    protected override double Verknuepfe(double a, double b) => a - b;
}

public class Mal : BinaererAusdruck {
    public Mal(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    protected override string Symbol => "*";

    protected override double Verknuepfe(double a, double b) => a * b;

    // x * 0 = 0, x * 1 = x; sonst die allgemeine Regel der Basisklasse.
    public override Ausdruck Vereinfache() {
        if (Links is Zahl l && l.Wert == 0.0 || Rechts is Zahl r && r.Wert == 0.0)
            return new Zahl(0.0);
        if (Links is Zahl eins && eins.Wert == 1.0)
            return Rechts;
        if (Rechts is Zahl auchEins && auchEins.Wert == 1.0)
            return Links;
        return base.Vereinfache();
    }
}

public class Geteilt : BinaererAusdruck {
    public Geteilt(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    protected override string Symbol => "/";

    protected override double Verknuepfe(double a, double b) => a / b;
}
