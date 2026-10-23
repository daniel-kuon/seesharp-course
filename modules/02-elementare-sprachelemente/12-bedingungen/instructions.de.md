# Zusatz: Bedingungen als Ausdrücke

Zusatzaufgabe: freiwillig, sie blockiert nichts. Im Operatoren-Quiz hast du
Ausdrücke im Kopf ausgewertet; jetzt schreibst du selbst welche. Jede Methode
besteht aus **einer einzigen `return`-Anweisung** — `if` kommt erst in
Level 3, hier reichen `&&`, `||`, `!` und `?:`.

Lies im Buch **4.5.5 Logische Operatoren** (Seite 225), **4.5.9
Konditionaloperator** (Seite 235) und die Operatorentabelle in **4.5.10**
(Seite 236).

Öffne `Bedingungen.cs`:

1. `IstSchaltjahr(int jahr)`: Ein Jahr ist ein Schaltjahr, wenn es durch 4
   teilbar ist, aber nicht durch 100 — es sei denn, es ist durch 400 teilbar.
   2024 und 2000 sind Schaltjahre, 1900 und 2023 nicht.
2. `ImBereich(int x, int min, int max)`: `true`, wenn `min <= x <= max`.
3. `AusserhalbBereich(int x, int min, int max)`: das Gegenteil von
   `ImBereich` — schreibe es **ohne `!`**, indem du die Bedingung nach De
   Morgan umformst.
4. `Vorzeichen(int x)`: `-1` für negative Zahlen, `0` für 0, `1` für positive
   — mit zwei verschachtelten `?:`.
5. `Maximum(int a, int b, int c)`: die größte der drei Zahlen, nur mit `?:`
   (kein `Math.Max`).

Diese Tests müssen bestehen:

- `BedingungenTests.Schaltjahre`
- `BedingungenTests.Keine_Schaltjahre`
- `BedingungenTests.Im_Bereich_einschliesslich_Grenzen`
- `BedingungenTests.Ausserhalb_ist_das_Gegenteil`
- `BedingungenTests.Vorzeichen`
- `BedingungenTests.Maximum_egal_an_welcher_Stelle`
