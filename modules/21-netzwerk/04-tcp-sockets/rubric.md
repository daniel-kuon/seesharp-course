# Rubrik — TCP-Server und -Klient (nur für die Betreuung)

- Kern: Ein TCP-Dialog ist ein Zeichenstrom ohne eingebaute Nachrichtengrenzen;
  das Zeilenende (`WriteLine`/`ReadLine`) ist hier die Grenze. `AutoFlush`
  und die `null`-Prüfung bei `ReadLine` sind die zwei klassischen Stolperstellen
  (Tests `Der_Server_antwortet_sofort_pro_Zeile...` und
  `Trennt_der_Klient_ohne_ENDE...`). Ohne `AutoFlush` hängt der Test bis zur
  Sicherheitsgrenze von 30 Sekunden und schlägt dann mit `TimeoutException` fehl.
- `Listener` mit Port 0: Nachfragen, warum die Tests so einen Port benutzen
  (keine Konflikte, parallele Testläufe, nichts von außen erreichbar).
- `using` an allen vier Stellen (Klient, Stream, Leser, Schreiber); Lecks sehen
  die Tests nicht. Nachfrage: Wer schließt die Verbindung beim Server nach
  `ENDE`? (Das `using` am Ende der Methode.)
- Überlauf: `ADD 2147483647 1` ergibt ohne `checked` still `-2147483648`;
  der Test fängt das. Die Zahl `99999999999` scheitert dagegen schon an
  `int.TryParse`.
- Kontext für das Gespräch zu Aufgabe 5: Der Server bedient nur einen Klienten
  und blockiert in `AcceptTcpClient()` und `ReadLine()`.
- `Antwort` ist öffentlich, damit die Rechenlogik ohne Netz getestet werden
  kann; Trennen von Protokolllogik und Ein-/Ausgabe ist ein guter Entwurf.

Modellantwort: `solution/` bzw. `samples/Netzwerk/Socket/TcpServer`, `TcpClient`,
`TcpClient mit verzögerter Rückmeldung`.
