# Zusatz: Zweite Reparatur

Zusatzaufgabe: freiwillig, sie blockiert nichts. Noch eine Runde Fehlerliste
lesen, diesmal mit anderen Fehlercodes und einem Fehler, den der Compiler gar
nicht findet.

Lies im Buch **3.1.6 Programmfehler** (Seite 76): Syntaxfehler meldet der
Compiler, Logikfehler nicht.

Das Projekt `Abschied` lässt sich nicht bauen. In `Abschied.cs` stecken
**vier Compilerfehler** und **ein Logikfehler**. Baue das Projekt, lies die
Fehlerliste von oben nach unten und notiere zu jedem Fehler den Code (`CS…`)
und was er bedeutet, bevor du ihn behebst. Nach jeder Korrektur neu bauen.

Wenn das Projekt baut, soll gelten:

- `Text()` liefert `Tschüss, SeeSharp!`
- `Unterschrift()` liefert `Bis morgen!` (mit Ausrufezeichen; diesen Fehler
  findet nur der Test)
- `Main()` gibt beide Zeilen aus.

Ändere nur, was nötig ist.

Diese Tests müssen bestehen:

- `AbschiedTests.Text_liefert_Tschuess_SeeSharp`
- `AbschiedTests.Unterschrift_liefert_Bis_morgen`
