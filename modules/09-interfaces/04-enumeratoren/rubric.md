# Rubrik — Enumeratoren (nur für die Betreuung)

- Die schwerste Übung des frühen Kurses (siehe MODULE-MAP). Häufige Fehler:
  `MoveNext` erhöht über das Ende hinaus immer weiter (dann klappt `Reset`
  zwar, aber `Current` ist unsauber), oder der Enumerator wird als Feld
  der Liste wiederverwendet (verschachtelte Schleifen brechen; der Test
  `Jeder_GetEnumerator_Aufruf_ist_unabhaengig` fängt das).
- Warum zwei `GetEnumerator`? Explizite Implementierung der
  nicht-generischen Schnittstelle aus 9.2 wiederholen.
- `Dispose()` leer: `foreach` ruft es am Ende; bei Dateien o. Ä. würde man
  hier aufräumen (Level 15).
- Ausblick: Die nächste Übung ersetzt die ganze Klasse durch `yield`.

Modellantwort: `solution/`; das Buch hat keinen handgeschriebenen Enumerator,
`samples/Interfaces/Enumeratoren` zeigt die `yield`-Fassung.
