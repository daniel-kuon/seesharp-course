# Zusatz: Rechentabelle

Lies im Buch **10.1.2 Delegatenobjekte erzeugen und aufrufen** (Seite 660).
Als Delegatentyp dient hier der vorgefertigte `Func<double, double, double>`.

Die Klasse `Rechentabelle` verwaltet benannte Rechenoperationen in einem
`Dictionary<string, Func<double, double, double>>`:

1. `Registriere(name, operation)` trägt die Operation ein (ein vorhandener
   Name wird überschrieben).
2. `Berechne(name, a, b)` ruft die Operation auf; bei unbekanntem Namen
   liefert sie `double.NaN`.
3. `Tabelle(name, von, bis)` liefert das Gitter `double[,]` mit
   `bis - von + 1` Zeilen und Spalten; Zelle `[i, j]` enthält
   `operation(von + i, von + j)` (wie ein Einmaleins). Ist `bis < von`, ist
   das Gitter leer (0 x 0); bei unbekanntem Namen ist jede Zelle `NaN`.

Tests: `Berechne_ruft_die_registrierte_Operation_auf`,
`Unbekannter_Name_liefert_NaN`, `Registriere_ueberschreibt`,
`Tabelle_ist_ein_Einmaleins`, `Tabelle_mit_Subtraktion`,
`Tabelle_mit_leerem_Bereich`, `Tabelle_mit_unbekanntem_Namen`.
