// Ein Stapel mit fester Kapazität, der ungültige Aufrufe mit Ausnahmen meldet.
public class SimpleStack<T>
{
    readonly T[] items;
    int anzahl;
    string name = "Stapel";

    // Die Kapazität muss größer als 0 sein: sonst ArgumentOutOfRangeException (Parametername "kapazitaet").
    public SimpleStack(int kapazitaet)
    {
        if (kapazitaet <= 0)
            throw new ArgumentOutOfRangeException(nameof(kapazitaet), kapazitaet, "Die Kapazität muss größer als 0 sein.");
        items = new T[kapazitaet];
    }

    public int Count => anzahl;

    // Der Name darf nicht null sein: ArgumentNullException (throw-Ausdruck im Setter).
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    // Auf einem vollen Stapel: InvalidOperationException.
    public void Push(T element)
    {
        if (anzahl == items.Length)
            throw new InvalidOperationException("Der Stapel ist voll.");
        items[anzahl++] = element;
    }

    // Auf einem leeren Stapel: InvalidOperationException.
    public T Pop()
    {
        if (anzahl == 0)
            throw new InvalidOperationException("Der Stapel ist leer.");
        return items[--anzahl];
    }

    // Das oberste Element, ohne es zu entfernen. Auf einem leeren Stapel: InvalidOperationException
    // (als Ausdruck: Bedingung ? Wert : throw ...).
    public T Peek() => anzahl > 0 ? items[anzahl - 1] : throw new InvalidOperationException("Der Stapel ist leer.");

    // Legt alle Elemente von quelle nacheinander auf den Stapel.
    // quelle == null: ArgumentNullException (Parametername "quelle") über ThrowIfNull.
    public void Fuelle(IEnumerable<T> quelle)
    {
        ArgumentNullException.ThrowIfNull(quelle);
        foreach (T element in quelle)
            Push(element);
    }
}
