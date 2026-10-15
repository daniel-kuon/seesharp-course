# Konstruktoren

Lies im Buch Abschnitt **5.4.3 Einsatzvorbereitung** (Seite 340), besonders
5.4.3.1.1 Standardkonstruktor und 5.4.3.1.2 Explizite Konstruktoren.

Öffne `Bruch.cs` und vervollständige die Klasse `Bruch`:

1. Der Konstruktor `Bruch(int zpar, int npar, string epar)` setzt Zähler, Nenner
   und Etikett. Weise über die **Eigenschaften** zu, nicht über die Felder,
   damit die Validierung im Setter greift (Nenner 0 wird ignoriert, Etikett auf
   40 Zeichen gekürzt).
2. `Kuerze()` kürzt den Bruch mit dem größten gemeinsamen Teiler (Euklid,
   Modulo-Variante). Ein Bruch mit Zähler 0 wird zu 0/1.
3. `Addiere(Bruch b)` addiert `b` zu diesem Bruch und kürzt anschließend.
4. `Addiere(int zpar, int npar, bool autokurz)` addiert `zpar/npar`. Bei
   `npar == 0` passiert nichts und die Methode liefert `false`; sonst `true`,
   und bei `autokurz` wird gekürzt.

`Bruchrechnung.cs` enthält ein `Main` zum Ausprobieren; die Tests prüfen nur
`Bruch`.
