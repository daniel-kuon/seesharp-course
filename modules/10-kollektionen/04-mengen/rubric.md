# Rubrik: Mengen mit HashSet<T> (nur für die Betreuung)

- **Kernidee:** Eine Menge beantwortet "ist das Element schon da?" in
  praktisch konstanter Zeit, weil sie Elemente über ihren Hashwert findet.
  Das funktioniert nur, wenn `Equals()` und `GetHashCode()` zusammenpassen:
  Was gleich ist, muss denselben Hashwert haben. Ohne Überschreibung gilt
  Referenzgleichheit, und `new Punkt(1, 2)` ist nie "dasselbe" wie ein
  zweiter.
- Häufiger Fehler bei den Mengenoperationen: `UnionWith` direkt auf `a`
  anwenden und damit das Argument verändern (der Test "…veraendern_die_
  Argumente_nicht" fängt das). Richtig ist die Kopie `new HashSet<string>(a)`.
- `Equals`: `obj is Punkt p && …` erledigt `null` und fremde Typen in einem
  Zug. Wer `(Punkt)obj` castet, erhält eine `InvalidCastException`.
- `GetHashCode`: `X ^ Y` funktioniert, ist aber schlecht ((1,2) und (2,1)
  kollidieren); `HashCode.Combine` ist besser. Nachfragen, warum veränderliche
  Felder als Grundlage für den Hashwert riskant sind (ein Punkt, der sich
  nach dem Einfügen ändert, wird nicht mehr gefunden).
- `ContainsAllListe`/`ContainsAllMenge`: Der Zeitgewinn (O(n·m) gegen
  O(n+m)) wird nicht getestet, sondern im Gespräch erklärt. Das Beispiel
  `ListSetContains` aus dem Buch misst die Zeit; hier geht es nur um
  Gleichwertigkeit.
- Modellantwort: `solution/`; Vorlage `samples/Kollektionen/HashSetDemo` und
  `ListSetContains`.
