# Structures, Value Semantics, and Boxing

Read Section **6.1**, **“Structures”** (page 431), in the book, especially 6.1.1 (“Value Semantics,” page 434), 6.1.2 (Creation and Initialization, page 438), and 6.1.6 (Boxing, page 450). The quiz question regarding `o1 == o2` is Exercise 1 from 6.10 (page 537).

Open `Punkt.cs`. `Punkt` is still a **class** in the Starter; the tests expect a **structure**:

1. Replace `class` with `struct`. Everything else (the primary constructor, the properties, the chained parameterless constructor `: this(0, 0)`) may stay as it is.
2. Implement `Verschoben(Punkt p, double hor, double vert)`: For a structure, `p` is already a copy of the argument. Move it and return it; the caller's point remains unchanged.

In `PunktDemo.cs`, try out what `var p3 = p1; p1.Bewegen(1, 0);` does with `p3` when used with a class and when used with a structure. The test `Geboxte_Kopien_sind_unabhaengig` demonstrates the same thing with `object`: The assignment to `object` boxes and copies the value.
