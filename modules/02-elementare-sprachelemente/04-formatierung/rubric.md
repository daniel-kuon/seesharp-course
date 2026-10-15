# Rubrik — Zeichenketten und Formatierung (nur für die Betreuung)

- `SummeText`: Kann der Trainee erklären, warum `"3 + 2 = " + 3 + 2` zu `32`
  führt? (Linksassoziativ; ab dem ersten String ist `+` Verkettung.)
- `Ausgerichtet`: `{i,4}` und `{i,-4}` sind der Kern. Wer mit Leerzeichen
  von Hand auffüllt, besteht den Test, hat aber den Abschnitt nicht gelesen —
  nachhaken. Ein verbatim-Literal (`@"..."`) oder ein Raw-String ist eine
  gute Alternative; `\n` und `\t` müssen dann echte Umbrüche/Tabs sein.
- Zusatzfrage: Was ändert sich, wenn man `{d,8:f3}` für einen `double`
  schreibt?

Modellantwort (angelehnt an `Elementare Sprachelemente/FormAus` im
Tool-Repository):

```csharp
public static string SummeText() => "3 + 2 = " + (3 + 2);
public static string Bruchzeile(int zaehler, int nenner) => $"{zaehler}/{nenner}";
public static string Ausgerichtet(int i, int j, int k, int m) =>
    $"Rechtsbündig:\n\ti = {i,4}\n\tj = {j,4}\n\tk = {k,4}\n\tm = {m,4}" +
    $"\n\nLinksbündig:\n\t{i,-4} (i)\n\t{j,-4} (j)\n\t{k,-4} (k)\n\t{m,-4} (m)";
```
