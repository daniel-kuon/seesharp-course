# Rubrik: finally, erneutes Werfen und Verpacken (nur für die Betreuung)

- **Kernidee:** `finally` läuft auf jedem Weg aus dem `try`: normal, per
  `return`, per Ausnahme. Deshalb steht dort die Aufräumarbeit (hier: "ende").
  Wer "ende" ans Ende der Methode schreibt, verpasst den Fehlerfall; wer es in
  `try` und `catch` doppelt schreibt, besteht den Test mit genau einem "ende"
  nicht.
- Ausnahmefilter: `catch (IOException ex) when (…)` fängt nur, wenn die
  Bedingung stimmt; sonst bleibt die Ausnahme für den nächsten passenden Block
  frei. Die Reihenfolge zählt: Der Block mit Filter steht **vor** dem allgemeinen
  `catch (IOException)`. Alternative ohne Filter (ein `if` im Block mit
  erneutem `throw;`) funktioniert ebenfalls; den Unterschied ansprechen
  (Der Filter entscheidet, bevor der Stapel abgebaut wird).
- `StartsWith("temporär", …)` wird in der Meldung geprüft: Wer `Contains`
  nimmt, fällt beim Test `…nur_irgendwo_temporaer_enthaelt…` durch.
- Verpacken: Ohne `ex` als zweites Argument geht die Ursache verloren. Der Test
  verlangt `Assert.Same(original, ex.InnerException)`.
- `throw;` gegen `throw ex;`: Der Stack-Trace-Test ist die Kontrolle.
  Der Test markiert die Schrittmethode mit `NoInlining`, damit ihr Eintrag
  im Stack Trace sicher erscheint. Nachfragen, wann man `throw;` und wann
  Verpacken wählt (nur weiterreichen / Kontext hinzufügen).
- Quiz Listing: A1 B1 B3 A3 M2 M3 M4. Wer B2 notiert, hat den Typ der
  Ausnahme (`InvalidOperationException` ist keine `ArgumentException`) nicht
  beachtet; wer M3 vor M2 setzt, hat vergessen, dass `finally` hinter dem `catch` läuft.
- Modellantwort: `solution/`; Vorlagen `samples/Ausnahmebehandlung/finally/Explizit`,
  `finally/Implizit` und `finally/Ausnahmenersetzung`.
