# Mehrere Klienten und WebView2

Diese Aufgabe wird von der Betreuung geprüft; es gibt keine Tests. Die zweite
Teilaufgabe braucht Windows. Lies im Buch **21.6.3 Simultane Bedienung von
mehreren Klienten** (Seite 1531) und **21.4 Browser per WebView2-Steuerelement**
(Seite 1516) mit **21.4.2 WPF-Programm mit WebView2-Steuerelement**
(Seite 1518). Vorlagen im Sample-Ordner des Buchs: `Netzwerk/Socket/TcpServerTPL`
und `Netzwerk/WebView2`.

**Teil 1: mehrere Klienten**

1. Der Server aus Aufgabe 4 bedient genau einen Klienten und beendet sich.
   Ändere ihn (in einem eigenen Konsolenprojekt, das auf deine Bibliothek
   verweist): Eine **Annahmeschleife** ruft `AcceptTcpClient()` immer wieder auf
   und gibt jeden angenommenen Klienten an eine eigene Task weiter, die ihn
   zeilenweise bedient (wie `BedieneEinenKlienten`, nur für den schon
   angenommenen Klienten).
2. Starte den Server in einem Terminal und zwei Klienten in zwei weiteren
   (zum Beispiel zwei Konsolenprogramme, die `Klient.Frage` aufrufen,
   oder `ncat 127.0.0.1 <Port>`). Beide Klienten müssen gleichzeitig
   verbunden sein und Antworten bekommen.
3. Überlege, wie du den Server sauber beendest (zum Beispiel
   `listener.Stop()` und das Abfangen der `SocketException` in der
   Schleife, Abbruchsignal).
4. Beantworte die offene Frage zum sequenziellen Server.

Tasks und Threads benutzt du hier nur als Werkzeug (`Task.Run(...)`); das
Wahlmodul Multithreading erklärt sie genauer, ist aber keine Voraussetzung.

**Teil 2: WebView2 (nur Windows)**

Baue eine kleine WPF-Anwendung (`net10.0-windows`) mit einem
`WebView2`-Steuerelement, das die lokale Adresse einer laufenden Seite anzeigt.
Beachte Abschnitt 21.4.1 (WebView2-Runtime) und 21.4.2.3 (was geschieht,
wenn die Runtime fehlt).
