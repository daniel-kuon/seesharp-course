# URIs, Parameter und IP-Adressen

Lies im Buch **21.2 URI bzw. URL** (Seite 1505), **21.3.3 Anforderungsparameter**
(Seite 1512) und **21.5 IP-Adressen bzw. Hostnamen ermitteln** (Seite 1523).
Das Beispielprojekt `Netzwerk/Uri` im Sample-Ordner des Buchs zeigt die
Klasse `Uri`; `Netzwerk/DNS` ist eine WPF-Anwendung, von der hier nur die
Logik interessiert. Diese Aufgabe braucht kein Netzwerk. Öffne `Adressen.cs`:

1. `Zerlege(url)` zerlegt eine absolute URL mit `Uri` in Schema, Host, Port,
   Pfad und Abfrage (ohne `?`). Fehlende Ports ergänzt `Uri` (80 und 443).
   Relative oder ungültige Zeichenketten lösen `UriFormatException` aus; die
   Methode macht daraus `null`.
2. `Baue(basis, parameter)` hängt die Parameter in Einfügereihenfolge an die
   Adresse an. Namen und Werte kodierst du mit `Uri.EscapeDataString`
   (`"a b&c"` wird zu `a%20b%26c`). Verwende `UriBuilder`.
3. `Parameter(url)` liest die Abfrage zurück in ein Wörterbuch
   (`Uri.UnescapeDataString`).
4. `TryAbsolut(s, out uri)` nutzt `Uri.TryCreate` mit `UriKind.Absolute`.
5. `IstLokal(ip)` meldet `true` für Loopback und die privaten IPv4-Bereiche
   (`10.x`, `172.16` bis `172.31`, `192.168.x`); unlesbare Eingaben ergeben
   `false`. Hilfreich: `IPAddress.TryParse`, `IPAddress.IsLoopback`.
6. `LoopbackAufgeloest()` prüft, dass `Dns.GetHostAddresses("localhost")`
   eine Loopback-Adresse enthält. `localhost` wird lokal aufgelöst; das
   Internet wird nicht gebraucht.

Diese Tests müssen bestehen:

- `AdressenTests.Zerlege_liefert_alle_Teile_einer_https_URL`
- `AdressenTests.Zerlege_ergaenzt_Standardports`
- `AdressenTests.Zerlege_uebernimmt_einen_ausdruecklichen_Port`
- `AdressenTests.Zerlege_ohne_Pfad_und_Abfrage`
- `AdressenTests.Zerlege_liefert_null_fuer_ungueltige_oder_relative_Eingaben`
- `AdressenTests.Baue_kodiert_Sonderzeichen_mit_Prozentzeichen`
- `AdressenTests.Baue_behaelt_die_Einfuegereihenfolge`
- `AdressenTests.Baue_kodiert_Umlaute_und_Namen`
- `AdressenTests.Baue_ohne_Parameter_liefert_die_Basis_unveraendert`
- `AdressenTests.Baue_haengt_an_eine_vorhandene_Abfrage_an`
- `AdressenTests.Baue_mit_ungueltiger_Basis_wirft_UriFormatException`
- `AdressenTests.Parameter_dekodiert_die_Abfrage`
- `AdressenTests.Parameter_ist_die_Umkehrung_von_Baue`
- `AdressenTests.Parameter_ohne_Abfrage_ist_leer_und_Fragment_wird_ignoriert`
- `AdressenTests.Parameter_ohne_Gleichheitszeichen_hat_den_Wert_leer_und_doppelte_Namen_der_letzte`
- `AdressenTests.Parameter_trennt_nur_am_ersten_Gleichheitszeichen`
- `AdressenTests.TryAbsolut_erkennt_absolute_Adressen`
- `AdressenTests.TryAbsolut_lehnt_andere_Eingaben_ab`
- `AdressenTests.IstLokal_ist_true_fuer_Loopback_und_private_Bereiche`
- `AdressenTests.IstLokal_ist_false_fuer_oeffentliche_Adressen`
- `AdressenTests.IstLokal_ist_false_fuer_unlesbare_Eingaben`
- `AdressenTests.Localhost_wird_zu_einer_Loopback_Adresse_aufgeloest`
