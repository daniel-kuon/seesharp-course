# Rubrik — Geschachtelte Klassen (nur für die Betreuung)

- Der Zugriff `f.name` auf ein privates Feld der äußeren Klasse ist der
  Kern. Wer stattdessen `name` als Parameter durchreicht, hat die
  Besonderheit nicht genutzt; nachfragen.
- `Tochter` muss privat bleiben (der Reflection-Test prüft das); `Sohn` ist
  bewusst öffentlich, damit `new Familie.Sohn(...)` von außen geht. Die
  Schreibweise `Familie.Sohn` besprechen.
- Primärkonstruktoren: Warum werden die Parameter in Felder kopiert? (Ein
  Parameter, den eine Methode direkt benutzt, landet in einem versteckten,
  veränderlichen Feld; die expliziten `readonly`-Felder machen den Zustand
  sichtbar und unveränderlich. Wer den Parameter zusätzlich in einer Methode
  benutzt, speichert ihn doppelt, Warnung CS9124, Buch 5.4.3.2.1, Seite 347.)

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Geschachtelte Klassen`.
