# Extra: Comparing and Sorting Shapes

Extra exercise: optional; it unlocks nothing. For further reading: **9.1.1.2 Concrete Instance Methods** (page 616), **9.2.1 Example IComparable<T>** (page 640) and **9.1.4 Inheritance and Extension of Interfaces** (page 631).

Circles, rectangles, and triangles should be sortable by area. Instead of writing `CompareTo` three times, the interface provides the implementation right away. Open `IForm.cs`:

1. Add the `double Umfang { get; }` property to `IForm` (`Flaeche` is already there) and extend the `IComparable<IForm>` interface: `public interface IForm : IComparable<IForm>`.
2. Implement `CompareTo` **in the interface** as a concrete member. Because `CompareTo` is part of `IComparable<IForm>`, the interface name precedes it (as in the explicit implementation): `int IComparable<IForm>.CompareTo(IForm? other) => ...`. Compare the areas; `null` is considered less than any form.
3. `Kreis(radius)`, `Rechteck(breite, hoehe)`, and `Dreieck(a, b, c)` implement only `Flaeche` and `Umfang`; they inherit `CompareTo` from the interface. The triangle area uses Heron's formula: `s = (a + b + c) / 2`, area `√(s·(s−a)·(s−b)·(s−c))`. Sides that do not form a triangle (one side is not shorter than the other two combined) throw an `ArgumentException` in the constructor.
4. `Formen.Sortiert(formen)` returns a **new** copy sorted in ascending order by area (the original remains unchanged; `Array.Sort` helps because `IForm` is now comparable). `Formen.Groesste(formen)` returns the shape with the largest area, or `null` for an empty array.

The following tests must be passed:

- `FormenVergleichenTests.IForm_erweitert_IComparable`
- `FormenVergleichenTests.Flaeche_und_Umfang`
- `FormenVergleichenTests.Ungueltiges_Dreieck_wirft`
- `FormenVergleichenTests.CompareTo_vergleicht_die_Flaechen`
- `FormenVergleichenTests.CompareTo_steckt_im_Interface`
- `FormenVergleichenTests.Sortiert_liefert_eine_sortierte_Kopie`
- `FormenVergleichenTests.Groesste_findet_die_groesste_Form`
