# Zusatzaufgabe: Eine Bibliothek mit Indexern

Diese Aufgabe ist freiwillig. Sie wiederholt Indexer, geschachtelte Klassen
und `ToString` an einem neuen Beispiel. Zum Nachlesen: **5.12 Indexer**
(Seite 393) und **5.11 Geschachtelte Klassen** (Seite 391).

Die `Bibliothek` speichert ihre Bücher in einer verketteten Liste wie die
`PersList` aus der Indexer-Übung. Der Knoten ist eine private geschachtelte
Klasse; von außen sieht man nur `Buch`-Objekte.

1. `Buch.ToString()` liefert `"Der Process (Kafka, 1925)"`.
2. `Bibliothek.Add(buch)` hängt einen Knoten an und erhöht `Anzahl`.
3. Der Indexer `this[int i]` liefert das Buch an Position `i` und wirft bei
   ungültigem Index `ArgumentOutOfRangeException`. Er ist nur lesend.
4. Der überladene Indexer `this[string titel]` liefert das erste Buch mit
   genau diesem Titel, oder `null`, wenn es keins gibt (Rückgabetyp `Buch?`).
5. `Ausleihen(titel)` und `Zurueckgeben(titel)` ändern `Ausgeliehen` und
   liefern `true`, wenn das gelingt. Fehlt das Buch, oder ist es schon
   ausgeliehen bzw. gar nicht ausgeliehen, liefern sie `false`. Verwende den
   `string`-Indexer.
6. `Verfuegbar` ist eine berechnete Eigenschaft: Sie zählt bei jedem Lesen
   die nicht ausgeliehenen Bücher.
7. `VonAutor(autor)` liefert die Titel des Autors in Einfügereihenfolge,
   getrennt durch `", "`, also `"Der Process, Das Schloss"`. Ohne Treffer
   liefert sie `""`.

Tipp: Eine Liste durchläuft man bequem mit
`for (Knoten? k = erster; k != null; k = k.Next)`. Das Fragezeichen in
`Buch?` und `Knoten?` heißt: `null` ist erlaubt (Buch Seite 338, Fußnote;
ausführlich kommt das in Kapitel 15.1.1).

Diese Tests müssen bestehen:

- `BibliothekTests.ToString_zeigt_Titel_Autor_und_Jahr`
- `BibliothekTests.Add_erhoeht_Anzahl`
- `BibliothekTests.Int_Indexer_liefert_Buecher_in_Einfuegereihenfolge`
- `BibliothekTests.Int_Indexer_wirft_bei_ungueltigem_Index`
- `BibliothekTests.String_Indexer_findet_das_Buch_oder_liefert_null`
- `BibliothekTests.Ausleihen_nur_einmal`
- `BibliothekTests.Zurueckgeben_nur_wenn_ausgeliehen`
- `BibliothekTests.Verfuegbar_zaehlt_nicht_ausgeliehene_Buecher`
- `BibliothekTests.VonAutor_listet_Titel_mit_Komma`
