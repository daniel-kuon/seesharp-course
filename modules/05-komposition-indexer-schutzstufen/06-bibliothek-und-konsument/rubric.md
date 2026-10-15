# Rubrik — Bibliothek und Konsument (nur für die Betreuung)

- Lernziel ist der Projektverweis und die Schutzstufe `internal`, nicht das
  Rechnen. Im Gespräch: Was steht in `Bruchrechnung.csproj`? Was wird in
  `bin/` kopiert, wenn man das Konsolenprojekt baut (FractionLib.dll)?
- Hat der Trainee ausprobiert, dass `Bruch.Ggt` im Konsolenprojekt nach der
  Änderung nicht mehr kompiliert (CS0122)? Wenn nicht: jetzt zeigen.
- Frage zur Standard-Schutzstufe: `class Helfer` ohne Modifizierer ist
  `internal`; nicht geschachtelte Klassen können nur `public` oder `internal`
  sein.
- `Summe` mit `+=`: Warum muss das Etikett am Ende noch einmal gesetzt werden?
  (Der Instanzoperator hängt die Etiketten an.)

Modellantwort: `solution/`; die Bibliothek entspricht
`samples/Klassen und Objekte/Bruch/FractionLib`.
