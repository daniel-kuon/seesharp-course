# Single File and ReadyToRun

Read section **23.1.6, “Compiling into a Single File”** (page 1646), **23.1.7 ReadyToRun Compilation** (page 1648), and the examples **23.2.1 Single-File Application** (page 1649) and **23.2.2 ReadyToRun Single-File Application** (page 1652). The book is published using the wizard and additionally with `PublishTrimmed`; you use the command-line command `dotnet publish` with the options from the manifest (without trimming).

Publish the console program from the previous exercise in three versions and compare them:

| Variant | Options |
|---|---|
| framework-dependent | `-c Release` |
| Standalone, single file | `-r win-x64 --self-contained -p:PublishSingleFile=true` |
| Standalone, single file, ReadyToRun | additionally `-p:PublishReadyToRun=true` |

If your computer isn't running Windows x64, select the appropriate runtime identifier (`linux-x64`, `osx-arm64`, ...). The first release with a new target runtime can download packages from the Internet.

Enter the number of files and their sizes into a table and explain the differences. There are no tests; the numbers depend on the SDK. The supervisor will compare them with the order-of-magnitude figures from 23.2.1 and 23.2.2.
