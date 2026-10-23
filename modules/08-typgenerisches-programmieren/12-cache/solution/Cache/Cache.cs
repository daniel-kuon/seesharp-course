// Zwischenspeicher mit Größenlimit. Ist er voll, verdrängt ein neuer Schlüssel den Eintrag,
// der am längsten nicht benutzt wurde (least recently used, LRU).
// Reihenfolge in den Arrays: Index 0 = am längsten unbenutzt, anzahl - 1 = zuletzt benutzt.
public class Cache<TKey, TValue> where TKey : IComparable<TKey> {
    readonly TKey[] schluessel;
    readonly TValue[] werte;
    int anzahl;

    public Cache(int kapazitaet) {
        if (kapazitaet < 1)
            throw new ArgumentOutOfRangeException(nameof(kapazitaet));
        schluessel = new TKey[kapazitaet];
        werte = new TValue[kapazitaet];
    }

    public int Count => anzahl;

    public int Kapazitaet => schluessel.Length;

    // Index von key oder -1.
    int Suche(TKey key) {
        for (int i = 0; i < anzahl; i++)
            if (schluessel[i].CompareTo(key) == 0)
                return i;
        return -1;
    }

    // Schiebt den Eintrag an index ans Ende; die Einträge dahinter rücken eins vor.
    void NachHinten(int index) {
        TKey k = schluessel[index];
        TValue w = werte[index];
        for (int i = index; i < anzahl - 1; i++) {
            schluessel[i] = schluessel[i + 1];
            werte[i] = werte[i + 1];
        }
        schluessel[anzahl - 1] = k;
        werte[anzahl - 1] = w;
    }

    public bool Enthaelt(TKey key) => Suche(key) >= 0;

    public void Setze(TKey key, TValue wert) {
        int i = Suche(key);
        if (i < 0) {
            if (anzahl == schluessel.Length) {
                NachHinten(0);            // ältester Eintrag ans Ende ...
                i = anzahl - 1;           // ... und dort überschreiben
            } else {
                i = anzahl++;
            }
            schluessel[i] = key;
        }
        werte[i] = wert;
        NachHinten(i);
    }

    public TValue? HoleOderDefault(TKey key) {
        int i = Suche(key);
        if (i < 0)
            return default;
        NachHinten(i);
        return werte[anzahl - 1];
    }

    // Schlüssel vom am längsten unbenutzten zum zuletzt benutzten.
    public TKey[] Schluessel() {
        var ergebnis = new TKey[anzahl];
        for (int i = 0; i < anzahl; i++)
            ergebnis[i] = schluessel[i];
        return ergebnis;
    }
}
