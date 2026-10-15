// Eine Liste, die ihre Elemente beim Einfügen sortiert hält.
public class SimpleSortedList<T> where T : IComparable<T> {
    readonly int capacity = 5;
    readonly T[] data;
    int size;

    public SimpleSortedList() {
        data = new T[capacity];
    }

    public SimpleSortedList(int len) {
        if (len > 0)
            capacity = len;
        data = new T[capacity];
    }

    public int Count => size;

    public void Add(T element) {
        if (size == data.Length)
            throw new InvalidOperationException("Kapazität erschöpft");
        int i;
        for (i = size - 1; i >= 0 && element.CompareTo(data[i]) < 0; i--)
            data[i + 1] = data[i];
        data[i + 1] = element;
        size++;
    }

    public T this[int index] {
        get {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index));
            return data[index];
        }
    }
}
