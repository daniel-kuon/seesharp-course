# Rubrik — Webanwendung veröffentlichen (nur für die Betreuung)

- Das Buch (23.2.3) deckt die lokale Veröffentlichung und den Start mit
  Kestrel auf Port 5000 ab und nennt Reverse Proxys (IIS, Nginx, Apache). IIS
  in-process gegen out-of-process, `ASPNETCORE_URLS` und `ASPNETCORE_ENVIRONMENT`
  stammen aus der Microsoft-Dokumentation; mündlich vertiefen, nicht
  überbewerten.
- Review: Screenshot der laufenden Seite und Konsolenausgabe mit der Zeile
  "Now listening on: http://localhost:<Port>". Prüfen, dass der Server aus dem
  `publish`-Ordner und nicht per `dotnet run` gestartet wurde (Pfad in der
  Konsole, Zeile "Content root path").
- Nachfrage: Warum steht in der Konsole "Hosting environment: Production"?
  (Ohne `launchSettings.json` und ohne Umgebungsvariable ist die Umgebung
  Production.) Was ändert das? (Entwickler-Fehlerseite aus, `UseExceptionHandler`.)
- Nachfrage: Wozu dient der Reverse Proxy (TLS-Zertifikat an einer Stelle,
  mehrere Anwendungen hinter Port 443, Neustart einer Anwendung ohne Unterbruch
  der anderen)?
