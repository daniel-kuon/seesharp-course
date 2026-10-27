# Rubrik — Tupel- und Listenmuster; Mautrechner (nur für die Betreuung)

- Kern: Ein Tupel hinter `switch` macht aus mehreren Eingaben ein Muster
  (`(a, b) switch`); Listenmuster beschreiben Arrays nach Form und Inhalt
  (`[1, .., 9]`, `[_, _, .. var rest]`). Im Mautrechner kommen alle Mustersorten
  zusammen; das ist die Prüfung, ob der Trainee die Arten unterscheiden kann.
- Fehlerquellen: Reihenfolge der Listenmuster (`[_, _]` vor `[_, _, ..]`;
  `[1, .., 9]` muss vor `[_, _]` stehen, sonst wird `[1, 9]` als "zwei
  Elemente" beschrieben); Grenzwerte bei Bus (genau 50 % und 90 % gehören zu
  "sonst"); der erschöpfende `switch` bei `ZeitZuschlag` (auch wenn alle vier
  Zeitbänder mit `true`/`false` abgedeckt sind, warnt der Compiler mit CS8524,
  weil eine Enum-Variable auch unbenannte Werte wie `(Zeitband)4` enthalten
  kann; ein letzter `_`-Arm beseitigt die Warnung und ist erlaubt).
- Negative Personenzahl bei `Auto`/`Taxi` muss `ArgumentException` werfen
  (Test `FahrzeugZuschlag_Fehlerfaelle`): Ein Auffangarm `Auto => -1.00m` wie
  im Buchbeispiel (Seite 972) besteht den Test nicht, `Auto { Passagiere: > 2 }`
  schon.
- `Sieger` darf nicht in drei verschachtelten `if`s stecken: genau ein
  `switch`-Ausdruck mit einem Tupel ist das Lernziel.
- Decimal statt double: Geldbeträge in `decimal`, die Tests vergleichen exakt.
- Nachfragen: Wie unterscheiden sich Positionsmuster und Tupelmuster? (Das
  Tupelmuster baut das Tupel erst aus Einzelwerten; das Positionsmuster ruft
  `Deconstruct` eines vorhandenen Typs auf.)
- Die Zeiten und Preise sind frei gewählt und folgen nur dem Aufbau des
  bekannten Microsoft-Mautbeispiels.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Musterabgleich/{Tupelmuster,Listenmuster,TollCalculator}`.
