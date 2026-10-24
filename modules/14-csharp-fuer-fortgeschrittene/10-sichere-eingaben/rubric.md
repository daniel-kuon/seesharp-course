# Rubrik — Zusatz: Sichere Eingaben (nur für die Betreuung)

- Kern: `?.` und `??` ersetzen Null-Prüfungen und kurze `if`-Ketten; mit `string?`
  im Parameter weiß der Compiler und der Aufrufer, dass `null` erlaubt ist.
- Kein `!` im Projekt. Wer eines braucht, hat die Kette falsch aufgebaut;
  gemeinsam anschauen.
- Typische Lösung `Alter`: `int.TryParse(daten?.GetValueOrDefault("alter"), out var a) ? a : 0`.
  `TryParse` akzeptiert ein `string?`, daher keine Warnung.
- `Bereinige`: Nach `string.IsNullOrEmpty(t)` weiß der Compiler (Attribut
  `[NotNullWhen(false)]`), dass `t` im Else-Zweig nicht null ist.
- Nachfrage: Warum liefert `ErstesWort(null)` `""` und nicht `null`? (Der Rückgabetyp
  bleibt ohne Nullbehandlung für den Aufrufer.)

Modellantwort: `solution/`.
