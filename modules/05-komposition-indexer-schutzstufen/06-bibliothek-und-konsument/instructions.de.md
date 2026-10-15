# Bibliothek und Konsument: FractionLib

Lies im Buch Abschnitt **5.13 Schutzstufen für Klassen und ihre Mitglieder**
(Seite 398) mit 5.13.1 (Klassen) und 5.13.2 (Mitglieder). Zum Projektverweis
hilft **3.3.10.1 Projektverweise** (Seite 128), falls du den Aufbau nicht mehr vor Augen hast.

Dieses Mal gibt es zwei Projekte:

- `FractionLib` ist eine **Klassenbibliothek** (`OutputType` Library, keine
  `Main`-Methode). Sie enthält die fertige Klasse `Bruch` im Namensraum
  `de.bebagoe.fraction`.
- `Bruchrechnung` ist ein Konsolenprojekt mit einem **Projektverweis** auf
  `FractionLib` (sieh in `Bruchrechnung.csproj` nach).

Aufgaben:

1. In `FractionLib/Bruch.cs` ist die Hilfsmethode `Ggt` fälschlich `public`.
   Sie gehört nicht zur Schnittstelle der Bibliothek: Ändere die Schutzstufe
   auf `internal`, damit nur Code innerhalb von `FractionLib` sie sieht.
   Prüfe anschließend in `Bruchrechnung`, dass `Bruch.Ggt(…)` dort nicht mehr
   kompiliert.
2. Sieh dir in `Bruchrechnung/Rechner.cs` die `using`-Direktive an: Ohne
   `using de.bebagoe.fraction;` kennt das Konsolenprojekt den Typ `Bruch`
   nicht, obwohl der Projektverweis gesetzt ist (Namensraum und Assembly sind
   zwei verschiedene Dinge, siehe Level 1).
3. `Rechner.Summe(params Bruch[] brueche)` startet mit `new Bruch(0, 1, "Summe")`,
   addiert alle Brüche mit `+=` und liefert das Ergebnis mit dem Etikett
   `"Summe"` (nach dem Addieren noch einmal setzen, denn `+=` hängt Etiketten
   an). Die übergebenen Brüche bleiben unverändert.
4. `Rechner.Mittel(...)`: Summe bilden, Nenner mit der Anzahl multiplizieren,
   kürzen, Etikett `"Mittel"`.

Das Testprojekt referenziert beide Projekte und prüft per Reflection, dass
`Ggt` nicht öffentlich ist.
