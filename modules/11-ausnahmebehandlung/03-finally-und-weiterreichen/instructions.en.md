# finally, Rethrowing, and Wrapping

Read section **13.3.1.3 "Cleanup in the finally Block"** (page 895), **13.3.2** (page 899) on execution sequences, and **13.6 Throwing Exceptions** (page 913) regarding `throw;` and `InnerException`.

The file `Vorgaben.cs` contains an interface `IArbeitsschritt` and a class `Protokoll` (a list of text lines). Both are predefined. The tests provide small steps that either succeed or fail with an exception. Open `Ablauf.cs` and implement:

1. `Verarbeite(schritt, protokoll)` writes `"start"`, executes the step, and **always** writes `"ende"`—even after an error and even if there is a `return` in the `try` block: This belongs in a `finally` block. Depending on the exception, the following applies:
   - No error: Result is `true`.
   - `IOException` with a message beginning with `"temporär"`: The exception is ignored, the log shows `"ignoriert"`, and the result is `false`. Use an **exception filter** (`catch (…) when (…)`).
   - Any other `IOException`: Wrap it in an `InvalidOperationException` with the message `"Verarbeitung fehlgeschlagen"`. The original exception becomes its `InnerException`.
   - All other exceptions continue unchanged.
2. `ProtokolliereUndWirfWeiter(schritt, protokoll)` executes the step. If it fails, the method writes `"fehler: "` and the type name of the exception (`ex.GetType().Name`) to the log and rethrows **the same exception**. The test checks the stack trace: it must still name the method of the step that triggered the error. Using `throw ex;` would cause this information to be lost.

Then answer the two questions.

## Quiz Listing: Nested try Statements

```csharp
static void A() {
    try {
        Console.Write("A1 ");
        B();
        Console.Write("A2 ");
    } finally {
        Console.Write("A3 ");
    }
}

static void B() {
    try {
        Console.Write("B1 ");
        throw new InvalidOperationException();
    } catch (ArgumentException) {
        Console.Write("B2 ");
    } finally {
        Console.Write("B3 ");
    }
}

static void Main() {
    try {
        A();
        Console.Write("M1 ");
    } catch (InvalidOperationException) {
        Console.Write("M2 ");
    } finally {
        Console.Write("M3 ");
    }
    Console.Write("M4");
}
```

Tests: `Verarbeite_ohne_Fehler_schreibt_start_und_ende`, `Voruebergehende_IOException_wird_ignoriert`, `Andere_IOException_wird_verpackt_und_die_Ursache_bleibt_InnerException`, `Ende_wird_in_jedem_Fall_genau_einmal_geschrieben`, `ProtokolliereUndWirfWeiter_reicht_dieselbe_Ausnahme_weiter`, and `ProtokolliereUndWirfWeiter_erhaelt_die_Stapelueberwachung_des_Ursprungs`.
