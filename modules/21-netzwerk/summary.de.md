# Netzwerkprogrammierung

Dieses Wahlmodul zeigt, wie C#-Programme über ein Netzwerk Daten austauschen
(Kapitel 21, Seite 1497). Alle Tests laufen ohne Internet: `HttpClient` spricht
mit einem Test-`HttpMessageHandler`, Sockets verbinden sich über `127.0.0.1`
auf einem freien Port. Das Buch hat in diesem Kapitel keine Übungsaufgaben;
die Aufgaben sind neu.

## Grundbegriffe (21.1, Seite 1497 bis 1505)

Das OSI-Modell teilt die Datenübertragung in sieben Schichten (21.1.1): von
der Bitübertragung über Sicherung (Ethernet) und Vermittlung (IP) bis zur
Anwendungsschicht (HTTP, DNS). Praktisch zählt das Protokollstapel-Modell
(21.1.2): Jede Schicht verpackt die Daten der darüberliegenden. Die
Transportschicht unterscheidet TCP (verbindungsorientiert, gesichert) von UDP
(verbindungslos); eine **Portnummer** wählt unter den Programmen eines
Rechners eines aus, eine **IP-Adresse** den Rechner. **DNS** übersetzt
Hostnamen in IP-Adressen. C# bietet zu allem passende Klassen im Namensraum
`System.Net` (21.1.3).

## URI und URL (21.2, Seite 1505)

Die Klasse `Uri` zerlegt eine Adresse in Schema, Host, Port, Pfad, Abfrage
und Fragment; fehlende Standardports ergänzt sie (80 für `http`, 443 für
`https`), Leerzeichen kodiert sie als `%20`. Eine ungültige Zeichenkette löst
`UriFormatException` aus. Parameter in der Abfrage beginnen mit `?` und
werden durch `&` getrennt; Zeichen wie `&` oder `=` in einem Wert müssen
deshalb kodiert werden. Die Aufrufe dafür (`Uri.EscapeDataString`,
`Uri.UnescapeDataString`, `Uri.TryCreate`) stehen nicht im Buch, Aufgabe 2
gibt sie vor (siehe Deep Dive).

## HttpClient (21.3, Seite 1506 bis 1516)

`HttpClient` ruft Web-Ressourcen ab. Man legt **ein** Objekt an und benutzt es
weiter (Seite 1507): Ein neuer Client je Aufruf verschwendet Verbindungen
und kann Ports erschöpfen. Anforderungsmethoden sind `GET` (lesen), `POST`
(senden, anlegen), `HEAD` (nur Kopfzeilen, etwa zur Existenzprüfung) und weitere
(21.3.1). `GetStringAsync` liefert den Text, `GetAsync` die ganze Antwort mit
Statuscode: 2xx Erfolg, 3xx Umleitung, 4xx Fehler des Klienten, 5xx Fehler
des Servers. `EnsureSuccessStatusCode()` wirft bei Misserfolg
`HttpRequestException` mit `StatusCode`. JSON überträgt das Buch mit `JsonSerializer`
und `StringContent` (21.3.3); mit `PropertyNamingPolicy = JsonNamingPolicy.CamelCase`
(16.5) passen die Namen zum üblichen JSON-Stil (kürzer: siehe Deep Dive). Die Methoden sind asynchron
(`Task<T>`); mit `await` wartet man auf das Ergebnis, ohne einen Thread zu
blockieren.

## IP-Adressen und Hostnamen (21.5, Seite 1523)

`Dns.GetHostEntryAsync` und `Dns.GetHostAddressesAsync` lösen einen Namen
in IP-Adressen auf (`localhost` klappt auch ohne Internet); eine IPv4-Adresse
hat 32 Bit, eine IPv6-Adresse 128 Bit. Die Klasse `IPAddress` stellt eine
Adresse dar (`IPAddress.IPv6Any` für alle Adressen eines Servers, 21.6.1).

## Sockets (21.6, Seite 1525 bis 1536)

Ein `TcpListener` wartet auf einem Port auf Verbindungen; `AcceptTcpClient()`
liefert einen `TcpClient`, dessen `NetworkStream` man wie eine Datei mit
`StreamReader` und `StreamWriter` benutzt (21.6.1, 21.6.2). Auf diese Weise
entsteht ein zeilenbasiertes Protokoll: Der Klient schickt eine Zeile, der
Server antwortet mit einer Zeile. Wichtig: `AutoFlush = true`, sonst bleiben
Antworten im Puffer; und `ReadLine()` liefert `null`, wenn die Gegenseite
die Verbindung schließt. Ein Server, der nur einen Klienten zugleich bedient,
lässt den nächsten warten; für mehrere Klienten gleichzeitig reicht jeder
Verbindung eine eigene Task (21.6.3, Seite 1531).

## WebView2 (21.4, Seite 1516)

Das `WebView2`-Steuerelement bettet einen Browser in eine WPF-Anwendung ein.
Es braucht Windows und die WebView2-Runtime; die Aufgabe dazu wird von der
Betreuung geprüft.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- **Adressen bearbeiten:** `Uri.EscapeDataString` und `Uri.UnescapeDataString`
  kodieren Werte für die Abfrage und zurück, `Uri.TryCreate` liefert `false`
  statt einer Ausnahme, `UriBuilder` setzt Adressen aus Teilen zusammen
  (Aufgabe 2 und die Deep-Dive-Aufgabe URL-Sammler).
- **IP-Adressen prüfen:** `IPAddress.TryParse`, `IPAddress.IsLoopback` und
  `GetAddressBytes()` (Aufgabe 2 gibt sie vor).
- **JSON in einem Aufruf:** `GetFromJsonAsync<T>`, `PostAsJsonAsync` und
  `ReadFromJsonAsync<T>` aus `System.Net.Http.Json` ersetzen
  `JsonSerializer` plus `StringContent`; sie nutzen von selbst camelCase-Namen.
- **HttpClient ohne Netzwerk testen:** Ein eigener `HttpMessageHandler`, den
  man dem `HttpClient` im Konstruktor mitgibt, zeichnet Anforderungen auf und
  liefert vorbereitete Antworten; so arbeiten die Tests dieses Levels.
