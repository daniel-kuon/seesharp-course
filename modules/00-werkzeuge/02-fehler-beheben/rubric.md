# Rubrik — Compilerfehler beheben (nur für die Betreuung)

Die vier eingebauten Fehler:

1. `static void main()` — Kleinbuchstabe, kein Einstiegspunkt (CS5001, erscheint
   erst, wenn die Syntaxfehler weg sind).
2. `Console.WriteLn(...)` — Methode heißt `WriteLine` (CS0117).
3. Fehlendes Semikolon hinter der Zuweisung an `gruss` (CS1002).
4. `return grus;` — Tippfehler, Variable heißt `gruss` (CS0103).

Beim Review fragen: In welcher Reihenfolge hat der Trainee die Fehler
gefunden? Hat er die Fehlerliste gelesen oder nur die roten Unterstreichungen
abgeklappert? Was ist der Unterschied zwischen CS5001 und den anderen drei?

Modellantwort (kein Sample im Tool-Repository):

```csharp
using System;

public class Hallo {
    static void Main() {
        Console.WriteLine(Gruss());
    }

    public static string Gruss() {
        string gruss = "Moin, SeeSharp!";
        return gruss;
    }
}
```
