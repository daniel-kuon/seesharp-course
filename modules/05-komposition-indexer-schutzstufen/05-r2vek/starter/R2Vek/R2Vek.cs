using System;

// Ein Vektor in der Ebene (R²).
public class R2Vek {
    // Beide Koordinaten dürfen frei gelesen und geschrieben werden, daher öffentliche Felder.
    public double X = 1.0, Y;

    public R2Vek(double xpar, double ypar) {
        X = xpar;
        Y = ypar;
    }

    public R2Vek() { }

    // Berechnete Nur-Lese-Eigenschaft: Länge nach Pythagoras
    public double Laenge {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Normiert den Vektor auf Länge 1; liefert false (und ändert nichts), wenn die Länge < 1e-14 ist.
    public bool Normiere() {
        // TODO
        throw new NotImplementedException();
    }

    // Verändert diesen Vektor.
    public void Addiere(R2Vek vpar) {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert einen neuen Vektor; beide Operanden bleiben unverändert.
    public R2Vek Plus(R2Vek vpar) {
        // TODO
        throw new NotImplementedException();
    }

    // Skalarprodukt
    public double SP(R2Vek vpar) {
        // TODO
        throw new NotImplementedException();
    }

    // Winkel zwischen beiden Vektoren in Grad (über das Skalarprodukt und Acos)
    public double Winkel(R2Vek vpar) {
        // TODO
        throw new NotImplementedException();
    }

    // Dreht den Vektor um deg Grad gegen den Uhrzeigersinn.
    public void Drehe(double deg) {
        // TODO: Drehmatrix: x' = cos·x − sin·y, y' = sin·x + cos·y (alten X-Wert merken!)
        throw new NotImplementedException();
    }
}
