# Reading Attributes via Reflection

Read Section **14.2, “Evaluating Attributes via Reflection”** (page 924), through and including the `GetCustomAttributes` methods (page 929), and Exercise **14.9**, **Task 1** (page 947). Reflection means that a program retrieves the metadata of its types at runtime. The starting point is always a `Type` object, either at compile time using `typeof(T)` or at runtime using `objekt.GetType()`.

The `[Autor("Name")]` attribute is specified (for classes and methods; multiple instances allowed). The following evaluations are missing from `Dokumentation.cs`:

The book works with `Attribute.IsDefined`, `Attribute.GetCustomAttribute(s)` and `FindMembers`. This exercise uses shorter forms of the same ideas that are not in the book and are given here: the generic methods `GetCustomAttribute<T>()` and `GetCustomAttributes<T>()`, `IsDefined(type)` on the `MemberInfo`, `GetMethods(BindingFlags)` instead of `FindMembers`, and `GetProperties()` with `PropertyInfo.Name` and `PropertyType`. Each part names the exact call.

1. `AutorenVon(Type t)`: the names of all `[Autor]` attributes of a class, sorted. `t.GetCustomAttributes<AutorAttribute>()` returns all attribute objects (`using System.Reflection;`).
2. `MethodenMitAutor(Type t)`: the names of **the public instance methods** with the `[Autor]` attribute, sorted. `GetMethods(BindingFlags.Public | BindingFlags.Instance)` already filters out static and non-public methods, while `IsDefined(typeof(AutorAttribute))` checks for the attribute without instantiating it.
3. `Eigenschaften(Type t)`: For each public property, a text string in the format `"Name:Typ"` (e.g., `"Alter:Int32"`), sorted. `GetProperties()` returns `PropertyInfo` objects containing `Name` and `PropertyType`.
4. `TypName(object o)` uses `o.GetType().Name`, while `TypNameStatisch<T>()` uses `typeof(T).Name`. The tests show when the two methods return different results: when a variable's runtime type is more specific than its declared type.
5. `Veraltet(Type t)`: the message of the `[Obsolete]` attribute, or `null`. `GetCustomAttribute<ObsoleteAttribute>()` returns `null` if the attribute is missing.

Sort using `List<string>.Sort(StringComparer.Ordinal)`; this ensures that the order is correct regardless of the computer's language settings.

The following tests must be passed:

- `DokumentationTests.AutorenVon_liefert_alle_Autoren_sortiert`
- `DokumentationTests.AutorenVon_ohne_Attribute_ist_leer`
- `DokumentationTests.MethodenMitAutor_liefert_nur_oeffentliche_Instanzmethoden_mit_Autor`
- `DokumentationTests.MethodenMitAutor_ohne_Attribute_ist_leer`
- `DokumentationTests.Eigenschaften_liefert_Name_und_Typ_sortiert`
- `DokumentationTests.TypName_verwendet_den_Laufzeittyp`
- `DokumentationTests.TypNameStatisch_verwendet_den_Typparameter`
- `DokumentationTests.Laufzeittyp_und_statischer_Typ_koennen_sich_unterscheiden`
- `DokumentationTests.Veraltet_liefert_die_Meldung_des_Obsolete_Attributs`
- `DokumentationTests.Veraltet_liefert_null_ohne_das_Attribut`
