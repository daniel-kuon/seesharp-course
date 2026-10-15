# Rubrik — Primzahltest, switch-Ausdruck, foreach (nur für die Betreuung)

- `IstPrim` ohne `break`: Das Flag `teilerGefunden` gehört in die
  Schleifenbedingung (`tk <= wurzel && !teilerGefunden`). Wer stattdessen
  `return false` in der Schleife schreibt, hat die Aufgabe elegant umgangen —
  gelten lassen, aber über die Absicht der Aufgabe sprechen.
- Wurzel: `Math.Sqrt(n)` mit Cast oder `tk * tk <= n`; letzteres vermeidet
  Gleitkomma ganz.
- `Wochentag`: Der Discard `_` im switch-Ausdruck ist Pflicht, sonst wirft
  der Ausdruck bei 8.
- `AnzahlVokale`: `char.ToLower(c)` oder `"aeiouAEIOU".Contains(c)`.

Modellantwort (angelehnt an `Elementare Sprachelemente/PrimitivOBC` im
Tool-Repository):

```csharp
public static bool IstPrim(long n) {
    if (n < 2)
        return false;
    bool teilerGefunden = false;
    for (long tk = 2; tk * tk <= n && !teilerGefunden; tk++)
        if (n % tk == 0)
            teilerGefunden = true;
    return !teilerGefunden;
}

public static string Wochentag(int tag) => tag switch {
    1 => "Montag", 2 => "Dienstag", 3 => "Mittwoch", 4 => "Donnerstag",
    5 => "Freitag", 6 => "Samstag", 7 => "Sonntag", _ => "ungültig"
};

public static int AnzahlVokale(string text) {
    int anzahl = 0;
    foreach (char c in text)
        if ("aeiou".Contains(char.ToLower(c)))
            anzahl++;
    return anzahl;
}
```
