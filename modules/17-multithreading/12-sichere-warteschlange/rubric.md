# Rubrik — Zusatz Sichere Warteschlange (nur für die Betreuung)

- Kern: Eine Sammlung, die mehrere Threads benutzen, braucht einen
  einzigen Schutz für ALLE Zugriffe, auch fürs Lesen (`Anzahl`). Ein
  `lock` nur in `Einreihen` genügt nicht. Prüfen: Sind alle drei Mitglieder
  unter derselben Sperre?
- Der klassische Fehler heißt "Check-then-act": `if (q.Count > 0) return
  q.Dequeue();` mit zwei getrennten gesperrten Schritten (oder gar ungesperrt)
  lässt einen anderen Thread dazwischen. Der Test fängt ihn nur mit einer
  gewissen Wahrscheinlichkeit; im Code nachsehen, ob Prüfen und Entnehmen
  im selben `lock` stehen.
- Gesprächsanlass: Die BCL hat `ConcurrentQueue<T>` und
  `BlockingCollection<T>`; wann baut man trotzdem selbst? (Zum Lernen, oder
  wenn mehrere Operationen zusammen atomar sein müssen.) Und: Warum warten
  die Verbraucher im Test aktiv mit `Thread.Yield()` statt zu schlafen?
  (Kein Schlafen heißt kein zeitabhängiges Verhalten; echte Verbraucher würden
  mit `Monitor.Wait/Pulse` oder `BlockingCollection` blockieren, siehe 17.2.4.1.2.2.)
- Teil der Testlogik: Die Verbraucher beenden sich erst, wenn
  `alleEingereiht` gesetzt ist UND die Warteschlange leer ist. Das
  Signal setzt der Test selbst, nachdem er alle Erzeuger mit `Join()`
  abgewartet hat; so braucht die Aufgabe weder Schlafen noch Zeitmessung.

Modellantwort: `solution/`.
