# Tupel- und Listenmuster; Mautrechner

Lies im Buch **15.2.6 Tupelmuster** (Seite 980) und **15.2.10
Listenmuster** (Seite 985) mit **15.2.10.1 Ausschuss- und Bereichsmuster**.
Der Mautrechner ist das Abschlussbeispiel zu Musterabgleich: Er kombiniert
Tupel-, Typ-, Merkmals-, Relations- und logische Muster mit `when`.

Öffne `Spiele.cs` und `MautRechner.cs`. Die Typen stehen in `Modell.cs`.

1. `SchereSteinPapier.Sieger(a, b)`: **Ein** `switch`-Ausdruck über das Tupel
   `(a, b)`. Die drei Gewinnpaare des Ersten, `(var x, var y) when x == y`
   für unentschieden, der Rest ist der Zweite.
2. `Lauf.Langstrecke(minuten, maenner)`: Tupelmuster mit Relationsmustern in
   den Positionen und `or` zwischen den Tupelmustern für Männer und
   Frauen (Grenzen in den `TODO`-Kommentaren). Null oder weniger Minuten
   wirft `ArgumentOutOfRangeException`, als Arm des `switch`.
3. `Listen.Beschreibe(int[])`: Listenmuster `[]`, `[var x]`, `[1, .., 9]`,
   `[_, _]` und `[_, _, .. var rest]`; die Reihenfolge steht im Kommentar.
4. `MautRechner`: `Band` teilt den Tag mit Relationsmustern ein.
   `FahrzeugZuschlag` unterscheidet `Auto`, `Taxi`, `Bus` und `Lieferwagen`
   mit Typ- und Merkmalsmustern, beim `Bus` mit `when` (Beträge in den
   `TODO`-Kommentaren). `null` wirft `ArgumentNullException`; ein anderer
   Fahrzeugtyp oder eine ungültige Angabe (ein `Auto` oder `Taxi` mit
   negativer Personenzahl) wirft `ArgumentException`. `ZeitZuschlag` ist ein
   Tupelmuster über Wochentag, Zeitband und Richtung. `Berechne` addiert
   Grundgebühr und beide Zuschläge.

Diese Tests müssen bestehen:

- `TupelListeMautTests.Sieger_in_allen_neun_Faellen`
- `TupelListeMautTests.Langstrecke_unterscheidet_Geschlecht_und_Zeit`
- `TupelListeMautTests.Langstrecke_lehnt_unsinnige_Zeiten_ab`
- `TupelListeMautTests.Listenmuster_Beschreibe`
- `TupelListeMautTests.Band_teilt_den_Tag_ein`
- `TupelListeMautTests.FahrzeugZuschlag_fuer_Auto_und_Taxi`
- `TupelListeMautTests.FahrzeugZuschlag_fuer_Bus_und_Lieferwagen`
- `TupelListeMautTests.FahrzeugZuschlag_Fehlerfaelle`
- `TupelListeMautTests.ZeitZuschlag_Tabelle_mit_zwoelf_Faellen`
- `TupelListeMautTests.Berechne_addiert_Grundgebuehr_Fahrzeug_und_Zeit`
