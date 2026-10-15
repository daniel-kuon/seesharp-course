public interface IZaehler {
    int Wert();
}

public interface IMesser {
    int Wert();
}

// Beide Interfaces verlangen Wert(), meinen aber Verschiedenes: der Zähler soll 1 liefern, der Messer 2.
// TODO: Beide Mitglieder explizit implementieren (int IZaehler.Wert() ... / int IMesser.Wert() ...).
//       Danach gibt es kein öffentliches Wert() mehr; der Zugriff geht nur über eine Interface-Referenz.
public class Sensor : IZaehler, IMesser {
    public int Wert() => 0;
}

// TODO: Geraet liefert über eine Geraet- oder IZaehler-Referenz 1 (implizite Implementation),
//       über eine IMesser-Referenz aber 2 (explizite Implementation).
public class Geraet : IZaehler, IMesser {
    public int Wert() => 0;
}
