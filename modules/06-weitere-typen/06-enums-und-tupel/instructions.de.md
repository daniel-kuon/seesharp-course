# Enumerationen und Tupel

Lies im Buch Abschnitt **6.4 Aufzählungstypen** (Seite 480) und **6.6
Tupel** (Seite 486), vor allem 6.6.4 (Dekonstruktion, Seite 491), 6.6.5
(Tupel als Rückgabetyp, Seite 493) und 6.6.6 (Dekonstruktion eigener Typen,
Seite 494).

Öffne `Temperament.cs`. Das Enum `Temperament` ist deklariert; die Klasse
`Person` nutzt es für die Eigenschaft `Temp`.

1. Der Setter von `Temp` soll nur definierte Werte übernehmen:
   `(Temperament)13` ist ein gültiger Cast, aber kein gültiger Wert;
   `Enum.IsDefined(value)` prüft das. Ungültige Werte werden ignoriert.
2. `Person.Deconstruct(out vn, out nn)` liefert Vorname und Name, damit
   `var (vn, nn) = person;` funktioniert.
3. `Analyse.Wert(t)` liefert die Ganzzahl hinter dem Wert (ein Cast genügt).
4. `Analyse.AnalyzeName("Otto Rentner")` zerlegt am ersten Leerzeichen
   (`IndexOf`, `Substring`) und liefert ein **benanntes Tupel**
   `(First, Last, FirstPalin, LastPalin)`; die Palindromprüfung ist eine
   lokale Methode, die von beiden Enden her vergleicht, ohne Rücksicht auf
   Groß-/Kleinschreibung (`"Otto"` ist ein Palindrom).

> **Deep Dive (optional):** `Analyse.ParseTemperament(text)` wandelt den
> Namen eines Werts ohne Rücksicht auf Groß-/Kleinschreibung in den
> Enum-Wert und wirft bei unbekanntem Text `ArgumentException`. Den Weg vom
> Namen zum Wert zeigt das Buch nicht; die BCL bietet
> `Enum.TryParse(text, true, out Temperament t)`, das `true` und den Wert in
> `t` liefert. Achtung: `TryParse` akzeptiert auch Zahlen wie `"7"`; prüfe
> das Ergebnis zusätzlich mit `Enum.IsDefined`. Umgekehrt liefert
> `ToString()` den Namen eines Enum-Werts. Der Test
> `EnumsTupelTests.ParseTemperament_ignoriert_die_Schreibweise` gehört zu
> diesem Teil und ist ein Extra; zum Bestehen zählen die anderen fünf Tests.
