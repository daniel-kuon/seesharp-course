# Publishing Applications

A program that runs during development has not yet been released. Chapter 23 (page 1637) describes the decisions that need to be made when releasing the program. The exercises for this level are quiz and review exercises: File lists and sizes depend on the computer and SDK, so no automated test checks them. The supervisor will compare your results with the actual output.

## Configuration and Target Framework (23.1.1 and 23.1.2, page 1637)

The compiler supports two configurations. **Debug** is the default for development: it’s easy to test, but not performance-optimized. **Release** is optimized (for example, by inlining short methods) but makes debugging more difficult; the Release build is the one that’s shipped. The `TargetFramework` in the project file (the Target Framework moniker, such as `net10.0`) specifies which APIs the project is built against and the minimum required .NET version. If the program requires operating system APIs, the operating system must be included in the moniker: `net10.0-windows` for a WPF application. With `TargetFrameworks` (plural), a project can be built for multiple targets; this is advanced knowledge and is not covered in the book.

## Target Runtime and Deployment Mode (23.1.4 and 23.1.5, pages 1643–1646)

The **Runtime Identifier** (RID) specifies the operating system and CPU architecture of the target computer: `win-x64`, `linux-x64`, `linux-arm64`, `osx-arm64`. For framework-dependent publications, it only affects the included Starter; for standalone and precompiled programs, it is critical. **“Framework-dependent”** means that a compatible .NET runtime must be installed on the target computer; the distribution consists of a `.dll` file, a starter, and configuration files, and is small (less than 140 KB in the book). **A** self-contained **build** includes the runtime; the example in the book grows from a few KB to 130 MB. In return, it runs on the target computer without installation, but must be republished for runtime updates.

## Single File and ReadyToRun (23.1.6 and 23.1.7, pages 1646–1649)

The standalone release in the book includes 191 files totaling 71.2 MB. `PublishSingleFile` combines them into a single file; `PublishTrimmed` removes unused code and significantly reduces the file size (not available for WPF; error NETSDK1168). **ReadyToRun** (R2R) precompiles the IL code into machine code for a specific target runtime: The program starts up faster, the file size increases, and it is not portable.

## Examples (23.2, pages 1649–1662)

The book publishes a console program as a trimmed single file and as an R2R single file for `win-x86`, `linux-x64`, and `osx-x64`; the command is `dotnet publish -r win-x64 -p:PublishSingleFile=true`. We replace the Visual Studio publishing profiles (23.1.3, page 1639) with `dotnet publish` in the terminal or in Rider. A web application is published locally as a folder and runs using the built-in Kestrel web server (default port 5000, HTTP only); the `launchSettings.json` file is missing from the publish folder. For online operation, a **reverse proxy** (IIS, Nginx, Apache) is usually set up in front of Kestrel (23.2.3.3, page 1662). IIS hosting options and the environment variables `ASPNETCORE_URLS` and `ASPNETCORE_ENVIRONMENT` are covered in the Microsoft documentation.
