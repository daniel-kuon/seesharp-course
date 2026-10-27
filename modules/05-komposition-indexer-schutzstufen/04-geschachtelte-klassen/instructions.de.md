# Geschachtelte Klassen

Lies im Buch Abschnitt **5.11 Geschachtelte Klassen** (Seite 391).

`Familie` besitzt eine `Tochter` und einen `Sohn`; beide Klassen sind
**innerhalb** von `Familie` deklariert. Der Vorteil: Sie dürfen auf das
private Feld `name` der Familie zugreifen, obwohl es privat ist. `Sohn` ist
fertig und dient als Vorlage.

Öffne `Familie.cs` und vervollständige:

1. Die geschachtelte Klasse `Tochter`: wie `Sohn`, aber **privat** (ohne
   `public`) und mit dem Text
   `"Ich bin die <alter>-jährige Tochter <name> von Familie <Familienname>."`
   Der Familienname kommt aus `f.name`, nicht aus einem eigenen Feld.
2. `Familie.Informiere()` liefert drei Zeilen, getrennt durch `\n`:
   die Überschrift `"Die Kinder von Familie <name>:"`, dann die Zeile der
   Tochter, dann die des Sohns.

Beachte die Primärkonstruktoren (`class Sohn(Familie f, string name, int alter)`):
`Sohn` übernimmt die Parameter ausdrücklich in `readonly`-Felder, damit sie nicht nur im
Konstruktor, sondern in allen Methoden verfügbar sind.
