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

    // Standard-Enumeration: alle Elemente aufsteigend, mit yield return.
    public IEnumerator<T> GetEnumerator() {
        for (int i = 0; i < size; i++)
            yield return data[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Benannter Iterator: die Elemente von first bis last (einschließlich).
    // Bei ungültigem Bereich wird nichts geliefert (yield break).
    public IEnumerable<T> RangeIt(int first, int last) {
        if (first < 0 || last >= size)
            yield break;
        for (int i = first; i <= last; i++)
            yield return data[i];
    }

    // Iterator als Eigenschaft: alle Elemente absteigend.
    public IEnumerable<T> DownIt {
        get {
            for (int i = size - 1; i >= 0; i--)
                yield return data[i];
        }
    }

    // Wie RangeIt, aber die Richtung ergibt sich aus first und last: first > last zählt abwärts.
    public IEnumerable<T> RangeItUpDown(int first, int last) {
        if (int.Min(first, last) < 0 || int.Max(first, last) >= size)
            yield break;
        if (first <= last)
            for (int i = first; i <= last; i++)
                yield return data[i];
        else
            for (int i = first; i >= last; i--)
                yield return data[i];
    }
}
