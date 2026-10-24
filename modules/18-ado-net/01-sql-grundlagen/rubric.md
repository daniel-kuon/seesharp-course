# Rubrik: SQL-Grundlagen mit SQLite (nur für die Betreuung)

- **Kernidee:** SQL beschreibt *was* man haben will, nicht *wie*. Die
  Einschränkungen (`PRIMARY KEY`, `UNIQUE`, `NOT NULL`, `CHECK`, `REFERENCES`)
  gehören in die Datenbank, nicht nur in den C#-Code: Die Datenbank bleibt auch
  dann konsistent, wenn ein anderes Programm sie benutzt.
- Fremdschlüssel sind in SQLite je Verbindung abschaltbar
  (`PRAGMA foreign_keys`). Die Tests schalten sie ein; in der Musterlösung steht
  die Deklaration `REFERENCES Kategorie (Id)`. Wer die Spalte nur als `INTEGER`
  anlegt, besteht den Test auf unbekannte Kategorien nicht.
- Typische Fehler:
  - `HAVING` in `WHERE` geschrieben (Syntaxfehler, Aggregat in `WHERE`);
  - `JOIN` ohne `ON` (kartesisches Produkt, Test auf die Zeilenzahl schlägt fehl);
  - `GROUP BY` nur nach dem Namen statt nach dem Schlüssel (hier gleichwertig, im
    Gespräch fragen, wann es das nicht wäre: zwei Kategorien mit gleichem Namen);
  - `UPDATE` ohne `WHERE` (alle Preise steigen; der Test prüft Hammer und Locher);
  - `DELETE` ohne `NOT EXISTS`-Bedingung (löscht alle Kategorien; SQLite verweigert
    das wegen der Fremdschlüssel erst, wenn Artikel darauf zeigen).
- `NOT IN (SELECT KategorieId FROM Artikel)` statt `NOT EXISTS` ist hier ebenfalls
  richtig, aber riskant: Enthält die Unterabfrage ein `NULL`, ist das Ergebnis leer.
  Gute Gesprächsfrage zur dreiwertigen Logik von SQL.
- Dialekt: Das Buch zeigt T-SQL (`TOP`, `IDENTITY`). Lass die Unterschiede aus der
  Tabelle in der Aufgabe in eigenen Worten wiedergeben.
- Quizfrage: `WHERE` filtert Zeilen vor dem Gruppieren, `HAVING` Gruppen danach.
- Modellantwort: `solution/`; keine Vorlage im `samples`-Ordner (dort benötigen
  alle Beispiele einen SQL Server).
