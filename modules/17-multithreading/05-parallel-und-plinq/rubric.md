# Rubrik — Parallel und PLINQ (nur für die Betreuung)

- Kern: Parallelisieren ist mit `Parallel.For` und `AsParallel()` leicht
  hingeschrieben und leicht falsch. Die beiden Fragen für jede parallele
  Schleife: Was teilen sich die Iterationen? Und hängt das Ergebnis von der
  Reihenfolge ab? Wer beides beantworten kann, hat das Kapitel verstanden.
- `SummeQuadrate`: `Interlocked.Add(ref summe, ...)` auf ein einzelnes
  Feld ist richtig; `lock` ginge auch. Das Bessere (nicht verlangt): Teilsummen
  pro Thread mit der Überladung `Parallel.For` mit lokalem Zustand und nur
  am Ende zusammenführen: eine Interlocked-Operation pro Iteration ist bei
  so wenig Arbeit eher bremsender Aufwand als Gewinn. Nachfragen, ob das
  parallele Ergebnis hier überhaupt schneller als das sequenzielle wäre
  (wahrscheinlich nicht: die Arbeit pro Element ist winzig).
- `SammleGerade`: Ein fehlendes `lock` erzeugt bei 300.000 Elementen praktisch
  immer Verluste oder eine Ausnahme, die Tests sind aber nur für den
  korrekten Code deterministisch: Eine Abgabe ohne `lock` kann mit Glück
  bestehen (Einkern-Maschine). Deshalb den Quelltext ansehen. Der
  Gesprächsanlass: Ist `lock` pro Element hier eigentlich sinnvoll?
  (Nein: besser `.Where(...).ToArray()` mit PLINQ, weil die
  Reihenfolge egal ist, und Sammelstellen vermeiden. Nur als Gedanke.)
- `WiederholeParallel`: Das Experiment mit `maxGrad = 1` ist die einzige
  streng nachweisbare Aussage über den Grad: Der Test erwartet genau 1.
  `maxGrad = 2` bedeutet höchstens 2, nicht genau 2.
- `Gleichzeitig`: `Parallel.Invoke` garantiert NICHT, dass die Aktionen wirklich
  gleichzeitig laufen, nur dass sie parallel laufen dürfen (auf einer
  Einkern-Maschine nacheinander). Darum prüft der Test nur Vollständigkeit
  und die Rückkehr erst nach dem Ende aller drei.
- `Primzahlen`: Ohne `AsOrdered()` ist die Reihenfolge nicht zugesichert. Mit
  `ToList()` auf einer `Range`-Quelle kommt sie in .NET 10 trotzdem meist
  geordnet heraus (geprüft: 20 von 20 Läufen; mit `foreach` über dieselbe
  Abfrage dagegen 20 von 20 durcheinander). Der Test erkennt ein
  fehlendes `AsOrdered()` deshalb nicht zuverlässig: im Code nachsehen.
  Gesprächsanlass: Was kostet `AsOrdered`, und wann ist `ForAll` besser?
  (`ForAll` kennt keine Reihenfolge und vermeidet das Zusammenführen.)

Modellantwort: `solution/`.
