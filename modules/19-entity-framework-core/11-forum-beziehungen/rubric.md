# Rubrik: Zusatz: Forum mit Themen und Antworten (nur für die Betreuung)

- **Kernidee:** Dasselbe Muster wie `19/04`, auf ein neues Modell übertragen: Fremdschlüssel
  auf der n-Seite, Navigationseigenschaften auf beiden Seiten, `Include` zum Laden, `Cascade`
  zum Mitlöschen. Gezählt wird auf dem Server.
- Typische Fehler: `Include` vergessen (leere Antwortliste); die Antworten vor dem Löschen einzeln
  laden und entfernen (überflüssig); `AntwortenProThema` mit `Join` oder `GroupBy` auf den
  Antworten statt auf den Themen: Themen ohne Antworten fehlen dann (Test mit `Leer`);
  die Antworten aller Themen laden und in C# zählen (richtig, aber unnötig teuer).
- Die Kaskade ist für einen nicht-nullbaren Fremdschlüssel schon die Konvention; die ausdrückliche
  Konfiguration macht die Absicht sichtbar und ist Übung der Fluent API.
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner.
