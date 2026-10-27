# Rubrik: Verständnisfragen Level 2 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, die Fachbegriffe müssen aber stimmen. Bei Ausgaben mit Dezimalzahlen sind Komma und Punkt gleichwertig (die Ausgabe hängt von der Spracheinstellung ab). Die Auswahlfragen (`betrag-literal`, `mittelwert`, `char-verschieben`, `spaltenformat`) sind automatisch bewertet und haben hier keinen Eintrag.

## double-vs-decimal

Kernpunkte:
- `double` speichert Zahlen **binär** (52 Bit Mantisse). Viele Dezimalbrüche wie 0,1 und 0,2 sind binär **nicht exakt darstellbar**, es werden nur die nächstgelegenen Näherungen gespeichert. Die Summe weicht deshalb minimal von der Näherung für 0,3 ab.
- `decimal` speichert **dezimal** und ist für Dezimalbrüche exakt (langsamer, kleinerer Bereich). Man nimmt es für **Geldbeträge** und alles, was dezimal exakt sein muss; `double` für Messwerte und wissenschaftliche Rechnungen.
- `double`-Werte vergleicht man **nicht mit `==`**, sondern mit einer **Toleranz**: der Betrag des Unterschieds (`Math.Abs(a - b)`) ist kleiner als ein kleiner Wert. Das Buch (4.5.4) empfiehlt genauer eine Schwelle für die relative Abweichung (`Math.Abs((a - b) / a) < 1e-14`); beides gilt als richtig.

Typische Irrtümer: Der Compiler sei fehlerhaft; `double` sei „zu ungenau“ allgemein (es ist nur für Dezimalbrüche nicht exakt); `float` löse das Problem; `decimal` sei exakt für **alle** Zahlen (1/3 ist auch dort nicht exakt).

## plus-verkettung

Exakte Ausgabe:

```
Summe: 32
Summe: 5
5 ist die Summe
Summe: 5
```

Kernpunkte:
- Zeile 1: `+` wird **von links nach rechts** ausgewertet. `"Summe: " + a` ist schon eine Zeichenkette, also wird danach `b` **angehängt** (`"Summe: 3"` + `2` ergibt `"Summe: 32"`), nicht addiert.
- Zeile 3: `a + b + " ist die Summe"`: Hier steht links zuerst `a + b`, zwei `int`-Werte, also wird **zuerst addiert** (5); erst dann folgt die Verkettung mit dem Text.
- Klammern (Zeile 2) oder Interpolation (Zeile 4) lösen das Problem.

Typischer Irrtum: In Zeile 1 werde addiert (`Summe: 5`), oder in Zeile 3 komme `32 ist die Summe` heraus.

## ganzzahldivision

Kernpunkte:
- Sind **beide Operanden `int`**, ist `/` eine **Ganzzahldivision**; die Nachkommastellen werden abgeschnitten (nicht gerundet), `7 / 2` ist `3`.
- Damit `3.5` herauskommt, muss **mindestens ein Operand** `double` sein: `7 / 2.0`, `7.0 / 2` oder `(double)7 / 2`. Entscheidend ist, dass der Cast **vor** der Division wirkt.
- Beispiele für die Falle: Mittelwert aus zwei `int`-Variablen, Prozentrechnung, Umrechnungen, Brüche (jede Stelle, an der zwei ganze Zahlen geteilt und das Ergebnis in ein `double` gesteckt wird).

Typischer Irrtum: Es genüge, das Ergebnis in eine `double`-Variable zu speichern; `(double)(7 / 2)` liefere `3.5`.

## division-und-cast

Exakte Ausgabe (Komma oder Punkt):

```
3
3,5
3
```

Kernpunkte:
- `x`: `a / b` ist eine Ganzzahldivision (`3`); das Ergebnis wird erst danach zu `double`. Ausgabe `3`.
- `y`: Der Cast `(double)a` bindet stärker als `/`; ein Operand ist `double`, also wird gleitkommamäßig geteilt: `3,5`.
- `z`: Die Klammer erzwingt zuerst die Ganzzahldivision `a / b` (= 3); der Cast kommt zu spät. Ausgabe `3`.

Typischer Irrtum: `x` und `z` seien `3,5`, weil die Variable ein `double` ist; oder `(double)a / b` caste das Ergebnis.

## umwandlung

Kernpunkte:
- **Implizit** passieren **erweiternde** Umwandlungen, bei denen nichts verloren geht: `int` nach `long`, `int` nach `double`, `char` nach `int` (Unicode-Code).
- Ein **expliziter Cast** `(int)d` ist bei **verengenden** Umwandlungen nötig, bei denen Information verloren gehen kann: `double` nach `int`, `int` nach `char`, `long` nach `int`, `decimal` nach `double`.
- Ein Cast von `double` nach `int` **schneidet die Nachkommastellen ab**, er rundet nicht (`2.7` wird `2`, `-2.7` wird `-2`, also Richtung null). Gerundet wird mit `Math.Round`.

Typische Irrtümer: Der Cast runde; `int` nach `double` brauche einen Cast; ein Cast wandle `-2.7` in `-3`.

## abschneiden-char

Exakte Ausgabe (drei Zeilen):

```
-2
97
b
```

Kernpunkte:
- `(int)(-2.7)` schneidet ab, Richtung null: `-2` (nicht `-3`, nicht gerundet).
- `int code = c;` ist eine implizite Erweiterung; ein `char` ist ein Unicode-Code, `'a'` hat den Code `97`.
- `c + 1` ist ein `int` (98); der Cast `(char)(…)` macht daraus wieder ein Zeichen: `'b'`. Ohne Cast wäre es ein Compilerfehler.

Typische Irrtümer: `-3` als Ergebnis; Ausgabe `a` oder `a1`; es werde `98` statt `b` ausgegeben.

## var-const-scope

Kernpunkte:
- **`var`** lässt den Compiler den Typ aus dem Initialisierer **ableiten** (`var x = 3.0;` ist `double`). Die Variable bleibt **fest typisiert**; es ist kein dynamischer Typ, und der Typ lässt sich später nicht ändern.
- **`const`** definiert eine **Konstante**, deren Wert zur **Übersetzungszeit** feststehen muss und die nicht verändert werden darf. Nutzen: keine „magischen Zahlen“, ein Wert an einer Stelle, vor versehentlichem Überschreiben geschützt.
- **Sichtbarkeitsbereich:** Eine lokale Variable gilt nur **innerhalb des Blocks** `{ … }`, in dem sie deklariert wurde (und in den inneren Blöcken). Außerhalb ist der Name unbekannt (Compilerfehler).

Typische Irrtümer: `var` sei wie `dynamic` oder ein Typ „beliebig“; eine mit `var` angelegte Variable könne später einen anderen Typ aufnehmen; `const` sei dasselbe wie eine normale Variable, die man „nicht ändert“; die Variable gelte in der ganzen Methode.

## ausrichtung

Exakte Ausgabe (`_` steht für ein Leerzeichen):

```
[___42]
[7____]
42
7
```

Kernpunkte:
- Die Zahl hinter dem Komma ist die **Mindestbreite** des Felds; kürzere Werte werden mit Leerzeichen aufgefüllt.
- **Positiv (`5`) = rechtsbündig** (Leerzeichen davor), **negativ (`-5`) = linksbündig** (Leerzeichen dahinter).
- `\n` ist eine **Escape-Sequenz** für den Zeilenumbruch, deshalb stehen `42` und `7` in zwei Zeilen.

Typischer Irrtum: Positiv bedeute linksbündig; die Breite sei die Zahl der Nachkommastellen; `\n` werde als Text ausgegeben.

## inkrement-praefix

Kernpunkte:
- **`i++`** (Postfix) liefert **den alten Wert** und erhöht danach; **`++i`** (Präfix) erhöht **zuerst** und liefert den neuen Wert. Allein als Anweisung ist das Ergebnis dasselbe (`i` ist um 1 größer).
- Ein Beispiel, in dem man den Unterschied sieht: bei `int i = 4;` ist `int a = i++;` danach `a == 4` und `i == 5`, `int b = ++i;` ergibt `b == 6`.
- In `x += 3 * 2` wird nach der **Rangfolge** zuerst `3 * 2` berechnet (6), dann zu `x` addiert; `+=` ist die Kurzform von `x = x + (3 * 2)`.

Typischer Irrtum: Beide Formen seien in jedem Ausdruck gleich; `x += 3 * 2` entspreche `x = (x + 3) * 2`.
