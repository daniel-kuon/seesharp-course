# Rubrik: Verständnisfragen Netzwerkprogrammierung (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-url-bauen` (richtig: Option 2), `mc-httpclient` (Option 1) und `mc-json` (Option 3) wertet das
Programm selbst aus. Alle Code-Listings wurden in einer `net10.0`-Konsolenanwendung ausgeführt (`HttpClient` mit einem Test-`HttpMessageHandler`,
Sockets über `127.0.0.1`); die Ausgaben unten sind echt.

## osi-und-protokolle

Wesentlich:
- Schichtenprinzip: Die Datenübertragung ist in Schichten geteilt (OSI: sieben; praktisch der Protokollstapel), jede Schicht verpackt die Daten der darüberliegenden
  und kümmert sich nur um ihre Aufgabe (Bitübertragung, Ethernet, IP/Vermittlung, TCP/UDP/Transport, HTTP/DNS/Anwendung).
- IP-Adresse wählt den **Rechner**, die Portnummer das **Programm** auf diesem Rechner, DNS übersetzt Hostnamen in IP-Adressen.
- TCP: verbindungsorientiert und gesichert (Reihenfolge, Wiederholung bei Verlust); UDP: verbindungslos, ohne Zusicherung. HTTP braucht einen zuverlässigen Datenstrom (vollständige Seite, richtige Reihenfolge) und läuft deshalb über TCP.

Typische Fehlvorstellungen: Port und IP-Adresse verwechseln; „UDP ist die schnellere Version von TCP" ohne den Verlust der Zusicherung zu nennen; DNS gehöre zu IP-Adressen ("DNS vergibt Adressen") statt Namen aufzulösen.

## code-uri-zerlegen

Ausgabe:

```
https example.org 8443
/a/b.html?x=1&y=zwei ?x=1&y=zwei #kopf
80 /start?x=a%20b
```

Wesentlich:
- `Uri` zerlegt die Adresse in Schema, Host, Port, Pfad mit Abfrage (`PathAndQuery`), Abfrage (`Query`, mit führendem `?`) und Fragment (`Fragment`, mit führendem `#`; nicht in `PathAndQuery`).
- Fehlt der Port, ergänzt `Uri` den Standardport des Schemas: 80 für `http`, 443 für `https` (21.2, Seite 1506).
- Das Leerzeichen kodiert der `Uri`-Konstruktor selbst als `%20` (ebenfalls Seite 1506).

Typische Fehlvorstellungen: `Query` ohne `?` oder `Fragment` ohne `#` erwartet; das Fragment in `PathAndQuery`; Port 0 oder eine Ausnahme bei fehlendem Port; Host mit Port (`example.org:8443`); eine Ausnahme wegen des Leerzeichens.

## uri-und-kodierung

Wesentlich:
- Teile: Schema, Host, Port, Pfad, Abfrage (Query), Fragment.
- In der Abfrage haben `&` (trennt Parameter), `=` (trennt Name und Wert), `?`, `#` und das Leerzeichen eine Bedeutung. Steckt solch ein Zeichen unkodiert im
  Wert, verändert es die Adresse: Aus `Tom & Jerry` würden zwei Parameter. Deshalb `Uri.EscapeDataString(wert)` (Prozentkodierung, auch für Umlaute und Leerzeichen); `Uri.UnescapeDataString` kehrt es um.
- `new Uri(text)` wirft bei ungültigem Text eine `UriFormatException`; `Uri.TryCreate` liefert stattdessen `false` (Benutzereingaben). `EscapeDataString` und `TryCreate` stehen nicht im Buch, Aufgabe 2 gibt sie vor.
- Bonus (Deep Dive): `UriBuilder` setzt Adressen aus Teilen zusammen (eine `Uri` ist unveränderlich).

Typische Fehlvorstellungen: Kodieren sei nur für Umlaute nötig; die ganze Adresse (nicht die Werte) kodieren; es reiche, Leerzeichen zu ersetzen.

## http-methoden-status

Wesentlich:
- `GET` liest eine Ressource, `POST` sendet Daten (legt an), `HEAD` liefert nur die Kopfzeilen (etwa zur Existenzprüfung, ohne Inhalt zu übertragen).
- 2xx Erfolg, 3xx Umleitung, 4xx Fehler des **Klienten** (falsche Adresse, fehlende Berechtigung, 404), 5xx Fehler des **Servers**.
- `GetAsync` liefert immer die ganze Antwort mit Statuscode und wirft bei 404 **keine** Ausnahme; `EnsureSuccessStatusCode()` wirft bei einem Misserfolg eine
  `HttpRequestException` mit `StatusCode` (hier `NotFound`).

Typische Fehlvorstellungen: `GetAsync` werfe bei 404; 4xx und 5xx vertauscht; `POST` sei „nur ein sichereres GET".

## code-statuscodes

Ausgabe:

```
200 404 False
NotFound
Ausnahme
```

Wesentlich:
- `GetAsync` liefert die Antwort einfach zurück, auch bei 404 (`IsSuccessStatusCode` ist `false`); die Prüfung ist Sache des Aufrufers.
- `EnsureSuccessStatusCode()` wirft bei 404 die `HttpRequestException`, ihr `StatusCode` ist `NotFound`.
- `GetStringAsync` liefert nur den Text und prüft den Status von sich aus: bei einem Misserfolg gibt es eine `HttpRequestException`, weil es keine Antwort mit Statuscode zurückgeben kann.

Typische Fehlvorstellungen: Schon `GetAsync` werfe bei 404 (dann gäbe es keine zweite Ausgabe der ersten Zeile); `GetStringAsync` liefere den Text der Fehlerseite; die Ausgabe `OK` statt `NotFound`.

## httpclient-und-async

Wesentlich:
- Ein Client pro Aufruf verschwendet Verbindungen (jede neue Instanz baut eigene Verbindungen auf) und kann bei vielen Aufrufen die Ports erschöpfen; deshalb **ein** Objekt anlegen und weiterverwenden.
- `Task<T>` steht für ein Ergebnis, das erst später fertig ist; `await` wartet darauf, **ohne den Thread zu blockieren**: Der Thread kann in der Zwischenzeit anderes tun, danach läuft die Methode weiter. Die Methode ist `async` und liefert selbst `Task<T>`.
- JSON (21.3.3, 16.5): Empfangen mit `GetStringAsync` und `JsonSerializer.Deserialize<T>(text, optionen)`; Senden mit `JsonSerializer.Serialize`, verpackt in `StringContent` (Kodierung UTF-8, Medientyp `application/json`), per `PostAsync`. Mit `PropertyNamingPolicy = JsonNamingPolicy.CamelCase` passen die JSON-Namen.
- Bonus (Deep Dive): `GetFromJsonAsync<T>` und `PostAsJsonAsync` aus `System.Net.Http.Json` (nicht im Buch) erledigen beides in einem Aufruf.

Typische Fehlvorstellungen: `await` blockiere den Thread, bis die Antwort da ist (wie `.Result`); `HttpClient` müsse per `using` bei jedem Aufruf neu erzeugt werden; `async` starte einen neuen Thread.

## code-tcp-schleife

Ausgabe: Der Klient empfängt `HALLO`, dann `WELT`; der Server gibt `Klient weg` aus.

Wesentlich:
- `ReadLine()` liefert die nächste Zeile; der Server schickt sie in Großbuchstaben zurück (`WriteLine` auf dem `NetworkStream`).
- Schließt der Klient die Verbindung, liefert `ReadLine()` `null`: Das ist das Zeichen für das Ende, die Schleife endet, danach folgt „Klient weg".
- Ohne `AutoFlush = true` bleiben die Antworten im Puffer des `StreamWriter`: Der Klient wartet auf die Antwort, der Server auf die nächste Zeile, keiner kommt weiter (Blockade, beim Klienten
  hier ein Timeout), obwohl der Code „richtig" aussieht.

Typische Fehlvorstellungen: Die Schleife ende nie / mit einer Ausnahme, wenn der Klient die Verbindung schließt (`null` ist der normale Fall); die Antworten kämen auch ohne `AutoFlush` sofort; `ReadLine` liefere eine leere Zeichenfolge bei Verbindungsende statt `null`.

## tcp-zeilenprotokoll

Wesentlich:
- `TcpListener` lauscht auf einem Port (`Start()`); `AcceptTcpClient()` wartet auf eine Verbindung und liefert einen `TcpClient`; dessen `NetworkStream` benutzt man wie eine Datei, mit `StreamReader` und `StreamWriter`.
- Zeilenbasiertes Protokoll: Der Klient schickt eine Zeile, der Server antwortet mit einer Zeile; Zeilenende ist das Trennzeichen; `AutoFlush = true`, damit nichts im Puffer bleibt; `ReadLine()` liefert `null`, wenn die Gegenseite schließt.
- Ein Server, der die Verbindung gleich in der Schleife bearbeitet, bedient keinen weiteren, solange der erste verbunden ist: Der nächste Klient wartet. Abhilfe: jede Verbindung in einer eigenen Task (`Task.Run`) bearbeiten, die Schleife nimmt sofort die nächste an.

Typische Fehlvorstellungen: `AcceptTcpClient` liefere Daten (es liefert die Verbindung); mehrere Klienten gingen automatisch; ein Thread pro Zeile.
