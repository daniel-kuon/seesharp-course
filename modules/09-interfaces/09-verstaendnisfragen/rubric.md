# Rubrik: Verständnisfragen, Interfaces (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `icomparable-richtig` = `public int CompareTo(K? o)`,
`explizit-richtig` = `string IA.Name()` und `string IB.Name()` ohne Zugriffsmodifikator,
`iterator-richtig` = `yield return` von 1 bis `n`, `generische-mathematik-richtig` =
`where T : IAdditionOperators<T, T, T>`).

## mehrere-interfaces

Wesentliche Punkte:
- Eine Klasse **erbt von genau einer** Basisklasse, darf aber **beliebig viele Interfaces**
  implementieren; deshalb geht `Kreis : Figur, IComparable<Kreis>, ICloneable`, eine zweite
  Basisklasse aber nicht.
- Ein **Interface** legt fest, **was** ein Typ anbieten muss (Methoden, Eigenschaften,
  Indexer); es beschreibt eine **Fähigkeit** quer durch Hierarchien und enthält keinen
  Zustand (keine Instanzfelder).
- Eine **abstrakte Klasse** gibt zusätzlich **Zustand (Felder) und Code** an die Erben weiter
  und bildet eine "ist-ein"-Hierarchie.

Typische Missverständnisse: Interfaces seien einfach abstrakte Klassen ohne das Wort `class`;
Interfaces dürften Felder enthalten; die Mehrfachvererbung sei in C# verboten (nur für
Klassen, nicht für Interfaces).

## explizit-wann

Wesentliche Punkte:
- Das Mitglied wird **ohne Zugriffsmodifikator** mit dem Interface-Namen davor
  implementiert (`int IMesser.Wert()`); es ist nicht Teil der öffentlichen Schnittstelle der
  Klasse.
- Gründe (zwei genügen): (1) zwei Interfaces verlangen **gleichnamige Mitglieder mit
  verschiedener Bedeutung**; (2) das Mitglied soll in der öffentlichen Schnittstelle der
  Klasse **nicht auftauchen** (z. B. nicht-generisches `IEnumerable.GetEnumerator()` zugunsten
  der generischen Fassung); (3) eine Methode passt nicht zum Rest der Klassenschnittstelle.
- Aufruf **nur über eine Referenz vom Interface-Typ** (`IMesser m = k; m.Wert();` oder Cast
  `((IMesser)k).Wert()`), nicht über die Klasse selbst.

Typische Missverständnisse: `private` statt explizit; man könne es über die Klasse aufrufen;
das explizite Mitglied sei "versteckt" im Sinne von verschwunden (es existiert und ist über das
Interface erreichbar).

## foreach-protokoll

Wesentliche Punkte:
- `foreach` ruft `GetEnumerator()` auf (Interface `IEnumerable<T>`) und erhält ein
  `IEnumerator<T>`.
- Es ruft **`MoveNext()`** so lange auf, bis es `false` liefert; vor jedem Durchlauf des
  Rumpfs wird `Current` gelesen (das aktuelle Element).
- Ein eigener Typ muss `IEnumerable<T>` implementieren (also `GetEnumerator()` liefern; das
  nicht-generische `GetEnumerator()` explizit); der Enumerator hat Position, `MoveNext`,
  `Current` (und `Reset`). Oder man schreibt die Methode mit `yield return`.

Typische Missverständnisse: `foreach` laufe über einen Index (`for`); `Current` sei vor dem
ersten `MoveNext()` schon gültig; `foreach` brauche das Interface `IList`.

## yield-faul

Wesentliche Punkte:
- `yield return` gibt bei jedem Aufruf von `MoveNext()` das **nächste Element** zurück und
  **merkt sich die Stelle**; der Compiler erzeugt die **Zustandsmaschine** (Klasse mit Position
  und `MoveNext`, `Current`), die man sonst von Hand schreiben müsste.
- **Faul** bedeutet: Der Aufruf der Methode führt noch **keinen** Code im Rumpf aus; der
  Rumpf läuft erst beim **Durchlaufen** (`foreach`, `MoveNext()`), und zwar bis zum nächsten
  `yield return`.
- Folge: Nebenwirkungen (Ausgaben, Prüfungen von Argumenten) im Rumpf passieren erst bei der
  ersten Iteration, jede neue Iteration beginnt von vorn; Elemente werden bei Bedarf erzeugt,
  Unendliches ist möglich. Auch `yield break` beendet vorzeitig.

Typische Missverständnisse: Die Methode berechne sofort alle Werte und lege sie in einer Liste ab;
`yield return` beende die Methode wie `return`.

## generische-mathematik

Wesentliche Punkte:
- Ohne Einschränkung kennt der Compiler für `T` keinen Operator `+`. Mit
  `where T : IAdditionOperators<T, T, T>` sichert man zu, dass `T` den Operator
  bereitstellt; dann ist `a + b` erlaubt.
- Möglich macht das, dass Interfaces seit C# 11 **statische abstrakte Mitglieder** (auch
  Operatoren) verlangen können (`static abstract TSelf operator +`).
- `int`, `double` und `decimal` sowie eigene Typen wie `Bruch` implementieren das Interface
  (die BCL tut das für die Zahlentypen; `Bruch` durch `operator +`), also funktioniert **derselbe
  generische Code** für alle. Verwandte: `INumber<T>`.

Typische Missverständnisse: `where T : struct` oder `IComparable<T>` genüge für `+`;
`object` als Parameter statt Generics (Boxing, kein `+`).

## code-explizit

Ausgabe, drei Zeilen: `1`, `2`, `1`
- `k.Wert()`: Über die Klasse ist nur die öffentliche Methode sichtbar: `1`. Das explizit
  implementierte `IMesser.Wert()` gehört nicht zur öffentlichen Schnittstelle von `Kopf`.
- `m.Wert()` über eine `IMesser`-Referenz ruft die **explizite** Implementierung: `2`.
- `((IGabel)k).Wert()`: Für `IGabel` gibt es keine explizite Version; das öffentliche
  `Wert()` erfüllt `IGabel`: `1`.

Typische Fehler: `1 1 1` (der Interface-Typ spiele keine Rolle); `2` für die erste Zeile.

## code-struct-interface

Ausgabe, zwei Zeilen: `0`, `2`
- Das Zuweisen einer `struct` an eine Interface-Variable (`IZaehler t = s;`) **boxt** sie:
  Es entsteht eine **Kopie** auf dem Heap; `t` verweist darauf.
- `t.Erhoehe()` zweimal erhöht die **Kopie**, nicht `s`: `s.N` bleibt `0`, `t.N` ist `2`.
- Strukturen sind Werttypen; Boxing erzeugt ein unabhängiges Objekt (Level 6, Buch 9.3.2).

Typische Fehler: `2 2` (wie bei einer `class` ein gemeinsames Objekt angenommen); eine Ausnahme
erwartet.

## code-yield

Ausgabe, fünf Zeilen: `vor foreach`, `Start`, `1`, `4`, `9`
- `Quadrate(3)` führt den Rumpf noch **nicht** aus, sondern erzeugt nur das Iteratorobjekt;
  deshalb steht `vor foreach` an erster Stelle.
- Der Rumpf läuft erst, wenn `foreach` `MoveNext()` aufruft: erst `Start`, dann bis zum ersten
  `yield return` (`1`), bei jedem weiteren `MoveNext()` bis zum nächsten (`4`, `9`).
- Genau das heißt "faul".

Typische Fehler: `Start` vor `vor foreach` (so, als liefe die Methode sofort).

## code-icomparable

Ausgabe: `3 2 1 False` (in einer Zeile; die Zahlen mit Leerzeichen, dann `False`)
- `CompareTo` vergleicht hier `o.W` mit `W`, also **umgekehrt**: Ein Objekt gilt als "kleiner",
  wenn sein `W` **größer** ist. `Array.Sort` sortiert nach `CompareTo` aufsteigend, also absteigend
  nach `W`: `3 2 1`.
- `new P(5).CompareTo(new P(9))` ist `9.CompareTo(5)` = positiv; `< 0` ist `False`.
- `CompareTo` liefert negativ (dieses Objekt kommt vor `o`), 0 (gleich) oder positiv (danach);
  `Array.Sort` braucht nur diese Zusage (`IComparable<T>`).

Typische Fehler: `1 2 3 True` (Umkehrung übersehen); `CompareTo` müsse genau -1/0/1 liefern
(nur das Vorzeichen zählt).
