# Rubrik: SQL-Grundlagen mit SQLite (nur für die Betreuung)

- **Kernidee:** SQL beschreibt *was* man haben will, nicht *wie*. Die
  Einschränkungen (`PRIMARY KEY`, `NOT NULL`, `CHECK`, `REFERENCES`)
  gehören in die Datenbank, nicht nur in den C#-Code: Die Datenbank bleibt auch
  dann konsistent, wenn ein anderes Programm sie benutzt.
- Fremdschlüssel sind in SQLite je Verbindung abschaltbar
  (`PRAGMA foreign_keys`). Die Tests schalten sie ein; in der Musterlösung steht
  die Deklaration `REFERENCES Kategorie (Id)`. Wer die Spalte nur als `INTEGER`
  anlegt, besteht den Test auf unbekannte Kategorien nicht.
- Pflicht sind die zehn Tests in `requiredTests` (Buchstoff). Typische Fehler:
  - `JOIN` ohne `ON` (kartesisches Produkt, Test auf die Zeilenzahl schlägt fehl);
  - `GROUP BY` nur nach dem Namen statt nach dem Schlüssel (hier gleichwertig, im
    Gespräch fragen, wann es das nicht wäre: zwei Kategorien mit gleichem Namen);
  - `UPDATE` ohne `WHERE` (alle Preise steigen; der Test prüft Hammer und Locher).
- Dialekt: Das Buch zeigt T-SQL (`IDENTITY`, `NVARCHAR`). Lass die Unterschiede aus der
  Tabelle in der Aufgabe in eigenen Worten wiedergeben.
- Quizfrage: `WHERE` wählt die Zeilen vor dem Gruppieren aus, `GROUP BY` bildet die
  Gruppen, `COUNT(*)` zählt je Gruppe; ohne `GROUP BY` zählt es die ganze Tabelle.
- **Bonus (Deep Dive)**, nicht im Buch, nie verlangt:
  - `UNIQUE` am Kategorienamen;
  - `KategorienMitMehrerenArtikeln` mit `HAVING` (typischer Fehler: die Bedingung in
    `WHERE` schreiben, Syntaxfehler wegen des Aggregats); im Gespräch: `WHERE` filtert
    Zeilen vor dem Gruppieren, `HAVING` Gruppen danach;
  - Unterabfrage statt der festen Id 2 in `Preiserhoehung`;
  - `LoescheLeereKategorien` mit `NOT EXISTS` (typischer Fehler: `DELETE` ohne
    Bedingung löscht alle Kategorien; SQLite verweigert das wegen der Fremdschlüssel
    erst, wenn Artikel darauf zeigen). `NOT IN (SELECT KategorieId FROM Artikel)` ist
    hier ebenfalls richtig, aber riskant: Enthält die Unterabfrage ein `NULL`, ist das
    Ergebnis leer. Gute Gesprächsfrage zur dreiwertigen Logik von SQL.
- Modellantwort: `solution/` (löst auch die Deep-Dive-Teile); keine Vorlage im
  `samples`-Ordner (dort benötigen alle Beispiele einen SQL Server).
