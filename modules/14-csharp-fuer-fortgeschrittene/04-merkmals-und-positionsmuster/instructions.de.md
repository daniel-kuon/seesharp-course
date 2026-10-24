# Merkmals-, Positions- und var-Muster

Lies im Buch **15.2.4 Merkmalsmuster** (Seite 976), **15.2.5 var-Muster**
(Seite 978) und **15.2.7 Positions- bzw. Dekonstruktionsmuster**
(Seite 981). Die Übungsaufgabe 3 in 15.7 (Seite 1012) ist `Zugelassen`.

Öffne `Muster.cs`. Die Records stehen in `Modell.cs`; für jeden Record
erzeugt der Compiler auch `Deconstruct`, das Positionsmuster brauchen.

1. `Zugelassen(PKW? p)`: Ein PKW ist zugelassen mit mindestens drei
   Passagieren **oder** als Elektroauto. Ein Merkmalsmuster, kombiniert mit
   `or`; für `null` kommt `false` heraus.
2. `Gebuehr(Fahrzeug f, int jahr)`: Ein `switch`-Ausdruck mit verschachtelten
   Merkmalsmustern. In dieser Reihenfolge: Halter aus Deutschland **und**
   Elektro kostet 0; Halter aus Deutschland, Fahrzeug über 20 Jahre alt
   (`jahr - Baujahr > 20`, per `when`) kostet 40; Halter aus Deutschland 20;
   alles andere, auch ohne Halter, 50. Das erweiterte Merkmalsmuster
   `{ Halter.Land: "DE" }` spart die geschachtelten Klammern.
3. `Quadrant(Punkt p)`: Positionsmuster auf den Record: `(0, 0)` ist
   `"Ursprung"`, dann `"I"` bis `"IV"` mit Relationsmustern, auf einer Achse
   `"Achse"`.
4. `Beschreibe(Punkt p)`: Mit `(var x, var y) when x == y` fängst du die
   Koordinaten und prüfst sie: `"Diagonale 3"`, sonst `"(2|5)"`.
5. `AufYAchse(Punkt? p)`: `p is { X: 0 }`.

Diese Tests müssen bestehen:

- `MusterTests.Zugelassen_bei_drei_Passagieren_oder_Elektro`
- `MusterTests.Zugelassen_null_ist_false`
- `MusterTests.Gebuehr_Elektro_aus_Deutschland_ist_frei`
- `MusterTests.Gebuehr_Deutschland_kostet_20_und_ab_ueber_20_Jahren_40`
- `MusterTests.Gebuehr_andere_Laender_und_fehlender_Halter_kosten_50`
- `MusterTests.Quadrant_nach_Positionsmuster`
- `MusterTests.Beschreibe_erkennt_die_Diagonale_mit_var_Muster`
- `MusterTests.AufYAchse_behandelt_null`
