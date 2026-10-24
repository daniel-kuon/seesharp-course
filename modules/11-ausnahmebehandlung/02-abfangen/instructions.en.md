# Handling Exceptions

Read section **13.3**, **“The try Statement**,” in the book, especially **13.3.1** (page 890) on catch blocks, **13.3.2** (page 899) on execution sequences, and **13.5** (page 911) on the hierarchy of BCL exceptions.

Open *`Taschenrechner.cs`*. **The code won't compile at first.** That's on purpose: Read the compiler's error message; it will tell you what's wrong.

1. `Berechne(a, op, b)` converts two texts to `int` and calculates with `+ - * / %` in a `checked` context. The method is supposed to turn errors into fixed messages:
   - A text is not a number: `"Keine Zahl: <Text>"` (the text that doesn't fit),
   - Overflow (during conversion or calculation): `"Zahl zu groß"`,
   - Division by zero: `"Division durch null"`,
   - Any other `ArithmeticException`: `"Rechenfehler"`.

   An unknown operator is a programming error on the part of the caller: The `ArgumentException` should be propagated outward and not swallowed by an overly general `catch`. Fix the catch blocks: the order, the block that’s too broad, and the missing block for `ArithmeticException`, the common base class of `OverflowException` and `DivideByZeroException`. The `ArithmeticException` block remains the last one; no test triggers it.
2. `SummeAusText(text)` splits `"1;2;x;4"` by semicolons and adds the numbers. Each part has its own `try`/`catch` block so that an error in one part does not stop the others. The function returns the sum, the number of errors, and a list of the exception type names (`ex.GetType().Name`, e.g., `"FormatException"`) in the order in which they occurred.

## Quiz Text: Sequences (Textbook Exercise 13.8, No. 2)

```csharp
class Sequenzen {
    static int Calc(String instr) {
        int erg = 0;
        try {
            Console.WriteLine("try-Block von Calc()");
            erg = 10 % Int32.Parse(instr);
        } catch (FormatException) {
            Console.WriteLine("FormatException-Handler in Calc()");
        } finally {
            Console.WriteLine("finally-Block von Calc()");
        }
        Console.WriteLine("Nach der try-Anweisung in Calc()");
        return erg;
    }

    static void Main(string[] args) {
        try {
            Console.WriteLine("try-Block von Main()");
            Console.WriteLine("10 % " + args[0] + " = " + Calc(args[0]));
        } catch (ArithmeticException) {
            Console.WriteLine("ArithmeticException-Handler in Main()");
        } finally {
            Console.WriteLine("finally-Block von Main()");
        }
        Console.WriteLine("Nach der try-Anweisung in Main()");
    }
}
```

Then answer the question about this program.

Tests: `Berechne_rechnet_mit_ganzen_Zahlen`, `Berechne_meldet_Text_der_keine_Zahl_ist`, `Berechne_meldet_Ueberlauf`, `Berechne_meldet_Division_durch_null`, `Berechne_wirft_bei_unbekanntem_Operator_ArgumentException`, and the `SummeAusText_…` tests.
