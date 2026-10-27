# Ausnahmebehandlung

Wenn eine Methode ihre Aufgabe nicht erfüllen kann, meldet sie das mit einer
**Ausnahme**: ein Objekt, das den Fehler beschreibt und vom Ort des Fehlers
durch die Aufrufer nach oben wandert, bis jemand es behandelt (Kapitel 13,
Seite 885). Fängt niemand die Ausnahme, beendet die Laufzeit das Programm und
gibt Meldung und Stack Trace (im Buch die Aufrufreihenfolge
bzw. die Eigenschaft `StackTrace`) aus (13.1 und 13.2, Seite 886 und 888). Der oberste Eintrag des Stack Trace nennt die Methode, in der die
Ausnahme ausgelöst wurde, die weiteren Einträge die Aufrufer.

Wichtigste Regel: **Fehlervermeidung geht vor Ausnahmebehandlung.** Wer vor der
Division prüft, ob der Divisor null ist, braucht keine
`DivideByZeroException` abzufangen. Ausnahmen sind für Fehler gedacht, die
man nicht sinnvoll vorher ausschließen kann.

## Die try-Anweisung (13.3.1, Seite 890)

```csharp
try { /* riskanter Code */ }
catch (FormatException ex) { /* behandeln */ }
catch (ArithmeticException) { /* breiter, steht deshalb weiter unten */ }
finally { /* läuft (fast) immer */ }
```

* Die `catch`-Blöcke werden von oben nach unten geprüft: **spezifische Klassen vor
  allgemeinen**. Ein allgemeiner Block vor einem speziellen ist ein Compilerfehler.
* Über die Variable (`ex`) erhält man `Message`, `StackTrace`, `InnerException` und
  `Data`; `ex.GetType().Name` liefert den Typnamen.
* Ein **Ausnahmefilter** (im Buch: `when`-Klausel) `catch (IOException ex) when (...)`
  fängt nur bei erfüllter Bedingung (13.3.1.2, Seite 891).
* Der `finally`-Block läuft **fast immer**: nach normalem Ende, nach einem `return`
  und nach einer Ausnahme. Verhindern können ihn nur eine Endlosschleife oder
  `Environment.Exit()`. Dort räumt man auf, z. B. Dateien schließen
  (13.3.1.3, Seite 895). Bei verschachtelten `try`-Anweisungen läuft die Ausnahme
  nach oben, und jedes `finally` auf dem Weg wird ausgeführt (13.3.2).

## Fehlerkommunikation (13.4, Seite 905)

Eine Methode kann Fehler per Rückgabewert oder per Ausnahme melden. Rückgabecodes
muss der Aufrufer prüfen, sie lassen den Code unübersichtlich werden und sind leicht
zu ignorieren. Ausnahmen kann man nicht übersehen und sie wandern automatisch zur
bestgerüsteten Methode. Die Wahl richtet sich nach der **Fehlerwahrscheinlichkeit**:
Häufige Fehler (Eingabe falsch getippt, Dateiende) meldet man per Rückgabe, seltene per
Ausnahme. Das **Try-Muster** `bool TryParse(string s, out int ergebnis)` liefert
Erfolg als Rückgabewert und das Ergebnis über `out`; es wirft nie.

## BCL-Ausnahmeklassen (13.5, Seite 911)

Alle erben von `Exception`. Die wichtigsten: `ArgumentException` und ihre
Unterklassen `ArgumentNullException` und `ArgumentOutOfRangeException` (falsches
Argument), `InvalidOperationException` (Objekt im falschen Zustand),
`NotSupportedException`, `FormatException`, `ArithmeticException` mit
`DivideByZeroException` und `OverflowException`, `IndexOutOfRangeException`
(zur Ausnahme beim Lesen eines fehlenden Dictionary-Schlüssels siehe Deep Dive). `checked`-Arithmetik (Level 3, Buch 4.6.1) löst bei Überlauf
`OverflowException` aus, `int.Parse()` bei ungültigem Text `FormatException` und bei
zu großen Zahlen `OverflowException`.

## Ausnahmen werfen (13.6, Seite 913)

* `throw new ArgumentOutOfRangeException(nameof(x), x, "…")` löst eine Ausnahme aus.
  Als Ausdruck geht `throw` auch in `a ?? throw …` oder `cond ? x : throw …`.
  `ArgumentNullException.ThrowIfNull(arg)` ist die Kurzform für Null-Prüfungen.
* In einem `catch` reicht **`throw;`** dieselbe Ausnahme weiter und behält den
  Stack Trace. `throw ex;` wirft sie neu und überschreibt den Ursprung: ein
  klassischer Fehler.
* Wer die Ursache in eine aussagekräftigere Ausnahme packt, gibt die ursprüngliche
  als **`InnerException`** mit: `throw new InvalidOperationException("…", ex);`

## Eigene Ausnahmen (13.7, Seite 916)

Man leitet von `Exception` (oder einer passenden Unterklasse) ab, bietet
die Konstruktoren `()`, `(string)` und `(string, Exception)` an und ergänzt
Eigenschaften für Zusatzinformationen. Für ein einzelnes Detail genügt oft
die `Data`-Kollektion einer BCL-Ausnahme. Die Übungsaufgaben am Kapitelende
(13.8, Seite 920) wiederholen das alles: Syntaxdiagramm von `try`, die Wirkung von
`OverflowException` im Beispiel `Sequenzen`, `Log2` mit Argumentprüfung und der
`SimpleStack` mit `ArgumentOutOfRangeException`.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- **`KeyNotFoundException`:** Diese Ausnahme (Namensraum
  `System.Collections.Generic`) löst der Indexer eines `Dictionary<K,V>` aus,
  wenn man einen fehlenden Schlüssel liest. Vermeiden lässt sie sich mit
  `TryGetValue()` oder `ContainsKey()` (Level 10).
- **Ausnahmefilter und Stapelabbau:** Die Bedingung in `when` wird geprüft,
  bevor der Aufrufstapel abgebaut wird. Darum ist ein Filter nicht dasselbe wie
  ein `catch`, der im Block per `if` prüft und dann mit `throw;` weiterreicht.
