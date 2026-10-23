using System.Numerics;

// Statistik für jeden Zahltyp: int, long, double, decimal, ...
// TODO: Jede Methode braucht die Einschränkung where T : INumber<T>. Erst dann kennt der
//       Compiler T.Zero, T.One, T.CreateChecked und die Operatoren + - * / < >.
public static class Statistik {
    // Beginnt bei T.Zero.
    public static T Summe<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Wie Summe, aber ein Überlauf wirft OverflowException: summe = checked(summe + w);
    public static T SummeGeprueft<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Beginnt bei T.One.
    public static T Produkt<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Summe geteilt durch T.CreateChecked(werte.Length); leere Serie -> ArgumentException.
    public static T Mittelwert<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Kleinster Wert (Vergleich mit <); leere Serie -> ArgumentException.
    public static T Minimum<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Größter Wert (Vergleich mit >); leere Serie -> ArgumentException.
    public static T Maximum<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Maximum - Minimum; leere Serie -> ArgumentException.
    public static T Spannweite<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }
}
