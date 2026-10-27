# Rubrik: Zusatz Ressourcen sicher schließen (nur für die Betreuung)

- **Kernidee:** Was geöffnet wurde, muss auf jedem Weg wieder geschlossen
  werden: `finally`. Zwei verschiedene Fehlerarten werden verschieden behandelt:
  Fehler beim **Öffnen** werden zu einer fachlichen Ausnahme verpackt (mit der
  Ursache als `InnerException`), Fehler beim **Senden** laufen unverändert weiter
  (`throw;`), nur mit einer Zählung.
- Häufige Fehler: `Schliessen()` am Ende des `try` (der Fehlerfall verpasst es,
  der Test `Sendefehler_…` fällt durch); `Schliessen()` zusätzlich in jedem `catch`
  (dann zweimal bei Fehlern); `throw ex;` statt `throw;` (die Tests prüfen
  nur die Identität der Ausnahme, nicht den Stack Trace; den Unterschied
  bitte besprechen, siehe `ausnahmen-finally-und-weiterreichen`).
- Der Test verlangt, dass `Schliessen()` auch nach einem Fehler beim Öffnen
  genau einmal läuft; das ist eine Festlegung der Aufgabe (eine halb geöffnete
  Verbindung wird freigegeben), keine allgemeine Regel. Nachfragen, wann
  man darauf besser verzichtet (wenn `Oeffnen` fehlschlägt, gibt es oft nichts
  zu schließen; `using` würde das Objekt erst nach erfolgreichem Erzeugen
  freigeben; Level 15).
- Die Aufgabe erlaubt zwei verschachtelte `try`-Blöcke oder einen
  mit zwei `catch`-Blöcken und einer Statusvariablen; beides ist in Ordnung.
- Modellantwort: `solution/`.
