# Erweiterungsmitglieder (C# 14)

Lies im Buch **7.15 Erweiterungsmitglieder** (Seite 581): 7.15.1 generelle
Regeln (Seite 582), 7.15.2 Erweiterungsblöcke ab C# 14 (Seite 583) und
7.15.3 Erweiterungsmethoden mit `this`-Parameter (Seite 585). Das ist
neues C#-14-Material; im Netz findest du dazu noch wenig, das Buch ist die
Quelle.

Mit Erweiterungsmitgliedern rüstest du fremde Typen nach, sogar versiegelte
wie `double` oder `string`. Öffne `DoubleExtensions.cs`; die Blöcke stehen
schon, die Rümpfe fehlen:

1. Im Block `extension(double arg)` (Instanzmitglieder, `arg` ist der
   Empfänger): `High(expo)` liefert `Math.Pow(arg, expo)`; `NumEquals(other)`
   prüft, ob die relative Abweichung `|arg − other| / |arg|` unter
   `double.DiffThreshold` liegt; `EqualsPi` nutzt `NumEquals` mit `Math.PI`.
2. Im Block `extension(double)` (statische Mitglieder, kein Empfänger):
   `DiffThreshold` ist `1.0e-14`, `NumEqualsPi(arg)` ruft `arg.NumEquals`,
   und der Operator `^` potenziert (`2.0 ^ 3.0` ergibt 8).
3. In `StringExtensions`: `Empty(this string? arg)` ist eine klassische
   Erweiterungsmethode (`true` nur für einen leeren, nicht-null String);
   `NullOrEmpty` im Erweiterungsblock ist `true` für `null` oder leer.

Beachte: `s.Empty()` funktioniert auch, wenn `s` null ist, denn in
Wirklichkeit wird `StringExtensions.Empty(s)` aufgerufen.
