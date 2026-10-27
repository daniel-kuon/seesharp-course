# Extra exercise: A rectangle owns its points

This exercise is optional. It explores composition in greater depth: An object contains other objects and protects them from external access. For further reading: **5.10 Aggregation and Composition** (page 388).

`Punkt` is ready. A `Rechteck` (parallel to the axes) consists of two `Punkt` objects: the bottom-left and top-right corners. Because `Punkt` is a class—that is, a reference type—the rectangle must be careful: if it simply stored the passed-in points, the caller could later manipulate the rectangle using its own reference.

Open `Rechteck.cs` and complete the following:

1. The constructor takes **any** two opposite corners and creates **its own** points: the bottom-left corner with the smaller coordinates and the top-right corner with the larger ones. `Math.Min(a, b)` returns the smaller and `Math.Max(a, b)` the larger of two numbers (not in the book, given here; a `?:` from Level 2 works as well).
2. `LinksUnten` and `RechtsOben` return **copies** (`Klone()`) to ensure that the getter doesn't open a backdoor either.
3. `Breite`, `Hoehe`, `Flaeche`, and `Umfang` are calculated properties.
4. `Enthaelt(p)`: Is `p` inside the rectangle? The border is included.
5. `Verschiebe(dx, dy)` delegates to `Verschiebe` of the two points.
6. `Schnitt(r)` returns the overlap as a **new** rectangle: the left side is the larger of the two left ends, the right side is the smaller of the two right ends, and the top and bottom sides are determined accordingly. If there is no positive width or height remaining, the method returns `null`; that is why the return type is `Rechteck?` (book page 338, footnote; it is covered in detail in chapter 15.1.1). Both rectangles remain unchanged.
7. `ToString()` returns `"[(1; 2), (4; 6)]"` (use `Punkt.ToString`).

The following tests must be passed:

- `RechteckTests.Konstruktor_ordnet_die_Ecken`
- `RechteckTests.Rechteck_haengt_nicht_an_den_uebergebenen_Punkten`
- `RechteckTests.Eckpunkte_werden_als_Kopie_geliefert`
- `RechteckTests.Breite_Hoehe_Flaeche_Umfang`
- `RechteckTests.Enthaelt_innen_auf_dem_Rand_und_aussen`
- `RechteckTests.Verschiebe_bewegt_beide_Ecken`
- `RechteckTests.Schnitt_liefert_die_Ueberlappung`
- `RechteckTests.Schnitt_ohne_Ueberlappung_oder_bei_Beruehrung_ist_null`
- `RechteckTests.Schnitt_mit_enthaltenem_Rechteck_ist_das_innere`
