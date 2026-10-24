# Rubrik — Mehrere Klienten und WebView2 (nur für die Betreuung)

Nichts Automatisches; Teil 2 braucht Windows.

Teil 1:
- Annahmeschleife mit `AcceptTcpClient()` (oder `AcceptTcpClientAsync`) und
  `Task.Run` je Klient. Befund, wenn die Klienten in der Schleife selbst
  bedient werden (dann ändert sich nichts gegenüber Aufgabe 4).
- Ausprobieren: Zwei Klienten gleichzeitig, der erste schweigt (liest
  nichts, sendet nichts): Der zweite muss trotzdem Antworten bekommen. Genau
  das ist die Frage `warum-blockiert`: Der sequenzielle Server hängt in
  `ReadLine()` des ersten Klienten und kommt gar nicht zum nächsten
  `AcceptTcpClient()`; Verbindungen warten dann im Backlog des Listeners.
- Antwort auf die Grenzen: ein Thread (bzw. eine Task) je Klient kostet
  Speicher und Planungsaufwand; beschränkt durch Thread-Pool, Speicher,
  Dateihandles/Ports (Betriebssystem), `backlog`-Länge des Listeners; für sehr
  viele Klienten ist asynchrones Lesen (`ReadLineAsync`) besser. Ein
  Hinweis genügt; Details gehören ins Multithreading-Modul.
- Sauberes Beenden: `listener.Stop()` lässt `AcceptTcpClient()` mit
  `SocketException` abbrechen; die Schleife fängt das ab. Unbedingt prüfen:
  Eine Ausnahme in einer Klienten-Task darf den Server nicht beenden
  (try/catch in der Task).
- Gemeinsamer Zustand (hier keiner) wäre der Anlass für Synchronisation.

Teil 2:
- Projektdatei: `net10.0-windows`, `UseWPF`, Paket `Microsoft.Web.WebView2`.
- Fenster zeigt die Seite; `EnsureCoreWebView2Async` bzw. `Source` richtig
  verwendet; Verhalten ohne installierte Runtime erklärt (21.4.2.3).

Modellantwort: `samples/Netzwerk/Socket/TcpServerTPL`, `samples/Netzwerk/WebView2`.
