# Extra: FizzBuzz

Extra exercise: optional; it blocks nothing. The classic job interview question—short, but the order of the conditions is key.

Read section **4.7.2.1**, **"if Statement**" (page 254), about the `else if` chain, and section **4.7.3.1, "Counter-Controlled Loop (for)**" (page 271).

Open `FizzBuzz.cs`:

1. `Wort(int zahl)` returns for a positive number
   - `FizzBuzz` if it is divisible by 3 **and** by 5,
   - `Fizz` if it is divisible only by 3,
   - `Buzz` if it is divisible only by 5,
   - otherwise, the number itself as text (`"7"`).

   Write this as an `if` / `else if` / `else` chain. Think about the order in which the cases should appear.
2. `Folge(int bis)` returns the words for 1 to `bis`, separated by one space each: `Folge(5)` returns `1 2 Fizz 4 Buzz`. There are no spaces at the beginning or end. Build the string in a `for` loop and call `Wort()` within it.

The following tests must be passed:

- `FizzBuzzTests.Gewoehnliche_Zahlen_bleiben_Zahlen`
- `FizzBuzzTests.Vielfache_von_3_sind_Fizz`
- `FizzBuzzTests.Vielfache_von_5_sind_Buzz`
- `FizzBuzzTests.Vielfache_von_15_sind_FizzBuzz`
- `FizzBuzzTests.Folge_bis_5`
- `FizzBuzzTests.Folge_bis_15`
- `FizzBuzzTests.Folge_bis_1`
