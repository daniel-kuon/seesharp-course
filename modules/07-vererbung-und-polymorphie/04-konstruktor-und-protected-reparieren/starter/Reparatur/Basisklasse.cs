// Aufgabe 1 aus 7.16: Warum scheitert die Übersetzung, und wie wird sie repariert?
public class Basisklasse {
    public int Ibas { get; init; } = 3;

    public Basisklasse(int i) {
        Ibas = i;
    }

    public virtual string Hallo() => "Hallo-Methode der Basisklasse";
}

public class Abgeleitet : Basisklasse {
    // TODO: Die Basisklasse hat keinen parameterlosen Konstruktor. Ergänze einen Konstruktor,
    //       der i mit base(i) weiterreicht.

    public override string Hallo() => "Hallo-Methode der abgeleiteten Klasse";
}
