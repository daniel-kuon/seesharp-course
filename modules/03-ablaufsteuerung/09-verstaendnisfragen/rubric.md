# Rubrik: Verständnisfragen Level 3 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, die Fachbegriffe müssen aber stimmen. Bei den Programmfragen zählt neben der Ausgabe die Begründung. Die Auswahlfragen (`ist-gerade`, `wochentag-switch`, `summe-schleife`, `ggt-modulo`) sind automatisch bewertet und haben hier keinen Eintrag.

## schleife-wahl

Kernpunkte:
- **`for`:** zählergesteuert; Anfangswert, Bedingung und Fortschaltung stehen im Kopf. Passt, wenn die Zahl der Durchläufe bekannt ist (von 1 bis n zählen, Teiler von 2 bis zur Wurzel prüfen).
- **`foreach`:** läuft über **alle Elemente** einer Kollektion ohne Index, etwa über die Zeichen eines Strings (Vokale zählen).
- **`while`:** prüft die Bedingung **vor** jedem Durchlauf; der Körper läuft möglicherweise nie. Passt, wenn die Zahl der Durchläufe nicht feststeht (Euklid mit Subtraktion: solange `a != b`).
- **`do … while`:** prüft **nach** dem Durchlauf; der Körper läuft **mindestens einmal** (Euklid mit Modulo, eine Eingabe wiederholen, bis sie gültig ist).
- Zu jeder Schleife ein passendes Beispiel.

Typische Irrtümer: `foreach` brauche einen Zähler; `do … while` prüfe vor dem Körper; `for` und `while` seien grundsätzlich verschieden mächtig.

## dangling-else

Exakte Ausgabe: `negativ`

Kernpunkte:
- Das `else` gehört zum **nächstgelegenen `if` ohne `else`**, also zu `if (x > 10)`, **nicht** zu `if (x > 0)`. Die Einrückung zählt für den Compiler nicht.
- `x = 5`: Das äußere `if` ist wahr, das innere (`x > 10`) falsch, also läuft dessen `else`: `negativ`, obwohl `x` positiv ist.
- Abhilfe: **geschweifte Klammern** um das innere `if`, damit die Absicht eindeutig ist.

Typische Irrtümer: Es werde nichts ausgegeben, weil das äußere `if` wahr sei; das `else` gehöre wegen der Einrückung zum äußeren `if`; Ausgabe `groß`.

## endlosschleife

Kernpunkte:
- Zwei typische Ursachen, zum Beispiel: die **Schleifenvariable wird nicht oder falsch verändert** (`i++` vergessen, `i--` statt `i++`); die **Bedingung wird nie falsch**; ein **Semikolon direkt hinter dem Schleifenkopf** (`while (i < 100);`), das als leere Anweisung den Körper ersetzt, sodass nichts die Bedingung ändert; eine Zuweisung statt eines Vergleichs in der Bedingung.
- Finden: Programm anhalten, mit dem **Debugger** (Haltepunkt in der Schleife, Variablen im Fenster „Variables“ beobachten, mit `F10` Schritt für Schritt) oder mit Ausgaben prüfen, wie sich die Variablen der Bedingung verändern.

Typische Irrtümer: Eine Endlosschleife sei ein Compilerfehler; man solle den Rechner neu starten.

## leere-anweisung

Exakte Ausgabe: `Hallo` (genau einmal).

Kernpunkte:
- Das Semikolon hinter `for (…)` ist eine **leere Anweisung** und damit der gesamte Schleifenkörper. Die Schleife läuft dreimal und tut dabei nichts.
- Der folgende Block `{ … }` gehört nicht zur Schleife, er ist ein normaler Block und wird **einmal** ausgeführt.
- Der Compiler **warnt** nur (CS0642, „möglicherweise falsche leere Anweisung“), es ist kein Fehler.

Typische Irrtümer: `Hallo` werde dreimal ausgegeben; der Compiler melde einen Fehler.

## switch-vs-if

Kernpunkte:
- Der **switch-Ausdruck** liefert direkt einen **Wert** (`tag switch { 1 => "Montag", … }`). Er ist kürzer und lesbarer, wenn ein Wert einer **Konstanten** zugeordnet wird (Wochentage, Kategorien).
- Eine **`if`-`else if`-Kette** nimmt man, wenn die Bedingungen komplizierter sind (zusammengesetzte Bedingungen, mehrere Variablen, Vergleiche, die keine Konstantenvergleiche sind).
- **`_`** (Discard) ist der Auffangzweig für alle übrigen Werte, vergleichbar mit `else`/`default`.
- Fehlt er, warnt der Compiler (CS8509), und bei einem nicht abgedeckten Wert wirft das Programm zur Laufzeit eine `SwitchExpressionException`.

Typische Irrtümer: `_` sei ein Variablenname oder ein Fehler; ohne `_` liefere der Ausdruck `null`; der switch-Ausdruck brauche `break`.

## do-while

Exakte Ausgabe: `1 5`. Mit `while` statt `do … while`: `0 10`.

Kernpunkte:
- `do … while` führt den Körper **zuerst aus** und prüft danach: `count = 1`, `n = 5`; `5 > 20` ist falsch, die Schleife endet.
- Eine `while`-Schleife prüft **vor** dem ersten Durchlauf: `10 > 20` ist falsch, der Körper läuft **nie**, `count` bleibt 0 und `n` bleibt 10.
- Fazit: `do … while` läuft **mindestens einmal**, `while` unter Umständen nie.

Typische Irrtümer: Ausgabe `0 10` oder `2 2` für den ersten Fall; beide Schleifen verhielten sich gleich; der Körper laufe bei `do … while` nur, wenn die Bedingung wahr ist.

## euklid-vergleich

Kernpunkte:
- **Subtraktion:** Solange die beiden Zahlen verschieden sind, zieht man die kleinere von der größeren ab; am Ende sind beide gleich dem ggT.
- **Modulo:** Der ggT von `a` und `b` ist der ggT von `b` und `a % b`; man wiederholt, bis der Rest 0 ist, der letzte Divisor ist das Ergebnis.
- Modulo ist schneller, weil **ein einziger Rest viele Subtraktionen ersetzt**. Beispiel: Bei `ggT(1000000, 1)` braucht die Subtraktion eine Million Durchläufe, der Modulo-Weg einen oder zwei.

Typische Irrtümer: Beide Verfahren liefen immer gleich schnell; Modulo sei „genauer“; der Rest werde mit `/` berechnet.

## euklid-trace

Exakte Ausgabe: `6`

Wertetabelle (zu Beginn jedes Durchlaufs und am Ende):

| Durchlauf | `a` | `b` | `r` |
|---|---|---|---|
| 1 | 48 | 18 | 12 |
| 2 | 18 | 12 | 6 |
| 3 | 12 | 6 | 0 |
| Ende | 6 | 0 | |

Kernpunkte:
- Das Programm berechnet den **größten gemeinsamen Teiler** von 48 und 18 mit der **Modulo-Variante** von Euklid: `ggT(a, b) = ggT(b, a % b)`.
- Die Schleife endet, wenn `b` 0 ist; dann steht das Ergebnis in `a`.

Typische Irrtümer: Es werde der Rest ausgegeben (`0`); es werde `18` oder `12` ausgegeben; es berechne das kleinste gemeinsame Vielfache.

## ueberlauf

Kernpunkte:
- Ganzzahltypen haben einen **festen Wertebereich** (`int`: etwa ±2,1 Milliarden). Bei `x = x + 1` mit `int.MaxValue` gibt es **keinen Fehler und keine Warnung**; der Wert **springt still auf den negativen Rand**, `x` ist danach `-2147483648` (`int.MinValue`).
- Gefährlich, weil das Programm mit einem völlig falschen Ergebnis weiterrechnet (Beispiel: Fakultäten, große Summen).
- Absichern: einen **größeren Typ** (`long`) wählen, oder mit **`checked`** eine `OverflowException` auslösen lassen.
- Nebenbei (nicht verlangt): Ein Ausdruck aus lauter Konstanten wie `int.MaxValue + 1` lehnt der Compiler schon beim Übersetzen ab (CS0220).

Typische Irrtümer: Das Programm stürze mit einer Ausnahme ab (nur mit `checked`); `x` bleibe bei `int.MaxValue`; das Ergebnis sei `2147483648`.
