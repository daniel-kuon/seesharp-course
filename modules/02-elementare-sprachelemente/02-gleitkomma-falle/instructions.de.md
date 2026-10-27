# Die Gleitkomma-Falle

Lies im Buch Abschnitt **4.3.5 Darstellung von Gleitkommazahlen im
Arbeitsspeicher** (Seite 189) und **4.5.4 Identitätsprüfung bei
Gleitkommawerten** (Seite 223). Zur Klasse `Math` genügt **4.5.2
Methodenaufruf** (Seite 220).

Öffne `Gleitkomma.cs` und vervollständige:

1. `SummeDouble()` liefert `0.1 + 0.2` als `double`.
2. `SummeDecimal()` liefert `0.1 + 0.2` als `decimal` (Literal-Suffix `m`).
   Ein Test prüft, dass die `double`-Summe **nicht** gleich `0.3` ist, die
   `decimal`-Summe aber schon. Schreibe beide Methoden ehrlich hin und sieh dir
   das Ergebnis an.
3. `EinsPlusZweiHochMinus(int i)` liefert `1.0 + 2^-i` (mit `Math.Pow`). Bei
   `i = 52` ist das Ergebnis noch größer als 1,0, bei `i = 53` nicht mehr.
4. `IstUngefaehrGleich(double a, double b, double toleranz)` liefert `true`,
   wenn der Abstand (`Math.Abs`) kleiner als die Toleranz ist. (Das Buch
   empfiehlt in 4.5.4 allgemein eine Schwelle für die *relative* Abweichung;
   hier genügt die absolute mit vorgegebener Toleranz.)
5. `RundeKaufmaennisch(decimal betrag)` rundet auf zwei Nachkommastellen,
   wobei `,005` aufgerundet wird (`Math.Round` mit `MidpointRounding.AwayFromZero`).

Diese Tests müssen bestehen:

- `GleitkommaTests.Double_Summe_ist_nicht_0_3`
- `GleitkommaTests.Decimal_Summe_ist_0_3`
- `GleitkommaTests.Eins_plus_2_hoch_minus_52_ist_groesser_als_eins`
- `GleitkommaTests.Eins_plus_2_hoch_minus_53_ist_eins`
- `GleitkommaTests.Ungefaehr_gleich_mit_Toleranz`
- `GleitkommaTests.Ungefaehr_gleich_erkennt_Unterschied`
- `GleitkommaTests.Kaufmaennisch_runden`
