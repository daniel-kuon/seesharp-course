# Zusatz: Ein Cache mit Größenlimit

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**8.2.2 Restringierte Typformalparameter** (Seite 593) und **8.7
default-Operator** (Seite 605).

Ein Cache merkt sich teuer berechnete Werte unter einem Schlüssel, aber nur
eine begrenzte Anzahl. Ist er voll, muss ein Eintrag weichen, und zwar der,
der **am längsten nicht benutzt** wurde (least recently used, LRU).
`Cache<TKey, TValue>` hat zwei Typformalparameter und speichert Schlüssel und
Werte in zwei parallelen Arrays. Die Reihenfolge in den Arrays ist die
Benutzungsreihenfolge: Index 0 ist am längsten unbenutzt, Index
`anzahl - 1` zuletzt benutzt. Öffne `Cache.cs`:

1. Schlüssel müssen sich vergleichen lassen. Schränke `TKey` mit
   `where TKey : IComparable<TKey>` ein und vergleiche mit
   `CompareTo(...) == 0`. Ein Test prüft die Einschränkung.
2. Konstruktor: Kapazität unter 1 wirft `ArgumentOutOfRangeException`.
   `Count` und `Kapazitaet` sind berechnete Eigenschaften.
3. Zwei private Hilfsmethoden sparen doppelten Code: `Suche(key)` liefert
   den Index des Schlüssels oder -1; `NachHinten(index)` schiebt den
   Eintrag an `index` ans Ende (die Einträge dahinter rücken eins vor).
4. `Setze(key, wert)`: Gibt es den Schlüssel, wird sein Wert ersetzt;
   sonst kommt ein neuer Eintrag dazu, bei vollem Cache verdrängt er den an
   Index 0. In beiden Fällen gilt der Eintrag danach als zuletzt benutzt.
5. `HoleOderDefault(key)`: der Wert, und der Eintrag gilt als zuletzt
   benutzt; ein unbekannter Schlüssel liefert `default` (0, `null`, ...).
   `Enthaelt(key)` prüft nur und zählt **nicht** als Benutzung.
6. `Schluessel()` liefert die Schlüssel vom am längsten unbenutzten zum
   zuletzt benutzten.

Diese Tests müssen bestehen:

- `CacheTests.TKey_ist_auf_IComparable_eingeschraenkt`
- `CacheTests.Ungueltige_Kapazitaet_wirft`
- `CacheTests.Setze_und_Hole`
- `CacheTests.Unbekannter_Schluessel_liefert_default`
- `CacheTests.Setze_ersetzt_einen_vorhandenen_Eintrag`
- `CacheTests.Voller_Cache_verdraengt_den_am_laengsten_unbenutzten`
- `CacheTests.Hole_zaehlt_als_Benutzung`
- `CacheTests.Enthaelt_zaehlt_nicht_als_Benutzung`
