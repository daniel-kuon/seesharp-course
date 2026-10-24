# Rubrik — Zusatz Mini-Testläufer (nur für die Betreuung)

- Kern: Das Zusammenspiel aus Attribut (Markierung), Reflexion (Suchen,
  Instanziieren, Aufrufen) und Ausnahmebehandlung. Die Ausnahme des
  aufgerufenen Tests kommt als `TargetInvocationException` an, die
  eigentliche Ursache steckt in `InnerException`; für das Ergebnis
  `bestanden = false` reicht das Fangen.
- Wer `catch (Exception)` schreibt, besteht ebenfalls; dann fragen, ob auch
  Fehler beim Aufruf selbst (z. B. falsche Parameter) als "Test nicht
  bestanden" gelten sollen. Besser: nur `TargetInvocationException` fangen.
- Gesprächsanlass: Warum erzeugt xunit pro Test eine neue Instanz, dieser
  Läufer aber nur eine? (Unabhängigkeit der Tests; hier wird die
  gemeinsame Instanz zur Absicherung der Reihenfolge benutzt.) Die
  Sortierung nach Namen macht die Ausführung deterministisch; echte Läufer
  garantieren gerade keine feste Reihenfolge.
- Die Tests der Aufgabe prüfen auch, dass Methoden mit Parametern, statische
  und nicht öffentliche Methoden nicht laufen (sie würden die Fixture
  absichtlich scheitern lassen).

Modellantwort: `solution/`.
