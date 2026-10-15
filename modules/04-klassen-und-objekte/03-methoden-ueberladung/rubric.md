# Rubrik — Methoden überladen (nur für die Betreuung)

- Was gehört zur Signatur (Name und Parameterliste), was nicht (Rückgabetyp,
  Parameternamen)? Frage: Könnte man eine dritte Überladung
  `int Addiere(Bruch b)` hinzufügen? (Nein.)
- `Addiere(int, int, bool)`: Bei `npar == 0` darf das Objekt nicht verändert
  werden — der Test `…_aendert_nichts` prüft das. Prüfung vor der Rechnung.
- Die `bool`-Rückgabe als Erfolgsmeldung: In Level 11 wird das durch
  Ausnahmen ersetzt; hier reicht die Beobachtung, dass der Aufrufer das
  Ergebnis auswerten muss.

Modellantwort: `samples/Klassen und Objekte/Bruch/b1 Methoden-Überladung` im
Tool-Repository.
