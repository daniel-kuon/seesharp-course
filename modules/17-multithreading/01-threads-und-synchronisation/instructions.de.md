# Threads, lock und Interlocked

Lies im Buch **17.1 Einführung** (Seite 1062), **17.2.1 Threads erzeugen**
und **17.2.2 Threads starten** (Seite 1065 bis 1072), **17.2.4.1.1 Die
lock-Anweisung** (Seite 1073) und **17.2.4.2.3 Atomare Operationen** (Seite
1084). Threads teilen sich den Heap, haben aber jeder einen eigenen Stapel.
Genau das macht gemeinsame Daten gefährlich: Zwei Threads, die dieselbe
Variable ändern, können sich gegenseitig überschreiben.

**Alle Tests dieser Aufgabe sind deterministisch.** Sie messen keine Zeit
und schlafen nie. Sie warten mit `Join()` auf die Threads (die
Zeitgrenzen sind nur Schutz vor einem Hänger) und lassen die Threads über
eine `Barrier` gleichzeitig starten, damit sich ihre Arbeit maximal
überschneidet.

1. `Parallelrechner.Berechne` (Datei `Parallelrechner.cs`) wendet eine
   Funktion auf jedes Element eines Arrays an, verteilt auf Threads.
   `Quadrate` benutzt es schon. Zerlege das Array in zusammenhängende
   Blöcke (höchstens `threads` Stück, der letzte darf kürzer sein), starte für
   jeden Block einen eigenen `Thread`, der seine Ergebnisse in ein
   gemeinsames Ergebnisarray schreibt, und warte mit `Join()` auf alle. Die
   Threads schreiben auf verschiedene Elemente, das Array braucht kein
   `lock`. Beachte beim Lambda des Threads die Falle mit der Laufvariable
   (Closure, 10.1.5.3): Kopiere sie vorher in eine lokale Variable. `threads < 1` ist
   ein `ArgumentOutOfRangeException`.
2. `UnsichererZaehler` ist vorgegeben und absichtlich falsch. Lies den
   Kommentar und starte das Programm: Der Wert liegt meist unter 400000, und zwar
   bei jedem Lauf anders.
3. `SichererZaehler`: Schütze Erhöhen **und** Lesen mit `lock` auf einem
   privaten Sperrobjekt.
4. `AtomarerZaehler`: Erhöhe mit `Interlocked.Increment`, ohne `lock`.
5. Beantworte die Quizfrage zur Race Condition.

Diese Tests müssen bestehen:

- `SynchronisationTests.SichererZaehler_verliert_keine_Updates`
- `SynchronisationTests.AtomarerZaehler_verliert_keine_Updates`
- `SynchronisationTests.Zaehler_beginnen_bei_null_und_zaehlen_einzeln`
- `SynchronisationTests.Quadrate_liefert_alle_Quadrate_in_der_richtigen_Reihenfolge`
- `SynchronisationTests.Quadrate_funktioniert_auch_fuer_leere_kleine_und_ungerade_Arrays`
- `SynchronisationTests.Quadrate_veraendert_die_Eingabe_nicht`
- `SynchronisationTests.Weniger_als_ein_Thread_ist_ein_Fehler`
- `SynchronisationTests.Die_Bloecke_laufen_wirklich_gleichzeitig_auf_eigenen_Threads`
