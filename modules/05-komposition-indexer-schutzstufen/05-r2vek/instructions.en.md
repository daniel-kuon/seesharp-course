# Vectors in the Plane (R²)

Read **5.15 Exercises for Chapter 5** in the book, Exercise 4 (page 425). For reference: **4.5.2 Method Calls** (class `Math`, page 220).

The `R2Vek` class describes a vector with coordinates `X` and `Y`. Open `R2Vek.cs` and complete the following:

1. `Laenge`: calculated read-only property, the square root of `X² + Y²`. There is no field for this; the value is recalculated each time it is read.
2. `Normiere()`: Divides both coordinates by the length so that the vector has a length of 1. If the length is less than `1e-14`, nothing happens and the method returns `false`; otherwise, it returns `true`.
3. `Addiere(R2Vek)` modifies **this** vector; `Plus(R2Vek)` leaves both vectors unchanged and returns a **new** vector containing their sum.
4. `SP(R2Vek)`: Scalar product `X·X' + Y·Y'`.
5. `Winkel(R2Vek)`: Angle between two vectors in **degrees**. The cosine of the angle is the dot product divided by the product of the lengths; `Math.Acos` returns the angle in radians, and `double.RadiansToDegrees` performs the conversion.
6. `Drehe(double deg)`: rotates the vector `deg` degrees counterclockwise: `x' = cos·x − sin·y`, `y' = sin·x + cos·y`. Make a note of the old `X` value before you overwrite it, because `Y` still needs it.

The tests compare floating-point values within a certain tolerance; exact equality is not expected with the `double` data type (see Level 2).
