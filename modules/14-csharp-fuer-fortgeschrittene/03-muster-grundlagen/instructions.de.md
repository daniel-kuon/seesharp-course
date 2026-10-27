# Muster: Konstante, Typ, Relation, logisch

Lies im Buch **15.2.1 Konstantenmuster** (Seite 973), **15.2.3 Typ- und
Deklarationsmuster** (Seite 975), **15.2.8 Relationsmuster** (Seite 983)
und **15.2.9 Kombinatoren und logische Muster** (Seite 984).
Die Übungsaufgabe 2 in 15.7 (Seite 1012) teilt das Alter ebenfalls per
Musterabgleich in Kategorien ein, aber mit anderen Grenzen.

Öffne `Muster.cs`. Schreibe jede Methode als **einen** `switch`-Ausdruck
oder `is`-Ausdruck, ohne `if`:

1. `Alterskategorie(int alter)`: 0 bis 12 `Kind`, 13 bis 17
   `Jugendlicher`, 18 bis 64 `Erwachsener`, 65 bis 150 `Senior`, negative
   Werte und alles über 150 `Ungueltig`. Verwende Relationsmuster (`< 13`)
   und `or`. Die Reihenfolge der Arme zählt: Der erste passende gewinnt.
2. `Beschreibe(object? o)`: `null` ergibt `"null"`, ein `int` `"Ganzzahl 5"`,
   ein `string` `"Text mit 4 Zeichen"`, ein `double`, `float` oder
   `decimal` `"Dezimalzahl"`, alles andere `"unbekannt"`. Ein Deklarationsmuster
   (`int i`) fängt den Wert gleich in einer Variablen.
3. `IstIdentifierZeichen(char c)`: `a` bis `z`, `A` bis `Z` und `_`, in einem
   `is`-Ausdruck mit `>=`, `<=`, `and` und `or`.
4. `IstPositiv(int? x)`: `x is not null and > 0`.

Diese Tests müssen bestehen:

- `MusterTests.Alterskategorie_an_den_Grenzen`
- `MusterTests.Beschreibe_erkennt_null_und_Ganzzahlen`
- `MusterTests.Beschreibe_erkennt_Text`
- `MusterTests.Beschreibe_erkennt_Dezimalzahlen`
- `MusterTests.Beschreibe_kennt_den_Rest_nicht`
- `MusterTests.IstIdentifierZeichen_prueft_die_Bereiche`
- `MusterTests.IstPositiv_behandelt_null_und_Grenzwerte`
