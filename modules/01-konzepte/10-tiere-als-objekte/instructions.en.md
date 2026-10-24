# Extra: Animals as Objects

Extra exercise: optional; it blocks nothing. Level 1 is otherwise purely theoretical; here, you'll try out classes, objects, and messages in code for the first time.

Read sections **1.3**, "**Object-Oriented Programming**" (page 9), and **1.5, "Start Class and Main() Method**" (page 12) in the book. There, an object is created using `Bruch b = new Bruch();`, and `b.Kuerze()` sends it a message.

Open *`Tiere.cs`*. The *`Hund`* and *`Katze`* classes are blueprints; their methods do not have *`static`*, so they belong to the **objects**, not to the class. Complete the following:

1. `Hund`: `Name()` returns `Bello`, `Laut()` returns `Wuff`, and `StellDichVor()` returns `Bello sagt Wuff`, which calls `Name()` and `Laut()` (you concatenate strings using `+`).
2. `Katze`: same thing with `Minka` and `Miau`.
3. `Zoo.Konzert()` is `static`. Use `new` to create a dog and a cat inside it, and output `Bello sagt Wuff, Minka sagt Miau` by sending the `StellDichVor()` message to both objects.

The following tests must be passed:

- `TiereTests.Ein_Hund_heisst_Bello_und_sagt_Wuff`
- `TiereTests.Ein_Hund_stellt_sich_vor`
- `TiereTests.Eine_Katze_heisst_Minka_und_sagt_Miau`
- `TiereTests.Eine_Katze_stellt_sich_vor`
- `TiereTests.Im_Konzert_stellen_sich_beide_vor`
