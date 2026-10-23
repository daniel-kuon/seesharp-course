# Zusatzaufgabe: Ein Lager aus Records

Diese Aufgabe ist freiwillig. Sie übt `with`-Ausdrücke, die Wertgleichheit
von Records und Tupel als Rückgabewert. Zum Nachlesen: **6.7.3
Kopierkonstruktoren und with-Ausdrücke** (Seite 499) und **6.6.5 Tupel als
Rückgabetypen von Methoden** (Seite 493).

Ein `Artikel` ist ein positionaler Record mit `Name`, `Preis` (`decimal`)
und `Bestand`. Er ist unveränderlich: Jede "Änderung" liefert eine Kopie.
Die Tests vergleichen Artikel mit `Assert.Equal`, also über die
Wertgleichheit, die der Compiler für Records erzeugt.

Öffne `Lager.cs` und implementiere die statischen Methoden:

1. `Einlagern(a, menge)`: Kopie mit `Bestand + menge` per
   `a with { ... }`. Bei `menge <= 0` wird `a` selbst zurückgegeben.
2. `Reduziere(a, prozent)`: Kopie mit gesenktem Preis, kaufmännisch auf
   Cent gerundet: `Math.Round(wert, 2, MidpointRounding.AwayFromZero)`.
   0,55 € minus 50 % sind 0,28 €.
3. `Gesamtwert(artikel)`: Summe aus Preis mal Bestand.
4. `Preisstatistik(artikel)`: liefert das **benannte Tupel**
   `(Min, Max, Schnitt)` der Preise, den Durchschnitt auf Cent gerundet.
   Für ein leeres Array `(0, 0, 0)`.
5. `Nachbestellen(artikel, mindestbestand)`: liefert ein **neues** Array.
   Artikel unter dem Mindestbestand werden als Kopie mit
   `Bestand = mindestbestand` übernommen, alle anderen unverändert (dasselbe
   Objekt). Das übergebene Array bleibt, wie es ist.

Diese Tests müssen bestehen:

- `LagerTests.Einlagern_liefert_Kopie_mit_hoeherem_Bestand`
- `LagerTests.Einlagern_mit_ungueltiger_Menge_aendert_nichts`
- `LagerTests.Reduziere_rundet_auf_Cent`
- `LagerTests.Gesamtwert_summiert_Preis_mal_Bestand`
- `LagerTests.Preisstatistik_liefert_benanntes_Tupel`
- `LagerTests.Preisstatistik_laesst_sich_dekonstruieren`
- `LagerTests.Nachbestellen_fuellt_auf_und_liefert_neues_Array`
- `LagerTests.Nachbestellen_uebernimmt_ausreichende_Artikel_unveraendert`
