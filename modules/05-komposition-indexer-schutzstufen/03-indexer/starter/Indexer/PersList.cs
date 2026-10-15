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
        // TODO: ein neues Element anhängen (erstes Element: first = last = e), Count erhöhen
        throw new NotImplementedException();
    }

    Element FindElement(int i) {
        // TODO: von first aus i-mal zu Next gehen und das Element liefern
        throw new NotImplementedException();
    }

    // Indexer über die Position
    public Person this[int i] {
        get {
            // TODO: bei gültigem Index die Person liefern, sonst ArgumentOutOfRangeException werfen
            throw new NotImplementedException();
        }
        set {
            // TODO: bei gültigem Index die Person im Element ersetzen, sonst nichts tun
            throw new NotImplementedException();
        }
    }

    // Überladener Indexer über den Vornamen (nur lesend)
    public Person this[string vn] {
        get {
            // TODO: die erste Person mit diesem Vornamen liefern, sonst ArgumentException werfen
            throw new NotImplementedException();
        }
    }
}
