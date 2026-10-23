// Warteschlange fester Größe: Ist sie voll, überschreibt Hinzufuegen das älteste Element.
public class Ringpuffer<T> {
    readonly T[] data;
    int anfang;   // Index des ältesten Elements
    int anzahl;

    public Ringpuffer(int kapazitaet) {
        if (kapazitaet < 1)
            throw new ArgumentOutOfRangeException(nameof(kapazitaet));
        data = new T[kapazitaet];
    }

    public int Kapazitaet => data.Length;

    public int Count => anzahl;

    public bool IstVoll => anzahl == data.Length;

    // Hängt element an; bei vollem Puffer wird das älteste überschrieben.
    public void Hinzufuegen(T element) {
        data[(anfang + anzahl) % data.Length] = element;
        if (IstVoll)
            anfang = (anfang + 1) % data.Length;
        else
            anzahl++;
    }

    // Entfernt das älteste Element und liefert es; leer -> InvalidOperationException.
    public T Entnehmen() {
        if (anzahl == 0)
            throw new InvalidOperationException("Puffer leer");
        T element = data[anfang];
        data[anfang] = default!;
        anfang = (anfang + 1) % data.Length;
        anzahl--;
        return element;
    }

    // Wie Entnehmen, aber default(T) bei leerem Puffer.
    public T? EntnehmenOderDefault() => anzahl == 0 ? default : Entnehmen();

    // [0] ist das älteste Element.
    public T this[int index] {
        get {
            if (index < 0 || index >= anzahl)
                throw new ArgumentOutOfRangeException(nameof(index));
            return data[(anfang + index) % data.Length];
        }
    }

    // Alle Elemente vom ältesten zum neuesten.
    public T[] AlsArray() {
        var ergebnis = new T[anzahl];
        for (int i = 0; i < anzahl; i++)
            ergebnis[i] = this[i];
        return ergebnis;
    }
}
