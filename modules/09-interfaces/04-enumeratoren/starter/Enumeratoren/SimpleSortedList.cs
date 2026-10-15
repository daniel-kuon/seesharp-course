using System.Collections;

public class SimpleSortedList<T> : IEnumerable<T> where T : IComparable<T> {
    readonly int capacity = 5;
    readonly T[] data;
    int size;

    public SimpleSortedList(int len) {
        if (len > 0)
            capacity = len;
        data = new T[capacity];
    }
    public SimpleSortedList() {
        data = new T[capacity];
    }

    public void Add(T element) {
        if (size == data.Length)
            throw new InvalidOperationException("Kapazität erschöpft");
        int i;
        for (i = size - 1; i >= 0 && element.CompareTo(data[i]) < 0; i--)
            data[i + 1] = data[i];
        data[i + 1] = element;
        size++;
    }

    public int Count => size;

    public T this[int index] {
        get {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index));
            return data[index];
        }
    }

    // Jeder Aufruf liefert einen neuen, unabhängigen Enumerator.
    public IEnumerator<T> GetEnumerator() {
        // TODO
        throw new NotImplementedException();
    }

    // Die nicht-generische Schnittstelle wird explizit implementiert und delegiert.
    IEnumerator IEnumerable.GetEnumerator() {
        // TODO
        throw new NotImplementedException();
    }

    // Geschachtelte Enumerator-Klasse: merkt sich die Liste und die aktuelle Position.
    class Enumerator(SimpleSortedList<T> liste) : IEnumerator<T> {
        readonly SimpleSortedList<T> liste = liste;
        int position = -1; // vor dem ersten Element

        public T Current {
            get {
                // TODO: liste.data[position]; vor MoveNext bzw. nach dem Ende InvalidOperationException
                throw new NotImplementedException();
            }
        }

        object? IEnumerator.Current => Current;

        public bool MoveNext() {
            // TODO: position weiterrücken; true, solange ein Element vorhanden ist
            throw new NotImplementedException();
        }

        public void Reset() {
            // TODO: wieder vor das erste Element
            throw new NotImplementedException();
        }

        public void Dispose() { }
    }
}
