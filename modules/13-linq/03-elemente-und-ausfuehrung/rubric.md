# Rubrik — Quantoren, Elemente, verzögerte Ausführung (nur für die Betreuung)

- Kernidee: Eine LINQ-Abfrage ist ein **Rezept**, kein Ergebnis. Jede
  Aufzählung führt das Rezept neu aus (Quelle wird erneut gelesen,
  Seiteneffekte wiederholen sich, Änderungen an der Quelle werden sichtbar).
- `ZweimalNutzen`: Die Abfrage steht in einer Variablen und wird von `Sum`
  und `Count` je einmal aufgezählt; der Test zählt die Protokolleinträge der
  Quelle (4 statt 8). Lösung: `ToList()` direkt bei der Variablen.
- Typische Fehler: `GeradeZahlen` mit `.ToList()` zurückgeben (Test erwartet
  ein leeres Protokoll nach dem Bauen), `GrosseWerteJetzt` ohne `ToList()`.
- `Single` versus `First`; `ElementAt` wirft `ArgumentOutOfRangeException`,
  `Last` bei leerer Folge `InvalidOperationException`; `...OrDefault` ist die
  ausnahmefreie Alternative. Ausnahmen als Ablaufsteuerung (`EindeutigerTrefferText`)
  sind hier Übungszweck; im Alltag nimmt man `SingleOrDefault` plus Prüfung.
- `All` auf leerer Folge ist `true`, `Any` ist `false`: gemeinsam besprechen.

Modellantwort: `solution/`.
