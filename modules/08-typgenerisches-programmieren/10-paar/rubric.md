# Rubrik — Zusatz generisches Paar (nur für die Betreuung)

- `Getauscht()` liefert `Paar<T2, T1>`: Typparameter lassen sich wie Werte
  "umsortieren". Nachfragen, warum `Getauscht()` keinen eigenen
  Typparameter braucht, `MitErstem<TNeu>` aber schon.
- `Paar` und `Paar<T1, T2>` sind zwei verschiedene Typen (die Zahl der
  Typparameter gehört zum Namen, `Paar` und ``Paar`2``). Die BCL macht es
  mit `Tuple` / `Tuple<T1, T2>` genauso.
- Typinferenz klappt nur bei Methoden, nicht bei Konstruktoren:
  `new Paar(1, "eins")` kompiliert nicht. Genau dafür gibt es `Paar.Von`.
- Unveränderlichkeit: Alle Methoden liefern neue Paare. Vergleich mit
  Records und `with` (Level 6).
- Ausblick: Tupel `(int, string)` (Level 6) sind die eingebaute Lösung.

Modellantwort: `solution/`.
