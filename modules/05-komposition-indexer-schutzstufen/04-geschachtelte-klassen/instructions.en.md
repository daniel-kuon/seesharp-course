# Nested Classes

Read Section **5.11**, "**Nested Classes,"** in the book (page 391).

The `Familie` class has a `Tochter` and a `Sohn`; both classes are declared **within** `Familie`. The advantage: They can access the family's private `name` field, even though it is private. `Sohn` is complete and serves as a template.

Open `Familie.cs` and complete the following:

1. The nested class `Tochter`: same as `Sohn`, but **private** (not `public`) and with the text `"Ich bin die <alter>-jährige Tochter <name> von Familie <Familienname>."` The family name comes from `f.name`, not from a separate field.
2. `Familie.Informiere()` returns three lines, separated by `\n`: the heading `"Die Kinder von Familie <name>:"`, followed by the line for the daughter, and then the line for the son.

Note the primary constructors (`class Sohn(Familie f, string name, int alter)`): The parameters are assigned to `readonly` fields so that they are available not only in the constructor but in all methods.
