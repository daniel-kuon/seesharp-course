# Primzahltest, switch-Ausdruck, foreach

Lies im Buch **4.7.3.1 Zählergesteuerte Schleife (for)** (Seite 271),
**4.7.3.2 foreach** (Seite 273), **4.7.3.6 Schleifen vorzeitig beenden**
(Seite 278, dort steht das Primzahlprogramm) und **4.7.2.4 switch-Ausdruck**
(Seite 268). Vorlage ist Aufgabe 3 in
**4.7.4** (Seite 282).

Öffne `Schleifen.cs`:

1. `IstPrim(long n)` liefert `true`, wenn `n` eine Primzahl ist. Zahlen unter
   2 sind keine. Prüfe Teiler von 2 bis zur Wurzel von `n` in einer
   `for`-Schleife **ohne `break` und ohne `continue`**: Baue die
   Abbruchbedingung in den Schleifenkopf ein (zum Beispiel mit einer
   `bool`-Variablen).
2. `Wochentag(int tag)` liefert per `switch`-Ausdruck `"Montag"` für 1 bis
   `"Sonntag"` für 7, sonst `"ungültig"`.
3. `AnzahlVokale(string text)` zählt mit `foreach` die Vokale a, e, i, o, u
   (Groß- und Kleinschreibung egal).

Diese Tests müssen bestehen:

- `SchleifenTests.Primzahlen_werden_erkannt`
- `SchleifenTests.Nicht_Primzahlen_werden_abgelehnt`
- `SchleifenTests.Wochentag_1_ist_Montag`
- `SchleifenTests.Wochentag_7_ist_Sonntag`
- `SchleifenTests.Wochentag_ausserhalb_ist_ungueltig`
- `SchleifenTests.Vokale_werden_gezaehlt`
- `SchleifenTests.Vokale_ohne_Treffer`
