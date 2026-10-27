# Bruch implementiert IComparable<T> und ICloneable

Lies im Buch **9.2.1 Beispiel IComparable<T>** (Seite 640), **9.2.3
Vorteile generischer Schnittstellen** (Seite 642) und Aufgabe 1 in **9.6**
(Seite 655).

Die Klasse `Bruch` aus Level 5 bekommt zwei Verträge:

1. Gib hinter dem Klassennamen `: IComparable<Bruch>, ICloneable` an.
2. `CompareTo(Bruch? b)` vergleicht die **Werte** per Kreuzmultiplikation:
   `Zaehler · b.Nenner` gegen `b.Zaehler · Nenner`. Rechne in `long`, damit
   große Zähler nicht überlaufen (`(long)Zaehler * b.Nenner`). Liefere
   negativ, 0 oder positiv; `long` hat selbst eine `CompareTo`-Methode, die
   das erledigt. Ist `b` null, gilt dieser Bruch als größer.
   **Achtung, negative Nenner:** `Bruch` erlaubt `1/-2`. Die Kreuzmultiplikation
   multipliziert beide Seiten mit `Nenner · b.Nenner`; ist genau einer der beiden
   Nenner negativ, ist dieses Produkt negativ und der Vergleich kehrt sich um
   (wie bei Ungleichungen: Multiplikation mit einer negativen Zahl dreht das
   Zeichen). Dreh das Ergebnis in diesem Fall um.
3. `Clone()` ist von `ICloneable` als `object Clone()` vorgeschrieben.
   `MemberwiseClone()` (geerbt von `Object`) liefert eine flache Kopie, das
   reicht hier, weil `Bruch` nur Werttypen und einen String enthält.

Danach sortiert `Array.Sort(b)` ein `Bruch[]` nach Wert, und `(Bruch)
b.Clone()` liefert eine Kopie. Die typsichere `Klone()` bleibt daneben
bestehen.
