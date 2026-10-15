# Rubrik — Records (nur für die Betreuung)

- Der Umbau ist klein; wichtig ist das Gespräch über das, was der Compiler
  erzeugt (6.7.2). Mit dem Decompiler in Rider (IL Viewer) zeigen, wie viel
  Code hinter einer Zeile steckt.
- `with`-Ausdruck gegen `Klone()` aus Level 4 abgrenzen: nicht-destruktive
  Mutation, Original bleibt.
- Records vs. Strukturen vs. Klassen: Referenztyp mit Wertgleichheit; wann
  `record struct` (6.7.5)?
- Anonyme Klassen und `using`-Alias nur per Quiz; wer unsicher ist, soll
  beides in einem Konsolenprojekt ausprobieren.

Modellantwort: `solution/`; das Buch hat zu 6.7 kein eigenes Beispielprojekt
in diesem Ordner, Record-Vererbung folgt in Level 7.
