# Extra exercise: Tic-Tac-Toe using a 2D array and enums

This exercise is optional. It combines a two-dimensional array with enumeration types. For further reading: **6.2.9 Multidimensional Arrays** (page 467) and **6.4 Enumeration Types** (page 480).

The game board is a `Feld[3, 3]` grid; each cell is either `Leer`, `X`, or `O`. `X` goes first, then the players take turns. `AusText` is complete; for the tests it builds a board from three rows such as `"XO."` (a period represents an empty cell).

Open *`Spielfeld.cs`* and complete the following:

1. The read-only indexer `this[int z, int s]`.
2. `AmZug`: Count the Xs and Os using two nested loops. If there are an equal number, it's X's turn; otherwise, it's O's turn. There is no separate field for this; the player whose turn it is is determined by the game board.
3. `Setze(z, s)`: Places the mark of the player whose turn it is and returns `true`. If the position is outside the board (`GetLength`), the square is occupied, or the game has already been decided, nothing happens and the method returns `false`.
4. `Gewinner()`: Check all three rows, all three columns, and both diagonals. If all three cells in a row belong to the same player (and are not empty), that player is the winner. Otherwise, return `Feld.Leer`.
5. `Spielstand()`: Map the winner to `Status.GewonnenX` or `Status.GewonnenO` with a `switch` expression. If there is no winner, the game is `Unentschieden` when there are no more empty squares (`foreach` also iterates over a 2D array); otherwise, it is `Laeuft`.

The following tests must be passed:

- `SpielfeldTests.Neues_Spielfeld_ist_leer_und_X_beginnt`
- `SpielfeldTests.Indexer_liest_Zeile_und_Spalte`
- `SpielfeldTests.Setze_wechselt_die_Spieler_ab`
- `SpielfeldTests.Setze_lehnt_belegte_Felder_und_ungueltige_Positionen_ab`
- `SpielfeldTests.Gewinner_in_Zeile_Spalte_und_Diagonale` (six cases)
- `SpielfeldTests.O_kann_auch_gewinnen`
- `SpielfeldTests.Kein_Gewinner_bei_gemischten_Reihen`
- `SpielfeldTests.Volles_Feld_ohne_Gewinner_ist_unentschieden`
- `SpielfeldTests.Nach_dem_Sieg_ist_kein_Zug_mehr_erlaubt`
