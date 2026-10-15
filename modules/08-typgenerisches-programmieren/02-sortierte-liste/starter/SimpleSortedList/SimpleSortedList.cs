// Eine Liste, die ihre Elemente beim Einfügen sortiert hält.
// TODO: Typformalparameter einschränken, damit CompareTo verfügbar ist (where T : IComparable<T>).
public class SimpleSortedList<T> {
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
        // TODO: bei voller Liste InvalidOperationException; sonst von hinten alle größeren Elemente um eine
        //       Position nach rechts schieben (element.CompareTo(data[i]) < 0) und element in die Lücke setzen
        throw new NotImplementedException();
    }

    public T this[int index] {
        get {
            // TODO: ArgumentOutOfRangeException bei ungültigem Index
            throw new NotImplementedException();
        }
    }
}
