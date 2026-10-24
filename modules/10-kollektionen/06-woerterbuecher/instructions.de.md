# Wörterbücher

Lies im Buch **11.6 Verwaltung von (Schlüssel-Wert) - Paaren** (Seite 714).
Dort steht auch das Beispiel `DictionaryDemo`, das Zeichen zählt.

Öffne `Woerterbuecher.cs`. Die Methode `Woerter(string)` (zerlegt einen Text
in kleingeschriebene Wörter) und die Klasse `Eintrag` in `Eintrag.cs` sind
vorgegeben. Implementiere die übrigen sieben Methoden:

1. `Haeufigkeiten(text)` liefert ein `Dictionary<string,int>` mit der
   Häufigkeit jedes Worts. Es vergleicht mit `StringComparer.OrdinalIgnoreCase`,
   sodass `d["DER"]` und `d["der"]` denselben Eintrag finden.
2. `Nachschlagen(telefonbuch, name)` liefert die Nummer oder `"unbekannt"`.
   Verwende `TryGetValue`; der Indexer löst bei einem fehlenden Schlüssel
   eine Ausnahme aus.
3. `Eintragen(telefonbuch, name, nummer)` legt den Eintrag an oder
   überschreibt ihn (zweiter Eintrag gewinnt).
4. `Umkehren(haeufigkeiten)` liefert ein `Dictionary<int, List<string>>`:
   zu jeder Häufigkeit alle Wörter, die so oft vorkommen.
5. `Haeufigste(haeufigkeiten, n)` liefert die `n` häufigsten Wörter, größte
   Anzahl zuerst, bei Gleichstand alphabetisch. Baue eine `List<Eintrag>` und
   rufe `Sort()` auf: `Eintrag` bringt seine Reihenfolge mit.
6. `Summe` zählt alle Häufigkeiten zusammen (`foreach` über `KeyValuePair`).
7. `Schluessel` liefert alle Schlüssel aus `Keys` alphabetisch.

Die Reihenfolge, in der ein `Dictionary` seine Einträge aufzählt, ist nicht
garantiert; die Tests verlassen sich nie darauf.

Tests: `Haeufigkeiten_zaehlt_Woerter_ohne_Beachtung_der_Schreibweise`,
`Haeufigkeiten_findet_Schluessel_in_jeder_Schreibweise`,
`Nachschlagen_liefert_Nummer_oder_unbekannt`,
`Eintragen_legt_an_und_ueberschreibt_beim_zweiten_Mal`,
`Umkehren_gruppiert_Woerter_nach_Haeufigkeit`,
`Haeufigste_sortiert_nach_Anzahl_dann_alphabetisch`,
`Summe_addiert_alle_Haeufigkeiten` und
`Schluessel_sind_alphabetisch_sortiert`.
