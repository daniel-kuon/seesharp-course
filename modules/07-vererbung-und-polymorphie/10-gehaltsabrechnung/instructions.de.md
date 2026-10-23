# Zusatz: Gehaltsabrechnung mit abstrakter Basisklasse

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**7.13 Abstrakte Methoden und Klassen** (Seite 577) und **7.8
Typtest-Operatoren** (Seite 563).

Eine kleine Firma bezahlt Angestellte, Teamleiter und Freelancer. Alle sind
`Mitarbeiter`, aber jeder wird anders bezahlt:

1. `Mitarbeiter.cs`: Ein Mitarbeiter "an sich" hat kein Gehalt. Mache die
   Klasse `abstract` und `Gehalt()` zu einer abstrakten Methode ohne Rumpf.
   Der Konstruktor darf dann `protected` sein.
2. `Angestellter`: festes `Monatsgehalt`, `Art` ist `"Angestellt"`.
3. `Teamleiter` ist ein `Angestellter` mit `Zulage`. Sein Gehalt ist das
   Gehalt des Angestellten plus Zulage; rechne es mit `base.Gehalt()` aus,
   nicht mit einer Kopie der Formel. `Art` ist `"Teamleitung"`.
4. `Freelancer`: `Stundensatz · Stunden`, `Art` ist `"Freelancer"`.
5. Negative Gehälter, Zulagen, Stundensätze und Stunden werden als 0
   übernommen.
6. `Lohnliste`: `Summe` addiert alle Gehälter, `Spitzenverdiener` liefert
   den Namen mit dem höchsten Gehalt (leeres Array: `""`),
   `FreelancerStunden` summiert die Stunden aller Freelancer und
   `AnzahlAngestellte` zählt alle Angestellten. Nutze den Typtest mit
   Musterdeklaration (`if (m is Freelancer f)`). Überlege vorher, was
   `is Angestellter` für einen Teamleiter liefert.

Diese Tests müssen bestehen:

- `GehaltTests.Mitarbeiter_ist_abstrakt`
- `GehaltTests.Angestellter_und_Freelancer_berechnen_ihr_Gehalt`
- `GehaltTests.Negative_Werte_werden_als_0_uebernommen`
- `GehaltTests.Teamleiter_rechnet_mit_dem_Gehalt_des_Angestellten`
- `GehaltTests.Beschreibung_nutzt_die_Art_der_Unterklasse`
- `GehaltTests.Lohnliste_summiert_und_findet_den_Spitzenverdiener`
- `GehaltTests.Typtest_zaehlt_Teamleiter_als_Angestellte`
- `GehaltTests.Leere_Lohnliste`
