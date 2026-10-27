# Using Reflection: Mappers, Callers, Plugins

Read **section 14.7.1**, **“Traditional Compensation via Type Parameters”** (pages 942–944) in the book: The `PersistenceHelper` example reads an attribute via reflection and uses `Activator.CreateInstance` to create an object whose type is not determined until runtime. The book only covers `Activator`; you’ll need two additional tools here:

- `PropertyInfo.GetValue(objekt)` reads a property, and `PropertyInfo.SetValue(objekt, wert)` writes a property. `SetValue` expects the value to be of the correct type; `Convert.ChangeType(text, p.PropertyType, CultureInfo.InvariantCulture)` converts text to that type.
- `MethodInfo.Invoke(objekt, parameter)` calls a method and returns its result as an `object?` (`null` for `void`). `GetMethod(name, Type.EmptyTypes)` searches for the overload without parameters.

Add the following to `Mapper.cs`, `Aufrufer.cs`, and `PluginFabrik.cs` (see the notes in the files). The `[Spalte("name")]` attribute and the `Kunde` class are predefined:

1. `Mapper.NachZeilen(o)`: every property with `[Spalte]` as `"name=wert"`, in the order they were declared (which is what `GetProperties()` returns in practice, although the documentation does not guarantee it); others are skipped. Format numbers using `CultureInfo.InvariantCulture` (`2.5`, not `2,5`).
2. `Mapper.VonZeilen<T>(zeilen)`: Create a `T` using `Activator.CreateInstance<T>()` and set the properties based on the lines. Unknown keys and lines without `=` are ignored; the first `=` is used as a delimiter. If a value cannot be converted (`FormatException`, `OverflowException`), the property remains unchanged; the remaining lines are still read.
3. `Aufrufer.Starte(o, methode)`: Call the public, parameterless instance method with this name. Return the result; return `null` if the method is `void`; return the text `"?"` if the name is unknown (no exception).
4. `PluginFabrik.Erzeuge(typname)`: Retrieve the type using `Type.GetType(typname)`. If the type does not exist, does not implement `IPlugin` (`typeof(IPlugin).IsAssignableFrom`), or is abstract (including interfaces), the result is `null`. Otherwise, create an instance.

The following tests must be passed:

- `ReflexionNutzenTests.NachZeilen_schreibt_nur_Spalten_in_Deklarationsreihenfolge`
- `ReflexionNutzenTests.NachZeilen_funktioniert_fuer_jeden_Typ_und_macht_null_zum_leeren_Text`
- `ReflexionNutzenTests.NachZeilen_formatiert_unabhaengig_von_der_Spracheinstellung`
- `ReflexionNutzenTests.VonZeilen_setzt_die_Eigenschaften_mit_umgewandelten_Werten`
- `ReflexionNutzenTests.VonZeilen_ignoriert_unbekannte_Schluessel_und_Zeilen_ohne_Gleichheitszeichen`
- `ReflexionNutzenTests.VonZeilen_teilt_am_ersten_Gleichheitszeichen`
- `ReflexionNutzenTests.VonZeilen_laesst_unlesbare_Werte_unveraendert_und_liest_den_Rest`
- `ReflexionNutzenTests.VonZeilen_liest_unabhaengig_von_der_Spracheinstellung`
- `ReflexionNutzenTests.Hin_und_zurueck_ergibt_dieselben_Werte`
- `ReflexionNutzenTests.Starte_liefert_das_Ergebnis_der_Methode`
- `ReflexionNutzenTests.Starte_waehlt_die_parameterlose_Ueberladung`
- `ReflexionNutzenTests.Starte_fuehrt_void_Methoden_aus_und_liefert_null`
- `ReflexionNutzenTests.Starte_liefert_ein_Fragezeichen_wenn_es_keine_passende_Methode_gibt`
- `ReflexionNutzenTests.Erzeuge_instanziiert_ein_Plugin_aus_dem_Typnamen`
- `ReflexionNutzenTests.Erzeuge_liefert_bei_jedem_Aufruf_ein_neues_Objekt`
- `ReflexionNutzenTests.Erzeuge_liefert_null_fuer_unbekannte_Typen`
- `ReflexionNutzenTests.Erzeuge_liefert_null_fuer_Typen_ohne_IPlugin`
- `ReflexionNutzenTests.Erzeuge_liefert_null_fuer_abstrakte_Typen_und_Interfaces`
