# Hello SeeSharp

This exercise checks whether your build chain is working: Rider opens the project, you build it, and the tests run. Before you begin, read sections **3.1.4, “Compiling Source Code to IL and Creating a Program”** (page 71), and **3.1.5**, **“Running the Program**” (page 74), in the book.

Open `Hallo.cs`. The `Hallo` class has a `Main` method that already calls `Gruss()`. Complete the static method `Gruss()` so that it returns exactly the text `Hallo, echt .NET hier!`

Run the program once using `Strg+F5` to see the output. Then set a breakpoint in `Main()` and run the program in debug mode.

The following tests must be passed:

- `HalloTests.Gruss_liefert_die_Begruessung`
- `HalloTests.Gruss_endet_mit_Ausrufezeichen`
