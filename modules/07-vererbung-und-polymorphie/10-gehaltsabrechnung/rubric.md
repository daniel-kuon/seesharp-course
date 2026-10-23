# Rubrik — Zusatz Gehaltsabrechnung (nur für die Betreuung)

- `Teamleiter.Gehalt()` soll `base.Gehalt() + Zulage` sein. Wer
  `Monatsgehalt + Zulage` schreibt, besteht auch; nachfragen, was passiert,
  wenn `Angestellter.Gehalt()` später z. B. ein anteiliges 13. Gehalt
  einrechnet.
- `AnzahlAngestellte`: `is Angestellter` ist auch für Teamleiter `true`.
  Wer `GetType() == typeof(Angestellter)` benutzt, fällt durch den Test;
  guter Anlass, Typtest und exakten Typvergleich zu unterscheiden.
- `protected` Konstruktor in einer abstrakten Klasse ändert nichts am
  Verhalten (instanziieren geht ohnehin nicht), dokumentiert aber die
  Absicht.
- `decimal` für Geld: kurz an Level 2 erinnern (double vs. decimal).

Modellantwort: `solution/`.
