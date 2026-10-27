# Publishing Applications

A program that runs during development has not yet been delivered. Chapter 23 (page 1637) describes the decisions that come up when publishing it. The exercises for this level are quiz and review exercises: File lists and sizes depend on the computer and SDK, so no automated test checks them. The supervisor will compare your results with the actual output.

## Configuration and Target Framework (23.1.1 and 23.1.2, page 1637)

The compiler supports two configurations. **Debug** is the default for development: it’s easy to test, but not performance-optimized. **Release** is optimized (for example, by inlining short methods) but makes debugging more difficult; the Release build is the one that’s shipped. The `TargetFramework` in the project file (the Target Framework moniker, such as `net10.0`) specifies which APIs the project is built against and the minimum required .NET version. If the program requires operating system APIs, the operating system must be included in the moniker: `net10.0-windows` for a WPF application.

## Target Runtime and Deployment Mode (23.1.4 and 23.1.5, pages 1643–1646)

The **Runtime Identifier** (RID) specifies the operating system and CPU architecture of the target computer: `win-x64`, `linux-x64`, `linux-arm64`, `osx-arm64`. For framework-dependent publications, it only affects the included launcher; for standalone and precompiled programs, it is critical. **“Framework-dependent”** means that a compatible .NET runtime must be installed on the target computer; the distribution consists of a `.dll` file, a starter, and configuration files, and is small (less than 140 KB in the book). **Self-contained** includes the runtime; the example in the book grows from a few KB to 130 MB. In return, it runs on the target computer without installation, but must be republished for runtime updates.

## Single File and ReadyToRun (23.1.6 and 23.1.7, pages 1646–1649)

The self-contained publication in the book includes 191 files totaling 71.2 MB. `PublishSingleFile` combines them into a single file; `PublishTrimmed` removes unused code and significantly reduces the file size (not available for WPF; error NETSDK1168). **ReadyToRun** (R2R) precompiles the IL code into machine code for a specific target runtime: The program starts up faster, the file size increases, and it is not portable.

## Examples (23.2, pages 1649–1662)

The book publishes a console program as a trimmed single file and as an R2R single file for `win-x86`, `linux-x64`, and `osx-x64`; the command for the trimmed single file is `dotnet publish -r win-x86 -p:PublishSingleFile=true -p:PublishTrimmed=true` (23.2.1, page 1652). We replace the Visual Studio publishing profiles (23.1.3, page 1639) with `dotnet publish` in the terminal or in Rider. A web application is published locally as a folder and runs using the built-in Kestrel web server (default port 5000, HTTP only); the `launchSettings.json` file is missing from the publish folder. For online operation, a **reverse proxy** (IIS, Nginx, Apache) is usually set up in front of Kestrel (23.2.3.3, page 1662): it receives the HTTP(S) requests from the Internet and forwards them to Kestrel.

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- **`TargetFrameworks`** (plural, for example `net10.0;net10.0-windows`) builds a project for several targets.
- **Hosting under IIS:** in the same process (in-process) or as a reverse proxy in front of its own Kestrel process (out-of-process). A reverse proxy often handles TLS encryption and distributes several applications behind port 443.
- **Environment variables** `ASPNETCORE_URLS` (addresses and ports Kestrel listens on) and `ASPNETCORE_ENVIRONMENT` (`Development`, `Production`) control a published application without `launchSettings.json`; `--urls` on the command line sets the addresses as well.
