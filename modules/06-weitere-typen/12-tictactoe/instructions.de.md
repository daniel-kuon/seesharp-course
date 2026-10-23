# Zusatzaufgabe: Tic-Tac-Toe mit 2D-Array und Enums

Diese Aufgabe ist freiwillig. Sie verbindet ein zweidimensionales Array mit
Aufzählungstypen. Zum Nachlesen: **6.2.9 Mehrdimensionale Arrays**
(Seite 467) und **6.4 Aufzählungstypen** (Seite 480).

Das Spielfeld ist ein `Feld[3, 3]`; jedes Feld ist `Leer`, `X` oder `O`.
`X` beginnt, dann wird abgewechselt. `AusText` ist fertig und baut für die
Tests ein Feld aus drei Zeilen wie `"XO."` (Punkt = leer).

Öffne `Spielfeld.cs` und vervollständige:

1. Den nur lesenden Indexer `this[int z, int s]`.
2. `AmZug`: Zähle mit zwei verschachtelten Schleifen die X und O. Stehen
   gleich viele, ist X am Zug, sonst O. Es gibt kein eigenes Feld dafür;
   der Spieler am Zug ergibt sich aus dem Spielfeld.
3. `Setze(z, s)`: setzt das Zeichen des Spielers am Zug und liefert `true`.
   Liegt die Position außerhalb (`GetLength`), ist das Feld belegt oder das
   Spiel schon entschieden, passiert nichts und die Methode liefert `false`.
4. `Gewinner()`: Prüfe alle drei Zeilen, alle drei Spalten und beide
   Diagonalen. Gehören alle drei Felder einer Reihe demselben Spieler (und
   sind nicht leer), ist er der Gewinner. Sonst `Feld.Leer`.
5. `Spielstand()`: Bilde den Gewinner mit einem `switch`-Ausdruck auf
   `Status.GewonnenX` bzw. `Status.GewonnenO` ab. Ohne Gewinner ist das
   Spiel `Unentschieden`, wenn kein Feld mehr leer ist (`foreach` läuft auch
   über ein 2D-Array), sonst `Laeuft`.

Diese Tests müssen bestehen:

- `SpielfeldTests.Neues_Spielfeld_ist_leer_und_X_beginnt`
- `SpielfeldTests.Indexer_liest_Zeile_und_Spalte`
- `SpielfeldTests.Setze_wechselt_die_Spieler_ab`
- `SpielfeldTests.Setze_lehnt_belegte_Felder_und_ungueltige_Positionen_ab`
- `SpielfeldTests.Gewinner_in_Zeile_Spalte_und_Diagonale` (sechs Fälle)
- `SpielfeldTests.O_kann_auch_gewinnen`
- `SpielfeldTests.Kein_Gewinner_bei_gemischten_Reihen`
- `SpielfeldTests.Volles_Feld_ohne_Gewinner_ist_unentschieden`
- `SpielfeldTests.Nach_dem_Sieg_ist_kein_Zug_mehr_erlaubt`
