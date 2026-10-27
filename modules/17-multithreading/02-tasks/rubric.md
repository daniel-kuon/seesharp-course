# Rubrik — Aufgaben (nur für die Betreuung)

- Kern: Eine `Task` trennt das Starten einer Arbeit vom Abholen des
  Ergebnisses. Wer `.Result` aufruft, blockiert den aufrufenden Thread; wer
  `ContinueWith` hängt, blockiert nicht. Die Tests unterscheiden das:
  `AlleFertig` und `Verdopple` müssen mit einer noch nicht fertigen Quelle
  sofort zurückkehren (`IsCompleted` ist `false`). Eine Abgabe, die intern
  `WaitAll` oder `.Result` benutzt, hängt (der Aufruf kehrt nie zurück) und
  scheitert erst an der Zeitgrenze der Bewertung, nicht an der des Tests.
- `SummeParallel`: Das Muster Aufgaben in einer Liste sammeln und DANACH die
  Ergebnisse abholen ist wichtig. Wer in derselben Schleife `Task.Run(...).Result`
  schreibt, rechnet nacheinander: Das Ergebnis stimmt, der Sinn ist verfehlt.
  Auf Code-Ebene prüfen. Die Closure-Falle mit der Schleifenvariable `i`
  kommt auch hier vor.
- `ErsterFertiger`: Das Ergebnis von `WhenAny` ist selbst eine Aufgabe, die die
  zuerst fertige Aufgabe als Ergebnis hat: zwei `Result` in Folge.
  Gesprächsanlass: Was passiert mit der langsameren Aufgabe? (Sie läuft
  weiter; WhenAny bricht nichts ab.)
- `WartenAufMesswert`: Der Test `nimmt_nur_den_ersten_Wert` fängt das
  doppelte `SetResult` ab (`InvalidOperationException`, die in `Melde`
  auftauchen würde); `TrySetResult` oder Abmelden löst es. Das Abmelden
  verhindert außerdem, dass der Sensor eine erledigte Aufgabe ewig
  festhält. Wer ein Lambda abmelden will, braucht eine Variable für den
  Delegaten: ein guter Anlass zur Frage, warum `s.Messwert -= wert => ...`
  nichts bewirkt.
- Im Test stehen die Quellen mit `TaskCreationOptions.RunContinuationsAsynchronously`,
  damit Fortsetzungen der Abgabe nicht im Testthread laufen. Das ist ein
  guter Einstieg in die Frage, auf welchem Thread eine Fortsetzung läuft.
- Die Aufgabe liefert die TCS-Anwendung, die das Buch in 17.7.3 für
  APM/EAP beschreibt, an einem Alltagsfall: einem Ereignis.

Modellantwort: `solution/`.
