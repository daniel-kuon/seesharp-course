# Rubrik: Verständnisfragen, Kollektionen (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `gerade-entfernen` = Rückwärtsschleife mit `RemoveAt`,
`spread-richtig` = `[0, ..mitte, 9]` mit Zieltyp `List<int>`, `trygetvalue-richtig` =
`TryGetValue("x", out int w)`, `kundennummern` = `HashSet<int>`).

## kollektion-waehlen

Erwartet (je Fall Kollektion **und** Begründung):
- (a) `Queue<T>`: Warteschlange, **FIFO**; der älteste Auftrag zuerst.
- (b) `Stack<T>`: Stapel, **LIFO**; die letzte Änderung wird zuerst rückgängig gemacht.
- Bonus (Deep Dive): die Methodennamen `Enqueue`/`Dequeue` bzw. `Push`/`Pop` (stehen nicht
  im Buch, nur die Klassen und das Prinzip in 11.4, Seite 697).
- (c) `HashSet<T>`: Existenzprüfung in nahezu konstanter Zeit (O(1)) statt O(n) wie bei
  `List<T>.Contains()`; keine Duplikate. (Ein `Dictionary<K,V>` mit `ContainsKey` wäre auch
  vertretbar, wenn zu der Nummer weitere Daten gehören.)
- (d) `Dictionary<K,V>`: Zugriff über den Schlüssel (Name) auf den Wert (Nummer).

Typische Missverständnisse: `List<T>` für alles ("einfach"); `Stack` und `Queue` verwechselt;
`HashSet<T>` wegen der Reihenfolge ablehnen, obwohl sie hier egal ist.

## hash-schnell

Wesentliche Punkte:
- `List<T>.Contains()` durchsucht alle Elemente nacheinander: **O(n)**.
- Das `HashSet<T>` berechnet aus dem Element einen **Hashwert** (`GetHashCode()`), der den
  Platz in der **Hashtabelle** bestimmt; dort wird nur noch das eine "Fach" geprüft (mit
  `Equals()`): im Mittel **O(1)**.
- Ein eigener Elementtyp muss **`Equals()` und `GetHashCode()`** passend überschreiben
  (gleiche Elemente liefern gleiche Hashwerte); sonst gelten zwei gleiche Werte als verschieden
  (Referenzvergleich).

Typische Missverständnisse: `HashSet<T>` sei sortiert (das ist `SortedSet<T>`); es genüge, nur
`Equals()` zu überschreiben.

## foreach-aendern

Wesentliche Punkte:
- Der Enumerator der Liste merkt sich einen Änderungszähler; ändert man die Liste während der
  Aufzählung, erkennt `MoveNext()` das und löst eine **`InvalidOperationException`** aus
  ("Collection was modified"). Die Aufzählung wäre sonst unzuverlässig, weil Elemente
  verrutschen.
- Sichere Wege (zwei genügen): eine **rückwärts laufende `for`-Schleife** mit `RemoveAt(i)`,
  zuerst die Elemente einsammeln und danach entfernen, oder über eine Kopie der Liste
  laufen und im Original entfernen. Bonus (Deep Dive): **`RemoveAll()`** mit einer Bedingung
  (nicht im Buch, braucht einen Lambda-Ausdruck aus Level 12).
- Rückwärts: Das Entfernen verschiebt nur Elemente **hinter** `i`, die schon bearbeitet sind;
  die Indizes der noch zu prüfenden Elemente bleiben gültig. Vorwärts würde das nächste
  Element nach `RemoveAt(i)` auf Platz `i` rutschen und übersprungen.

Typische Missverständnisse: Es sei ein Fehler des Compilers (die Ausnahme kommt zur Laufzeit);
vorwärts laufende `for`-Schleife sei genauso sicher.

## woerterbuch-lesen

Wesentliche Punkte:
- Lesen eines fehlenden Schlüssels über den Indexer: eine **Ausnahme** (11.6, Seite 714).
  Bonus (Deep Dive): ihr Name `KeyNotFoundException` (steht nicht im Buch).
- Schreiben `d["x"] = 1` mit fehlendem Schlüssel: der Eintrag wird **neu angelegt** (mit
  vorhandenem Schlüssel überschrieben); keine Ausnahme.
- Sicher lesen: **`TryGetValue(key, out wert)`** (liefert `bool`) oder vorher
  **`ContainsKey()`**.
- Mehrere Werte pro Schlüssel: **`Dictionary<K, List<V>>`**.
- Auf die **Reihenfolge** der Aufzählung darf man sich **nicht** verlassen.

Typische Missverständnisse: Schreiben mit unbekanntem Schlüssel werfe ebenfalls eine Ausnahme;
`Add()` und Indexer verhielten sich bei vorhandenem Schlüssel gleich (`Add` wirft dort eine
Ausnahme; nur bei Bedarf ansprechen).

## sicht-oder-unveraenderlich

Wesentliche Punkte:
- `IReadOnlyList<T>` bzw. `AsReadOnly()` gibt nur eine **Sicht** auf die Liste heraus: Der
  Empfänger kann nichts ändern, **sieht** aber spätere Änderungen des Besitzers. (Ist es die
  Liste selbst als `IReadOnlyList<T>`, kann der Empfänger sie per Cast doch ändern; ein
  Pluspunkt, kein Pflichtpunkt.)
- `ImmutableList<T>` ist **wirklich unveränderlich**: Der Empfänger hat einen festen Stand;
  `Add()` liefert eine **neue** Liste und lässt die alte unverändert.
- Mehrere Threads: Unveränderliche Daten ändern sich nie; wer liest, sieht einen festen Stand,
  auch während die Klasse eine neue Fassung erzeugt. Deshalb braucht man keine
  Synchronisierung (keine Sperren). Bei der Sicht dagegen kann sich die Liste mitten im
  Lesen ändern.

Typische Missverständnisse: Die Sicht sei eine Kopie (sie ist keine); "unveränderlich" heiße, die
Elemente selbst dürften nie geändert werden (es geht um die Kollektion).

## code-liste-rueckwaerts

Ausgabe: `1 9 5 `
- Rückwärts läuft `i` von 5 bis 0; entfernt werden `6`, `4`, `2`; die Liste ist
  `[1, 3, 5]`.
- `Insert(1, 9)` fügt `9` an Position 1 ein: `[1, 9, 3, 5]`.
- `Remove(3)` entfernt den **Wert** `3` (nicht die Position 3): `[1, 9, 5]`.
- Die Schleife läuft rückwärts, damit das Entfernen keine noch zu prüfenden Elemente
  verschiebt (kein Überspringen).

Typische Fehler: `1 9 3` (`Remove(3)` wie `RemoveAt(3)` gelesen); `Insert` als Ersetzen
gedeutet.

## code-sortedset

Ausgabe, drei Zeilen: `False True`, `1 3 5 9 `, `10`
- `Add()` liefert `false`, wenn das Element schon da war (`1`), und `true` bei einem neuen
  (`3`); eine Menge hat keine Duplikate (11.5, Seite 702).
- Ein `SortedSet<T>` liefert seine Elemente beim Durchlaufen immer aufsteigend, egal in
  welcher Reihenfolge sie eingefügt wurden (11.5.3, Seite 711).
- `Min` ist `1`, `Max` ist `9`; `1 + 9` = `10` (Zahlen addiert, keine Verkettung).

Typische Fehler: `5 1 9 3` (Einfügereihenfolge angenommen); `True True` (Duplikat nicht
erkannt); `19` für die dritte Zeile (als Text verkettet).

## code-hashset-punkt

Ausgabe, zwei Zeilen: `True`, `2`
- `Punkt` überschreibt weder `Equals()` noch `GetHashCode()`; es gilt die **Referenzgleichheit**.
- Das zweite `new Punkt(1, 2)` ist ein anderes Objekt, also "neu": `Add` liefert `True`, die
  Menge hat 2 Elemente.
- Erwartet hätte man `False` und `1`, weil beide Punkte dieselben Koordinaten haben.
  Behebung: **`Equals(object?)` und `GetHashCode()` überschreiben**, die `X` und `Y` vergleichen
  bzw. kombinieren (z. B. `HashCode.Combine(X, Y)`); oder aus `Punkt` einen Record machen.

Typische Fehler: `False`/`1` (Wertgleichheit angenommen); nur `Equals()` ohne `GetHashCode()`
überschreiben.

## code-woerterbuch

Ausgabe (vor dem Absturz), zwei Zeilen: `kein b`, `True 6`; die letzte Zeile löst eine
Ausnahme aus
- `d["a"] = 1;` legt den Schlüssel an, `d["a"] += 5;` liest und schreibt zurück: `6`.
- `TryGetValue("b", ...)` liefert `false`, also der `else`-Zweig: `kein b`.
- `d.ContainsKey("a")` ist `True`, `d["a"]` ist `6`: `True 6`.
- `d["b"]` liest einen fehlenden Schlüssel über den Indexer: eine **Ausnahme**; das
  Programm bricht (unbehandelt) ab. Bonus (Deep Dive): der Name `KeyNotFoundException`. Das lässt sich mit `TryGetValue` oder `ContainsKey` vermeiden.

Typische Fehler: Es werde `0` ausgegeben (wie bei einem Array); die zweite Zeile als
Fehler gedeutet (`+=` auf einem vorhandenen Schlüssel ist in Ordnung).
