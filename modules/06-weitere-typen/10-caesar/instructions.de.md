# Zusatzaufgabe: Caesar-Verschlüsselung knacken

Diese Aufgabe ist freiwillig. Sie übt das Rechnen mit Zeichen, den
`StringBuilder` und ein Zähl-Array. Zum Nachlesen: **6.3 Klassen für
Zeichenfolgen** (Seite 472), besonders **6.3.2 StringBuilder** (Seite 479),
und **6.2 Arrays** (Seite 455).

Die Caesar-Verschlüsselung verschiebt jeden Buchstaben um eine feste Zahl
von Stellen im Alphabet: Mit Schlüssel 3 wird aus A ein D, aus X ein A.

Öffne `Caesar.cs` und implementiere die vier statischen Methoden:

1. `Verschluessele(text, schluessel)`: Großbuchstaben `A`–`Z` und
   Kleinbuchstaben `a`–`z` werden verschoben, alles andere (Leerzeichen,
   Ziffern, Satzzeichen, Umlaute, ß) bleibt stehen. Rechne mit der Position
   im Alphabet: `c - 'A'` liefert 0 bis 25; nach dem Verschieben mit `% 26`
   zurück in den Bereich und mit `(char)('A' + pos)` wieder zum Zeichen.
   Der Schlüssel darf negativ oder größer als 26 sein; normiere ihn vorher
   auf 0 bis 25 (Achtung: `-3 % 26` ist in C# `-3`). Baue das Ergebnis mit
   einem `StringBuilder` auf.
2. `Entschluessele(geheim, schluessel)`: Verschlüsseln mit dem negativen
   Schlüssel.
3. `Haeufigkeiten(text)`: ein `int[26]`, in dem Index 0 zählt, wie oft A
   oder a vorkommt, Index 1 für B und b, und so weiter.
4. `Knacke(geheim)`: In deutschen Texten ist E fast immer der häufigste
   Buchstabe. Suche den Index mit der größten Häufigkeit; sein Abstand zu E
   (Index 4) ist der Schlüssel, normiert auf 0 bis 25.

Diese Tests müssen bestehen:

- `CaesarTests.Verschluessele_verschiebt_Gross_und_Kleinbuchstaben`
- `CaesarTests.Verschluessele_laeuft_am_Alphabetende_herum`
- `CaesarTests.Andere_Zeichen_bleiben_unveraendert`
- `CaesarTests.Negative_und_grosse_Schluessel`
- `CaesarTests.Entschluessele_hebt_Verschluessele_auf`
- `CaesarTests.Haeufigkeiten_zaehlt_ohne_Gross_Kleinschreibung`
- `CaesarTests.Knacke_findet_den_Schluessel`
- `CaesarTests.Knacke_liefert_Werte_von_0_bis_25`
