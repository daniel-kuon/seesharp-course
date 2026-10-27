# Listen verwalten

Lies im Buch **11.4.1 Klasse List<T> mit Array-Unterbau** (Seite 697), dazu
11.1 (Seite 691) für den Unterschied zu Arrays.

Öffne `Listenwerkzeuge.cs` und implementiere die fünf Methoden. Die Signaturen
bleiben unverändert.

1. `RemoveEvens` entfernt alle geraden Zahlen aus der Liste selbst. Die Tests
   verwenden Listen mit mehreren geraden Zahlen hintereinander: Ein `foreach`
   mit `Remove()` bricht ab, eine Vorwärtsschleife überspringt Elemente.
2. `InsertSorted` fügt einen Wert in eine aufsteigend sortierte Liste so ein,
   dass sie sortiert bleibt.
3. `MoveToFront` stellt einen Eintrag an Index 0. Fehlt er, wird er eingefügt;
   doppelt darf er nie vorkommen.
4. `Top3` liefert eine **neue** Liste mit den drei größten Werten, größter
   zuerst; bei weniger als drei Werten kommen alle zurück. Das Argument bleibt
   unverändert.
5. `Rotate` liefert ein neues Array, das um `k` Stellen nach links gedreht
   ist; das Argument bleibt unverändert. `k` darf größer als die Länge sein,
   ein leeres Array bleibt leer. Nimm eine `List<int>` als Arbeitsmittel und
   gib sie mit `ToArray()` zurück.

Beantworte danach die Frage zum `foreach` mit `Remove()`.

Die Tests heißen u. a. `RemoveEvens_entfernt_auch_aufeinanderfolgende_gerade_Zahlen`,
`InsertSorted_haelt_die_Liste_aufsteigend`,
`MoveToFront_verschiebt_vorhandenen_Eintrag_ohne_Duplikat`,
`Top3_veraendert_das_Argument_nicht` und
`Rotate_dreht_nach_links_und_laesst_das_Original_unveraendert`.
