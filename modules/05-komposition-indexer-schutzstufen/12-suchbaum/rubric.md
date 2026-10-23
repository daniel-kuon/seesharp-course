# Rubrik — Zusatzaufgabe Suchbaum (nur für die Betreuung)

- `Einfuegen` und `Enthaelt` gehen iterativ (Schleife) oder rekursiv; beides
  ist richtig. `Anzahl`, `Hoehe` und `ToString` sind rekursiv deutlich
  einfacher. Wer sie iterativ schreibt, braucht einen eigenen Stapel; das
  ist hier nicht verlangt.
- Die Hilfsmethoden nehmen `Knoten?` und sind deshalb privat: Ein
  öffentliches Mitglied darf den privaten Typ `Knoten` nicht in der Signatur
  haben (Compilerfehler CS0050/CS0051). Gute Gelegenheit, Schutzstufen und
  geschachtelte Klassen zusammen zu besprechen.
- Test `Sortiert_eingefuegt_entsteht_eine_Kette`: Ein unbalancierter Baum
  entartet zur Liste. Nachfrage: Was kostet `Enthaelt` dann? Ausblick auf
  `SortedSet<T>` (Level 10), das intern balanciert.
- `ToString`-Leerzeichen sind der häufigste Fehler; `Trim()` am Ende ist als
  Abkürzung in Ordnung.

Modellantwort: `solution/Suchbaum/Suchbaum.cs`.
