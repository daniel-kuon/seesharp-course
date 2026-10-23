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

    // TODO: liefert Wert
    public override double Auswerten() => throw new NotImplementedException();

    // TODO: eine Zahl ist ein Knoten
    public override int Knoten => throw new NotImplementedException();

    // TODO: ToString() überschreiben, liefert den Wert als Text, z. B. "4"
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

    // TODO: Links und Rechts auswerten, Ergebnisse mit Verknuepfe verknüpfen.
    //       Versiegeln (sealed override), damit die Operatoren das nicht ändern.
    public override double Auswerten() => throw new NotImplementedException();

    // TODO: 1 + Knoten links + Knoten rechts; ebenfalls versiegeln.
    public override int Knoten => throw new NotImplementedException();

    // TODO: ToString() überschreiben: "(links symbol rechts)", z. B. "(2 + 3)"

    // TODO: Sind Links und Rechts beide Zahlen, eine neue Zahl mit dem Ergebnis liefern, sonst this.
    public override Ausdruck Vereinfache() => throw new NotImplementedException();
}

public class Plus : BinaererAusdruck {
    public Plus(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    // TODO: "+"
    protected override string Symbol => throw new NotImplementedException();

    // TODO: a + b
    protected override double Verknuepfe(double a, double b) => throw new NotImplementedException();
}

public class Minus : BinaererAusdruck {
    public Minus(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    // TODO: "-"
    protected override string Symbol => throw new NotImplementedException();

    // TODO: a - b
    protected override double Verknuepfe(double a, double b) => throw new NotImplementedException();
}

public class Mal : BinaererAusdruck {
    public Mal(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    // TODO: "*"
    protected override string Symbol => throw new NotImplementedException();

    // TODO: a * b
    protected override double Verknuepfe(double a, double b) => throw new NotImplementedException();

    // TODO: Vereinfache() überschreiben: eine Seite ist die Zahl 0 -> new Zahl(0);
    //       eine Seite ist die Zahl 1 -> die andere Seite; sonst base.Vereinfache().
}

public class Geteilt : BinaererAusdruck {
    public Geteilt(Ausdruck links, Ausdruck rechts) : base(links, rechts) { }

    // TODO: "/"
    protected override string Symbol => throw new NotImplementedException();

    // TODO: a / b
    protected override double Verknuepfe(double a, double b) => throw new NotImplementedException();
}
