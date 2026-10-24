# Eigene Ausnahmeklasse mit Zusatzinformationen

Lies im Buch **13.7 Ausnahmen definieren** (Seite 916) mit den Beispielen
`BadFaculArgException` und der Variante mit der `Data`-Kollektion, dazu
**13.5** (Seite 911) zu den Eigenschaften `InnerException` und `Data`.

Die Fakultät ist für negative Zahlen nicht definiert, und ab 21 passt das
Ergebnis nicht mehr in ein `long`. Ein Aufrufer soll beides genau erkennen
können und dazu das ungültige Argument erfahren.

1. Öffne `FakultaetArgumentException.cs`. Die Klasse soll von
   `ArgumentException` erben und die Eigenschaft `Argument` mit dem ungültigen
   Wert haben. Der Konstruktor `(int argument)` setzt die Meldung
   `"Fakultät nicht definiert für <argument>"`. Der Konstruktor
   `(int argument, Exception innerException)` setzt die Meldung
   `"Fakultät von <argument> ist zu groß"` und gibt die innere Ausnahme an die
   Basisklasse weiter.
2. In `Mathe.cs` ist die Berechnung `Fakultaet(int n)` vorgegeben (mit
   `checked`). Ergänze: Für `n < 0` wirft sie die neue Ausnahme. Löst die
   Rechnung eine `OverflowException` aus, wird diese abgefangen und als
   `InnerException` in einer `FakultaetArgumentException` weitergegeben.
3. `FakultaetMitData(int n)` löst das Problem ohne eigene Klasse: Für
   `n < 0` und `n > 20` wirft sie eine gewöhnliche `ArgumentException` (genau
   diese Klasse) und legt das Argument unter dem Schlüssel `"Argument"` in
   `ex.Data` ab.

Tests: `Eigene_Ausnahme_erbt_von_ArgumentException`,
`Konstruktor_mit_Argument_setzt_Eigenschaft_und_Standardmeldung`,
`Konstruktor_mit_innerer_Ausnahme_behaelt_sie`,
`Fakultaet_wirft_fuer_negative_Zahlen_die_eigene_Ausnahme`,
`Fakultaet_verpackt_den_Ueberlauf_als_InnerException`,
`Wer_ArgumentException_faengt_faengt_auch_die_eigene_Ausnahme` und
`FakultaetMitData_wirft_eine_gewoehnliche_ArgumentException_mit_Data`.
