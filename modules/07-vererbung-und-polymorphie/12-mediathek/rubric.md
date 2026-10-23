# Rubrik — Zusatz Mediathek (nur für die Betreuung)

- `Bestseller.Mahngebuehr` soll `2 * base.Mahngebuehr(tage)` sein. Wer die
  Formel kopiert (`Math.Min(1.00m * tage, 20m)`), besteht auch; fragen, was
  passiert, wenn die Bibliothek die Buchgebühr ändert.
- `Info()`: drei Ebenen (`Medium` → `Buch` → `Bestseller`) hängen jeweils
  an `base.Info()` an. Die Leihfrist in der Basisfassung kommt trotzdem
  richtig (14 Tage), weil `Leihfrist` virtuell ist; gut zum Nachfragen.
- `protected` statt `public` für `ausleihen`: Unterklassen lesen, Fremde
  nicht. Bonusfrage: Wäre eine `protected` Eigenschaft mit `get` schöner
  als ein `protected` Feld? (Ja, Kapselung auch gegenüber Unterklassen.)
- `Film` sealed: der Test prüft `IsSealed`.

Modellantwort: `solution/`.
