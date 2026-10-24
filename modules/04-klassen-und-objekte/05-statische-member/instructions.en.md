# Static Members

Read sections **5.8, "Static Members and Classes"** (page 373), through 5.8.4, "Static Constructors" (page 377), and **5.6, "Automatically Implemented Properties Instead of Explicit fields"** (page 367) in the book regarding the keyword `field`.

Open `Bruch.cs`. The class now uses automatically implemented properties without its own fields. Complete:

1. `Nenner` and `Etikett`: Complete the validation in the setter (ignore denominator 0, truncate the label to 40 characters). To do this, use the keyword field instead of an explicit `field`.
2. `Anzahl` counts the objects created: Increase the static property in **both** constructors. Its setter remains `private`.
3. Write a **static constructor** `static Bruch()` that sets `ZaehlerVoreinst` to a random number between 1 and 6 and `NennerVoreinst` to a random number between `ZaehlerVoreinst` and 8 (`Random.Next(min, max)`; `max` is excluded). The parameterless constructor already uses these default values.
4. `BenDef(string e)` is a static factory method: It creates a 0/1 fraction labeled `e`, has the user fill it in using `Frage()`, truncates it, and returns it. If `Frage()` fails, it returns `null`.

The following tests must be passed:

- `BruchTests.Nenner_ignoriert_null`
- `BruchTests.Etikett_wird_gekuerzt`
- `BruchTests.Anzahl_zaehlt_beide_Konstruktoren`
- `BruchTests.Standardkonstruktor_nutzt_Voreinstellungen_aus_statischem_Konstruktor`
- `BruchTests.BenDef_liefert_gekuerzten_Bruch_mit_Etikett`
- `BruchTests.BenDef_liefert_null_bei_ungueltiger_Eingabe`
