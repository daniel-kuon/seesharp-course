# Rubrik — Inline-Arrays und Serienparameter mit Kollektionstyp (nur für die Betreuung)

- Kern: Ein Inline-Array ist eine Struktur, die ein Feld N-fach enthält; die
  Größe steht im Attribut, das Feld ist das einzige Instanzfeld. Es hat
  Wertsemantik (Kopie bei Zuweisung, Test `Puffer8_hat_Wertsemantik`), lässt
  sich indizieren und in einen Span umwandeln. Der Index wird zur Laufzeit
  geprüft (`IndexOutOfRangeException`).
- Serienparameter: `params` kennt seit C# 13 neben Arrays auch
  `ReadOnlySpan<T>`, `Span<T>`, `IEnumerable<T>`, `List<T>` u. a. Wichtig ist
  der Zusammenhang mit dem Quiz-Item: Mit `params ReadOnlySpan<int>` legt der
  Compiler die Argumente in einem Inline-Array auf dem Stack ab.
- Falle bei `params List<T>`: Übergibt man ein `T[]` an `Zaehle<T>`, gilt das
  Array als **ein** Element (T wird `T[]`); beim `params`-Array wäre es die
  Normalform. Genau deshalb braucht man bei Kollektionstypen die passende
  Kollektion. Das lohnt eine Nachfrage.
- Die Starterversion zeigt die Lage vor C# 13 (`params`-Array plus eigene
  Überladung für vorhandene Kollektionen, vgl. `Loga` im Buch 15.6.1); die
  Aufgabe ist das Zusammenführen. Buch 15.6.2 („Überladungen für alle Fälle")
  meint etwas anderes: zwei Serienparameter-Überladungen mit
  `IEnumerable<T>` und `ReadOnlySpan<T>`. Der Reflexionstest
  `Serienparameter_haben_Kollektionstypen` prüft Typ und Attribut
  (`ParamCollectionAttribute`) und schlägt bei einer zweiten Überladung fehl.
- Der Test prüft nur `Unsafe.SizeOf<Puffer8>() == 32`, keine Allokation.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Serienparameter mit Kollektionstyp` (Inline-Arrays: neu geschrieben).
