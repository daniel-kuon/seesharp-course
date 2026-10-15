# Rubrik — Operatoren überladen (nur für die Betreuung)

- `operator +` darf `b1` nicht verändern. Ein häufiger Fehler ist
  `b1.Addiere(b2); return b1;` — der Test `Plus_laesst_die_Operanden_unveraendert`
  fängt das, aber die Erklärung (Referenz vs. Kopie) lohnt sich.
- `+=` als Instanzoperator: Hat der Trainee verstanden, warum hier keine neue
  Instanz entsteht und `Anzahl` nicht hochzählt? Mit `Bruch.Anzahl` vor und
  nach `b1 += b2` im Debugger zeigen.
- `Klone()` sollte den expliziten Konstruktor nutzen; `DuplWerte` kopiert nur
  Zähler und Nenner, nicht das Etikett.
- Bonus-Frage: Warum ist `operator +` `static`, `+=` aber nicht?

Modellantwort: `samples/Klassen und Objekte/Bruch/b7 Operatoren-Überladung` im
Tool-Repository.
