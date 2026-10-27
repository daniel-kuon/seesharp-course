# Rubrik — Attribute per Reflexion auslesen (nur für die Betreuung)

- Kern: Reflexion beginnt mit einem `Type`. `GetCustomAttributes<T>()`
  instanziiert die Attributobjekte (der Attributkonstruktor läuft jetzt),
  `IsDefined` fragt nur ab, ob sie vorhanden sind. Gesprächsanlass: Wann
  genügt `IsDefined`? (Wenn die Werte egal sind: billiger, kein Objekt.)
- Typische Falle: `GetMethods()` ohne `BindingFlags` liefert auch statische
  Methoden; der Test enthält deshalb eine statische Methode mit `[Autor]`,
  die nicht erscheinen darf. Die von `object` geerbten (`ToString`, `Equals`)
  kommen in beiden Varianten mit (wie im Buch, Seite 928), stören aber nicht,
  weil sie kein `[Autor]` tragen. Private Methoden bleiben in beiden
  Varianten draußen.
- `GetType()` vs. `typeof(T)`: Der Test mit `IEnumerable<int> folge = new
  List<int>()` ist das Herz der Aufgabe: Der Laufzeittyp ist `List<int>`, der
  deklarierte Typ `IEnumerable<int>`. Bei generischen Typen heißt der Name
  mit Anzahl der Typparameter (`List`1`): Nachfragen, was die Zahl bedeutet.
- Die Sortierung mit `StringComparer.Ordinal` hält die Tests von der
  Kultur des Rechners unabhängig; wer `Sort()` ohne Argument nimmt, besteht
  auch, aber nur durch Zufall der Testdaten.
- Das Buch sortiert nicht und liefert `object[]`; die generische
  Erweiterungsmethode `GetCustomAttributes<T>()` macht den Cast überflüssig.
  Wer `Attribute.GetCustomAttributes(...)` mit Cast schreibt, ist ebenfalls
  richtig.

Modellantwort: `solution/`.
