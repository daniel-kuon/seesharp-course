# Rubrik — Attribute: Quiz (nur für die Betreuung)

- `conditional` ist die Frage mit dem häufigsten Irrtum: Die Methode bleibt
  in der Assembly, nur der Aufruf verschwindet (und mit ihm die Auswertung
  der Argumente). Gesprächsanlass: Warum wäre ein `if (Debug)` zur Laufzeit
  anders? (Kosten bleiben, Code bleibt im Release.)
- `return-target`: Die Antwort ist nicht im Kernabschnitt zu finden, sondern
  über 14.3 (Attributziele) und 14.8 (Seite 945, `return:` an Lambdas).
  Wer falsch liegt, bekommt `assembly:` als Brücke.
- Offene Frage `obsolete-error`: Gute Antworten nennen, dass der Compiler
  jede verbleibende Stelle findet (Fehlerliste als Arbeitsliste), ein
  Kommentar dagegen von niemandem gelesen wird. `error: false` ist richtig,
  solange Aufrufer in anderen Teams oder Paketen noch umziehen müssen:
  erst Warnung, nach einer Frist Fehler, danach Löschen.
- `attribut-vs-basisklasse`: Bei Unsicherheit das Beispiel `[Obsolete]` und
  `[Serializable]` besprechen: Beides ändert nicht, was die Klasse tut.
