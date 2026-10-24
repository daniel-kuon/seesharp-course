# Ausnahmen abfangen

Lies im Buch **13.3 Die try-Anweisung**, besonders **13.3.1** (Seite 890) mit
den catch-Blöcken, **13.3.2** (Seite 899) zu den Ablaufsequenzen und **13.5**
(Seite 911) zur Hierarchie der BCL-Ausnahmen.

Öffne `Taschenrechner.cs`. **Der Code kompiliert zunächst nicht.** Das ist Absicht:
Lies die Fehlermeldung des Compilers, sie sagt dir, was falsch ist.

1. `Berechne(a, op, b)` wandelt zwei Texte in `int` um und rechnet mit `+ - * / %`
   in einem `checked`-Kontext. Die Methode soll Fehler zu festen Meldungen
   machen:
   - ein Text ist keine Zahl: `"Keine Zahl: <Text>"` (der Text, der nicht passt),
   - Überlauf (beim Umwandeln oder beim Rechnen): `"Zahl zu groß"`,
   - Division durch null: `"Division durch null"`,
   - jeder andere `ArithmeticException`: `"Rechenfehler"`.

   Ein unbekannter Operator ist ein Programmierfehler des Aufrufers: Die
   `ArgumentException` soll nach außen gelangen und nicht von einem allzu
   allgemeinen `catch` verschluckt werden. Repariere die catch-Blöcke:
   Reihenfolge, der zu breite Block und der fehlende Block für
   `ArithmeticException`, die gemeinsame Basisklasse von `OverflowException` und
   `DivideByZeroException`. Der `ArithmeticException`-Block bleibt der letzte; kein
   Test löst ihn aus.
2. `SummeAusText(text)` zerlegt `"1;2;x;4"` an Semikolons und addiert die Zahlen.
   Jeder Teil bekommt sein eigenes `try`/`catch`, damit ein fehlerhafter
   Teil die anderen nicht stoppt. Geliefert werden die Summe, die Anzahl der Fehler
   und eine Liste mit den Typnamen der Ausnahmen (`ex.GetType().Name`, z. B.
   `"FormatException"`) in der Reihenfolge ihres Auftretens.

## Quiztext: Sequenzen (Buchaufgabe 13.8 Nr. 2)

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

Beantworte danach die Frage zu diesem Programm.

Tests: `Berechne_rechnet_mit_ganzen_Zahlen`, `Berechne_meldet_Text_der_keine_Zahl_ist`,
`Berechne_meldet_Ueberlauf`, `Berechne_meldet_Division_durch_null`,
`Berechne_wirft_bei_unbekanntem_Operator_ArgumentException` und die Tests
`SummeAusText_…`.
