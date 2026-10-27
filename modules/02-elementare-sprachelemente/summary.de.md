# Elementare Sprachelemente

Kapitel 4 des Buchs (ab Seite 161) ist das Fundament für alles Weitere:
Programmaufbau, Ausgabe, Variablen und Datentypen, Eingabe und Operatoren.
Dieses Level deckt die Abschnitte 4.1 bis 4.5 ab; die Ablaufsteuerung (4.6 und
4.7) folgt im nächsten Level. Vier der fünf Übungen sind kurz, aber eine
davon, die Gleitkomma-Falle, solltest du nicht vergessen: Sie erklärt Fehler,
die dir sonst Jahre später in Rechnungsbeträgen begegnen.

## Programmaufbau und Namen (4.1, Seite 161)

Ein C#-Programm besteht aus Klassen mit Methoden; die Startklasse besitzt
`Main()`. Mit Anweisungen auf oberster Ebene (4.1.2, Seite 163) erzeugt der
Compiler diese Klasse selbst. Die Übungen in SeeSharp verwenden fast immer eine
explizite Klasse mit statischen Methoden, weil die Tests Methoden aufrufen
müssen. Bezeichner (4.1.6, Seite 171) bestehen aus Buchstaben, Ziffern und
Unterstrich, dürfen nicht mit einer Ziffer beginnen und kein Schlüsselwort
sein; Umlaute sind erlaubt, aber unüblich. Konvention: `PascalCase` für
Klassen, Methoden und Eigenschaften, `camelCase` für lokale Variablen und
Parameter.

## Ausgabe und Formatierung (4.2, Seite 175)

`Console.WriteLine()` gibt eine Zeile aus, `Write()` ohne Zeilenschaltung.
Zeichenketten verknüpft man mit `+`, aber Vorsicht: `"3 + 2 = " + 3 + 2`
ergibt `3 + 2 = 32`, weil `+` von links nach rechts ausgewertet wird und ab
dem ersten String nur noch verkettet. Klammern um die Rechnung lösen das.
Übersichtlicher ist die **Interpolation** (4.2.3.2, Seite 178): `$"{i} und
{j}"`. Hinter dem Ausdruck kann eine Breite stehen, `{i,8}` für rechtsbündig
und `{i,-8}` für linksbündig, und ein Format wie `{d:f2}` für zwei
Nachkommastellen. Escape-Sequenzen wie `\n` (Zeilenschaltung) und `\t`
(Tabulator) gelten in normalen Zeichenfolgenliteralen; `@"..."` schaltet sie ab.

## Variablen und Datentypen (4.3, Seite 180)

C# ist streng typisiert: Jede Variable hat einen festen Typ, muss vor der
Verwendung deklariert und initialisiert sein. Die elementaren Typen (4.3.4,
Seite 186) sind `int` und `long` für ganze Zahlen, `double` und `float` für
binäre Gleitkommazahlen, `decimal` für dezimale Gleitkommazahlen, `bool` und
`char`. Suffixe legen den Typ eines Literals fest: `3.5f` für `float`, `3.5m`
für `decimal`, `10L` für `long`; ohne Suffix ist `3.5` ein `double` und `10`
ein `int`.
`var` lässt den Compiler den Typ aus dem Initialisierer ableiten; die Variable
bleibt trotzdem fest typisiert. `const` definiert eine Konstante, die zur
Übersetzungszeit feststehen muss. Eine lokale Variable gilt nur innerhalb des
Blocks, in dem sie deklariert wurde (4.3.8, Seite 198).

**Gleitkommadarstellung (4.3.5, Seite 189):** `double` speichert Zahlen
binär mit 52 Bit Mantisse. Viele Dezimalbrüche wie 0,1 sind binär nicht exakt
darstellbar, deshalb ist `0.1 + 0.2 == 0.3` falsch. Der Abstand zur nächsten
darstellbaren Zahl bei 1,0 ist 2^-52; addiert man höchstens die Hälfte davon
(2^-53), wird das Ergebnis auf 1,0 gerundet.
Für Geldbeträge nimmt man `decimal`: langsamer, aber dezimal exakt. Vergleiche
auf Gleitkommawerten macht man mit einer Toleranz (4.5.4, Seite 223).

## Typumwandlung (4.5.7, Seite 229)

Erweiternde Umwandlungen passieren implizit: `int` nach `long`, `int` nach
`double`, `char` nach `int` (der Unicode-Code des Zeichens). Verengende
Umwandlungen brauchen einen expliziten Cast `(int)d`, und der schneidet
Nachkommastellen ab, rundet nicht. Die Klasse `Math` bietet `Round`, `Abs`,
`Sqrt`, `Pow` und mehr.

## Operatoren (4.5, Seite 215)

Arithmetik mit `+ - * / %`: Zwei `int`-Operanden ergeben eine
**Ganzzahldivision**, `7 / 2` ist `3`; sobald ein Operand `double` ist, wird
gleitkommamäßig gerechnet. `%` liefert den Rest. Vergleiche (`<`, `==`, `!=`)
liefern `bool`; logische Operatoren `&&`, `||`, `!` verknüpfen Wahrheitswerte,
`&&` und `||` werten den rechten Operanden nur bei Bedarf aus. `i++` liefert
den alten Wert und erhöht danach, `++i` erhöht zuerst. Verbundzuweisungen
`+=`, `*=` kürzen `i = i + x` ab. Der Konditionaloperator `b ? x : y` wählt
einen von zwei Werten. Die Rangfolge (4.5.10, Seite 236) entscheidet, was
zuerst gerechnet wird; im Zweifel Klammern setzen. Die Regeln von De Morgan
helfen beim Negieren zusammengesetzter Bedingungen: `!(a || b)` ist dasselbe
wie `!a && !b`.

Vertiefung: Kapitel 4, Abschnitte 4.1 bis 4.5 (Seite 161 bis 243).
