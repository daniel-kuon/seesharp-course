# Rubrik — Zusatz: Zweite Reparatur (nur für die Betreuung)

Zusatzaufgabe zu Level 0. Die eingebauten Fehler:

1. `using system;` — C# unterscheidet Groß- und Kleinschreibung, der
   Namensraum heißt `System` (CS0246). Mit `ImplicitUsings` ist die Zeile
   sogar überflüssig; Löschen ist ebenfalls richtig.
2. `Console.Writeline(...)` — heißt `WriteLine` (CS0117).
3. `Console.Writeline(Text();` — schließende Klammer fehlt (CS1026).
4. `public static void Text()` mit `return "...";` — eine `void`-Methode darf
   keinen Wert zurückgeben (CS0127); richtig ist `string`. Erscheint je nach
   Reihenfolge zusammen mit CS1503 beim Aufruf in `WriteLine`.
5. Logikfehler: `Unterschrift()` liefert `Bis morgen` ohne Ausrufezeichen.
   Der Compiler ist zufrieden, erst der Test schlägt fehl.

Beim Review: Hat der Trainee die Fehlercodes notiert? Kann er erklären,
warum Fehler 5 kein Compilerfehler ist? Wie hätte er ihn ohne Test bemerkt?
(Programm starten und Ausgabe lesen.)

Modellantwort:

```csharp
using System;

public class Abschied {
    static void Main() {
        Console.WriteLine(Text());
        Console.WriteLine(Unterschrift());
    }

    public static string Text() {
        return "Tschüss, SeeSharp!";
    }

    public static string Unterschrift() {
        return "Bis morgen!";
    }
}
```
