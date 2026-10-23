# Rubrik — Zusatz: Ziffern und Uhrzeit (nur für die Betreuung)

Zusatzaufgabe zu Level 2: Ganzzahldivision und Modulo als Werkzeug statt als
Falle.

- `Quersumme`: `n / 100 + n / 10 % 10 + n % 10`. Nachfragen, warum
  `n / 10 % 10` ohne Klammern funktioniert (gleicher Rang, links nach rechts).
- `Umgedreht`: `n % 10 * 100 + n / 10 % 10 * 10 + n / 100`.
- `IstGerade`: `n % 2 == 0`. Wer `n % 2 == 1` für ungerade prüft, irrt bei
  negativen Zahlen (`-3 % 2` ist `-1`) — der Test mit `-3` und `-4` zeigt das
  indirekt; gut zum Besprechen.
- `Uhrzeit`: `{h:d2}` oder `{h:00}` — beides gilt. Wer mit `?:` eine Null
  davorsetzt, hat den Formatabschnitt nicht gelesen.

Modellantwort:

```csharp
public static int Quersumme(int n) => n / 100 + n / 10 % 10 + n % 10;
public static int Umgedreht(int n) => n % 10 * 100 + n / 10 % 10 * 10 + n / 100;
public static bool IstGerade(int n) => n % 2 == 0;
public static string Uhrzeit(int sekunden) =>
    $"{sekunden / 3600:d2}:{sekunden / 60 % 60:d2}:{sekunden % 60:d2}";
```
