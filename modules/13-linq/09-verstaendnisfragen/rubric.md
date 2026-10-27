# Rubrik — Verständnisfragen Level 13 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0) geprüft. Eine
Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen; Wortlaut
und Fachbegriffe müssen nicht exakt stimmen.

## ausfuehrung

Kernpunkte:
- **Zurückgestellt** (verzögert): `Where`, `Select`, `OrderBy` usw. bauen nur eine Abfrage (ein „Rezept“) und lesen die Quelle erst, wenn jemand sie aufzählt (`foreach`) oder ein sofortiger Operator sie abholt. **Sofort**: `ToList()`, `ToArray()`, `ToDictionary()`, `Count()`, `Sum()`, `First()` werten sofort aus und liefern ein Ergebnis bzw. eine materialisierte Sammlung.
- **Jede Aufzählung führt die Abfrage von vorn aus** (Lambdas laufen erneut, Kosten fallen erneut an); wer ein Ergebnis mehrfach braucht, materialisiert es einmal mit `ToList()`.
- Änderungen an der Quelle zwischen Bauen und Aufzählen sind in der Abfrage **sichtbar** (anders als bei einer bereits mit `ToList()` erzeugten Kopie).

Typische Irrtümer: `Where` filtere sofort bei der Zeile selbst; die Abfrage speichere ihr Ergebnis; ein zweites `foreach` sei „gratis“.

## groupby-countby

Kernpunkte:
- `GroupBy` liefert eine Folge von Gruppen (`IGrouping<TKey, T>`); jede Gruppe ist selbst eine Sequenz der zugehörigen Elemente (mit `foreach`, `Count()`, `Select` … durchlaufbar) und trägt ihren Schlüssel in der Eigenschaft `Key`.
- Zählen je Schlüssel: `GroupBy(f).Select(g => (g.Key, g.Count()))`; `Count()` auf der Gruppe liefert ihre Größe.
- Bonus (Deep Dive, nicht im Buch): `CountBy(f)` (ab .NET 9) zählt je Schlüssel in einem Durchlauf, ohne Gruppen mit allen Elementen aufzubauen.

Typische Irrtümer: `GroupBy` liefere ein Dictionary oder eine Liste von Listen mit Indexzugriff; `Key` sei ein Element der Gruppe; `Count()` auf dem Ergebnis von `GroupBy` zähle die Elemente statt der Gruppen.

## join-vs-groupjoin

Kernpunkte:
- `Join` ist ein **innerer Join**: Ein Kunde ohne Bestellung taucht im Ergebnis **gar nicht** auf (und ein Kunde mit mehreren Bestellungen erscheint mehrfach, je Paar eine Zeile).
- `GroupJoin` liefert für **jeden** Kunden genau eine Zeile mit der Gruppe seiner Bestellungen; bei einem Kunden ohne Bestellung ist die Gruppe **leer** (z. B. Anzahl 0).
- `GroupJoin` verwendet man, wenn alle Elemente der äußeren Sequenz im Ergebnis bleiben sollen (auch ohne Partner) oder wenn man je Element die Gruppe der Partner aggregieren will (Summe, Anzahl).

Typische Irrtümer: `Join` liefere eine Zeile mit `null`; `GroupJoin` verwerfe Kunden ohne Bestellung; die beiden seien dasselbe.

## select-vs-selectmany

Kernpunkte:
- `Select` bildet jedes Element auf **genau ein** Ergebnis ab; liefert die Abbildung selbst eine Folge (z. B. `satz.Split(' ')`), entsteht eine **Folge von Folgen** (`IEnumerable<string[]>`).
- `SelectMany` flacht ab: Es bildet jedes Element auf eine Folge ab und hängt alle diese Folgen zu **einer** flachen Folge aneinander (`saetze.SelectMany(s => s.Split(' '))` liefert alle Wörter in einer Folge).

Typische Irrtümer: `SelectMany` sei nur ein Filter; beide liefern dasselbe; `SelectMany` sortiere die Elemente.

## code-mehrfach

Ausgabe, drei Zeilen: `3`, `3`, `4`.
Kernpunkte:
- `gross` ist nur eine Abfrage. Beim ersten `Count()` ist die 10 schon in `zahlen`, es zählen 2, 3, 10 → `3` (Änderungen vor der Aufzählung sind sichtbar).
- `liste` ist per `ToList()` eine **Kopie** zum Zeitpunkt des Aufrufs (2, 3, 10): Die später hinzugefügte 20 fehlt, `liste.Count` bleibt `3`.
- Das zweite `gross.Count()` zählt die Quelle neu: 2, 3, 10, 20 → `4`.

Typische Irrtümer: `2`, `3`, `3` (Abfrage sei beim Bauen ausgewertet worden); `liste` wachse mit der Quelle mit.

## code-select-zweimal

Ausgabe: `gebaut`, dann `S S S S S S ` (sechsmal `S`, auf einer Zeile hinter dem Zeilenumbruch von „gebaut“).
Kernpunkte:
- Beim Bauen von `q` läuft nichts: „gebaut“ erscheint zuerst, ohne ein `S` davor.
- Jedes `foreach` zählt die Abfrage von vorn auf, der Selektor läuft je Element: 3 Elemente × 2 Durchläufe = 6 mal.
- Wer das vermeiden will, materialisiert mit `ToList()`.

Typische Irrtümer: drei `S` (nur einmal ausgewertet); `S` erscheine schon vor „gebaut“; die leeren Schleifenrümpfe führten nichts aus (der Selektor läuft trotzdem, weil aufgezählt wird).

## code-gruppen

Ausgabe, drei Zeilen:
```
A: 2 (Apfel, Ananas)
B: 2 (Birne, Banane)
K: 1 (Kiwi)
```
Kernpunkte:
- Gruppiert wird nach dem ersten Buchstaben (`w[0]`, ein `char`); der Schlüssel ist der Buchstabe.
- Die Gruppen erscheinen in der Reihenfolge des ersten Auftretens des Schlüssels, die Elemente innerhalb einer Gruppe in der Quellreihenfolge.

Typische Irrtümer: Gruppen alphabetisch sortiert erwartet (hier zufällig gleich, aber nicht garantiert); `Count()` zähle Buchstaben statt Elemente.

## code-leere-folge

Ausgabe, drei Zeilen: `0`, `0`, `leer`.
Kernpunkte:
- `Sum()` einer leeren Folge ist `0` (neutrales Element, kein Fehler); `FirstOrDefault()` liefert den Standardwert des Typs (`0` für `int`, bei Referenztypen `null`).
- `Average()` hat bei einer leeren Folge keinen sinnvollen Wert (Division durch 0 wäre `NaN`, ein Mittelwert ist hier nicht definiert) und wirft eine `InvalidOperationException`, die der `catch` abfängt → „leer“. Dasselbe gilt für `Min`, `Max`, `First`, `Single` auf einer leeren Folge. Man prüft vorher mit `Any()` (Bonus (Deep Dive): `DefaultIfEmpty()`).

Typische Irrtümer: `Average()` liefere `0` oder `NaN`; `FirstOrDefault()` werfe eine Ausnahme; `Sum()` werfe eine Ausnahme.
