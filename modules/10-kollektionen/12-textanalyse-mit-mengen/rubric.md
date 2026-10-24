# Rubrik: Zusatz Textanalyse mit Mengen (nur für die Betreuung)

- **Kernidee:** Zwei Texte werden über ihre Wortmengen verglichen. Die
  Mengenoperationen ersetzen Schleifen mit `Contains`: Schnitt (`IntersectWith`),
  Differenz (`ExceptWith`), Vereinigung (`UnionWith`). Wer die Operationen auf
  `a` direkt anwendet, verändert das Argument (Test `Die_Eingabemengen_bleiben_
  unveraendert`); richtig ist die Kopie `new HashSet<string>(a)`.
- `Aehnlichkeit`: Häufiger Fehler ist die ganzzahlige Division
  `schnitt.Count / vereinigung.Count` (immer 0 oder 1). Ein Cast auf `double`
  vor der Division behebt es. Zwei leere Mengen: Division durch null liefert bei
  `double` NaN; der Test verlangt 0.
- Sortiert wird mit `List<string>.Sort()`; die Menge selbst hat keine
  Reihenfolge. Die Tests nutzen nur Wörter, deren Reihenfolge nicht von der
  Kultureinstellung abhängt.
- Modellantwort: `solution/`.
