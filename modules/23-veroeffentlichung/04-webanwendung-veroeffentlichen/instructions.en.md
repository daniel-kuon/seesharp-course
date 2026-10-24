# Publish and Host a Web Application

Read section **23.2.3, "Web Application with ASP.NET Core Razor Pages**," in the book (page
1658) with **23.2.3.1 Local Installation** (page 1658), **23.2.3.2 Hosting,** and **23.2.3.3 Reverse Proxy** (page 1662). Section 22.2.2 (page
1553) Have you seen this yet? It explains what `launchSettings.json` controls.

Answer the quiz questions. Then publish a web application yourself and run it from the publish folder:

1. `dotnet new webapp -o MeineWeb`
2. In `MeineWeb`: `dotnet publish -c Release`
3. In the `bin/Release/net10.0/publish` folder: `dotnet MeineWeb.dll --urls http://localhost:5123`
4. Open the browser, take a screenshot of the page, and capture the console output.

The questions about IIS hosting and environment variables go beyond the scope of the book; the explanations indicate where this is the case. There are no tests.
