# Record Hierarchy: Missing Position Values

Read section **6.7.4, “Inheritance in Records”** (page 502), and Exercise 4 in section **7.16** (page 587).

`Figur` is a positional record that explicitly declares its parameters `X` and `Y` as properties in order to validate them with `CheckGE0`. `Kreis` inherits from it and adds `Radius`. However, the program `Program.cs` outputs `dx=0, dy=0, dr=30`: The position does not arrive.

1. Build the project and read the compiler warning for `Kreis.cs` (CS8907: Parameter not read). It explains the cause: The base class declaration `: Figur` calls the **parameterless** constructor of `Figur`, so the positional parameters `X` and `Y` of the circle are never passed.
2. Fix this with the smallest possible change in `Kreis.cs`: Pass the parameters to the primary constructor of the base class.

After that, the validation of the base also works for circles (`new Kreis(-1, 0, 1)` throws), and two circles with the same values are equal.
