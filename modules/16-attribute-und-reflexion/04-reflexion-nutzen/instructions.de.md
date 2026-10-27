# Reflexion nutzen: Mapper, Aufrufer, Plugins

Lies im Buch **14.7.1 Traditionelle Kompensation per Type-Parameter** (Seite
942 bis 944): Das Beispiel `PersistenceHelper` liest ein Attribut per
Reflexion und erzeugt mit `Activator.CreateInstance` ein Objekt, dessen Typ
erst zur Laufzeit feststeht. Das Buch zeigt nur `Activator`; zwei weitere
Werkzeuge brauchst du hier zusätzlich:

- `PropertyInfo.GetValue(objekt)` liest und `PropertyInfo.SetValue(objekt, wert)`
  schreibt eine Eigenschaft. `SetValue` erwartet den Wert im richtigen Typ;
  aus Text macht ihn `Convert.ChangeType(text, p.PropertyType,
  CultureInfo.InvariantCulture)`.
- `MethodInfo.Invoke(objekt, parameter)` ruft eine Methode auf und liefert
  ihr Ergebnis als `object?` (`null` bei `void`). `GetMethod(name,
  Type.EmptyTypes)` sucht die Überladung ohne Parameter.

Ergänze in `Mapper.cs`, `Aufrufer.cs` und `PluginFabrik.cs` (Hinweise in den
Dateien). Das Attribut `[Spalte("name")]` und die Klasse `Kunde` sind
vorgegeben:

1. `Mapper.NachZeilen(o)`: jede Eigenschaft mit `[Spalte]` als
   `"name=wert"`, in Deklarationsreihenfolge (die liefert `GetProperties()` in
   der Praxis, garantiert ist sie laut Dokumentation nicht), andere übersprungen. Zahlen
   mit `CultureInfo.InvariantCulture` formatieren (`2.5`, nicht `2,5`).
2. `Mapper.VonZeilen<T>(zeilen)`: mit `Activator.CreateInstance<T>()` ein
   `T` erzeugen und die Eigenschaften aus den Zeilen setzen. Unbekannte
   Schlüssel und Zeilen ohne `=` werden ignoriert, geteilt wird am ersten
   `=`. Ein Wert, der sich nicht umwandeln lässt (`FormatException`,
   `OverflowException`), lässt die Eigenschaft unverändert; die übrigen Zeilen
   werden trotzdem gelesen.
3. `Aufrufer.Starte(o, methode)`: die öffentliche, parameterlose
   Instanzmethode dieses Namens aufrufen. Ergebnis zurückgeben, bei `void`
   `null`, bei unbekanntem Namen den Text `"?"` (keine Ausnahme).
4. `PluginFabrik.Erzeuge(typname)`: den Typ mit `Type.GetType(typname)`
   holen. Gibt es ihn nicht, implementiert er `IPlugin` nicht
   (`typeof(IPlugin).IsAssignableFrom`) oder ist er abstrakt (auch
   Interfaces), ist das Ergebnis `null`. Sonst eine Instanz erzeugen.

Diese Tests müssen bestehen:

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
