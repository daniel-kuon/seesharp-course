# Rubrik — Fehlersuche in Verzweigungen (nur für die Betreuung)

- `Gewinn`: Hat der Trainee das dangling else erkannt oder nur so lange
  umgestellt, bis die Tests grün waren? Erklären lassen, warum die Einrückung
  des Starters lügt.
- `Beschreibe`: `=` statt `==`. Rider zeigt eine Warnung (CS0665); darauf
  hinweisen, dass Warnungen gelesen werden wollen. Idiomatisch ist `if (!b)`
  oder `if (b == false)`.
- Alternative mit `?:` für `Beschreibe` ist willkommen.

Modellantwort (kein Sample im Tool-Repository):

```csharp
public static int Gewinn(int losNr) {
    if (losNr % 13 == 0)
        return 100;
    else if (losNr % 7 == 0)
        return 1;
    else
        return 0;
}

public static string Beschreibe(bool b) {
    if (b == false)
        return "b ist False";
    else
        return "b ist True";
}
```
