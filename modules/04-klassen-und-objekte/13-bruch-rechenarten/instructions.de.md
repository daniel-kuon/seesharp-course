# Zusatzaufgabe: Bruch mit allen Grundrechenarten

Diese Aufgabe ist freiwillig. Sie baut auf **Operatoren überladen** auf;
lies bei Bedarf noch einmal **5.9.3 Operatoren überladen** (Seite 385).

Öffne `Bruch.cs`. Diese `Bruch`-Fassung kürzt sich schon im Konstruktor und
hält den Nenner immer positiv (`2/-4` wird zu `-1/2`). `operator +` ist als
Beispiel fertig. Alle Operatoren liefern **neue** Brüche; die Operanden
bleiben unverändert.

1. Den **unären** Operator `-` (ein Parameter): `-(3/4)` ist `-3/4`.
2. Den binären Operator `-`. Tipp: `b1 - b2` ist `b1 + (-b2)`.
3. Den Operator `*`: Zähler mal Zähler, Nenner mal Nenner.
4. `Kehrwert()`: `3/4` wird `4/3`, `-2/5` wird `-5/2`. Ein Bruch mit Zähler 0
   hat keinen Kehrwert; dann liefert die Methode `null`. Der Rückgabetyp
   `Bruch?` sagt genau das.
5. Den Operator `/`: `b1` mal Kehrwert von `b2`. Ist `b2` gleich 0, liefert
   er `null`.
6. `Vergleiche(b)`: -1, wenn dieser Bruch kleiner ist als `b`, 0 bei
   gleichem Wert, sonst 1. Tipp: `a/b < c/d` genau dann, wenn `a·d < c·b`,
   weil beide Nenner positiv sind.

Diese Tests müssen bestehen:

- `BruchTests.Vorzeichenwechsel_liefert_neuen_Bruch`
- `BruchTests.Subtraktion_kuerzt_und_laesst_Operanden_unveraendert`
- `BruchTests.Multiplikation_kuerzt`
- `BruchTests.Kehrwert_vertauscht_und_behaelt_das_Vorzeichen_im_Zaehler`
- `BruchTests.Kehrwert_von_null_ist_null`
- `BruchTests.Division_multipliziert_mit_dem_Kehrwert`
- `BruchTests.Division_durch_null_liefert_null`
- `BruchTests.Vergleiche_liefert_minus_eins_null_oder_eins`
