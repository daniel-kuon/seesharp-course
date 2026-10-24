# Extra: Payroll Processing Using an Abstract Base Class

Extra exercise: optional; it unlocks nothing. For further reading: **7.13 Abstract Methods and Classes** (page 577) and **7.8 Type Test Operators** (page 563).

A small company pays employees, team leaders, and freelancers. They are all `Mitarbeiter`, but each is paid differently:

1. `Mitarbeiter.cs`: An employee "in and of itself" does not have a salary. Make the class `abstract`, and make Gehalt() an `Gehalt()` method without a body. The constructor can then be `protected`.
2. `Angestellter`: fixed `Monatsgehalt`; `Art` is `"Angestellt"`.
3. `Teamleiter` is an `Angestellter` with `Zulage`. Its salary is the employee's salary plus `Zulage`; calculate it with `base.Gehalt()`, not with a copy of the formula. `Art` is `"Teamleitung"`.
4. `Freelancer`: `Stundensatz · Stunden`, `Art` is `"Freelancer"`.
5. Negative salaries, allowances, hourly rates, and hours are treated as 0.
6. `Lohnliste`: `Summe` adds up all salaries, `Spitzenverdiener` returns the name of the person with the highest salary (empty array: `""`), `FreelancerStunden` adds up the hours worked by all freelancers, and `AnzahlAngestellte` counts all employees. Use the type test with a sample declaration (`if (m is Freelancer f)`). Think about beforehand what `is Angestellter` returns for a team leader.

The following tests must be passed:

- `GehaltTests.Mitarbeiter_ist_abstrakt`
- `GehaltTests.Angestellter_und_Freelancer_berechnen_ihr_Gehalt`
- `GehaltTests.Negative_Werte_werden_als_0_uebernommen`
- `GehaltTests.Teamleiter_rechnet_mit_dem_Gehalt_des_Angestellten`
- `GehaltTests.Beschreibung_nutzt_die_Art_der_Unterklasse`
- `GehaltTests.Lohnliste_summiert_und_findet_den_Spitzenverdiener`
- `GehaltTests.Typtest_zaehlt_Teamleiter_als_Angestellte`
- `GehaltTests.Leere_Lohnliste`
