# Zusatz: Ein generischer Ringpuffer

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**8.2.1 Generische Klassen: Definition** (Seite 591) und **8.7
default-Operator** (Seite 605).

Ein Ringpuffer ist eine Warteschlange fester Größe: Was zuerst
hineinkommt, kommt zuerst heraus. Ist er voll, **überschreibt** ein neues
Element das älteste. So hält etwa ein Messgerät immer die letzten 100
Messwerte. Intern liegt alles in einem Array `T[]`; `anfang` zeigt auf das
älteste Element, und die Positionen laufen mit `% data.Length` im Kreis
herum, statt Elemente zu verschieben. Öffne `Ringpuffer.cs`:

1. Der Konstruktor legt das Array an; eine Kapazität unter 1 wirft
   `ArgumentOutOfRangeException`. `Kapazitaet`, `Count` und `IstVoll`
   sind berechnete Eigenschaften.
2. `Hinzufuegen(element)` schreibt an die Position hinter dem neuesten
   Element. Ist der Puffer voll, wird dabei das älteste überschrieben, und
   `anfang` rückt eins weiter.
3. `Entnehmen()` entfernt das älteste Element und liefert es; ein leerer
   Puffer wirft `InvalidOperationException`. Überschreibe den frei
   gewordenen Platz mit `default`, damit der Puffer keine Referenzen auf
   alte Objekte festhält.
4. `EntnehmenOderDefault()` liefert bei leerem Puffer `default(T)` statt
   einer Ausnahme: 0 für `int`, `null` für `string`.
5. Der Indexer zählt ab dem ältesten Element (`[0]` ist das älteste);
   Indizes außerhalb `0 .. Count - 1` werfen
   `ArgumentOutOfRangeException`. `AlsArray()` liefert alle Elemente vom
   ältesten zum neuesten.

Diese Tests müssen bestehen:

- `RingpufferTests.Neuer_Puffer_ist_leer`
- `RingpufferTests.Ungueltige_Kapazitaet_wirft`
- `RingpufferTests.Entnehmen_liefert_das_aelteste_zuerst`
- `RingpufferTests.Voller_Puffer_ueberschreibt_das_aelteste`
- `RingpufferTests.Indexer_zaehlt_ab_dem_aeltesten`
- `RingpufferTests.Leerer_Puffer_wirft_oder_liefert_default`
- `RingpufferTests.Viele_Runden_ueber_das_Arrayende`
