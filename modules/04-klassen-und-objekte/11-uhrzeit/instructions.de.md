# Zusatzaufgabe: Uhrzeit mit Überladung und Operatoren

Diese Aufgabe ist freiwillig. Sie übt Methodenüberladung und Operatoren an
einer Klasse, die nichts mit Brüchen zu tun hat. Zum Nachlesen: **5.3.5
Methoden überladen** (Seite 334) und **5.9.3 Operatoren überladen**
(Seite 385).

Die Klasse `Uhrzeit` speichert nur **ein** privates Feld: die Minuten seit
Mitternacht, immer zwischen 0 und 1439. Stunde und Minute werden daraus
berechnet. So kann der Zustand nie ungültig werden.

Öffne `Uhrzeit.cs` und vervollständige:

1. `Normiere(m)`: bringt jede Minutenzahl in den Bereich 0 bis 1439. Achtung:
   In C# ist `-1 % 1440` gleich `-1`; ein negativer Rest braucht noch
   `1440` dazu.
2. Beide Konstruktoren normieren: `new Uhrzeit(25, 70)` ist 02:10,
   `new Uhrzeit(-1, 0)` ist 23:00, `new Uhrzeit(1500)` ist 01:00.
3. `Stunde` und `Minute` berechnen ihren Wert aus dem Feld (Ganzzahldivision
   und Rest).
4. Zwei Überladungen von `Addiere`: mit Minuten und mit Stunden und Minuten.
   Die zweite ruft die erste auf.
5. `Text()` liefert `"07:05"`. Tipp: `$"{Stunde:D2}"` füllt mit Nullen auf
   (nicht im Buch, hier vorgegeben).
6. `operator +(Uhrzeit, int)` liefert eine **neue** Uhrzeit; das Original
   bleibt unverändert.
7. `operator -(Uhrzeit a, Uhrzeit b)` liefert, wie viele Minuten von `b` bis
   `a` vergehen, vorwärts gezählt: von 22:45 bis 01:15 sind es 150.

Diese Tests müssen bestehen:

- `UhrzeitTests.Konstruktor_mit_gueltigen_Werten`
- `UhrzeitTests.Konstruktor_normiert_Ueberlauf`
- `UhrzeitTests.Konstruktor_normiert_negative_Werte`
- `UhrzeitTests.Konstruktor_aus_Minuten_seit_Mitternacht`
- `UhrzeitTests.Text_mit_fuehrenden_Nullen`
- `UhrzeitTests.Addiere_Minuten_ueber_Mitternacht`
- `UhrzeitTests.Addiere_negative_Minuten`
- `UhrzeitTests.Addiere_Stunden_und_Minuten`
- `UhrzeitTests.Plus_liefert_neues_Objekt_und_laesst_das_Original_in_Ruhe`
- `UhrzeitTests.Minus_liefert_Minuten_vorwaerts_auch_ueber_Mitternacht`
