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
            return Math.Sqrt(X * X + Y * Y);
        }
    }

    // Normiert den Vektor auf Länge 1; liefert false (und ändert nichts), wenn die Länge < 1e-14 ist.
    public bool Normiere() {
        double b = Laenge;
        if (b < 1e-14)
            return false;
        X /= b;
        Y /= b;
        return true;
    }

    // Verändert diesen Vektor.
    public void Addiere(R2Vek vpar) {
        X += vpar.X;
        Y += vpar.Y;
    }

    // Liefert einen neuen Vektor; beide Operanden bleiben unverändert.
    public R2Vek Plus(R2Vek vpar) {
        return new R2Vek(X + vpar.X, Y + vpar.Y);
    }

    // Skalarprodukt
    public double SP(R2Vek vpar) {
        return X * vpar.X + Y * vpar.Y;
    }

    // Winkel zwischen beiden Vektoren in Grad (über das Skalarprodukt und Acos)
    public double Winkel(R2Vek vpar) {
        double temp = SP(vpar) / (Laenge * vpar.Laenge);
        return double.RadiansToDegrees(Math.Acos(temp));
    }

    // Dreht den Vektor um deg Grad gegen den Uhrzeigersinn.
    public void Drehe(double deg) {
        double rad = double.DegreesToRadians(deg % 360);
        double cosinus = Math.Cos(rad);
        double sinus = Math.Sin(rad);
        double oldX = X;
        X = cosinus * X - sinus * Y;
        Y = sinus * oldX + cosinus * Y;
    }
}
