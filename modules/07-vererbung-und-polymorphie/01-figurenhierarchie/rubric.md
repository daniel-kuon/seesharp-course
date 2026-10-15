# Rubrik — Figurenhierarchie (nur für die Betreuung)

- Ohne `: base(x, y)` kompiliert der Code (Figur hat einen parameterlosen
  Konstruktor), aber die Position bleibt 100/100. Der zweite Test fängt das;
  Gelegenheit, die Initialisierungssequenz (7.4.2) zu besprechen.
- `protected` statt `private`: Warum kommt `Kreis` sonst nicht an `xpos`?
  Warum nicht einfach `public`?
- `is Kreis k` gegen `(Kreis)e` mit vorherigem `is`: Musterdeklaration ist
  die erwartete Form.
- Bonus: Das Buch-Beispiel `Rechteck` hat in der Validierung einen Tippfehler
  (`breite >= 0.0` statt `b >= 0.0`); wer ihn beim Abtippen übernimmt, lernt
  etwas über Tests.

Modellantwort: `solution/`; Vorlagen in
`samples/Vererbung und Polymorphie/Figuren` und `Basisklassenreferenzen`.
