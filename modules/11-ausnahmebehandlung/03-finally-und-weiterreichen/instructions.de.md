# finally, erneutes Werfen und Verpacken

Lies im Buch **13.3.1.3 Aufräumarbeiten im finally-Block** (Seite 895),
**13.3.2** (Seite 899) zu den Ablaufsequenzen und **13.6 Ausnahmen werfen**
(Seite 913) mit `throw;` und `InnerException`.

Die Datei `Vorgaben.cs` enthält ein Interface `IArbeitsschritt` und eine Klasse
`Protokoll` (eine Liste von Textzeilen). Beide sind vorgegeben. Die Tests
liefern kleine Arbeitsschritte, die gelingen oder mit einer Ausnahme scheitern.
Öffne `Ablauf.cs` und implementiere:

1. `Verarbeite(schritt, protokoll)` schreibt `"start"`, führt den Schritt aus
   und schreibt **immer** `"ende"`, auch nach einem Fehler und auch bei einem
   `return` im `try`: Das gehört in einen `finally`-Block. Je nach Ausnahme
   gilt:
   - Kein Fehler: Ergebnis `true`.
   - `IOException`, deren Meldung mit `"temporär"` beginnt: Die Ausnahme wird
     ignoriert, im Protokoll steht `"ignoriert"`, das Ergebnis ist `false`.
     Verwende einen **Ausnahmefilter** (`catch (…) when (…)`).
   - Jede andere `IOException`: Verpacke sie in eine
     `InvalidOperationException` mit der Meldung `"Verarbeitung fehlgeschlagen"`.
     Die ursprüngliche Ausnahme wird deren `InnerException`.
   - Alle anderen Ausnahmen laufen unverändert nach oben.
2. `ProtokolliereUndWirfWeiter(schritt, protokoll)` führt den Schritt aus.
   Scheitert er, schreibt die Methode `"fehler: "` und den Typnamen der Ausnahme
   (`ex.GetType().Name`) ins Protokoll und reicht **dieselbe Ausnahme** weiter.
   Der Test prüft die Stapelüberwachung: Sie muss weiter die Methode des
   Schritts nennen, der den Fehler ausgelöst hat. Mit `throw ex;` ginge
   das verloren.

Beantworte danach die beiden Fragen.

## Quizlisting: Verschachtelte try-Anweisungen

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

Tests: `Verarbeite_ohne_Fehler_schreibt_start_und_ende`,
`Voruebergehende_IOException_wird_ignoriert`,
`Andere_IOException_wird_verpackt_und_die_Ursache_bleibt_InnerException`,
`Ende_wird_in_jedem_Fall_genau_einmal_geschrieben`,
`ProtokolliereUndWirfWeiter_reicht_dieselbe_Ausnahme_weiter` und
`ProtokolliereUndWirfWeiter_erhaelt_die_Stapelueberwachung_des_Ursprungs`.
