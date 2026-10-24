# Webanwendung veröffentlichen und hosten

Lies im Buch **23.2.3 Webanwendung mit ASP.NET Core Razor Pages** (Seite
1658) mit **23.2.3.1 Lokale Installation** (Seite 1658), **23.2.3.2 Hosting**
und **23.2.3.3 Reverse Proxy** (Seite 1662). Den Abschnitt 22.2.2 (Seite
1553) kennst du schon: Dort steht, was `launchSettings.json` regelt.

Beantworte die Quizfragen. Danach veröffentlichst du selbst eine
Webanwendung und startest sie aus dem Veröffentlichungsordner:

1. `dotnet new webapp -o MeineWeb`
2. In `MeineWeb`: `dotnet publish -c Release`
3. Im Ordner `bin/Release/net10.0/publish`:
   `dotnet MeineWeb.dll --urls http://localhost:5123`
4. Browser öffnen, Screenshot der Seite und Konsolenausgabe aufheben.

Die Fragen zu IIS-Hosting und zu den Umgebungsvariablen gehen über das Buch
hinaus; die Erklärungen sagen, wo das der Fall ist. Es gibt keine Tests.
