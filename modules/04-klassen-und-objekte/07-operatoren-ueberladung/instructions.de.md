# Operatoren überladen

Lies im Buch Abschnitt **5.9.3 Operatoren überladen** (Seite 385), einschließlich
des Teils zum Instanzoperator `+=` (neu in C# 14).

Öffne `Bruch.cs`. Die Klasse hat jetzt automatische Eigenschaften mit `field`
und einen Instanzzähler `Anzahl`. Vervollständige:

1. `Kuerze()`, `Addiere(Bruch)` und `Addiere(int, int, bool)` wie in der
   vorigen Übung.
2. `DuplWerte(Bruch bc)` kopiert Zähler und Nenner **nach** `bc`; das Etikett
   von `bc` bleibt erhalten.
3. `Klone()` liefert eine unabhängige Kopie mit gleichen Werten.
4. `static Bruch operator +(Bruch b1, Bruch b2)` liefert einen **neuen**,
   gekürzten Bruch mit dem Etikett `"b1 + b2"` (die Etiketten der Operanden
   mit `" + "` verbunden). Die Operanden bleiben unverändert.
5. `void operator +=(Bruch b)` verändert **dieses** Objekt: addieren, Etikett
   anhängen, kürzen. Es darf kein neues Objekt entstehen.

Tipp: `operator +` kann `Klone()` und `Addiere()` wiederverwenden.
