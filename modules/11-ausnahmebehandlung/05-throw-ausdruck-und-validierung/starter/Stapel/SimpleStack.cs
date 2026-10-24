// Ein Stapel mit fester Kapazität. Bisher reagiert er auf Fehler gar nicht oder zufällig:
// Aufgabe ist, ungültige Aufrufe mit passenden Ausnahmen zu melden.
public class SimpleStack<T>
{
    readonly T[] items;
    int anzahl;
    string name = "Stapel";

    // TODO: Ist kapazitaet <= 0, soll eine ArgumentOutOfRangeException mit Parametername
    // "kapazitaet" geworfen werden (nameof(kapazitaet)), statt still eine Standardgröße zu nehmen.
    public SimpleStack(int kapazitaet)
    {
        items = new T[kapazitaet > 0 ? kapazitaet : 5];
    }

    public int Count => anzahl;

    // TODO: Der Name darf nicht null sein. Wirf eine ArgumentNullException (nameof(value)) mit einem
    // throw-Ausdruck im Setter:  name = value ?? throw new ...
    public string Name
    {
        get => name;
        set => name = value;
    }

    // TODO: Auf einem vollen Stapel eine InvalidOperationException mit deutscher Meldung werfen,
    // bevor etwas geschrieben wird.
    public void Push(T element)
    {
        items[anzahl++] = element;
    }

    // TODO: Auf einem leeren Stapel eine InvalidOperationException werfen, bevor anzahl verändert wird.
    public T Pop()
    {
        return items[--anzahl];
    }

    // TODO: Schreibe Peek als Ausdruckskörper mit throw-Ausdruck:
    //   => anzahl > 0 ? items[anzahl - 1] : throw new InvalidOperationException("...");
    public T Peek() => items[anzahl - 1];

    // Legt alle Elemente von quelle nacheinander auf den Stapel.
    // TODO: quelle == null soll eine ArgumentNullException (Parametername "quelle") auslösen.
    // Verwende dafür ArgumentNullException.ThrowIfNull(quelle).
    public void Fuelle(IEnumerable<T> quelle)
    {
        foreach (T element in quelle)
            Push(element);
    }
}
