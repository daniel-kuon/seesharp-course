# Rubrik — Netzwerkbegriffe-Quiz (nur für die Betreuung)

- Kern sind Port gegen IP-Adresse, die Statuscode-Klassen und die
  Lebensdauer des `HttpClient`; alle drei kommen in den Aufgaben 2 bis 4
  wieder vor.
- Die offene Frage `browseraufruf` verlangt keine Fachbegriffe in
  Perfektion: DNS-Anfrage (Name zu IP), TCP-Verbindung zu Port 80, Anforderung
  `GET /index.html` mit Host-Kopfzeile, Antwort mit Statuszeile `200 OK`,
  Kopfzeilen und HTML-Inhalt. Nachfrage: Was ändert sich bei `https`
  (Port 443, TLS-Verschlüsselung zwischen TCP und HTTP)?
- Zur `HttpClient`-Frage nachfragen, warum ein Test-`HttpMessageHandler`
  (Aufgabe 3) trotz eines gemeinsamen Clients kein Problem ist (der Handler
  wird dem Client beim Anlegen mitgegeben).

Modellantwort: `samples/Netzwerk/HTTPS/HttpMethod.Head` (nur lesen).
