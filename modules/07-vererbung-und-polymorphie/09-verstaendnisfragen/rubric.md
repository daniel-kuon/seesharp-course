# Rubrik: Verständnisfragen, Vererbung und Polymorphie (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `ueberschreiben-richtig` = `public override double`,
`konstruktor-richtig` = `: base(x, y)`, `abstrakt-richtig` = `abstract class` mit
`public abstract double Flaeche();`, `erweiterung-richtig` = `static class` mit
`static ... Quadrat(this double x)`).

## verdecken-ueberschreiben

Wesentliche Punkte:
- **Überschreiben**: Basis `virtual`, Unterklasse `override`. Die Methode ersetzt die
  Basisfassung **für das Objekt**; es zählt der **dynamische Typ** (das tatsächliche Objekt),
  egal über welche Referenz man aufruft. Das ist Polymorphie.
- **Verdecken** (`new`, oder ohne Modifizierer mit Warnung CS0114): Die Unterklasse führt
  eine zweite, unabhängige Methode gleicher Signatur ein. Es zählt der **statische Typ**
  der Referenz: Über `Figur f` läuft die Basisfassung, über `Kreis k` die verdeckende.
- Bei `Figur f = new Kreis(); f.Beschreibe();` läuft mit `override` die Kreis-Version,
  mit `new` die Figur-Version.

Typische Missverständnisse: `new` sei "überschreiben, nur mit anderem Wort"; die
Entscheidung falle zur Übersetzung für beide Fälle (nur beim Verdecken, beim
Überschreiben erst zur Laufzeit); `override` ohne `virtual` in der Basis sei möglich.

## polymorphie

Wesentliche Punkte:
- **Statischer Typ** = der deklarierte Typ der Variablen (`Figur`); **dynamischer Typ** =
  der tatsächliche Typ des Objekts (`Kreis` oder `Rechteck`).
- **Polymorphie**: Ein Aufruf einer `virtual`/`abstract`-Methode über eine
  Basisklassenreferenz führt die Version des dynamischen Typs aus.
- Vorteil: Eine einzige Schleife über `Figur[]` ruft `Flaeche()` auf, ohne den konkreten
  Typ zu prüfen; neue Unterklassen funktionieren, ohne den Schleifencode zu ändern.

Typische Missverständnisse: Verwechslung mit Überladen (gleicher Name, andere Parameter,
zur Übersetzungszeit entschieden); "Polymorphie heißt, dass es mehrere Klassen gibt";
ein `Figur[]` könne nur `Figur`-Objekte (nicht Unterklassen) enthalten.

## abstrakt

Wesentliche Punkte:
- `abstract` nimmt man, wenn die Basisklasse **keine sinnvolle** Implementierung hat
  (die Fläche einer allgemeinen "Figur" gibt es nicht); eine `virtual`-Methode mit Standardwert
  (0) wäre eine Scheinlösung, die eine Unterklasse zu implementieren **vergessen** kann,
  ohne dass der Compiler es merkt.
- Eine abstrakte Klasse kann **nicht instanziiert** werden (`new Figur()` geht nicht). Ein
  abstraktes Mitglied hat **keinen Rumpf**.
- Die erste konkrete Unterklasse **muss** jedes abstrakte Mitglied mit `override`
  implementieren, sonst bleibt sie selbst abstrakt (Compilerfehler, wenn nicht).

Typische Missverständnisse: Eine abstrakte Klasse dürfe keinen Code oder keine Felder
enthalten (sie darf beides); `abstract` und `virtual` seien dasselbe.

## basiskonstruktor-protected

Wesentliche Punkte:
- Ein `Kreis`-Objekt enthält den `Figur`-Teil; die Basisklasse wird **zuerst**
  initialisiert, deshalb läuft ihr Konstruktor vor dem Rumpf des abgeleiteten.
- Fehlt `: base(...)`, ruft der Compiler den **parameterlosen** Basiskonstruktor. Gibt es den
  nicht, **kompiliert es nicht** (Fehler CS7036); die Lösung ist `: base(x, y)`.
- `private`: nur in der eigenen Klasse zugänglich; die Mitglieder werden zwar vererbt (sind im
  Objekt vorhanden), aber in der Unterklasse nicht ansprechbar. `protected` öffnet sie
  für abgeleitete Klassen und sonst niemanden.

Typische Missverständnisse: `private` Mitglieder würden nicht vererbt (sie sind im
Objekt, nur unzugänglich); `protected` sei dasselbe wie `public`; man dürfe den
Basiskonstruktor im Rumpf aufrufen.

## erweiterungsmitglieder

Wesentliche Punkte:
- Erweiterungsmitglieder rüsten **fremde** Typen (auch versiegelte wie `double`, `string`)
  nach, **ohne sie zu verändern**; `pi.High(2)` ist in Wahrheit ein Aufruf einer statischen
  Methode. Klassisch: statische Methode in statischer Klasse mit `this`-Parameter; seit C# 14
  der Erweiterungsblock `extension(...)`.
- Grenzen (mindestens zwei von drei genügen): Sie sehen nur die **öffentliche**
  Schnittstelle (kein Zugriff auf `private`/`protected`); sie können keine Instanzfelder
  hinzufügen; sie sind nicht virtuell; **echte Mitglieder haben Vorrang**: Hat der Typ
  selbst schon ein gleichnamiges Mitglied, gewinnt dieses, die Erweiterung wird nie aufgerufen.

Typische Missverständnisse: Erweiterungsmethoden änderten die Klasse selbst oder könnten
Mitglieder überschreiben.

## code-verdecken

Ausgabe, drei Zeilen: `Figur`, `Kreis`, `ein Kreis`
- `f.Name()`: `Name` ist **verdeckt** (`new`); entscheidend ist der **statische Typ** `Figur`,
  also die Basisfassung: `Figur`.
- `((Kreis)f).Name()`: Der Cast ändert den statischen Typ auf `Kreis`; die verdeckende Methode
  wird gewählt: `Kreis`.
- `f.Beschreibe()`: `virtual`/`override`, es zählt der **dynamische Typ** `Kreis`:
  `ein Kreis`.

Typische Fehler: `Kreis` in der ersten Zeile (Verdecken wie Überschreiben behandelt).

## code-konstruktorreihenfolge

Ausgabe, drei Zeilen: `Figur`, `Kreis`, `Figur mit r=2`
- `new Kreis(2)`: erst läuft der (implizit gewählte, parameterlose) Basiskonstruktor
  und gibt `Figur` aus, dann der Rumpf von `Kreis` mit `Kreis`.
- `Console.WriteLine(k)` ruft `ToString()` auf; die Überschreibung in `Kreis` ruft mit
  `base.ToString()` die Figur-Fassung (`Figur`) und hängt ` mit r=2` an.

Typische Fehler: `Kreis` vor `Figur` (Reihenfolge verdreht); `Kreis` statt `Figur mit r=2` in der
letzten Zeile.

## code-typtest

Ausgabe: `K1 Quadrat K3 ` (mit Leerzeichen am Ende)
- Das Array hat statisch den Elementtyp `Figur`; `f is Kreis k` prüft zur Laufzeit,
  ob das Objekt ein `Kreis` ist, und liefert dann gleich eine passende Referenz `k` vom Typ
  `Kreis` mit Zugriff auf `R`.
- `f.R` geht nicht, weil `f` den **statischen Typ** `Figur` hat und `Figur` kein `R`
  kennt (Compilerfehler); man braucht die Referenz `k` (oder einen Cast).
- Für das `Quadrat` greift der `else`-Zweig; `GetType().Name` liefert den Typnamen des
  tatsächlichen Objekts: `Quadrat`.

Typische Fehler: Es werde `Figur` für alle ausgegeben (`GetType()` verwechselt mit dem
statischen Typ); `K2` für das Quadrat.

## code-record-vererbung

Ausgabe, zwei Zeilen: `False`, `Kreis { X = 1, Y = 2, R = 5 }`
- Die Wertgleichheit von Records berücksichtigt den **exakten Typ** (`EqualityContract`):
  Ein `Kreis` ist nie gleich einem `Figur`, selbst wenn alle gemeinsamen Eigenschaften
  übereinstimmen: `False`.
- `WriteLine(b)` verwendet das erzeugte `ToString()` des **dynamischen** Typs: `Kreis` mit
  allen drei Eigenschaften, nicht `Figur { X = 1, Y = 2 }`.

Typische Fehler: `True` (nur Eigenschaften verglichen, den Typ vergessen); `Figur { X = 1, Y = 2 }`
für die zweite Zeile.
