# Tools and First Project

Before you can write a single line of C#, you need to set up your toolchain: the .NET SDK, a development environment, and a basic understanding of what happens when you build and run a program. Chapter 3 (starting on page 61) of this book covers the command line, Visual Studio, and VS Code. In this course, we’ll be working with **JetBrains Rider**; the concepts are the same, only the menu names are different. Therefore, be sure to read Section 3.1 (.NET SDK, page 61) thoroughly and use the IDE sections 3.3 and 3.5 only for orientation.

## The .NET SDK (3.1.1, page 61)

The SDK includes a compiler, a runtime environment, and the `dotnet` command-line tool. Use `dotnet --list-sdks` to see which versions are installed. If multiple versions are available, `dotnet` uses the latest one, unless a `global.json` file in the project folder or a higher-level folder specifies a particular version. That’s exactly what SeeSharp does: The `global.json` file in the course folder ensures that all exercises are built using the same SDK.

## Create, Build, and Start a Project (3.1.2 through 3.1.5, pages 65 through 74)

`dotnet new console -n Hallo` creates a console project: a project file named `Hallo.csproj` and a source code file. The project file describes what is being built (target framework, output type), while the `.cs` files contain the code. A **solution** (`.sln` or `.slnx`) groups multiple projects together; Rider opens both solutions and projects.

`dotnet build` compiles the source code into IL code and stores the result in `bin/`; `obj/` contains only intermediate results and can be deleted at any time. `dotnet run` builds and runs the application in a single step. The following files must be deployed from the `bin/` directory: the `.dll` file containing the IL code, the `.exe` file as a startup helper for Windows, and the `.runtimeconfig.json` file, which tells the runtime environment which .NET version the program requires. The `.pdb` file is intended solely for the debugger.

## Reading Program Errors (3.1.6, page 76)

The book distinguishes between three types of errors: The compiler reports **syntax errors** by providing the filename, line number, column number, and a code such as `CS1002`; the program doesn’t even compile. **Runtime errors** occur during execution and terminate the program with an exception. **Logical errors** run through the program but produce incorrect results; they can only be detected through testing or using the debugger. Get into the habit of reading the line number first and then the error code when you encounter a compiler error; the message is almost always more precise than it appears at first glance.

## The Process in SeeSharp

Each programming exercise in SeeSharp consists of a **starter project**, which you open and edit in Rider, and a **test project** that checks your results. The process is always the same:

1. Open the exercise in SeeSharp, read the instructions, and read the section of the book mentioned.
2. Click “Open in Rider”; Rider will open the file containing the task.
3. Write the code, press `Strg+F5`, or click the Run button to test it.
4. In SeeSharp, click “Submit.” SeeSharp copies your code to a clean directory, runs the tests, and shows whether each test passed.
5. Reviewing red tests: The test name indicates what was expected; the message shows the expected value and the actual value. Correct the test and resubmit it.

You can run the tests in the "Starter" folder directly in Rider (right-click the test project, then select "Run Unit Tests"). However, only the copy that SeeSharp runs counts toward the evaluation.

## Stops in Rider

The book describes the debugger for Visual Studio (3.3.9, page 126). In Rider, you set a breakpoint by clicking to the left of the line number, start debugging by clicking the bug icon (Debug), and view the current values in the “Variables” window. `F10` executes the next line; `F11` jumps into a method call. Try this out right away in the first exercise: set a breakpoint in `Main()`, start debugging, and view the variables.

## What is expected of you in this level

Two short programming exercises and a quiz. The first exercise simply checks whether the toolchain is set up correctly: a method that returns a greeting. The second exercise contains a program that’s intentionally broken, which you’ll fix based on the compiler messages. The quiz covers SDK selection, project structure, and output files.
