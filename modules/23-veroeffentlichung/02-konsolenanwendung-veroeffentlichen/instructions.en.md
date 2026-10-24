# Publish a Console Application

Read sections **23.2.1 "Single-File Application**" (page 1649) and **23.1.5 "Deployment Mode**" (page 1644, only the *"framework-dependent"* part) in the book. The book shows the Visual Studio wizard there; in this exercise, you’ll use the command that the wizard executes in the background instead: `dotnet publish`. Exercise 4 in **Section 3.7** also asks for the files in a publication.

1. Select a console application from a previous level (or create a new one using `dotnet new console`).
2. Publish it to the project folder using `dotnet publish -c Release`. The result is located in `bin/Release/net10.0/publish`.
3. Launch it from there using `dotnet <Name>.dll` and `<Name>.exe`. First, use `dir` to see what's in the folder.
4. Answer the open-ended question using the file list and your assessment of what a customer needs to receive.

There are no tests: The files and sizes depend on the SDK and the computer. The supervisor will compare your answers with the actual output.
