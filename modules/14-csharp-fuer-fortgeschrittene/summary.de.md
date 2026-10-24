# C# für Fortgeschrittene: Null-Sicherheit, Musterabgleich, Span

Kapitel 15 (Seite 949) sammelt Sprachmittel, mit denen sich Fehler früh
aufspüren und Code kurz und schnell halten lässt: Der Compiler überwacht
`null`, Muster ersetzen Verzweigungsketten, und Spans vermeiden Kopien.

## Null-Sicherheit (15.1, Seite 949 bis 971)

Bei eingeschaltetem **Nullable-Kontext** (`<Nullable>enable</Nullable>`)
gilt ein Referenztyp als nicht null: `string` darf `null` nicht annehmen,
`string?` schon (15.1.1). Zur Laufzeit gibt es keinen Unterschied; die
Kennzeichnung ist eine Information für den Compiler. Die
**Nullzustandsanalyse** verfolgt für jeden Ausdruck, ob er „vielleicht null"
oder „nicht null" ist, und warnt bei Zuweisung von `null` an eine
nicht-nullable Variable und bei Zugriff auf einen möglichen Nullwert (15.1.2,
Seite 953). Warnungen behebt man durch Code: prüfen, `?`-Typen verwenden oder
anders modellieren. Der **Null-Vergebungs-Operator** `!` (15.1.2.2, Seite 955)
unterdrückt nur die Warnung und ist erlaubt, wenn man es begründen kann.
Mit `<WarningsAsErrors>nullable</WarningsAsErrors>` (15.1.3.3) werden
Nullwarnungen zu Fehlern.

Wo die Analyse den Zusammenhang nicht erkennt, helfen Attribute (15.1.4,
Seite 962): `[NotNullWhen(true)]` beschreibt einen `out`-Parameter, der nur bei
Rückgabe `true` nicht null ist (das Muster hinter `TryParse`);
`[NotNullIfNotNull("s")]` sagt, dass die Rückgabe nicht null ist, wenn
das Argument `s` es nicht ist. Dazu kommen die Operatoren (15.1.5, Seite 968):
`?.` und `?[ ]` brechen bei `null` ab, `??` liefert einen Ersatzwert, `??=`
weist nur zu, wenn die linke Seite null ist. Neu in C# 14 ist die
**null-bedingte Zuweisung** `k?.Alter = 5;`: Zuweisung und rechte Seite
werden nur ausgeführt, wenn `k` nicht null ist.

## Musterabgleich (15.2, Seite 971 bis 988)

Muster beschreiben die Form eines Werts und stehen hinter `is` und in
`switch`-Ausdrücken. Es gibt **Konstantenmuster** (`null`, `0`, `"DE"`),
**Typ- und Deklarationsmuster** (`string s`, 15.2.3), **Relationsmuster**
(`< 13`, `>= 18`, 15.2.8) und die Kombinatoren `and`, `or`, `not` (15.2.9);
`not` bindet stärker als `and`, und das stärker als `or`. **Merkmalsmuster**
(`{ Elektro: true }`, 15.2.4) prüfen Eigenschaften und sind null-sicher;
erweiterte Merkmalsmuster schreiben `{ Halter.Land: "DE" }`. Das
**var-Muster** (15.2.5) fängt einen Teilwert in einer Variablen,
**Positionsmuster** (15.2.7) nutzen `Deconstruct` (jeder Record hat eines),
**Tupelmuster** (15.2.6) werten mehrere Werte gleichzeitig aus, und
**Listenmuster** (15.2.10, Seite 985) beschreiben Arrays und Listen
(`[1, .., 9]`, `[var kopf, .. var rest]`). Mit `when` hängt man jedem Arm
eine beliebige Bedingung an. In `switch`-Ausdrücken entscheidet die
Reihenfolge: Der erste passende Arm gewinnt, und der Compiler meldet
unerreichbare oder fehlende Fälle.

## ref, Span und Co. (15.3 bis 15.6, Seite 988 bis 1012)

Eine `ref`-Rückgabe (15.3, Seite 988) liefert einen Verweis auf eine
Speicherstelle statt eines Werts; `Hoechster(a) = 0;` schreibt dann ins Array.
`ref readonly` erspart das Kopieren großer Strukturen. `Span<T>` und
`ReadOnlySpan<T>` (15.4, Seite 991) sind Fenster auf vorhandenen Speicher
(Array, String, Stack): Ausschnitte kopieren nichts, ein Parametertyp
passt für alle Quellen. Es sind `ref struct`-Typen und leben nur auf dem Stack.
Seit C# 14 (15.4.3, Seite 994) gehen Arrays und Strings implizit in Spans über,
auch als Empfänger von Erweiterungsmitgliedern in `extension`-Blöcken. Ein
**Inline-Array** (15.5, Seite 1005) ist eine Struktur mit festem, per
`[InlineArray(n)]` deklariertem Array in sich selbst. Mit **Serienparametern
mit Kollektionstyp** (15.6, Seite 1008) darf `params` auch
`ReadOnlySpan<T>`, `IEnumerable<T>` oder `List<T>` tragen und ersetzt viele
Überladungen.

Vertiefung im Buch: Kapitel 15 (Seite 949 bis 1012); die Übungsaufgaben in
15.7 (Seite 1012) liefern `PalindromReverse`, die Altersgruppen und
`Zugelassen` dieses Levels. Nicht Teil der Aufgaben: Kontextvarianten und
Präprozessordirektiven (15.1.3), `MemberNotNull`, `AllowNull` (15.1.4).
