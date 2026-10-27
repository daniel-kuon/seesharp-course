# Rubrik — Verständnisfragen Level 12 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0) geprüft. Eine
Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen; Wortlaut
und Fachbegriffe müssen nicht exakt stimmen.

## delegat-typ

Kernpunkte:
- Ein Delegatentyp beschreibt eine **Signatur** (Parameterliste und Rückgabetyp); er ist ein Typ für Methodenreferenzen.
- Ein Delegatenobjekt **zeigt auf eine konkrete Methode** (bei einer Instanzmethode merkt es sich das Zielobjekt mit) und wird wie eine Methode aufgerufen (`op(2, 3)` oder `op.Invoke(2, 3)`).
- Die Methode muss zur Signatur passen: gleiche Parameter (Anzahl und Typen) und passender Rückgabetyp. Namen von Methode und Parametern sowie die Frage static/Instanz spielen keine Rolle.

Typische Irrtümer: „Der Rückgabetyp ist egal“; ein Delegat sei die Methode selbst oder enthalte Quelltext; die Parameternamen müssten übereinstimmen.

## closure

Kernpunkte:
- Eingefangen wird die **Variable selbst**, nicht eine Kopie ihres Werts; das Lambda sieht spätere Änderungen und kann sie auch selbst vornehmen.
- Die Variable lebt so lange weiter, wie das Delegatenobjekt sie braucht, **auch nach dem Ende der Methode**.
- Bei jedem Aufruf der Methode entsteht eine **neue, eigene Variable**; zwei zurückgegebene Lambdas haben also getrennten Zustand.

Typische Irrtümer: Das Lambda bekomme einen Wert zum Zeitpunkt der Erzeugung; die lokale Variable verschwinde mit dem Methodenende; mehrere Aufrufe teilten sich dieselbe Variable.

## event-vs-feld

Kernpunkte:
- Beim öffentlichen Feld kann fremder Code das Delegatenobjekt **auslösen** (`x.Meldung("…")`) und **überschreiben oder löschen** (`x.Meldung = null`, `x.Meldung = …` ersetzt alle anderen Abonnenten).
- Beim Ereignis bleiben von außen nur `+=` und `-=` (anmelden und abmelden); Auslösen und Zuweisen sind der eigenen Klasse vorbehalten (abgeleitete Klassen über die `OnXyz`-Methode). Technisch: private Delegatenvariable plus öffentliche add/remove-Zugriffe.
- Vorteil: Der Anbieter bestimmt, wann das Ereignis ausgelöst wird, und die Abonnenten können sich nicht gegenseitig abmelden oder stören.

Typische Irrtümer: Ein Ereignis sei ein Datenobjekt oder ein Array von Delegaten; ein Ereignis sei schneller.

## standardmuster

Kernpunkte:
- Typ `EventHandler<TEventArgs>` (bzw. `EventHandler`), Nutzdaten in einer von `EventArgs` abgeleiteten Klasse, Behandlungsmethoden haben die Parameter `(object? sender, TEventArgs e)`.
- Ausgelöst wird in einer Methode `OnXyz(...)`; `?.Invoke(this, e)`, weil die Aufrufliste **`null`** ist, solange niemand abonniert hat (ohne `?.` droht eine `NullReferenceException`); `this` ist der `sender`.
- `protected virtual`, damit **abgeleitete Klassen** die Auslösung überschreiben und steuern können (unterdrücken, ergänzen), ohne an die private Delegatenvariable zu kommen.

Typische Irrtümer: Das Ereignis sei ohne `?.` immer sicher; `virtual` mache die Methode schneller; `On…` sei ein vorgeschriebener Name, ohne den der Compiler das Ereignis nicht auslöst.

## abmelden

Kernpunkte:
- Über die Aufrufliste hält der **Anbieter eine Referenz auf den Abonnenten**: Der Abonnent bleibt im Speicher (der Garbage Collector darf ihn nicht einsammeln) und bekommt weiter Benachrichtigungen, auch wenn er sie nicht mehr braucht.
- Jede Lambda-Stelle im Quelltext erzeugt ein **eigenes Delegatenobjekt**; `-=` entfernt nur ein Delegatenobjekt, das auf dieselbe Methode und dasselbe Ziel zeigt. Ein zweites, zufällig gleich aussehendes Lambda ist eine andere Methode und wird nicht gefunden (kein Fehler, es passiert einfach nichts).
- Abhilfe: benannte Methode verwenden oder das Delegatenobjekt in einer Variablen/einem Feld aufbewahren und genau dieses abmelden.

Typische Irrtümer: Der Compiler melde einen Fehler; beide Lambdas seien „gleich“, weil der Text gleich ist; Abmelden sei unnötig, weil der GC aufräumt.

## code-multicast

Ausgabe: `A B 2` (und dann Zeilenumbruch).
Kernpunkte:
- `+=` hängt ein zweites Ziel an die Aufrufliste; beim Aufruf laufen **alle Ziele in Anmeldereihenfolge** (erst A, dann B).
- Bei einem Rückgabewert zählt nur das **letzte** Ziel (2); der Wert 1 geht verloren.

Typische Irrtümer: Ausgabe `1` oder `A 3` (Summe), nur ein Ziel werde aufgerufen, `+=` sei bei `Func` ein Fehler.

## code-schleife

Ausgabe: `3 3 3 ` (dreimal die 3).
Kernpunkte:
- Alle drei Lambdas fangen **dieselbe** Schleifenvariable `i` ein (bei `for` gibt es nur eine); sie hat nach der Schleife den Wert 3, und die Lambdas laufen erst danach.
- Lösung: in jedem Durchlauf eine Kopie in eine lokale Variable innerhalb der Schleife ziehen (`int kopie = i;` und `kopie` benutzen) oder `foreach` verwenden (dort hat jeder Durchlauf eine eigene Variable). Geprüft: Mit der Kopie erscheint `0 1 2 `.

Typische Irrtümer: Ausgabe `0 1 2` (Wert werde kopiert); `2 2 2`; Lösung durch Ändern der Schleifenbedingung.

## code-zaehler

Ausgabe: `1`, `2`, `1` (drei Zeilen).
Kernpunkte:
- Das Lambda fängt die lokale Variable `n` ein; `n` lebt weiter, solange der Delegat lebt, und `++n` zählt bei jedem Aufruf weiter (`a()` ergibt 1, dann 2).
- Jeder Aufruf von `Zaehler()` erzeugt eine **neue** Variable `n`; `b` hat daher eigenen Zustand und liefert 1.

Typische Irrtümer: `1 1 1` (n starte jedes Mal neu); `1 2 3` (gemeinsamer Zähler); `n` sei nach dem Methodenende nicht mehr verfügbar.

## code-on-methode

Ausgabe: `vorher Basis Abo ` (in genau dieser Reihenfolge).
Kernpunkte:
- `Arbeite()` ruft die **virtuelle** Methode auf; es läuft die überschriebene Version in `Abgeleitet` (zuerst „vorher“).
- `base.OnFertig()` schreibt „Basis“ und löst dann das Ereignis aus, daher kommt der Abonnent („Abo“) zuletzt.
- Das zeigt, warum `OnXyz` `protected virtual` ist: Die abgeleitete Klasse steuert die Auslösung (hier ergänzt sie Ausgabe; sie könnte `base.OnFertig()` auch weglassen und das Ereignis damit unterdrücken).

Typische Irrtümer: „Basis vorher Abo“ (die Basisversion laufe zuerst); „Abo“ erscheine vor „Basis“; die Methode in der Basisklasse werde direkt aufgerufen, weil `Arbeite` dort steht.
