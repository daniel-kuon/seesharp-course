# Rubrik — Verständnisfragen Level 14 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0, C# 14) geprüft.
Eine Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen;
Wortlaut und Fachbegriffe müssen nicht exakt stimmen.

## nullable-kontext

Kernpunkte:
- Beim Übersetzen: `string?` und `string` sind eine **Information für den Compiler**; die Nullzustandsanalyse warnt bei Zuweisung von `null` an eine nicht-nullable Variable und beim Zugriff auf einen möglichen Nullwert.
- Zur Laufzeit gibt es **keinen Unterschied**: Es sind dieselben Typen, nichts wird geprüft oder verhindert (ein `string` kann trotzdem `null` enthalten, z. B. durch Reflexion oder unsaubere Bibliotheken).
- `!` (Null-Vergebung) **unterdrückt nur die Warnung**, er schützt nicht vor einer `NullReferenceException`. Vertretbar ist er, wenn man nachweisen kann, dass der Wert nicht null ist, der Compiler das aber nicht erkennt, am besten mit Kommentar. Normalerweise behebt man Warnungen durch Code (prüfen, `?`-Typ, anderes Modell).

Typische Irrtümer: `string?` sei ein eigener Typ zur Laufzeit; `!` prüfe auf null oder mache den Wert sicher; man solle Warnungen mit `!` wegmachen, wenn sie nerven.

## null-operatoren

Kernpunkte (je Operator ein sinnvolles Beispiel):
- `?.` bricht bei `null` ab und liefert `null` (z. B. `name?.Length` ist `int?`); `?[ ]` entsprechend für Indexer.
- `??` liefert einen Ersatzwert, wenn die linke Seite null ist (`name ?? "unbekannt"`).
- `??=` weist nur zu, wenn die linke Seite null ist (`liste ??= new List<int>();`).
- Null-bedingte Zuweisung: Bei `k == null` passiert **nichts**: weder die Zuweisung noch die Berechnung der rechten Seite (`Berechne()` wird nicht aufgerufen, keine Ausnahme); ist `k` nicht null, wird zugewiesen.

Typische Irrtümer: `?.` liefere bei null einen Standardwert wie 0 statt `null`; `Berechne()` werde trotzdem aufgerufen; es gebe eine `NullReferenceException`; `??=` überschreibe immer.

## muster-statt-if

Kernpunkte:
- Besser lesbar, wenn mehrere Fälle nach der **Form** eines Werts (Typ, Eigenschaften, Bereiche, Tupel/Listen) unterschieden und dabei ein Ergebnis berechnet werden; ein Ausdruck, kein Verzweigungsgerüst, und der Compiler prüft auf fehlende oder unerreichbare Fälle.
- Mindestens drei Mustertypen mit Beispiel, z. B. Konstantenmuster (`0`, `null`, `"DE"`), Typmuster (`string s`), Relationsmuster (`< 13`, `>= 18`), logische Muster (`and`, `or`, `not`), Merkmalsmuster (`{ Elektro: true }`), Positionsmuster, Tupelmuster, Listenmuster (`[1, .., 9]`) oder `when`-Bedingung.
- **Reihenfolge:** Der erste passende Arm gewinnt; allgemeinere Arme vor spezielleren verdecken diese (der Compiler meldet unerreichbare Arme), und spezielle Fälle müssen deshalb vor dem Auffangarm `_` stehen.

Typische Irrtümer: Alle passenden Arme würden ausgeführt; die Reihenfolge sei egal; Muster seien nur eine andere Schreibweise ohne Vorteil.

## span

Kernpunkte:
- Ein Span ist ein **Fenster auf vorhandenen Speicher** (Array, String, Stack): Er enthält Anfang und Länge, aber keine eigenen Daten. `ReadOnlySpan<T>` erlaubt nur Lesen.
- Vorteil: Ausschnitte **kopieren nichts und erzeugen keine neuen Objekte** (kein neues Array wie bei `Array.Copy`, keine neue Zeichenkette wie bei `Substring`); Schreiben über einen `Span<T>` verändert das Original; eine Methode mit Span-Parameter passt für Arrays, Strings und Stack-Speicher.
- Span ist ein `ref struct` und lebt nur auf dem Stack. Folge: kein Feld einer (normalen) Klasse, nicht boxen, nicht über ein `await` hinweg halten, nicht in Lambdas einfangen; er darf nie länger leben als der Speicher, auf den er zeigt.

Typische Irrtümer: Ein Span kopiere die Elemente; ein Span sei unveränderlich; ein Span dürfe nur für Strings benutzt werden.

## code-null-operatoren

Ausgabe, zwei Zeilen: `-1` und `Ada 3`.
Kernpunkte:
- `name` ist `null`: `name?.Length` ist `null` (`int?`), `?? -1` liefert dann -1.
- Das erste `??=` weist "Ada" zu (links war null), das zweite tut nichts, weil `name` jetzt nicht mehr null ist; es bleibt "Ada" (Länge 3).

Typische Irrtümer: `0` statt `-1`; `Bob 3` (zweites `??=` überschreibe); NullReferenceException.

## code-span-ref

Ausgabe, zwei Zeilen: `1,20,3,4,5` und `1,0,3,4,5`.
Kernpunkte:
- `AsSpan(1, 3)` ist ein Fenster auf die Elemente 2, 3, 4 **desselben** Arrays; `mitte[0] = 20` schreibt ins Original (erstes Element des Fensters ist Index 1 des Arrays).
- `Hoechster` liefert per `ref`-Rückgabe einen **Verweis auf die Speicherstelle** des größten Elements (jetzt die 20 an Index 1); `Hoechster(daten) = 0;` schreibt dorthin, nicht in eine Kopie.

Typische Irrtümer: Das Array bleibe unverändert (Span kopiere); `1,2,3,4,0` (größte Zahl sei die letzte oder vor der Änderung bestimmt); die Zuweisung an einen Methodenaufruf sei ein Fehler oder verändere nur eine Kopie.

## code-switch-reihenfolge

Ausgabe (eine Zeile): `gerade; negativ; ungerade; leer; Text Hi; nichts; anderes; `
Kernpunkte:
- `4` → zweiter Arm passt nicht (nicht < 0), dritter passt (gerade).
- `-2` → ist gerade, trifft aber zuerst den Arm `int and < 0`, also **"negativ"**: Der erste passende Arm gewinnt.
- `7` → ungerade; `""` → leer (Merkmalsmuster `Length: 0`); `"Hi"` → Text Hi; `null` → nichts (erster Arm, ein `null` erreicht die Typmuster nicht); `2.5` (double) → `_`.

Typische Irrtümer: `-2` ergebe "gerade" (Reihenfolge nicht beachtet); `null` lande bei `_`; der leere String ergebe "Text ".

## code-listenmuster

Ausgabe (eine Zeile): `leer; eins:5; 1 bis 9; 1 bis 9; 2+2; `
Kernpunkte:
- `[]` passt nur auf ein leeres Array; `[var x]` auf genau ein Element.
- `[1, .., 9]` passt auf jedes Array mit mindestens zwei Elementen, dessen erstes 1 und dessen letztes 9 ist, `..` steht für beliebig viele (auch null) Elemente dazwischen; deshalb passen sowohl `{1, 9}` als auch `{1, 2, 9}`.
- `[var kopf, .. var rest]` fängt das erste Element und den Rest (hier `{3, 4}`, Länge 2) → `2+2`.
- Auch hier gilt: Der erste passende Arm gewinnt.

Typische Irrtümer: `{1, 9}` passe nicht auf `[1, .., 9]` (zu kurz); `{5}` werde dem letzten Arm zugeordnet; `rest` enthalte alle Elemente.
