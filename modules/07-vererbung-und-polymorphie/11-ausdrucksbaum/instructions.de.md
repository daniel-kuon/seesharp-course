# Zusatz: Rechenausdrücke als Baum

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**7.9 Polymorphie** (Seite 566) und **7.10 Versiegelte Methoden und
Klassen** (Seite 570).

Der Ausdruck `(2 + 3) * 4` lässt sich als Baum speichern: ein `Mal`-Knoten
mit einem `Plus`-Knoten links und der `Zahl` 4 rechts. Jeder Knoten ist ein
`Ausdruck`; wer den Baum auswertet, ruft nur `Auswerten()` an der Wurzel auf,
und jeder Knoten erledigt seinen Teil selbst (Polymorphie plus Rekursion).
Öffne `Ausdruck.cs`:

1. `Zahl`: `Auswerten()` liefert den Wert, `Knoten` ist 1, `ToString()`
   liefert den Wert als Text (`"4"`).
2. `BinaererAusdruck` ist die gemeinsame Basis aller Operatoren mit zwei
   Operanden. `Auswerten()` wertet `Links` und `Rechts` aus und gibt beide
   Ergebnisse an `Verknuepfe` weiter; `Knoten` ist 1 plus die Knoten beider
   Seiten; `ToString()` liefert `"(links symbol rechts)"`, also z. B.
   `"((2 + 3) * 4)"`. `Auswerten()` und `Knoten` sollen in den Operatoren
   **nicht** mehr überschrieben werden können: `sealed override`.
3. `Plus`, `Minus`, `Mal`, `Geteilt` liefern nur noch ihr `Symbol` (`"+"`,
   `"-"`, `"*"`, `"/"`) und ihre `Verknuepfe`-Rechnung.
4. `Vereinfache()`: In `Ausdruck` liefert die Methode den Ausdruck selbst.
   `BinaererAusdruck` überschreibt sie: Sind beide Seiten `Zahl`en, wird der
   Knoten durch eine neue `Zahl` mit dem Ergebnis ersetzt, sonst bleibt er,
   wie er ist. `Mal` kann mehr: Ist eine Seite die Zahl 0, ist das Ergebnis
   `new Zahl(0)`; ist eine Seite die Zahl 1, ist das Ergebnis die **andere**
   Seite (dasselbe Objekt). In allen übrigen Fällen ruft `Mal` die
   Basisfassung mit `base.Vereinfache()` auf.

Diese Tests müssen bestehen:

- `AusdrueckeTests.Zahl_wertet_zu_sich_selbst_aus`
- `AusdrueckeTests.Baum_wird_rekursiv_ausgewertet`
- `AusdrueckeTests.ToString_setzt_Klammern`
- `AusdrueckeTests.Knoten_zaehlt_alle_Knoten`
- `AusdrueckeTests.Auswerten_und_Knoten_sind_in_BinaererAusdruck_versiegelt`
- `AusdrueckeTests.Vereinfache_faltet_Konstanten`
- `AusdrueckeTests.Mal_vereinfacht_mit_0_und_1`
