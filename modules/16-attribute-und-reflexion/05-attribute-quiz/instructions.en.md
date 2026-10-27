# Attributes: Quiz

See sections **14.3 "Attributes for Assemblies"** (page 929), **14.5.2 "Conditional Method Execution Using ConditionalAttribute"** (page 935), **14.5.3 Preventing Debugger Stops,** and **14.5.5 Unions Using StructLayoutAttribute** (pages 937–940). The examples `ConditionalAttribute` and `DebuggerStepThrough` are located in the book’s Sample folder under `Attribute`.

Why no programming task? `[Conditional("DEBUG")]` depends on which symbols the compiler is using; that's determined by the build, not the test. Try it out in the sample project `ConditionalAttribute` anyway: it uses the symbol `Kontrollausgaben`. Comment out the line `#define Kontrollausgaben` at the top of the file and compare the output. (The symbol `DEBUG`, by contrast, is set automatically by the debug build, not by the release build.)

The open-ended question at the end is not automatically graded; write down one or two sentences and discuss them with your supervisor.
