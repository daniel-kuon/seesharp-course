# Zusatz: ASCII-Banner

Zusatzaufgabe: freiwillig, sie blockiert nichts. Hier darfst du gestalten,
die Tests prüfen nur die Form.

Lies im Buch noch einmal **3.1.5 Ausführen** (Seite 74). Wer mehrzeiligen Text
in einem einzigen Literal schreiben möchte, findet das Rohzeichenfolgenliteral
(`"""`) als Vorgriff in **4.3.10.5 Zeichenfolgenliterale** (Seite 208 f.).

Öffne `Banner.cs` und vervollständige die drei statischen Methoden:

1. `Rahmenlinie()` liefert eine Linie wie `+--------------------+`: vorne und
   hinten ein `+`, dazwischen nur Minuszeichen, insgesamt mindestens 10
   Zeichen.
2. `Titelzeile()` liefert eine Zeile wie `|  Hallo, SeeSharp!  |`: vorne und
   hinten ein `|`, irgendwo das Wort `SeeSharp`, und **genau so breit wie
   deine Rahmenlinie**. Den Text dazwischen wählst du selbst.
3. `Komplett()` liefert alles in einer Zeichenkette mit drei Zeilen:
   Rahmenlinie, Titelzeile, Rahmenlinie. Entweder setzt du die Zeilen mit
   `+` und `"\n"` aus den beiden anderen Methoden zusammen, oder du schreibst
   ein Rohzeichenfolgenliteral.

`Main()` gibt das Banner bereits aus. Starte das Programm und sieh es dir an.

Diese Tests müssen bestehen:

- `BannerTests.Rahmenlinie_hat_Plus_an_den_Enden_und_Minus_dazwischen`
- `BannerTests.Rahmenlinie_ist_mindestens_10_Zeichen_breit`
- `BannerTests.Titelzeile_steht_zwischen_senkrechten_Strichen`
- `BannerTests.Titelzeile_nennt_SeeSharp`
- `BannerTests.Titelzeile_ist_so_breit_wie_die_Rahmenlinie`
- `BannerTests.Banner_besteht_aus_Linie_Titel_Linie`
