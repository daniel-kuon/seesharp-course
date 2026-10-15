# Compilerfehler beheben

Lies im Buch Abschnitt **3.1.6 Programmfehler** (Seite 76) über Syntax-,
Laufzeit- und Logikfehler.

Das Projekt `Reparatur` lässt sich nicht bauen. In `Hallo.cs` stecken **vier
Fehler**. Baue das Projekt in Rider (`Strg+F5` oder Build > Build Solution),
lies die Fehlerliste von oben nach unten und behebe einen Fehler nach dem
anderen. Achte auf Zeile, Spalte und den Fehlercode (`CS…`); nach jeder
Korrektur neu bauen, denn manche Fehler tauchen erst auf, wenn die vorherigen
weg sind.

Am Ende soll das Programm `Moin, SeeSharp!` ausgeben und `Gruss()` diesen Text
zurückliefern. Ändere nur, was nötig ist; der Text selbst bleibt.

Diese Tests müssen bestehen:

- `ReparaturTests.Gruss_liefert_Moin_SeeSharp`
