# Rubrik — using, Dispose und AutoFlush (nur für die Betreuung)

- Kern: `using` ist `try/finally` mit `Dispose()`; die Freigabe läuft auch bei
  `return` und bei Ausnahmen, und zwar in umgekehrter Reihenfolge der Öffnung.
  Die Tests prüfen das mit einem zählenden Strom (`ZaehlenderStrom`, im
  Testprojekt): genau ein `Dispose`, Reihenfolge Ziel vor Quelle, auch wenn
  `ziel()` selbst wirft. Die erste Version der Starter hat `Close()` nur am Ende
  des Erfolgswegs; das sah im Normalfall richtig aus.
- Zwei Schreibweisen: `using (…) { … }` hat einen sichtbaren Bereich, die
  Deklaration `using var` gilt bis zum Ende des umgebenden Blocks. In
  `SchreibeSicher` steht `using var` innerhalb von `try`: Fehler beim Schließen
  (z. B. Flush auf vollen Datenträger) landen so im `catch`. Das ist die
  Antwort auf die Frage „using und try/catch kombinieren“ (16.2.5).
- Falle bei Ketten wie `new StreamReader(new FileStream(…))`: Der äußere Leser
  gibt den inneren Strom mit frei. Darum arbeiten die Methoden hier ohne
  Wrapper, sonst würde derselbe Strom zweimal freigegeben (harmlos, aber
  für den Zähler unübersichtlich).
- AutoFlush: Sicherheit gegen Tempo. Beim Protokoll ist es richtig (Zeile liegt
  im Strom, auch wenn das Programm danach abstürzt). Bei `SchreibeViele` ist es
  falsch, das ist die Buchaufgabe 16.7/2: nur den Schalter für die Schleife
  ausstellen; der Test zählt `Flush`-Aufrufe am zugrunde liegenden Strom
  (höchstens 5 bei 1000 Zeilen; das Zurückstellen von AutoFlush auf `true`
  löst selbst einen Flush aus). Ein dauerhaft ausgeschalteter AutoFlush nach
  `SchreibeViele` fällt im letzten Test durch.
- Abweichung vom Buch: Statt der Uhr misst der Test Flush-Aufrufe (deterministisch).

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/Freigabe von Ressourcen/*`.
