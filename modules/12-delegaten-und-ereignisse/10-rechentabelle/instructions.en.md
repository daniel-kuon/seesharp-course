# Extra: Calculation Table

See section **10.1.2**, **“Creating and Calling Delegate Objects”** (page 660). The predefined `Func<double, double, double>` is used as the delegate type here.

The `Rechentabelle` class manages named arithmetic operations in a `Dictionary<string, Func<double, double, double>>`:

1. `Registriere(name, operation)` registers the operation (an existing name is overwritten).
2. `Berechne(name, a, b)` calls the operation; if the name is unknown, it returns `double.NaN`.
3. `Tabelle(name, von, bis)` returns the grid `double[,]` with `bis - von + 1` rows and columns; cell `[i, j]` contains `operation(von + i, von + j)` (like a multiplication table). If `bis < von`, the grid is empty (0 x 0); if the name is unknown, every cell is `NaN`.

Tests: `Berechne_ruft_die_registrierte_Operation_auf`, `Unbekannter_Name_liefert_NaN`, `Registriere_ueberschreibt`, `Tabelle_ist_ein_Einmaleins`, `Tabelle_mit_Subtraktion`, `Tabelle_mit_leerem_Bereich`, `Tabelle_mit_unbekanntem_Namen`.
