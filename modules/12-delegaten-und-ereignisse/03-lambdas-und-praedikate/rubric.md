# Rubrik — Lambdas und Prädikate (nur für die Betreuung)

- Kernidee: Ein Lambda ist die Kurzschreibweise für ein Delegatenobjekt; der
  Zieltyp (hier `Predicate<T>`, `Comparison<T>`, `Action<T>`) bestimmt
  Parametertypen und Rückgabetyp.
- `FindAll` liefert eine **neue** Liste, `RemoveAll` verändert die **vorhandene**
  (Test `aendert_die_Quelle_nicht` bzw. `entfernt_in_der_Liste_selbst`).
- `Summe`: Das Lambda verändert die lokale Variable `summe` der umgebenden
  Methode — erster Kontakt mit dem Einfangen, Vertiefung in 12/04.
- `Sort` ist nicht stabil; die Vergleichsfunktion muss deshalb eine
  vollständige Ordnung liefern (Länge, dann Text).
- Nachfrage: Warum ist `a - b` als Vergleich für beliebige `int`-Werte
  gefährlich (Überlauf, z. B. `int.MinValue - 1` wird positiv), bei Längen
  (nie negativ) aber unproblematisch? `CompareTo` hat das Problem nie.

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Delegaten/FindAll`.
