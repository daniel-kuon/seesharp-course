# Rubrik — Razor-Pages-Grundlagen-Quiz (nur für die Betreuung)

- Die Reihenfolge der Middleware ist die Reihenfolge der `Use...`-Aufrufe.
  Ein Trainee soll erklären können, was jede der fünf Komponenten leistet und
  warum `MapRazorPages` (der Endpunkt) am Ende steht. Die Frage zur falschen
  Reihenfolge ist bewusst allgemein formuliert; das genaue Verhalten bei
  vertauschten Aufrufen hängt von der Version ab und steht nicht im Buch.
- Zustandslosigkeit: Der Gegenbeweis ist der Singleton-Dienst aus Aufgabe 4;
  das PageModel ist pro Anforderung neu, der Dienst nicht.
- Overposting im Gespräch vorführen lassen: Formular im Browser
  (Entwicklerwerkzeuge) um ein Feld ergänzen und absenden. Warum hilft ein
  verstecktes Feld nicht?
- Das Buch nennt `[Bind]`/`[BindNever]` und eine eigene Eingabemodellklasse
  (22.8.7); `[BindProperty]` selbst ist kein Schutz, es schaltet die Bindung
  ein.
