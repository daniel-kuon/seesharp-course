# Zusatzaufgabe: Ein Rechteck besitzt seine Punkte

Diese Aufgabe ist freiwillig. Sie vertieft Komposition: Ein Objekt besitzt
andere Objekte und schützt sie vor fremdem Zugriff. Zum Nachlesen: **5.10
Aggregation bzw. Komposition** (Seite 388).

`Punkt` ist fertig. Ein `Rechteck` (achsenparallel) besteht aus zwei
`Punkt`-Objekten: links unten und rechts oben. Weil `Punkt` eine Klasse ist,
also ein Referenztyp, muss das Rechteck aufpassen: Würde es die übergebenen
Punkte einfach speichern, könnte der Aufrufer das Rechteck später über seine
eigene Referenz verbiegen.

Öffne `Rechteck.cs` und vervollständige:

1. Der Konstruktor bekommt zwei **beliebige** gegenüberliegende Ecken und
   legt **eigene** Punkte an: links unten mit den kleineren Koordinaten,
   rechts oben mit den größeren. `Math.Min(a, b)` liefert die kleinere,
   `Math.Max(a, b)` die größere von zwei Zahlen (nicht im Buch, hier
   vorgegeben; ein `?:` aus Level 2 tut es auch).
2. `LinksUnten` und `RechtsOben` liefern **Kopien** (`Klone()`), damit auch
   der Getter keine Hintertür öffnet.
3. `Breite`, `Hoehe`, `Flaeche`, `Umfang` sind berechnete Eigenschaften.
4. `Enthaelt(p)`: liegt `p` im Rechteck? Der Rand gehört dazu.
5. `Verschiebe(dx, dy)` delegiert an `Verschiebe` der beiden Punkte.
6. `Schnitt(r)` liefert die Überlappung als **neues** Rechteck: links ist das
   größere der beiden linken Enden, rechts das kleinere der beiden rechten,
   oben und unten entsprechend. Bleibt keine positive Breite oder Höhe übrig,
   liefert die Methode `null`; deshalb ist der Rückgabetyp `Rechteck?` (Buch
   Seite 338, Fußnote; ausführlich kommt das in Kapitel 15.1.1). Beide
   Rechtecke bleiben unverändert.
7. `ToString()` liefert `"[(1; 2), (4; 6)]"` (nutze `Punkt.ToString`).

Diese Tests müssen bestehen:

- `RechteckTests.Konstruktor_ordnet_die_Ecken`
- `RechteckTests.Rechteck_haengt_nicht_an_den_uebergebenen_Punkten`
- `RechteckTests.Eckpunkte_werden_als_Kopie_geliefert`
- `RechteckTests.Breite_Hoehe_Flaeche_Umfang`
- `RechteckTests.Enthaelt_innen_auf_dem_Rand_und_aussen`
- `RechteckTests.Verschiebe_bewegt_beide_Ecken`
- `RechteckTests.Schnitt_liefert_die_Ueberlappung`
- `RechteckTests.Schnitt_ohne_Ueberlappung_oder_bei_Beruehrung_ist_null`
- `RechteckTests.Schnitt_mit_enthaltenem_Rechteck_ist_das_innere`
