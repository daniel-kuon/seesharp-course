# Zusatz: Zahlenbereiche und unendliche Folgen mit yield

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**9.5.2 Algorithmus-Enumeratoren** (Seite 651) und **9.5.3 Benannte
Kollektions-Enumeratoren** (Seite 652).

Ein Iterator muss keine Kollektion durchlaufen; er kann seine Werte auch
ausrechnen. `Bereich` speichert nur Start, Ende und Schrittweite und liefert
die Zahlen dazwischen erst, wenn jemand mit `foreach` danach fragt. Öffne
`Bereich.cs`:

1. `Bereich(start, ende, schritt = 1)`: Die Werte laufen von `Start` bis
   höchstens `Ende` (einschließlich): `new Bereich(1, 10, 3)` liefert
   1, 4, 7, 10. Mit negativer Schrittweite geht es abwärts:
   `new Bereich(5, 1, -2)` liefert 5, 3, 1. Zeigt die Schrittweite in die
   falsche Richtung, ist der Bereich leer. Schrittweite 0 wirft
   `ArgumentOutOfRangeException`.
2. `Count` und `Enthaelt(zahl)` **rechnen**, statt die Werte zu
   durchlaufen: Wie viele ganze Schritte passen zwischen Start und Ende? Liegt
   `zahl` auf einem Schritt, und ist es einer der ersten `Count` Schritte?
3. `GetEnumerator()` liefert die Werte mit `yield return`; das
   nicht-generische `IEnumerable.GetEnumerator()` ist explizit
   implementiert und delegiert (steht schon da).
4. Benannte Iteratoren: `Rueckwaerts` (Eigenschaft) liefert dieselben
   Werte in umgekehrter Reihenfolge, `Vielfache(teiler)` (Methode) nur die
   Werte, die durch `teiler` teilbar sind; bei `teiler == 0` beendet
   `yield break` den Iterator sofort.
5. `Folgen.Quadratzahlen()` ist eine **unendliche** Folge 1, 4, 9, 16, ...
   (`long`). Das geht nur, weil Iteratoren faul sind: Sammle die Werte nicht
   in einem Array, sonst läuft das Programm ewig.
   `Folgen.Erste(quelle, anzahl)` liefert höchstens die ersten `anzahl`
   Werte einer beliebigen Folge und beendet sich dann mit `yield break`. So
   wird aus der unendlichen Folge eine endliche.

Diese Tests müssen bestehen:

- `BereicheTests.Bereich_ist_mit_foreach_durchlaufbar`
- `BereicheTests.Schrittweite_auf_und_ab`
- `BereicheTests.Schrittweite_0_wirft`
- `BereicheTests.Count_und_Enthaelt_rechnen`
- `BereicheTests.Rueckwaerts_ist_ein_Iterator_als_Eigenschaft`
- `BereicheTests.Vielfache_filtert_und_bricht_bei_0_ab`
- `BereicheTests.Erste_holt_aus_einer_unendlichen_Folge`
- `BereicheTests.Zwei_Durchlaeufe_sind_unabhaengig`
