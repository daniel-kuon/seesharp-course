# Rubrik: Verständnisfragen, Typgenerisches Programmieren (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `einschraenkung-richtig` = `where T : IComparable<T>`,
`typinferenz-richtig` = `Leer<int>()`, `nullable-richtig` = `n ?? -1`,
`einschraenkungen-kombinieren` = `where T : class, IComparable<T>, new()`).

## warum-generics

Wesentliche Punkte (mindestens zwei Nachteile der `object`-Lösung):
- **Casts nötig** beim Herausnehmen (`(double)stapel.Pop()`), der Code wird länger und
  unleserlich.
- **Keine Typsicherheit zur Übersetzungszeit**: In denselben Stapel kann man `int` und `string`
  mischen; der Fehler zeigt sich erst zur Laufzeit als `InvalidCastException`.
- **Boxing** bei Werttypen (`int` als `object`): Speicher und Zeit; mit `SimpleStack<int>`
  entfällt es.
- Ersatzlösung "eine Kopie der Klasse pro Elementtyp" wäre Wartungsaufwand.
- Generisch: Der Typformalparameter `T` wird erst beim Verwenden durch einen Typ ersetzt
  (`SimpleStack<double>`); der Compiler prüft ihn.

Typische Missverständnisse: Generics seien nur "bequemer"; `T` sei zur Laufzeit `object` (es
entstehen eigene konkretisierte Typen).

## einschraenkung

Wesentliche Punkte:
- Ohne Einschränkung weiß der Compiler über `T` nur, was **jedes** `object` kann; Aufrufe wie
  `element.CompareTo(other)` oder `<` sind nicht erlaubt.
- `where T : IComparable<T>` **sichert zu**, dass jedes `T` vergleichbar ist; dann darf die
  Klasse `CompareTo` aufrufen (Einfügen an der richtigen Stelle der sortierten Liste).
- Zugleich **schließt** sie Typen aus, die das nicht können (`new SortedList<object>()` geht
  nicht): Der Fehler tritt beim Übersetzen auf, nicht erst zur Laufzeit.

Typische Missverständnisse: Die Klasse selbst müsse `IComparable` implementieren (es geht um
den Typ `T`); die Einschränkung sei nur Dokumentation.

## invarianz

Wesentliche Punkte:
- Wäre die Zuweisung erlaubt, könnte man über `lo` ein `int` (oder anderes
  Nicht-`string`-Objekt) in die Liste schreiben, die in Wahrheit eine `List<string>` ist:
  Typsicherheit verloren (Laufzeitfehler). Generische Klassen sind deshalb **invariant**.
- Varianz gibt es nur bei **Interfaces und Delegaten**, die ein `T` ausdrücklich nur in
  einer Richtung verwenden (`out` für nur Ausgabe: kovariant, `in` für nur Eingabe:
  kontravariant); Level 9 und 12. Beispiel: `IEnumerable<out T>`.
- Klassen wie `List<T>` benutzen `T` in beiden Richtungen (Parameter und Rückgabe);
  deshalb kann es für sie keine Varianz geben.

Typische Missverständnisse: Die Beziehung `string` : `object` übertrage sich automatisch auf
`List<string>` : `List<object>`; Invarianz sei ein Fehler oder eine Altlast der Sprache.

## nullable-default

Wesentliche Punkte:
- `int?` ist die Kurzform der generischen **Struktur** `Nullable<int>`: ein `int`-Wert plus ein
  Flag `HasValue`. Ein `int` kann nie `null` sein, ein `int?` schon.
- Generischer Code braucht `default(T)` (oder `default`), um ein `T` zu initialisieren, ohne
  den Typ zu kennen (ein `new T()` geht nur mit `new()`-Einschränkung).
- Werte: `default(int)` = `0`, `default(string)` = `null`, `default(int?)` = `null`.

Typische Missverständnisse: `int?` sei ein Referenztyp oder `int` mit Zeiger; `default(T)`
sei immer `null`; Verwechslung mit `string?` (Annotation für Referenztypen).

## generische-methode

Wesentliche Punkte:
- Bei `SimpleStack<T>` gehört `T` der **Klasse**; `T Pop()` benutzt nur dieses `T` und ist
  selbst **keine** generische Methode. Der Typ wird beim Erzeugen festgelegt
  (`new SimpleStack<double>()`).
- Eine **generische Methode** hat einen **eigenen** Typformalparameter (`Max<T>`), unabhängig
  von der Klasse (kann auch in einer nicht generischen Klasse stehen).
- **Typinferenz**: Der Compiler leitet `T` aus den **Argumenten** ab (`Max(3, 9, 4)` ergibt
  `T = int`); man schreibt das Typargument nicht.
- Selbst angeben muss man es, wenn aus den Argumenten nichts abzuleiten ist, z. B. bei leerer
  Argumentliste (`Max<int>()`); aus dem Zieltyp der Zuweisung wird `T` nie abgeleitet.

Typische Missverständnisse: Jede Methode in einer generischen Klasse sei eine generische
Methode; der Compiler leite `T` aus dem Rückgabetyp oder Zielvariablen ab.

## code-nullable

Ausgabe, vier Zeilen: `10`, `5`, `False`, `7`
- `a ?? 10`: `a` ist `null`, also der Ersatzwert `10`.
- `b ?? 10`: `b` hat den Wert, also `5`.
- `a.HasValue`: `a` ist `null`: `False`.
- `a ??= 7` weist nur zu, wenn `a` `null` ist: jetzt `7`; `WriteLine(a)` gibt `7` aus.

Typische Fehler: `0` für `a ?? 10` (so, als wäre `a` ein `int`); `??=` als "immer
zuweisen" gedeutet (hier gleiches Ergebnis; bei `b ??= 7` bliebe `5`).

## code-generische-methode

Ausgabe, drei Zeilen: `9`, `Birne`, `x`
- `Groesser(3, 9)`: aus den Argumenten folgt `T = int`; `9`.
- `Groesser("Apfel", "Birne")`: `T = string`; `string` implementiert `IComparable<string>`,
  "Birne" ist alphabetisch größer: `Birne`.
- `Groesser('x', 'k')`: `T = char`, `x` ist größer als `k`: `x`.
- `Groesser(new object(), new object())` kompiliert nicht: `T` würde `object` und
  `object` implementiert `IComparable<object>` nicht; die Einschränkung ist verletzt (CS0311).
  Der Fehler kommt zur Übersetzungszeit.

Typische Fehler: Die Einschränkung gelte nur "ungefähr" und `object` sei durch den Compiler irgendwie
vergleichbar; `Birne` und `x` falsch herum (Vergleich verwechselt).

## code-default

Ausgabe, drei Zeilen: `7`, `0`, `True`
- Erster `Pop()`: `7`.
- Zweiter `Pop()` auf leerem `Stapel<int>`: `default!` ist `default(int)`, also `0`.
- `b.Pop()` auf leerem `Stapel<string>`: `default(string)` ist `null`: `True`.
- Der Stapel kennt `T` nicht und braucht `default`, um einen Wert zu erzeugen, der für jeden
  Typ passt; `new T()` wäre nur mit `new()`-Einschränkung möglich. `Stapel<int>` und
  `Stapel<string>` sind zwei verschiedene Typen.

Typische Fehler: `null` auch für `Stapel<int>` (ein `int` kann nicht `null` sein); eine Ausnahme
erwartet.

## code-invarianz

Wesentliche Punkte:
- Die Zeile **`List<object> lo = ls;`** (die dritte) kompiliert nicht (CS0029), weil
  `List<T>` **invariant** ist. `object o = ls[0];` ist dagegen in Ordnung (ein `string` ist
  ein `object`).
- Wäre sie erlaubt, würde `lo.Add(42)` ein `int` in eine Liste schreiben, die eigentlich
  Strings enthält: Beim Lesen über `ls[2]` käme ein `InvalidCastException`, oder es entstünde
  eine falsch gefüllte Liste. Der Compiler verbietet deshalb schon die Zuweisung.

Typische Fehler: Die vierte Zeile `lo.Add(42)` als den Fehler benennen (sie ist nur Folge); die
zweite Zeile für fehlerhaft halten.
