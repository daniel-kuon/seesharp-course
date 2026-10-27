# Lotto: Fisher-Yates und Selection Sort

Lies im Buch Aufgabe 2 in **6.10** (Seite 538), die beide Verfahren
beschreibt, dazu **6.2.4** zur Klasse `Random` (Seite 459) und **6.2.6
Suchen und Sortieren** (Seite 463) für das, was die Klasse `Array` fertig
mitbringt.

Öffne `Lotto.cs`. Alle drei Methoden sind statisch, es gibt keinen Zustand:

1. `Mische(int[] vektor, Random rnd)` verwirbelt das Array **in place** nach
   Fisher-Yates: Für `i` von `Length - 1` abwärts bis 1 einen zufälligen
   Index `k` aus `0..i` (einschließlich, also `rnd.Next(i + 1)`) wählen und
   die Elemente `k` und `i` tauschen. Der Aufrufer sieht die Änderung, weil
   Arrays Referenztypen sind.
2. `SortiereAuswahl(int[] a)` sortiert aufsteigend durch Auswahl: Für jede
   Position `i` das kleinste Element aus dem Rest nach vorn tauschen.
3. `Ziehe(int seed)`: Array mit 1 bis 49 füllen, mit `new Random(seed)`
   mischen, die ersten 6 Zahlen in ein neues Array kopieren, sortieren,
   zurückgeben. Zum Kopieren taugt der Bereich `vektor[..6]` (6.2.8,
   Seite 467) oder `Array.Copy(vektor, ziehung, 6)` (nicht im Buch, hier vorgegeben).

Ein fester Seed macht die Ziehung reproduzierbar; genau deshalb kann der
Test das Ergebnis vorhersagen. Benutze keine fertigen Methoden wie
`rnd.Shuffle` oder `Array.Sort`, die Tests prüfen das Verfahren selbst.
