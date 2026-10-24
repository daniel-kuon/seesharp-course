# Rubrik: Die richtige Kollektion; schreibgeschützt und unveränderlich (nur für die Betreuung)

- **Kernidee:** Schreibgeschützt ist nicht unveränderlich. `AsReadOnly()` und
  `IReadOnlyList<T>` sperren nur den **Empfänger**; der Besitzer ändert weiter,
  und die Sicht zeigt es. `ImmutableList<T>` kann **niemand** ändern;
  "Änderungen" liefern eine neue Liste, und ein Schnappschuss bleibt für immer
  gültig (thread-sicher ohne Sperren).
- Typischer Fehler: `Teilnehmer => teilnehmer;` (implizite Umwandlung in
  `IReadOnlyList<string>`). Das kompiliert, versagt aber im Test
  `Teilnehmer_gibt_nicht_die_List_selbst_heraus`. Frage: Was kann ein
  böswilliger Aufrufer tun? (`(List<string>)kurs.Teilnehmer` und dann `Add`.)
- Quiz: Aussage 1 ist falsch (die Einfügereihenfolge ist nicht Sortierung);
  die anderen vier stimmen. Bei den Szenarien auf Begründung bestehen:
  "Warum nicht `List<T>` für die Warteschlange?" (`RemoveAt(0)` verschiebt
  alle Elemente.)
- Offene Frage Monate: Eine feste Zahl von zwölf Einträgen, die sich nie
  ändert, spricht für ein Array (speichereffizient, fester Umfang, Indexzugriff).
  Eine `List<T>` ist ebenfalls vertretbar, wenn danach gefiltert oder
  erweitert würde; gute Antworten nennen "feste Größe" und "Indexzugriff".
- Modellantwort: `solution/`; das Beispiel `samples/Kollektionen/
  ImmutableList-Performance` ist eine Zeitmessung und wurde nur für die API
  übernommen.
