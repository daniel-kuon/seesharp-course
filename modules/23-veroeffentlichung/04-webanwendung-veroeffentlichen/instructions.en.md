# Publish and Host a Web Application

Read section **23.2.3, "Web Application with ASP.NET Core Razor Pages**," in the book (page
1658) with **23.2.3.1 Local Installation** (page 1658), **23.2.3.2 Hosting,** and **23.2.3.3 Reverse Proxy** (page 1662). You already know section 22.2.2 (page
1553): it explains what `launchSettings.json` controls.

Answer the quiz questions. Then publish a web application yourself and run it from the publish folder:

1. `dotnet new webapp -o MeineWeb`
2. In `MeineWeb`: `dotnet publish -c Release`
3. In the `bin/Release/net10.0/publish` folder: `dotnet MeineWeb.dll --urls http://localhost:5123` (the option `--urls` sets the port; not in the book, given here)
4. Open the browser, take a screenshot of the page, and capture the console output.

There are no tests.

> **Deep Dive (optional):** Not in the book, material from the Microsoft documentation for further reading: IIS can host an ASP.NET Core application in the same process (in-process) or as a reverse proxy in front of Kestrel (out-of-process). The environment variables `ASPNETCORE_URLS` (addresses and ports) and `ASPNETCORE_ENVIRONMENT` (`Development`, `Production`) control a published application without `launchSettings.json`.
