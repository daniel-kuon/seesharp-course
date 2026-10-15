// Aufgabe 1 aus 7.16: Warum scheitert die Übersetzung, und wie wird sie repariert?
public class Basisklasse {
    public int Ibas { get; init; } = 3;

    public Basisklasse(int i) {
        Ibas = i;
    }

    public virtual string Hallo() => "Hallo-Methode der Basisklasse";
}

public class Abgeleitet : Basisklasse {
    // Die Basisklasse hat nur einen Konstruktor mit Parameter, also keinen impliziten
    // Standardkonstruktor. Der automatisch erzeugte Konstruktor von Abgeleitet würde
    // base() aufrufen, den es nicht gibt (CS7036).
    public Abgeleitet(int i) : base(i) { }

    public override string Hallo() => "Hallo-Methode der abgeleiteten Klasse";
}
