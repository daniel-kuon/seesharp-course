// Warteschlange fester Größe: Ist sie voll, überschreibt Hinzufuegen das älteste Element.
public class Ringpuffer<T> {
    readonly T[] data;
    int anfang;   // Index des ältesten Elements
    int anzahl;

    public Ringpuffer(int kapazitaet) {
        // TODO: kapazitaet < 1 -> ArgumentOutOfRangeException; sonst Array anlegen
        throw new NotImplementedException();
    }

    public int Kapazitaet => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public bool IstVoll => throw new NotImplementedException();

    // Hängt element an; bei vollem Puffer wird das älteste überschrieben.
    public void Hinzufuegen(T element) {
        // TODO: Position (anfang + anzahl) % data.Length
        throw new NotImplementedException();
    }

    // Entfernt das älteste Element und liefert es; leer -> InvalidOperationException.
    public T Entnehmen() {
        // TODO: den frei gewordenen Platz mit default überschreiben
        throw new NotImplementedException();
    }

    // Wie Entnehmen, aber default(T) bei leerem Puffer.
    public T? EntnehmenOderDefault() {
        // TODO
        throw new NotImplementedException();
    }

    // [0] ist das älteste Element; außerhalb 0 .. Count - 1 -> ArgumentOutOfRangeException.
    public T this[int index] {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Alle Elemente vom ältesten zum neuesten.
    public T[] AlsArray() {
        // TODO
        throw new NotImplementedException();
    }
}
