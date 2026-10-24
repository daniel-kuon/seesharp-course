# Binärdateien: FileStream und BinaryWriter

Lies im Buch **16.1.3 Wichtige Methoden und Eigenschaften der
Basisklasse Stream** (Seite 1015), **16.1.4 FileStream** mit **FileMode**,
**FileAccess** und **FileShare** (Seite 1018) und **16.3.1 Schreiben und
Lesen im Binärformat** (Seite 1032).

Öffne `Binaerdaten.cs`. Wie in Aufgabe 1 schließt du jede Datei mit
`Close()` in einem `finally`-Block; die Tests legen alle Dateien in einem
eigenen Temp-Ordner an.

1. `Kopiere(quelle, ziel)`: byteweise über einen Puffer von 4096 Bytes mit
   `Read` und `Write`. Die Quelle wird nur zum Lesen geöffnet
   (`FileMode.Open`, `FileAccess.Read`, `FileShare.Read`); das Ziel mit
   `FileMode.Create`. Schreibe genau so viele Bytes, wie `Read` geliefert hat.
   Rückgabe ist die Zahl der kopierten Bytes.
2. `SchreibeMesswerte(pfad, werte)`: ein `BinaryWriter` schreibt die Anzahl
   als `int` und danach jeden `double`. Die Datei ist dann `4 + 8 * n` Bytes
   groß. `LiesMesswerte(pfad)` liest dasselbe Format mit einem
   `BinaryReader`.
3. `HaengeAn(pfad, daten)`: `FileMode.Append` legt die Datei bei Bedarf an
   und schreibt hinten weiter.
4. `LiesAb(pfad, offset, anzahl)`: mit `Seek` an die Position springen und bis
   zu `anzahl` Bytes lesen. Am Dateiende kommen weniger Bytes zurück, hinter
   dem Ende ein leeres Array.
5. `Erzeuge(pfad)`: legt eine neue, leere Datei an (`FileMode.CreateNew`). Gibt
   es sie schon, kommt `false` zurück, ohne dass eine Ausnahme fliegt (prüfe
   vorher mit `File.Exists`).

Diese Tests müssen bestehen:

- `BinaerdatenTests.Kopiere_kopiert_100000_Bytes_unveraendert`
- `BinaerdatenTests.Kopiere_ueberschreibt_ein_laengeres_Ziel_vollstaendig`
- `BinaerdatenTests.Kopiere_kopiert_eine_leere_Datei`
- `BinaerdatenTests.Kopiere_oeffnet_die_Quelle_nur_lesend`
- `BinaerdatenTests.Kopiere_fehlende_Quelle_wirft`
- `BinaerdatenTests.Messwerte_haben_die_Dateigroesse_4_plus_8_mal_n`
- `BinaerdatenTests.Messwerte_Rundreise`
- `BinaerdatenTests.Messwerte_Rundreise_ohne_Werte`
- `BinaerdatenTests.Messwerte_speichern_die_Anzahl_zuerst_als_int`
- `BinaerdatenTests.HaengeAn_haengt_hinten_an_und_legt_bei_Bedarf_an`
- `BinaerdatenTests.LiesAb_springt_an_die_Position`
- `BinaerdatenTests.LiesAb_am_Dateiende_liefert_weniger`
- `BinaerdatenTests.Erzeuge_legt_neu_an_und_verweigert_Vorhandenes_ohne_Ausnahme`
