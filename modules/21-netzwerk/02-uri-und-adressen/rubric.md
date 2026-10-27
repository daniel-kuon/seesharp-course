# Rubrik — URIs, Parameter und IP-Adressen (nur für die Betreuung)

- Kern: Parameter immer mit `Uri.EscapeDataString` kodieren (in der Aufgabe
  vorgegeben, nicht im Buch); `?` und `&` richtig setzen. Bonus (Deep Dive):
  `Baue` mit `UriBuilder` statt mit Verkettung (nicht im Buch). Der
  Round-Trip-Test (`Parameter_ist_die_Umkehrung_von_Baue`) mit Umlauten, `=`
  und `&` im Wert ist der Prüfstein.
- `Uri.EscapeDataString` gegen `Uri.EscapeUriString` (veraltet) und
  `WebUtility.UrlEncode` (Leerzeichen als `+`): Nachfragen, warum hier `%20`
  verlangt wird. Das Leerzeichen als `+` gilt nur in Formulardaten.
- `Zerlege`: Der Weg über die Ausnahme ist hier gewollt (Level 11,
  `exceptions.catch-specific`); `TryAbsolut` zeigt die Alternative ohne
  Ausnahme. Nachfrage: Wann nimmt man welche?
- `IstLokal`: Stolperstein `IPAddress.TryParse` akzeptiert auch Kurzformen wie
  `192.168.1` (wird zu `192.168.0.1`) und `127.1`. Der Test verlangt dazu
  nichts; eine strengere Prüfung (genau vier Teile) ist erlaubt. Typische
  Fehler im Bereich 172: nur `172.16` statt `16` bis `31` prüfen,
  Zeichenkettenvergleich statt `GetAddressBytes()` (beides in der Aufgabe
  vorgegeben, nicht im Buch).
- Auf Linux wird ein absoluter Pfad wie `/tmp/x` von `Uri` als Datei-URI
  akzeptiert; die Tests meiden deshalb solche Eingaben.
- `LoopbackAufgeloest` ist ein Funktionstest für die lokale Namensauflösung;
  er benötigt kein Internet.

Modellantwort: `solution/` bzw. `samples/Netzwerk/Uri`, `samples/Netzwerk/DNS`
(nur die Logik).
