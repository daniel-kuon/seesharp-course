# Rubrik — Zusatz Typed Client (nur für die Betreuung)

- Kern: Fehlerstatus gezielt unterscheiden (404 normal, 503 vorübergehend,
  übrige Fehler), statt jeden Fehler gleich zu behandeln. Typischer Fehler:
  Wiederholung bei jedem Fehler, `catch (Exception)` um alles, Zählfehler
  (vier statt drei Anforderungen, oder nur zwei).
- Eine echte Wiederholung wartet zwischen den Versuchen (`Task.Delay`, mit
  wachsender Pause) und beachtet Abbruchsignale; hier bewusst weggelassen,
  damit die Tests schnell und ohne Wanduhr laufen. Nachfrage: Wie würde man
  das ohne `Thread.Sleep` im Test prüfen (`TimeProvider`, Delegat für die Wartezeit)?
- `ReadFromJsonAsync` (nicht im Buch) ist in der Aufgabe vorgegeben; der
  Buchweg `ReadAsStringAsync` plus `JsonSerializer.Deserialize` mit
  camelCase-Optionen ist gleichwertig. Bonus (Deep Dive): `GetFromJsonAsync`
  wäre ohne Statusprüfung bequemer, wirft aber bei 404 eine Ausnahme; deshalb
  hier `GetAsync`.
- Die Antwort immer freigeben (`using var`); bei Wiederholung in einer Schleife
  sonst ein Verbindungsleck.

Modellantwort: `solution/`.
