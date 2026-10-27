# Log2 mit ArgumentOutOfRangeException

Lies im Buch **13.6 Ausnahmen werfen (throw)** (Seite 913), dazu **13.1** und
**13.2** (Seite 886 und 888) zu Fehlervermeidung und unbehandelten Ausnahmen,
und danach die Übungsaufgabe **13.8 Nr. 3** (Seite 920).

Die Methode `Dualog.Log2` liefert für ungültige Argumente im Moment `NaN` oder
`-Infinity`. Solche Sonderwerte laufen unbemerkt durch das Programm und
zeigen den Fehler erst Schritte später. Öffne `Dualog.cs`:

1. `Log2(double x)` wirft für `x <= 0` eine `ArgumentOutOfRangeException`.
   Der Parametername ist `"x"`, die Meldung ist eine eigene deutsche (Konstruktor
   mit `paramName`, `actualValue` und `message`). Gültige Argumente liefern
   den Logarithmus: `Log2(1) = 0`, `Log2(8) = 3`.
2. `Wurzel(double x)` wirft für negative `x` dieselbe Ausnahme, ebenfalls mit
   Parametername `"x"` und eigener Meldung.
3. `Fakultaet(int n)` wirft für `n < 0` (Parametername `"n"`, eigene Meldung) und liefert
   sonst `n!` als `long`. Gültig ist `n` von 0 bis 20; für größere Zahlen
   passt das Ergebnis nicht mehr in ein `long`, das ist nicht Teil der Tests.

Beantworte danach die beiden Fragen. Für die erste brauchst du diesen
Stack Trace:

## Frage zum Stack Trace

```text
Unbehandelte Ausnahme: System.ArgumentOutOfRangeException: Der duale Logarithmus ist nur für Zahlen größer als 0 definiert. (Parameter 'x')
Der tatsächliche Wert war -1.
   bei Dualog.Log2(Double x) in C:\Kurs\Rechner\Dualog.cs:Zeile 9.
   bei Messung.Dezibel(Double verhaeltnis) in C:\Kurs\Rechner\Messung.cs:Zeile 14.
   bei Programm.Main() in C:\Kurs\Rechner\Programm.cs:Zeile 6.
```

Tests: `Log2_wirft_fuer_Argumente_kleiner_gleich_null`,
`Log2_hat_eine_eigene_Meldung`, `Wurzel_wirft_fuer_negative_Zahlen`,
`Wurzel_liefert_die_Quadratwurzel`,
`Fakultaet_wirft_fuer_negative_n` und die Tests für gültige Werte
(`Log2_liefert_den_Logarithmus_gueltiger_Argumente`, `Fakultaet_liefert_n_Fakultaet`).
