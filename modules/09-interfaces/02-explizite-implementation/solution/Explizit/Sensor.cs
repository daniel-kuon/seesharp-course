public interface IZaehler {
    int Wert();
}

public interface IMesser {
    int Wert();
}

// Beide Interfaces verlangen Wert(), meinen aber Verschiedenes: der Zähler soll 1 liefern, der Messer 2.
public class Sensor : IZaehler, IMesser {
    int IZaehler.Wert() => 1;
    int IMesser.Wert() => 2;
}

// Geraet liefert über eine Geraet- oder IZaehler-Referenz 1, über eine IMesser-Referenz 2.
public class Geraet : IZaehler, IMesser {
    public int Wert() => 1;
    int IMesser.Wert() => 2;
}
