# Rubrik — Tupel- und Listenmuster; Mautrechner (nur für die Betreuung)

- Kern: Ein Tupel hinter `switch` macht aus mehreren Eingaben ein Muster
  (`(a, b) switch`); Listenmuster beschreiben Arrays nach Form und Inhalt
  (`[1, .., 9]`, `[_, _, .. var rest]`). Im Mautrechner kommen alle Mustersorten
  zusammen; das ist die Prüfung, ob der Trainee die Arten unterscheiden kann.
- Fehlerquellen: Reihenfolge der Listenmuster (`[_, _]` vor `[_, _, ..]`;
  `[1, .., 9]` muss vor `[_, _]` stehen, sonst wird `[1, 9]` als "zwei
  Elemente" beschrieben); Grenzwerte bei Bus (genau 50 % und 90 % gehören zu
  "sonst"); der erschöpfende `switch` bei `ZeitZuschlag` (der Compiler erkennt
  mit den drei Zeitbändern und `bool` die Vollständigkeit nicht immer; ein
  letzter `_`-Arm ist erlaubt, soll aber hinterfragt werden).
- `Sieger` darf nicht in drei verschachtelten `if`s stecken: genau ein
  `switch`-Ausdruck mit einem Tupel ist das Lernziel.
- Decimal statt double: Geldbeträge in `decimal`, die Tests vergleichen exakt.
- Nachfragen: Wie unterscheiden sich Positionsmuster und Tupelmuster? (Das
  Tupelmuster baut das Tupel erst aus Einzelwerten; das Positionsmuster ruft
  `Deconstruct` eines vorhandenen Typs auf.)
- Die Zeiten und Preise sind frei gewählt und folgen nur dem Aufbau des
  bekannten Microsoft-Mautbeispiels.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Musterabgleich/{Tupelmuster,Listenmuster,TollCalculator}`.
