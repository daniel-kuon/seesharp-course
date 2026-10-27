# Multithreading und asynchrone Programmierung

Ein Programm, das mehrere Dinge zugleich erledigt, nutzt mehrere Threads
(Kapitel 17, Seite 1061). Dieses Level ist ein Wahlmodul und gehört zu den
anspruchsvollsten des Kurses, weil Fehler hier vom Zufall abhängen: Derselbe
Code liefert mal das richtige, mal ein falsches Ergebnis.

## Threads (17.1 und 17.2, Seite 1062 bis 1072)

Alle Threads eines Prozesses teilen sich den Heap, jeder hat aber einen
eigenen Stapel mit seinen lokalen Variablen (17.1.1). Das nutzt der
Parallelität (mehrere Kerne, ein wartender Thread blockiert die anderen
nicht) und kostet Komplexität: Gemeinsame Daten müssen geschützt werden. Ein
`Thread` wird mit einem Delegaten erzeugt, mit `Start()` gestartet, und
`Join()` wartet auf sein Ende (17.2.1 und 17.2.2). Ein Lambda fängt
Variablen ein, nicht ihre Werte (10.1.5.3, Seite 671): Die Laufvariable einer
`for`-Schleife kopiert man deshalb vorher in eine lokale Variable, sonst
sehen die Threads ihren späteren Wert.

## Zugriff koordinieren (17.2.4, Seite 1072 bis 1085)

Eine **Race Condition** entsteht, wenn zwei Threads dieselbe Variable ohne
Schutz ändern. Schon `zaehler++` besteht aus Lesen, Addieren und
Schreiben; zwei Threads können denselben alten Wert lesen, und ein Update
geht verloren. Die `lock`-Anweisung (17.2.4.1.1, Seite 1073) lässt nur
einen Thread zugleich in den geschützten Block und gehört auf ein privates
Objekt. Für einzelne Operationen auf Zahlen genügt `Interlocked`, etwa
`Increment` oder `Add`, das aus den drei Schritten einen einzigen
unteilbaren macht (17.2.4.2.3, Seite 1084). Sammlungen wie `List<T>` oder
`Queue<T>` vertragen gleichzeitigen Zugriff nicht: Jeder Zugriff gehört unter
dieselbe Sperre.

## Aufgaben (17.5, Seite 1118 bis 1152)

Die Task Parallel Library hebt die Ebene an: Eine `Task<T>` ist ein
Versprechen auf ein späteres Ergebnis. `Task.Run` startet Arbeit im
Threadpool (17.5.1.3.2, Seite 1124); `Result` wartet und holt das Ergebnis.
`Task.WhenAll` und `Task.WhenAny` kombinieren Aufgaben, `ContinueWith`
hängt Folgearbeit an (17.5.8 und 17.5.9, Seite 1138 bis 1142). Eine Ausnahme in
einer Aufgabe wird erst beim Warten sichtbar, als `AggregateException`
mit allen Fehlern; `Flatten()` löst verschachtelte Gruppen auf (17.5.6,
Seite 1129). Abbrechen ist **kooperativ**: Der Aufrufer ruft `Cancel()` einer
`CancellationTokenSource` auf, die Aufgabe prüft ihr `CancellationToken`,
am einfachsten mit `ThrowIfCancellationRequested()`, und endet dann als
"abgebrochen" (17.5.10, Seite 1145). `TaskCompletionSource<T>` macht aus
einem Ereignis oder einer beliebigen asynchronen Operation eine Aufgabe
(17.7.3, Seite 1205).

## Parallel und PLINQ (17.5.11 und 18.5, Seite 1152 und 1245)

`Parallel.Invoke` verteilt mehrere Aktionen, `Parallel.For` und
`Parallel.ForEach` verteilen Schleifeniterationen selbständig auf Threads (Seite 1153 bis 1157), mit
`ParallelOptions` lässt sich der Grad begrenzen. `AsParallel()` parallelisiert
LINQ-Abfragen; `AsOrdered()` stellt die ursprüngliche Reihenfolge wieder
her (18.5.5, Seite 1252). Alles, was die Iterationen gemeinsam benutzen,
braucht Schutz.

## async und await (17.6, Seite 1161 bis 1202)

`async` und `await` schreiben asynchronen Code wie sequenziellen. Eine
`async`-Methode liefert `Task` oder `Task<T>` (17.6.4); beim `await` gibt sie
den Thread frei und läuft nach dem Ende der erwarteten Aufgabe weiter
(17.6.5). Ausnahmen kommen beim `await` im Originaltyp an (17.6.7),
Abbruch läuft über ein durchgereichtes `CancellationToken` (17.6.8).
Zwei Fallen (17.6.12): Bei `async void` kann der Aufrufer weder warten
noch Ausnahmen abfangen, eine Ausnahme beendet z. B. eine
Konsolenanwendung; `async void` gehört nur zu Ereignishandlern; und das Blockieren mit `.Result` oder `.Wait()` kann in einer
Anwendung mit Benutzeroberfläche zu einem Deadlock führen, weil die
Fortsetzung auf den blockierten UI-Thread wartet.

## Zum Üben

Die Aufgaben sind **deterministisch**: keine Zeitmessung, kein
`Thread.Sleep` in Prüfungen. Auf Ergebnisse wird mit `Join()`,
`TaskCompletionSource`, `ManualResetEventSlim` oder einer `Barrier` gewartet;
Zeitgrenzen sind nur Hängerschutz. Eine Race Condition lässt sich so nicht
zuverlässig nachweisen, wohl aber die korrekte Variante: Sie muss jedes Mal
das exakte Ergebnis liefern.
