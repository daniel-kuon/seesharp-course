# Rubrik — Zusatz URL-Sammler (nur für die Betreuung)

- Deep-Dive-Aufgabe (nicht im Buch), freiwillig. Kern: Wiederholung von Aufgabe 2 ohne Vorgaben: `Uri.TryCreate` statt
  Ausnahmen, `UriBuilder` und `EscapeDataString`. Typischer Fehler:
  Zeichenketten mit `Split('?')` und Verkettung statt `Uri`/`UriBuilder`;
  vorhandene Werte doppelt kodieren (`%2520`); Parameterreihenfolge
  verändern (Wörterbuch ohne Ordnung statt Liste von Paaren).
- Stolperstein `Uri.Host`: kleingeschrieben, bei IPv6 in eckigen Klammern.
  Standardports verschwinden in `AbsoluteUri` (`:443` bei `https`), ein
  anderer Port bleibt.
- Gesprächsanlass: Warum nimmt `Lese` nur `http` und `https` an? (Auf Linux
  gilt auch `/tmp/x` als absolute Datei-URI; ohne die Schema-Prüfung käme
  ein leerer Host in die Liste.)

Modellantwort: `solution/`.
