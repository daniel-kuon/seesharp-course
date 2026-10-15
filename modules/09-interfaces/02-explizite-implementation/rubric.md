# Rubrik — Explizite Implementierung (nur für die Betreuung)

- Syntaxfalle: explizite Implementierungen dürfen keinen Modifizierer
  tragen (kein `public`); Fehlermeldung CS0106 besprechen, falls sie
  auftrat.
- Reflection-Test prüft, dass `Sensor` kein öffentliches `Wert()` mehr hat.
- Anwendung in der BCL: `IEnumerable.GetEnumerator()` explizit, generische
  Fassung öffentlich — kommt in 9.4/9.5 dieses Levels.
- Nachfrage: Was liefert `((IZaehler)new Geraet()).Wert()` und warum?

Modellantwort: `solution/` bzw. `samples/Interfaces/Explizite Implementation`.
