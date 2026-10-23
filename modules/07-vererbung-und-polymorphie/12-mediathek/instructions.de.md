# Zusatz: Leihfristen und Mahngebühren in der Mediathek

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**7.4 Konstruktoren und Vererbung** (Seite 549), **7.5
Zugriffsmodifikator protected** (Seite 554) und **7.9 Polymorphie**
(Seite 566).

Die Stadtbibliothek verleiht Bücher, Bestseller und Filme. `Medium` ist
fertig: jedes Medium hat einen Titel, eine Leihfrist von 28 Tagen und kostet
bei Verspätung 0,50 € pro Tag, höchstens 10 €. Die Unterklassen ändern nur,
was bei ihnen anders ist, und benutzen für den Rest die Basisfassung:

1. `Buch(titel, autor)`: Den Titel übernimmt der Basiskonstruktor
   (`: base(titel)`). `Info()` hängt an die Basisfassung `", "` und den
   Autor an: `"Faust (28 Tage), Goethe"`.
2. `Bestseller(titel, autor)` ist ein `Buch` mit 14 Tagen Leihfrist. Die
   Mahngebühr ist doppelt so hoch wie beim Buch (also auch die Obergrenze);
   rechne sie mit `base.Mahngebuehr(...)` aus. `Info()` hängt
   `" [Bestseller]"` an. `IstGefragt` ist `true`, sobald das Medium
   mindestens dreimal ausgeliehen wurde.
3. `IstGefragt` braucht den Ausleihzähler `ausleihen` aus `Medium`. Der ist
   dort `private` und in `Bestseller` deshalb unsichtbar. Mache ihn
   `protected`, nicht `public`: Von außen soll ihn niemand verändern.
4. `Film(titel, minuten)`: 7 Tage Leihfrist, 2 € pro Tag Verspätung,
   höchstens 20 €, kein Verzug kostet nichts. `Info()` hängt `", "`, die
   Minuten und `" min"` an. Von `Film` soll niemand mehr ableiten: `sealed`.

Diese Tests müssen bestehen:

- `MediathekTests.Leihfrist_haengt_vom_Laufzeittyp_ab`
- `MediathekTests.Mahngebuehren_je_Medium`
- `MediathekTests.Bestseller_verdoppelt_die_Mahngebuehr_des_Buchs`
- `MediathekTests.Info_baut_auf_der_Basisfassung_auf`
- `MediathekTests.Bestseller_ist_ab_drei_Ausleihen_gefragt`
- `MediathekTests.Ausleihzaehler_ist_protected`
- `MediathekTests.Film_ist_versiegelt`
