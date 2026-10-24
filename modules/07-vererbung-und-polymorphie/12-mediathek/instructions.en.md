# Extra: Loan Periods and Late Fees in the Media Library

Extra exercise: optional; it unlocks nothing. For further reading: **7.4 Constructors and Inheritance** (page 549), **7.5 The `protected` Access Modifier** (page 554), and **7.9 Polymorphism** (page 566).

The city library lends out books, bestsellers, and movies. The `Medium` is ready: each item has a title, a 28-day loan period, and incurs a late fee of €0.50 per day, up to a maximum of €10. The subclasses only change what is different about them and use the base version for the rest:

1. `Buch(titel, autor)`: The title is taken from the base constructor (`: base(titel)`). `Info()` appends `", "` and the author to the base version: `"Faust (28 Tage), Goethe"`.
2. `Bestseller(titel, autor)` is a `Buch` with a 14-day loan period. The late fee is twice as high as for a book (including the upper limit); calculate it using `base.Mahngebuehr(...)`. `Info()` appends `" [Bestseller]"`. `IstGefragt` is `true` as soon as the item has been checked out at least three times.
3. `IstGefragt` needs the `ausleihen` loan counter from `Medium`. It's set to `private` there and is therefore invisible in `Bestseller`. Set it to `protected`, not `public`: No one from outside should be able to change it.
4. `Film(titel, minuten)`: 7-day rental period, 2 € per day late, maximum 20 €, no late fees if returned on time. `Info()` appends `", "`, the number of minutes, and `" min"`. Nobody should derive from `Film` any more: `sealed`.

The following tests must be passed:

- `MediathekTests.Leihfrist_haengt_vom_Laufzeittyp_ab`
- `MediathekTests.Mahngebuehren_je_Medium`
- `MediathekTests.Bestseller_verdoppelt_die_Mahngebuehr_des_Buchs`
- `MediathekTests.Info_baut_auf_der_Basisfassung_auf`
- `MediathekTests.Bestseller_ist_ab_drei_Ausleihen_gefragt`
- `MediathekTests.Ausleihzaehler_ist_protected`
- `MediathekTests.Film_ist_versiegelt`
