# Eine eigene IDisposable-Klasse

Lies im Buch **5.4.5 Überflüssige Objekte abräumen** (Seite 355), **16.2.1
Dispose() oder Close()** und **16.2.2 Garbage Collector** (Seite 1026).

Wer eine Datei oder eine andere externe Ressource in einem Feld hält, muss
seinen Benutzern das Freigeben ermöglichen: durch `IDisposable`. Dann
funktionieren `using`-Anweisung und `using`-Deklaration auch für deine
Klasse. Öffne `Logbuch.cs`. Das Logbuch öffnet im Konstruktor eine Datei und
schreibt mit `Eintrag(text)` Zeilen hinein:

1. `Dispose()` schließt den `StreamWriter` (und damit die Datei).
2. `Dispose()` ist **idempotent**: Ein zweiter oder dritter Aufruf tut nichts.
3. Nach `Dispose()` wirft `Eintrag(…)` eine `ObjectDisposedException`
   (Tipp: `ObjectDisposedException.ThrowIf(bedingung, this)`; sie ist von
   `InvalidOperationException` abgeleitet).
4. Die statische Eigenschaft `Offene` zählt Logbücher, die erzeugt und noch
   nicht freigegeben wurden: Sie wird nach dem erfolgreichen Öffnen der Datei im
   Konstruktor hochgezählt (scheitert der Konstruktor, gibt es nichts
   freizugeben) und in `Dispose()` genau einmal heruntergezählt.

Einen Finalizer (`~Logbuch`) brauchst du nicht: Die Klasse hält nur ein
verwaltetes Objekt, das sich selbst um die Datei kümmert (16.2.2).

Diese Tests müssen bestehen:

- `LogbuchTests.Logbuch_implementiert_IDisposable`
- `LogbuchTests.Eintraege_stehen_nach_dem_Dispose_in_der_Datei`
- `LogbuchTests.Dispose_gibt_die_Datei_frei`
- `LogbuchTests.Offene_zaehlt_erzeugte_und_noch_nicht_freigegebene_Logbuecher`
- `LogbuchTests.Zweites_Dispose_tut_nichts`
- `LogbuchTests.Eintrag_nach_Dispose_wirft_ObjectDisposedException`
- `LogbuchTests.Using_gibt_auch_frei_wenn_eine_Ausnahme_durchlaeuft`
- `LogbuchTests.Scheitert_der_Konstruktor_wird_nichts_gezaehlt`
- `LogbuchTests.Ohne_Dispose_bleibt_die_Datei_gesperrt`
