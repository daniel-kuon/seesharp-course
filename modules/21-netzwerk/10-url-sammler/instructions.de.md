# Deep Dive: URL-Sammler

> **Deep Dive (optional):** Diese Aufgabe geht über das Buch hinaus. Sie
> arbeitet mit `Uri.TryCreate`, `UriBuilder`, `Uri.EscapeDataString` und
> `Uri.UnescapeDataString`, die das Buch nicht behandelt (Aufgabe 2 hat einige
> davon vorgegeben). Sie ist ein Beispiel dafür, was du dir als Nächstes ansehen
> kannst: die Dokumentation der Klassen `Uri` und `UriBuilder`.

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**21.2 URI bzw. URL** (Seite 1505) und **21.3.3 Anforderungsparameter**
(Seite 1512).

Ein kleines Werkzeug bereinigt eine Liste von Adressen, etwa aus einem
Logfile. Die Eingaben sind unordentlich: Es gibt relative Pfade, leere
Zeilen, Text und Adressen mit anderen Schemata. Nur absolute `http`- und
`https`-Adressen zählen; die fertige Hilfsmethode `Lese` entscheidet das.
Öffne `UrlSammler.cs`:

1. `Hosts(urls)` liefert die verschiedenen Hosts, aufsteigend sortiert.
2. `OhneParameter(url)` liefert die Adresse ohne Abfrage (ein Fragment bleibt).
3. `MitParameter(url, name, wert)` setzt den Parameter: Ein vorhandener Wert
   wird an seiner Stelle ersetzt, sonst kommt der Parameter ans Ende. Namen
   und Werte werden korrekt kodiert, vorhandene Parameter nicht doppelt.
4. Ungültige oder relative Eingaben ergeben bei 2 und 3 `null`, bei 1 werden
   sie übersprungen.

Die Tests arbeiten unter anderem mit einer Liste von zehn gemischten Adressen.

Diese Tests müssen bestehen:

- `UrlSammlerTests.Hosts_liefert_die_verschiedenen_Hosts_sortiert`
- `UrlSammlerTests.Hosts_ignoriert_Grossschreibung_und_Duplikate`
- `UrlSammlerTests.Hosts_einer_leeren_Folge_ist_leer`
- `UrlSammlerTests.OhneParameter_entfernt_die_Abfrage`
- `UrlSammlerTests.OhneParameter_und_MitParameter_liefern_null_fuer_relative_oder_ungueltige_Eingaben`
- `UrlSammlerTests.MitParameter_haengt_einen_neuen_Parameter_an`
- `UrlSammlerTests.MitParameter_ersetzt_einen_vorhandenen_an_derselben_Stelle`
- `UrlSammlerTests.MitParameter_kodiert_Name_und_Wert`
- `UrlSammlerTests.MitParameter_kodiert_vorhandene_Werte_nicht_doppelt`
- `UrlSammlerTests.MitParameter_behaelt_das_Fragment`
- `UrlSammlerTests.MitParameter_ersetzt_nur_einmal_und_auch_leere_Werte`
