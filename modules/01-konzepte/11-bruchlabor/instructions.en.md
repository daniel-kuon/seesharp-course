# Extra: Fraction Lab

Extra exercise: optional; it blocks nothing. You'll use the `Bruch` class from Chapter 1, without modifying it, and observe how objects respond to messages.

Read sections **1.3, "Object-Oriented Programming"** (page 9), and **1.5, "The Start Class and the Main() Method"** (page 12), in the book.

`Bruch.cs` is complete; **do not modify it**. A Bruch object has the properties `Zaehler` and `Nenner`, as well as the methods `Kuerze()`, `Addiere(Bruch b)`, and `Text()` (which returns, for example, `1/2`). You create a new object with `Bruch b = new Bruch();`, and you set a property with `b.Zaehler = 4;`.

Open `Bruchlabor.cs` and complete the three static methods. Each one generates its own fractions and returns `Text()` at the end:

1. `KuerzeVierAchtel()`: Create the fraction 4/8 and pass it to `Kuerze()`. Result: `1/2`.
2. `NennerNull()`: Create a fraction, set the numerator to 3 and **the denominator to 0**. What happens? The result is `3/1`. Check out `Bruch.cs` to see why.
3. `EinHalbPlusEinDrittel()`: Create two fractions, 1/2 and 1/3; send the message `Addiere(...)` to the first one using the second one. Result: `5/6`.

The following tests must be passed:

- `BruchlaborTests.Vier_Achtel_gekuerzt_ist_ein_Halb`
- `BruchlaborTests.Nenner_null_wird_abgelehnt`
- `BruchlaborTests.Ein_Halb_plus_ein_Drittel_ist_fuenf_Sechstel`
