// Eine einfach verkettete Liste von Personen mit Indexer-Zugriff.
public class PersList {
    Element? first, last;

    // Ein Listenknoten: geschachtelte Klasse, nur PersList kennt ihn.
    class Element(Person p) {
        public Person VP { get; set; } = p;
        public Element? Next { get; set; }
    }

    public int Count { get; private set; }

    public void Add(Person neu) {
        ArgumentNullException.ThrowIfNull(neu);
        Element e = new(neu);
        if (Count == 0)
            first = last = e;
        else {
            last!.Next = e;
            last = e;
        }
        Count++;
    }

    Element FindElement(int i) {
        Element sel = first!;
        for (int j = 0; j < i; j++)
            sel = sel.Next!;
        return sel;
    }

    // Indexer über die Position
    public Person this[int i] {
        get {
            if (i >= 0 && i < Count)
                return FindElement(i).VP;
            else
                throw new ArgumentOutOfRangeException(nameof(i));
        }
        set {
            if (i >= 0 && i < Count && value != null)
                FindElement(i).VP = value;
        }
    }

    // Überladener Indexer über den Vornamen (nur lesend)
    public Person this[string vn] {
        get {
            for (int j = 0; j < Count; j++)
                if (this[j].Vorname == vn)
                    return this[j];
            throw new ArgumentException($"Keine Person mit dem Vornamen {vn} gefunden");
        }
    }
}
