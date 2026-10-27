# Rubrik — Zusatz Berechtigungen mit Flags (nur für die Betreuung)

- Kern: Ein Bitfeld packt viele Ja/Nein-Merkmale in eine Zahl; `[Flags]`
  ändert nicht die Arithmetik, sondern nur, wie `ToString` Kombinationen
  darstellt (`Enum.Parse` liest `"Leser, Autor"` auch ohne `[Flags]`). Der Test `Rolle_ist_ein_Bitfeld` und die
  Beschreibung prüfen genau das.
- `Darf`: `(Rollen & benoetigt) == benoetigt`. Wer `!= 0` schreibt, prüft nur,
  ob irgendeine Rolle passt. `Rolle.Keine` ist immer erfüllt.
- `Entziehe`: `Rollen &= ~rolle`. Fehler: `Rollen ^= rolle` schaltet um und
  würde eine nicht vorhandene Rolle setzen. Der Test entzieht deshalb auch
  `Rolle.Admin`, die der Benutzer gar nicht hat.
- Gesprächsanlass: Warum Zweierpotenzen? (Jede Rolle belegt ein eigenes
  Bit; sonst überlappen Kombinationen.) Warum ist `Keine = 0` sinnvoll?
  Was passiert mit einem zusätzlichen Wert `Redakteur = Leser | Autor`?
  (Er erscheint dann bei der Ausgabe statt der Einzelnamen.)

Modellantwort: `solution/`.
