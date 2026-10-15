# Hallo SeeSharp

Diese Übung prüft, ob deine Werkzeugkette steht: Rider öffnet das Projekt, du
baust es, die Tests laufen. Lies vorher im Buch Abschnitt **3.1.4 Quellcode in
IL-Code übersetzen und Programm erstellen** (Seite 71) und **3.1.5 Ausführen**
(Seite 74).

Öffne `Hallo.cs`. Die Klasse `Hallo` hat eine `Main`-Methode, die bereits
`Gruss()` aufruft. Vervollständige die statische Methode `Gruss()`, sodass sie
genau den Text `Hallo, echt .NET hier!` zurückgibt.

Starte das Programm einmal mit `Strg+F5`, um die Ausgabe zu sehen. Setze
anschließend einen Haltepunkt in `Main()` und starte im Debug-Modus.

Diese Tests müssen bestehen:

- `HalloTests.Gruss_liefert_die_Begruessung`
- `HalloTests.Gruss_endet_mit_Ausrufezeichen`
