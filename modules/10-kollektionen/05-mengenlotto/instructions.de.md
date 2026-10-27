# Lotto mit SortedSet<T>

Lies im Buch **11.5.3 Balancierte Binärbäume und die Klasse SortedSet<T>**
(Seite 711) und danach die Aufgabe **11.8 Nr. 2** (Seite 723): Die
Lottoziehung kennst du aus Level 6 mit Arrays, mit einer passenden Kollektion
wird sie sehr kurz.

Öffne `Lotto.cs` und implementiere vier Methoden:

1. `Ziehe(Random rnd)` liefert eine `SortedSet<int>` mit sechs verschiedenen
   Zahlen von 1 bis 49. Rufe `rnd.Next(1, 50)` so lange auf und füge die Zahl
   hinzu, bis die Menge sechs Elemente hat. Die Aufrufreihenfolge ist
   festgelegt: Der Test mit `new Random(42)` kennt das genaue Ergebnis.
2. `Treffer(tipp, ziehung)` zählt die gemeinsamen Zahlen. Keine der beiden
   Mengen darf verändert werden: Kopiere eine und wende `IntersectWith` an.
3. `NaechsteZahl(s, x)` liefert die kleinste Zahl in `s`, die größer als `x`
   ist, oder `-1`. Verwende `GetViewBetween` (nicht im Buch:
   `s.GetViewBetween(unten, oben)` liefert eine Sicht auf alle Elemente von
   `unten` bis `oben`, beide eingeschlossen).
4. `Spanne(s)` liefert `Max - Min` (bei einer leeren Menge 0).

Tests: `Ziehe_mit_festem_Startwert_liefert_das_Ergebnis_der_Musterloesung`,
`Ziehe_liefert_sechs_verschiedene_Zahlen_von_1_bis_49_aufsteigend`,
`Doppelte_Zahl_aendert_die_Menge_nicht`, `Treffer_zaehlt_gemeinsame_Zahlen`,
`Treffer_veraendert_keine_der_Mengen`,
`NaechsteZahl_liefert_die_kleinste_groessere_Zahl` und
`Spanne_ist_Maximum_minus_Minimum`.
