# Abstrakte Klassen und Mitglieder

Lies im Buch **7.13 Abstrakte Methoden und Klassen** (Seite 577) und zur
Einordnung **7.14 Das Liskovsche Substitutionsprinzip** (Seite 579).

Im Starter ist `Figur` eine konkrete Klasse mit nichtssagenden
Standardimplementierungen: `Skaliere` tut nichts, `Inhalt` und `Breite`
liefern 0. Das ist unehrlich, eine "Figur an sich" hat keine Fläche. Besser
ist, die Basisklasse zu zwingen, dass jede konkrete Unterklasse diese
Mitglieder liefert:

1. Mache `Figur` `abstract` und deklariere `Skaliere`, `Inhalt` und
   `Breite` als abstrakte Mitglieder ohne Rumpf (`public abstract double
   Inhalt { get; }`). `Wo()` bleibt virtuell mit Implementierung.
2. Implementiere die drei Mitglieder in `Kreis` (Fläche `π·r²`, Breite
   `2·r`) und `Rechteck` (Fläche `b·h`, Breite `b`); `Skaliere` ignoriert
   negative Faktoren.
3. `Figur.Gesamtflaeche(Figur[])` summiert `Inhalt` über alle Figuren. Das
   geht nur, weil jede Figur garantiert einen Inhalt hat.

Probiere danach aus, dass eine Zeile `new Figur(1.0, 2.0)` in `Program.cs`
nicht mehr kompiliert, `Figur[]` als Typ aber weiterhin erlaubt ist.
