# Inline-Arrays und Serienparameter mit Kollektionstyp

Lies im Buch **15.5 Inline-Array** (Seite 1005) und **15.6 Serienparameter
mit Kollektionstyp** (Seite 1008) mit **15.6.1** und **15.6.2**
(Überladungen für alle Fälle, Seite 1010).

Öffne `Puffer.cs` und `Serie.cs`.

1. `Puffer8` ist eine Struktur mit einem `int`-Feld. Mach daraus mit dem
   Attribut `[InlineArray(8)]` ein Inline-Array für acht `int`-Werte (32 Byte,
   direkt in der Struktur, kein Array-Objekt). Dann lässt sie sich wie ein
   Array indizieren (`p[i]`) und einem `Span<int>` zuweisen.
2. `Puffer8Werkzeuge.Fuelle(ref Puffer8, int start)` schreibt `start`,
   `start + 1`, ... in die acht Plätze. `Summe(in Puffer8)` summiert über
   einen Span (`ReadOnlySpan<int> s = p;`). `Lies(in Puffer8, int)` liest
   über den Indexer.
3. `Serie` hat noch je zwei Überladungen: ein `params`-Array und eine
   Variante für vorhandene Kollektionen. Seit C# 13 kann `params` auch einen
   Kollektionstyp tragen. Ersetze die Überladungen durch jeweils **eine**
   Methode: `Summe(params ReadOnlySpan<int>)`, `Verbinde(params IEnumerable<string>)`
   (Teile mit `-` verbinden) und `Zaehle<T>(params List<T>)`. Dann klappen
   Aufrufe mit keinem, einem und vielen Argumenten, mit einem vorhandenen Array
   oder einer Liste und mit einem Kollektionsausdruck (`Summe([1, 2, 3])`).
   Löse zuerst die Rümpfe, dann die Signaturen: Die Tests prüfen beides.

Diese Tests müssen bestehen:

- `InlineUndParamsTests.Puffer8_ist_ein_Inline_Array_mit_32_Byte`
- `InlineUndParamsTests.Fuelle_schreibt_aufsteigende_Werte`
- `InlineUndParamsTests.Summe_addiert_alle_acht_Werte`
- `InlineUndParamsTests.Puffer8_hat_Wertsemantik`
- `InlineUndParamsTests.Lies_ausserhalb_wirft`
- `InlineUndParamsTests.Summe_mit_null_einem_und_vielen_Argumenten`
- `InlineUndParamsTests.Summe_mit_Array_und_Kollektionsausdruck`
- `InlineUndParamsTests.Verbinde_mit_allen_Aufrufformen`
- `InlineUndParamsTests.Zaehle_mit_allen_Aufrufformen`
- `InlineUndParamsTests.Serienparameter_haben_Kollektionstypen`
