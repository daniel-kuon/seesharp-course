// Ein Stapel (LIFO) fester Kapazität für Elemente eines beliebigen Typs T.
public class SimpleStack<T> {
    readonly int capacity = 5;
    readonly T[] data;
    int size;

    public SimpleStack() {
        data = new T[capacity];
    }

    public SimpleStack(int max) {
        if (max > 0)
            capacity = max;
        data = new T[capacity];
    }

    public int Count => size;

    public void Push(T element) {
        if (size < capacity)
            data[size++] = element;
        else
            throw new InvalidOperationException("Kapazität erschöpft");
    }

    public T Pop() {
        if (size > 0)
            return data[--size];
        throw new InvalidOperationException("Stapel leer");
    }

    public T Peek() {
        if (size > 0)
            return data[size - 1];
        throw new InvalidOperationException("Stapel leer");
    }
}
