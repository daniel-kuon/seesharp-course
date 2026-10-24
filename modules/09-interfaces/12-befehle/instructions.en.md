# Extra: Commands with Undo and Redo

Extra exercise: optional; it unlocks nothing. For further reading: **9.2 Implementing Interfaces** (page 640) and **9.3 Interfaces as Reference Data Types** (page 644).

Every editor supports "Undo" and "Redo." A proven approach: Every action is an object that can execute **and** undo itself. The `IBefehl` interface describes this capability; the Rechner only knows the interface and never the specific commands. New commands can thus be added without modifying the `Rechner`. Open `Befehle.cs`; the `Addiere` command is already implemented as an example:

1. `Multipliziere(faktor)`: The `Name` is, for example, `"Multipliziere 3"`. A factor of 0 cannot be undone and therefore throws an `ArgumentOutOfRangeException` in the constructor. Undoing the operation divides by the factor.
2. `Negiere`: `Name` is `"Negiere"`; Execute and Undo flip the sign.
3. `Makro(params IBefehl[] befehle)` combines multiple commands into one and is itself an `IBefehl` (so a macro can also contain macros). Execute applies the commands in sequence; Undo reverses them in **reverse** order. `Name`: `"Makro(Addiere 2, Multipliziere 3)"`.
4. `Rechner`: `Ausfuehren(befehl)` applies the command to `Wert` and stores it in the history (`verlauf` is an array with an index, like a stack). `Rueckgaengig()` retrieves the last executed command and places it on the `zurueckgenommen` stack; `Wiederholen()` re-executes the last undone command. Both return `false` if there is nothing to do. A new command via `Ausfuehren` clears the `zurueckgenommen` stack. `Protokoll()` returns the names in the history, joined by `", "` (`string.Join`).

The following tests must be passed:

- `BefehleTests.Alle_Befehle_sind_IBefehle`
- `BefehleTests.Ausfuehren_und_Rueckgaengig_heben_sich_auf`
- `BefehleTests.Multipliziere_mit_0_wirft`
- `BefehleTests.Makro_fuehrt_der_Reihe_nach_aus_und_rueckwaerts_zurueck`
- `BefehleTests.Rechner_fuehrt_aus_und_protokolliert`
- `BefehleTests.Rueckgaengig_nimmt_den_letzten_Befehl_zurueck`
- `BefehleTests.Wiederholen_nach_Rueckgaengig`
