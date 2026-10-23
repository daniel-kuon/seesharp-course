# Zusatz: Statistik für alle Zahltypen mit INumber<T>

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**9.1.3 Generische Mathematik** (Seite 625) mit **9.1.3.2 Beispiel für die
Verwendung der numerischen Schnittstellen** (Seite 626).

In Übung 6 hast du mit `IAdditionOperators<T, T, T>` nur das Plus
verlangt. `INumber<T>` fasst alles zusammen, was eine Zahl kann: die
Operatoren `+ - * /`, Vergleiche mit `<` und `>`, und **statische**
Mitglieder wie `T.Zero`, `T.One` und `T.CreateChecked(...)`. Statische
Mitglieder ruft man am Typparameter auf (`T.Zero`); das geht nur, weil das
Interface sie als `static abstract` verlangt und `int`, `double`,
`decimal` usw. sie implementieren. Öffne `Statistik.cs`:

1. Ergänze bei jeder Methode die Einschränkung `where T : INumber<T>`
   (`using System.Numerics;` steht schon da). Ein Test prüft das.
2. `Summe` beginnt bei `T.Zero`, `Produkt` bei `T.One`; für eine leere
   Serie sind das auch die Ergebnisse.
3. `SummeGeprueft` addiert in einem `checked`-Ausdruck:
   `summe = checked(summe + w);`. Dann wählt der Compiler den
   `operator checked +` von `T`, und ein Überlauf wirft
   `OverflowException`, statt still umzuschlagen wie bei `Summe`.
4. `Mittelwert` teilt die Summe durch die Anzahl. Die Anzahl ist ein
   `int`; `T.CreateChecked(werte.Length)` macht daraus ein `T`. Bei
   Ganzzahltypen wird ganzzahlig geteilt.
5. `Minimum` und `Maximum` vergleichen mit `<` bzw. `>`; `Spannweite` ist
   `Maximum - Minimum`.
6. `Mittelwert`, `Minimum`, `Maximum` und `Spannweite` werfen für eine
   leere Serie `ArgumentException`.

Diese Tests müssen bestehen:

- `StatistikTests.Alle_Methoden_sind_auf_INumber_eingeschraenkt`
- `StatistikTests.Summe_fuer_verschiedene_Zahltypen`
- `StatistikTests.SummeGeprueft_erkennt_Ueberlauf`
- `StatistikTests.Produkt_beginnt_bei_Eins`
- `StatistikTests.Mittelwert_teilt_im_Zahltyp`
- `StatistikTests.Minimum_Maximum_und_Spannweite`
- `StatistikTests.Leere_Serie_wirft_wo_es_kein_Ergebnis_gibt`
