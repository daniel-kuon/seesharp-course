# Rubrik: Wörterbücher (nur für die Betreuung)

- **Kernidee:** Ein `Dictionary` findet zu einem Schlüssel den Wert ohne
  Durchsuchen (Hashtabelle). Das Muster "zählen" lautet: `TryGetValue`, dann
  hochzählen oder mit 1 anlegen. Das Muster "gruppieren" lautet: `TryGetValue`
  für die Liste zum Schlüssel, bei Misserfolg eine neue anlegen und
  eintragen, dann `Add`.
- Der Indexer mit fehlendem Schlüssel löst `KeyNotFoundException` aus; der
  Indexer beim **Schreiben** legt dagegen an oder überschreibt. `Add` mit einem
  vorhandenen Schlüssel löst eine `ArgumentException` aus. Teilnehmer sollen
  den Unterschied erklären können.
- `OrdinalIgnoreCase` gehört in den Konstruktor des Dictionary. Wer vor dem
  Einfügen `ToLower()` ruft und einen Standardvergleicher nimmt, besteht den
  Test `Haeufigkeiten_findet_Schluessel_in_jeder_Schreibweise` nicht.
  `Woerter()` liefert schon Kleinbuchstaben.
- `Haeufigste`: `Eintrag` ist die Hilfe, damit `Sort()` ohne Lambda auskommt
  (Delegaten folgen in Level 12). Nachfragen: Warum kann man ein
  `Dictionary` nicht direkt sortieren? (Es hat keine Reihenfolge; die Paare
  müssen erst in eine Liste.)
- Die Tests prüfen nie die Aufzählreihenfolge eines Dictionary; wer sich
  trotzdem auf sie verlässt, hat Glück gehabt, nicht richtig gearbeitet.
- Modellantwort: `solution/`; Vorlage `samples/Kollektionen/DictionaryDemo`.
