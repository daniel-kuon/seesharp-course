# Zusatz: FizzBuzz

Zusatzaufgabe: freiwillig, sie blockiert nichts. Der Klassiker aus
Bewerbungsgesprächen — kurz, aber die Reihenfolge der Bedingungen
entscheidet.

Lies im Buch **4.7.2.1 if-Anweisung** (Seite 254) zur `else if`-Kette und
**4.7.3.1 Zählergesteuerte Schleife (for)** (Seite 271).

Öffne `FizzBuzz.cs`:

1. `Wort(int zahl)` liefert für eine positive Zahl
   - `FizzBuzz`, wenn sie durch 3 **und** durch 5 teilbar ist,
   - `Fizz`, wenn sie nur durch 3 teilbar ist,
   - `Buzz`, wenn sie nur durch 5 teilbar ist,
   - sonst die Zahl selbst als Text (`"7"`).

   Schreibe das als `if` / `else if` / `else`-Kette. Überlege dir, in welcher
   Reihenfolge die Fälle stehen müssen.
2. `Folge(int bis)` liefert die Wörter für 1 bis `bis`, getrennt durch je ein
   Leerzeichen: `Folge(5)` ist `1 2 Fizz 4 Buzz`. Kein Leerzeichen am Anfang
   oder Ende. Baue die Zeichenkette in einer `for`-Schleife auf und rufe
   darin `Wort()` auf.

Diese Tests müssen bestehen:

- `FizzBuzzTests.Gewoehnliche_Zahlen_bleiben_Zahlen`
- `FizzBuzzTests.Vielfache_von_3_sind_Fizz`
- `FizzBuzzTests.Vielfache_von_5_sind_Buzz`
- `FizzBuzzTests.Vielfache_von_15_sind_FizzBuzz`
- `FizzBuzzTests.Folge_bis_5`
- `FizzBuzzTests.Folge_bis_15`
- `FizzBuzzTests.Folge_bis_1`
