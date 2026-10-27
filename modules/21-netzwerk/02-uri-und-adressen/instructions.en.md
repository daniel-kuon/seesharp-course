# URIs, Parameters, and IP Addresses

Read sections **21.2 "URI or URL"** (page 1505), **21.3.3 "Request Parameters**" (page 1512), and **21.5 "Determining IP Addresses or Host Names**" (page 1523) in the book. The sample project `Netzwerk/Uri` in the book’s Sample folder demonstrates the `Uri` class; `Netzwerk/DNS` is a WPF application, but only its logic is relevant here. This exercise does not require a network. Open `Adressen.cs`:

The book shows `new Uri(...)` with its properties and the `UriFormatException`. The other calls in this exercise are not in the book; they are given here and are to be used exactly as shown below.

1. `Zerlege(url)` breaks down an absolute URL with `Uri` into schema, host, port, path, and query (without `?`). `Uri` adds missing ports (80 and 443). `uri.AbsolutePath` returns the path without the query (not in the book, given here). Relative or invalid strings trigger a `UriFormatException`; the method returns `null` in such cases.
2. `Baue(basis, parameter)` appends the parameters to the address in the order they were inserted: `?` before the first one, `&` between the pairs; if the base already has a query (`?`), continue with `&`. Encode names and values with `Uri.EscapeDataString(text)` (not in the book, given here: `"a b&c"` becomes `a%20b%26c`). An invalid base should throw a `UriFormatException`: create `new Uri(basis)` once for that.
3. `Parameter(url)` reads the query back into a dictionary; the inverse of the encoding is `Uri.UnescapeDataString(text)` (not in the book, given here).
4. `TryAbsolut(s, out uri)` is one line: `Uri.TryCreate(s, UriKind.Absolute, out uri)` (not in the book, given here; returns `false` instead of throwing).
5. `IstLokal(ip)` returns `true` for loopback and the private IPv4 ranges (`10.x`, `172.16` through `172.31`, `192.168.x`); unreadable inputs return `false`. Given (not in the book): `IPAddress.TryParse(ip, out var adresse)` reads the address, `IPAddress.IsLoopback(adresse)` recognizes `127.x.x.x` and `::1`, `adresse.GetAddressBytes()` returns the bytes (4 for IPv4, 16 for IPv6).
6. `LoopbackAufgeloest()` checks to see if `Dns.GetHostAddresses("localhost")` contains a loopback address (the non-asynchronous form of `GetHostAddressesAsync` from 21.5). `localhost` is resolved locally; the Internet is not required.

> **Deep Dive (optional):** The class `UriBuilder` (not in the book) assembles addresses from parts instead of concatenating strings: `new UriBuilder(basis)`, then set the property `Query` and finally read `builder.Uri.AbsoluteUri`. If you like, rewrite `Baue` with it; the tests stay the same.

The following tests must be passed:

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
