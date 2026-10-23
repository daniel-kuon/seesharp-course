# Rubrik — Zusatzaufgabe Rechteck (nur für die Betreuung)

- Kernpunkt: defensive Kopien. `linksUnten = a;` lässt den Test
  `Rechteck_haengt_nicht_an_den_uebergebenen_Punkten` scheitern, ein
  Getter `return linksUnten;` den Test `Eckpunkte_werden_als_Kopie_geliefert`.
  Im Gespräch erklären lassen, warum `readonly` am Feld dagegen nicht hilft
  (es schützt die Referenz, nicht das Objekt).
- Komposition vs. Aggregation: Hier lebt der Punkt nur im Rechteck
  (Komposition). Bei der `Aufgabe` aus der Pflichtübung war es ähnlich.
- `Schnitt` greift auf `r.linksUnten` zu, obwohl das Feld privat ist:
  Schutzstufen gelten pro Klasse, nicht pro Objekt (5.13).
- Ausblick Level 6: Wäre `Punkt` eine Struktur, wären die Kopien automatisch.
  Gute Brücke zur Wertsemantik.
- `ToString` mit `double`: Die Tests verwenden nur ganze Werte, weil
  `1.5` in deutscher Kultur als `1,5` erscheint.

Modellantwort: `solution/Rechteck/Rechteck.cs`.
