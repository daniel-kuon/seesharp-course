# Rückgabecode, Ausnahme oder Try-Muster

Lies im Buch **13.4 Ausnahmeobjekte im Vergleich zur Fehlerkommunikation per
Rückgabe** (Seite 905), besonders **13.4.4** (Seite 910) zur Wahl nach der
Fehlerwahrscheinlichkeit, und **13.5 Ausnahmeklassen in der BCL** (Seite 911).
Die Übungsaufgabe **13.8 Nr. 1** (Seite 920) ist die offene Frage am Ende.

Die Datei `Bruch.cs` mit einem unveränderlichen `Bruch` ist vorgegeben (ein
Nenner 0 löst dort eine `ArgumentException` aus). Öffne `BruchParser.cs` und
implementiere dieselbe Aufgabe auf mehreren Wegen:

1. `Parse(string s)` wandelt `"3/4"` in einen `Bruch` um. Ein ungültiges Format
   (`"3/"`, `"a/b"`, `""`, mehr als ein Schrägstrich) löst eine
   `FormatException` aus, der Nenner 0 (`"1/0"`) eine `ArgumentException`
   (sie kommt vom `Bruch`-Konstruktor), Zahlen jenseits des `int`-Bereichs
   eine `OverflowException` (sie kommt von `int.Parse`).
2. `TryParse(string? s, out Bruch? ergebnis)` ist das **Try-Muster**: Es liefert
   `true` und den Bruch oder `false` und `null`. Es wirft für **keine** Eingabe eine
   Ausnahme, auch nicht für `null`, zu große Zahlen oder `"1/0"`. Die Tests
   probieren viele schlechte Eingaben.
3. `TeileRc(a, b, out ergebnis)` meldet per **Rückgabecode**: `0` für Erfolg,
   `1` für Division durch null (dann ist `ergebnis` 0). `Teile(a, b)` rechnet
   einfach und löst bei `b == 0` eine `DivideByZeroException` aus.
4. `ParseAlleMitAusnahmen(string[])` und `ParseAlleMitTry(string[])` zählen
   gültige und ungültige Eingaben, die erste mit `Parse` und `try`/`catch`, die
   zweite mit `TryParse`. Beide müssen dasselbe Ergebnis liefern. Du siehst,
   welche der beiden den Code übersichtlicher hält und welche bei vielen
   Fehlern viele Ausnahmeobjekte erzeugt. Die Zeit wird nicht gemessen.

Beantworte danach die Fragen: Welche Technik passt zu fünf Szenarien, welche
BCL-Ausnahme zu fünf Situationen, und die offene Frage zum `try`-Syntaxdiagramm.

Tests: `Parse_wirft_FormatException_bei_ungueltigem_Format`,
`Parse_wirft_ArgumentException_bei_Nenner_null`,
`TryParse_liefert_false_und_wirft_nie`,
`TeileRc_meldet_Division_durch_null_mit_1`,
`Teile_liefert_das_Ergebnis_und_wirft_bei_null` und
`ParseAlle_zaehlt_gueltige_und_ungueltige_Eingaben`.
