# Rubrik — Konstruktoren (nur für die Betreuung)

Beim Review mit dem Trainee ansehen:

- Weist der Konstruktor über `Zaehler = …` / `Nenner = …` zu oder direkt über
  die Felder? Direkt über Felder lässt `Konstruktor_ignoriert_Nenner_null`
  scheitern — falls er grün ist, trotzdem fragen, warum die Eigenschaft der
  bessere Weg ist.
- `Kuerze()`: Euklid mit `%` in einer `do`/`while`-Schleife, `Math.Abs` für
  negative Brüche. Ein handgeschriebener Teilerschleifenlauf von 1 bis n ist
  korrekt, aber Anlass, über Laufzeit zu sprechen.
- `Addiere(Bruch b)` sollte `Kuerze()` wiederverwenden, nicht den Algorithmus
  kopieren.
- Die `bool`-Rückgabe der zweiten `Addiere`-Überladung: Was passiert mit dem
  Objekt, wenn `false` zurückkommt? (Nichts — gute Gelegenheit für das Thema
  Invarianten.)

Modellantwort: `samples/Klassen und Objekte/Bruch/b2 Konstruktoren` im
Tool-Repository.
