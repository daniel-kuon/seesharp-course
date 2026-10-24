# Extra: URL Collector

Extra exercise: optional; it unlocks nothing. For further reading: **21.2 URI or URL** (page 1505) and **21.3.3 Request Parameters** (page 1512).

A small tool cleans up a list of URLs, such as those from a log file. The input is disorganized: it contains relative paths, empty lines, text, and URLs with different formats. Only absolute `http` and `https` URLs are valid; the finished helper method `Lese` determines this. Open `UrlSammler.cs`:

1. `Hosts(urls)` lists the various hosts, sorted in ascending order.
2. `OhneParameter(url)` returns the URL without the query string (the fragment remains).
3. `MitParameter(url, name, wert)` sets the parameter: If a value already exists, it is replaced; otherwise, the parameter is appended to the end. Names and values are encoded correctly, and existing parameters are not duplicated.
4. Invalid or relative entries result in `null` for 2 and 3; for 1, they are skipped.

Among other things, the tests use a list of ten random addresses.

The following tests must be passed:

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
