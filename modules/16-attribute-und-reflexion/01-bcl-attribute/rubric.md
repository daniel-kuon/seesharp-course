# Rubrik — BCL-Attribute (nur für die Betreuung)

- Kern: Attribute sind Metadaten, die nicht die Logik der Methode ändern,
  sondern vom Compiler (`Obsolete`, `CallerMemberName`) oder von der
  Laufzeit/Werkzeugen (`Flags` beim `ToString`) gelesen werden. Die Tests
  prüfen `Obsolete` und `Flags` per Reflexion; `Caller*` zeigt sich am
  Ergebnis.
- `nameof` lässt sich nicht testen, ohne umzubenennen: Im Code nachsehen, ob
  `nameof(name)` statt `"name"` steht. Gesprächsanlass: Was passiert beim
  Refaktorieren mit einem Literal? (Es bleibt veraltet.) Warum nimmt man bei
  Eigenschaften lieber `[CallerMemberName]`? (Der Name kommt automatisch.)
- `[Obsolete(..., true)]` würde den Aufruf zum Compilerfehler machen; hier
  bewusst `false`. Frage: Wann ist welche Variante angebracht?
- `Hat`: `(vorhanden & gesucht) == gesucht`. Das Muster `(vorhanden & gesucht) != 0`
  prüft nur, ob IRGENDEIN Bit passt; der Test mit `Lesen` gegen
  `Lesen | Schreiben` entlarvt das. `Entziehe`: `vorhanden & ~entzogen`.
- Ohne `[Flags]` liefert `(Rechte)3` den Text `3`; mit `[Flags]` zerlegt
  `ToString` in die Einzelnamen. Die Werte müssen Zweierpotenzen sein, sonst
  ist die Zerlegung nicht eindeutig.
- Die Zeilennummer im Test wird mit demselben Attribut ermittelt (zwei
  Anweisungen in einer Zeile): ein schöner Beleg, dass der Compiler den Wert
  fest einsetzt, nicht erst zur Laufzeit ermittelt.

Modellantwort: `solution/`.
