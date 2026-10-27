# Delegaten deklarieren, erzeugen und aufrufen

Lies im Buch **10.1.1 Delegatentypen definieren** (Seite 659) und
**10.1.2 Delegatenobjekte erzeugen und aufrufen** (Seite 660).

Ein Delegatentyp beschreibt eine Methodensignatur; ein Delegatenobjekt
verweist auf eine passende Methode (und bei einer Instanzmethode auf ihr
Zielobjekt). Öffne `Operation.cs` und `Rechner.cs`:

1. `Operation.cs` enthält die Deklaration `public delegate double Operation(double a,
   double b);`. Lies sie und die Beschreibung im Kommentar genau.
2. `Rechner`: Implementiere die statischen Methoden `Addiere`, `Subtrahiere`,
   `Multipliziere` und `Dividiere` und die Instanzmethode `Potenz`, die zum
   Delegatentyp passen. `Potenz` berechnet `(a + b)` hoch `Exponent`. `Dividiere` rechnet wie
   üblich mit `double`: Division durch 0 liefert Unendlich, keine Ausnahme.
3. `Anwenden(op, a, b)` ruft den Delegaten auf; `Reduziere(op, werte)` faltet
   ein nichtleeres Array von links nach rechts mit `op` zu einem Wert
   (leeres Array: `ArgumentException`).
4. `Waehle(zeichen)` liefert für `+ - * /` den passenden Delegaten (switch-
   Ausdruck mit Methodengruppen), sonst `null`. `PotenzDelegat()` liefert einen
   Delegaten auf die Instanzmethode `Potenz` dieses Objekts.
5. Bearbeite danach die Review-Aufgabe (zweiter Delegatentyp `Bedingung`).

Tests: `Anwenden_ruft_statische_Methoden`,
`Dividiere_durch_null_liefert_Unendlich`, `Reduziere_faltet_von_links`,
`Reduziere_leeres_Array_wirft`, `Waehle_liefert_den_passenden_Delegaten`,
`Waehle_unbekanntes_Zeichen_liefert_null`,
`Instanzdelegat_behaelt_sein_Zielobjekt`, `Zwei_Rechner_zwei_Ziele`.
