# Rubrik: Verständnisfragen, Kollektionen (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `gerade-entfernen` = Rückwärtsschleife mit `RemoveAt`,
`spread-richtig` = `[0, ..mitte, 9]` mit Zieltyp `List<int>`, `trygetvalue-richtig` =
`TryGetValue("x", out int w)`, `kundennummern` = `HashSet<int>`).

## kollektion-waehlen

Erwartet (je Fall Kollektion **und** Begründung):
- (a) `Queue<T>`: Warteschlange, **FIFO**, `Enqueue`/`Dequeue`; der älteste Auftrag zuerst.
- (b) `Stack<T>`: Stapel, **LIFO**, `Push`/`Pop`; die letzte Änderung wird zuerst
  rückgängig gemacht.
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
  zuerst die Elemente einsammeln und danach entfernen, oder **`RemoveAll()`** mit einer
  Bedingung (Lambda-Ausdruck, erst Level 12; als Antwort trotzdem gültig).
- Rückwärts: Das Entfernen verschiebt nur Elemente **hinter** `i`, die schon bearbeitet sind;
  die Indizes der noch zu prüfenden Elemente bleiben gültig. Vorwärts würde das nächste
  Element nach `RemoveAt(i)` auf Platz `i` rutschen und übersprungen.

Typische Missverständnisse: Es sei ein Fehler des Compilers (die Ausnahme kommt zur Laufzeit);
vorwärts laufende `for`-Schleife sei genauso sicher.

## woerterbuch-lesen

Wesentliche Punkte:
- Lesen eines fehlenden Schlüssels über den Indexer: **`KeyNotFoundException`**.
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

Ausgabe: `5,3,9,1`
- Rückwärts läuft `i` von 5 bis 0; entfernt werden `6`, `4`, `2`; die Liste ist
  `[1, 3, 5]`.
- `Insert(1, 9)` fügt `9` an Position 1 ein: `[1, 9, 3, 5]`.
- `Reverse()` kehrt die Reihenfolge um: `[5, 3, 9, 1]`.
- Die Schleife läuft rückwärts, damit das Entfernen keine noch zu prüfenden Elemente
  verschiebt (kein Überspringen).

Typische Fehler: `1,9,3,5` (`Reverse` vergessen); `Insert` als Ersetzen gedeutet.

## code-queue-stack

Ausgabe, drei Zeilen: `ac`, `bb`, `4`
- Die Warteschlange gibt `a, b, c` in Einfügereihenfolge heraus (FIFO), der Stapel
  `c, b, a` (LIFO).
- `q.Dequeue()` = `a`, `s.Pop()` = `c`: `ac`.
- Danach `q.Peek()` = `b` (nächstes, ohne zu entfernen), `s.Peek()` = `b`: `bb`.
- `q.Count + s.Count` = 2 + 2 = `4` (Zahlen addiert, keine Verkettung).

Typische Fehler: `aa` oder `cc` (Reihenfolgen verwechselt); `22` für die dritte Zeile
(als Text verkettet).

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

Ausgabe (vor dem Absturz), zwei Zeilen: `kein b`, `True 6`; die letzte Zeile endet mit
`KeyNotFoundException`
- `d["a"] = 1;` legt den Schlüssel an, `d["a"] += 5;` liest und schreibt zurück: `6`.
- `TryGetValue("b", ...)` liefert `false`, also der `else`-Zweig: `kein b`.
- `d.ContainsKey("a")` ist `True`, `d["a"]` ist `6`: `True 6`.
- `d["b"]` liest einen fehlenden Schlüssel über den Indexer: **`KeyNotFoundException`**; das
  Programm bricht (unbehandelt) ab. Das lässt sich mit `TryGetValue` oder `ContainsKey` vermeiden.

Typische Fehler: Es werde `0` ausgegeben (wie bei einem Array); die zweite Zeile als
Fehler gedeutet (`+=` auf einem vorhandenen Schlüssel ist in Ordnung).
