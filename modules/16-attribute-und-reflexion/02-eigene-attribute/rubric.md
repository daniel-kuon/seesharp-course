# Rubrik — Eigene Attribute (nur für die Betreuung)

- Kern: Ein Attribut ist eine gewöhnliche Klasse, die von `Attribute`
  erbt; `[AttributeUsage]` (selbst ein Attribut: ein Meta-Attribut) legt
  Ziele und Mehrfachverwendung fest. Der Starter hat die Klassen absichtlich
  nicht von `Attribute` abgeleitet: Die Tests lesen sie ohne Generics-
  Einschränkung, damit er übersetzt.
- Positional vs. benannt: Der Konstruktorparameter ist Pflicht, die
  benannte Eigenschaft ist optional und braucht einen öffentlichen Setter.
  Frage: Warum passt `Version` nicht in den Konstruktor? (Optionale Angaben
  als benannte Parameter halten die Anwendung lesbar.)
- Die Modellantwort versiegelt die Klassen (`sealed`, Buch Seite 942).
  Fehlt das, ist es kein Fehler; nachfragen, warum Microsoft es empfiehlt.
- `AllowMultiple = true` ist nötig, damit `Rechner` zwei Autoren tragen
  kann. Ohne den Wert würde die zweite Zeile nicht übersetzt. Typische
  Abgabe-Falle: `ValidOn` nur `Class`, dann fehlt `Addiere`.
- `ImplementierungAttribute<T>`: Die Typeinschränkung ersetzt das
  `IsAssignableFrom` im Konstruktor des alten `PersistenceHelperAttribute`.
  Gesprächsanlass: Fehler, die der Compiler findet, sind besser als welche,
  die erst zur Laufzeit auffallen. Vor C# 11 ging das nicht, weil Attribute
  nicht generisch sein durften.
- Die Anwendung der Attribute (Schritt 4) ist der eigentliche
  Alltagsfall: Wer nur die Klassen schreibt, hat die Hälfte.

Modellantwort: `solution/`.
