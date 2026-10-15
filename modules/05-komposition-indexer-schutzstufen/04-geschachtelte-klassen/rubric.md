# Rubrik — Geschachtelte Klassen (nur für die Betreuung)

- Der Zugriff `f.name` auf ein privates Feld der äußeren Klasse ist der
  Kern. Wer stattdessen `name` als Parameter durchreicht, hat die
  Besonderheit nicht genutzt; nachfragen.
- `Tochter` muss privat bleiben (der Reflection-Test prüft das); `Sohn` ist
  bewusst öffentlich, damit `new Familie.Sohn(...)` von außen geht. Die
  Schreibweise `Familie.Sohn` besprechen.
- Primärkonstruktoren: Warum werden die Parameter in Felder kopiert? (Sonst
  entstehen Capture-Felder mit Doppelspeicherung, siehe Buch 7.4.3.2.)

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Geschachtelte Klassen`.
