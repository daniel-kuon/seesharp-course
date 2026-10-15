// Ein Stapel (LIFO) fester Kapazität für Elemente eines beliebigen Typs T.
public class SimpleStack<T> {
    readonly int capacity = 5;
    readonly T[] data;
    int size;

    public SimpleStack() {
        // TODO: Array mit der Standardkapazität anlegen
        throw new NotImplementedException();
    }

    public SimpleStack(int max) {
        // TODO: max nur übernehmen, wenn > 0; dann Array anlegen
        throw new NotImplementedException();
    }

    public int Count {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    public void Push(T element) {
        // TODO: bei vollem Stapel InvalidOperationException("Kapazität erschöpft")
        throw new NotImplementedException();
    }

    public T Pop() {
        // TODO: oberstes Element entfernen und liefern; bei leerem Stapel InvalidOperationException("Stapel leer")
        throw new NotImplementedException();
    }

    public T Peek() {
        // TODO: oberstes Element liefern, ohne es zu entfernen; leer -> InvalidOperationException
        throw new NotImplementedException();
    }
}
