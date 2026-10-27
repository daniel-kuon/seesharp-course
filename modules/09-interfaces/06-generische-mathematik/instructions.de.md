# Generische Mathematik: IAdditionOperators und operator checked +

Lies im Buch **9.1.2 Statische Mitglieder** (Seite 622, besonders 9.1.2.2
abstrakte ausführbare Mitglieder, Seite 623), **9.1.3 Generische
Mathematik** (Seite 625) und Aufgabe 3 in **9.6** (Seite 655). Zur
Erinnerung an `checked` siehe Level 3 (4.6).

Seit C# 11 dürfen Interfaces **statische abstrakte** Mitglieder verlangen,
auch Operatoren. Darauf baut die generische Mathematik der BCL: Ein Typ,
der `IAdditionOperators<T, T, T>` implementiert, verspricht einen
Plusoperator, und generischer Code darf `a + b` schreiben. `Bruch` erfüllt
das Interface bereits durch `operator +` aus Level 4.

1. In `Bruch.cs`: Ergänze `public static Bruch operator checked +(Bruch b1,
   Bruch b2)`. Sie rechnet Zähler und Nenner mit `checked(...)` und wirft
   dadurch `OverflowException` statt leise überzulaufen; das Etikett
   entsteht wie beim normalen `+` (`$"{b1.Etikett} + {b2.Etikett}"`), das
   Ergebnis wird gekürzt. In einem `checked`-Block wählt der Compiler diese
   Variante.
2. In `Rechner.cs`: `Summe<T>(T first, params T[] rest)` summiert mit `+=`;
   die Einschränkung `where T : IAdditionOperators<T, T, T>` macht das
   möglich, für `int`, `double`, `decimal` und `Bruch` gleichermaßen.
3. `IKombinierbar<TSelf>` ist ein eigenes Interface mit `static abstract
   TSelf operator +`. Implementiere den Operator in `Glas` (Sticker mit
   Leerzeichen verbinden) und `Gras` (Größen addieren) und schreibe
   `Kombinierer.Combine<T>(params T[])`, das alle Elemente mit `+`
   verkettet.

> **Deep Dive (optional):** Die checked-Fassung des Instanzoperators `+=`
> steht nicht im Buch; sie verbindet `void operator +=` aus 5.9 (Seite 387)
> mit der checked-Variante aus 9.6. Ergänze in `Bruch.cs`
> `public void operator checked +=(Bruch b)`, das Zähler und Nenner mit
> `checked(...)` aktualisiert. Ohne sie wählt der Compiler auch in einem
> `checked`-Block das normale `+=`, und ein Überlauf bleibt unbemerkt. Das
> prüft der Test `GenerischeMathematikTests.Checked_PlusGleich_wirft_bei_Ueberlauf`;
> er ist zusätzlich und für das Bestehen der Übung nicht nötig.
