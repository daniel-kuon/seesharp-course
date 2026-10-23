// Zwischenspeicher mit Größenlimit. Ist er voll, verdrängt ein neuer Schlüssel den Eintrag,
// der am längsten nicht benutzt wurde (least recently used, LRU).
// Reihenfolge in den Arrays: Index 0 = am längsten unbenutzt, anzahl - 1 = zuletzt benutzt.
// TODO: Schlüssel müssen vergleichbar sein: where TKey : IComparable<TKey>
public class Cache<TKey, TValue> {
    readonly TKey[] schluessel;
    readonly TValue[] werte;
    int anzahl;

    public Cache(int kapazitaet) {
        // TODO: kapazitaet < 1 -> ArgumentOutOfRangeException; sonst beide Arrays anlegen
        throw new NotImplementedException();
    }

    public int Count => throw new NotImplementedException();

    public int Kapazitaet => throw new NotImplementedException();

    // TODO: private Hilfsmethoden
    //   int Suche(TKey key)         Index von key oder -1 (Vergleich mit CompareTo(...) == 0)
    //   void NachHinten(int index)  Eintrag an index ans Ende schieben, die dahinter rücken eins vor

    // Prüft nur; zählt nicht als Benutzung.
    public bool Enthaelt(TKey key) {
        // TODO
        throw new NotImplementedException();
    }

    // Ersetzt den Wert eines vorhandenen Schlüssels oder fügt einen neuen Eintrag hinzu
    // (bei vollem Cache wird der Eintrag an Index 0 verdrängt). Danach zuletzt benutzt.
    public void Setze(TKey key, TValue wert) {
        // TODO
        throw new NotImplementedException();
    }

    // Wert zu key (danach zuletzt benutzt); unbekannter Schlüssel -> default.
    public TValue? HoleOderDefault(TKey key) {
        // TODO
        throw new NotImplementedException();
    }

    // Schlüssel vom am längsten unbenutzten zum zuletzt benutzten.
    public TKey[] Schluessel() {
        // TODO
        throw new NotImplementedException();
    }
}
