# Aufgaben: Task.Run, WhenAll, WhenAny, ContinueWith

Lies im Buch **17.5.1 Aufgaben ohne bzw. mit Rückgabe erstellen** (Seite
1120, besonders 17.5.1.3.2 `Run()` auf Seite 1124), **17.5.5.2 Warten auf
mehrere Aufgaben** (Seite 1129), **17.5.8 Fortsetzungsaufgaben** (Seite 1138),
**17.5.9 Metaaufgaben** mit `WhenAll` und `WhenAny` (Seite 1142) und
**17.7.3 Task-Verpackung für beliebige asynchrone Operationen** mit
`TaskCompletionSource` (Seite 1205).

Eine `Task` ist ein Versprechen auf ein späteres Ergebnis. `Task.Run` startet
Arbeit im Threadpool, `ContinueWith` hängt Folgearbeit an, `WhenAll` und
`WhenAny` kombinieren Aufgaben, und `TaskCompletionSource<T>` verwandelt
alles, was ein Ereignis ist, in eine Aufgabe, die du selbst beendest.

**Die Tests sind deterministisch:** Sie messen keine Zeit und schlafen nie.
Aufgaben, die "irgendwann" fertig werden, sind in den Tests
`TaskCompletionSource`-Objekte, die der Test selbst beendet. Die
Wartezeiten im Test sind reine Hängerschutz-Grenzen.

Ergänze in `Berechnungen.cs`:

1. `SummeParallel(int[] a)`: vier Aufgaben mit `Task.Run`, jede summiert einen
   Abschnitt zu einem `long`. Das Gesamtergebnis ist die Summe der vier
   `Result`-Werte. Der `Sensor` in `Sensor.cs` ist vorgegeben.
2. `AlleFertig(aufgaben)`: eine Aufgabe, die erst fertig wird, wenn **alle**
   fertig sind, und dann die sortierten Ergebnisse liefert. Die Methode
   blockiert nicht: `Task.WhenAll(...)`, dann `ContinueWith`.
3. `ErsterFertiger(a, b)`: das Ergebnis der Aufgabe, die zuerst fertig wird
   (`WhenAny`). Die andere Aufgabe darf nie fertig werden; auf sie zu warten wäre
   ein Fehler.
4. `Verdopple(t)`: eine Fortsetzung, die nach `t` das Doppelte von `t.Result`
   liefert. `Verdopple` blockiert nicht.
5. `WartenAufMesswert(sensor)`: eine `Task<double>`, die vom
   `TaskCompletionSource<double>` kommt und mit dem ersten `Messwert`-Ereignis
   fertig wird. Danach meldet sich die Methode wieder vom Ereignis ab, weitere
   Messwerte ändern nichts.

Diese Tests müssen bestehen:

- `AufgabenTests.SummeParallel_summiert_Arrays_jeder_Groesse`
- `AufgabenTests.SummeParallel_rechnet_mit_long_und_ueberlaeuft_nicht`
- `AufgabenTests.SummeParallel_summiert_viele_Elemente`
- `AufgabenTests.AlleFertig_wird_erst_fertig_wenn_alle_fertig_sind_und_sortiert`
- `AufgabenTests.AlleFertig_mit_leerer_Folge_liefert_ein_leeres_Array`
- `AufgabenTests.ErsterFertiger_nimmt_die_fertige_Aufgabe_auch_wenn_die_andere_nie_fertig_wird`
- `AufgabenTests.Verdopple_wartet_nicht_und_setzt_nach_dem_Ende_fort`
- `AufgabenTests.Verdopple_funktioniert_auch_fuer_eine_schon_fertige_Aufgabe`
- `AufgabenTests.WartenAufMesswert_ist_erst_nach_dem_Ereignis_fertig`
- `AufgabenTests.WartenAufMesswert_nimmt_nur_den_ersten_Wert_und_meldet_sich_ab`
- `AufgabenTests.WartenAufMesswert_kann_mehrfach_hintereinander_benutzt_werden`
