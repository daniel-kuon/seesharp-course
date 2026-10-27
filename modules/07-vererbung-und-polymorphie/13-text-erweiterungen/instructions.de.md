# Zusatz: Erweiterungsmitglieder für string

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**7.15.2 Erweiterungsblöcke (ab C# 14)** (Seite 583) und **7.15.3
Erweiterungsmethoden mit this-Parameter** (Seite 585).

`string` ist versiegelt, du kannst keine Unterklasse bilden. Mit
Erweiterungsmitgliedern rüstest du trotzdem Eigenschaften, Methoden und
sogar einen Operator nach. Öffne `TextExtensions.cs`; die Blöcke und
Signaturen stehen schon:

1. Im Block `extension(string text)` (Instanzmitglieder):
   - `IstPalindrom` (Eigenschaft): `true`, wenn der Text vorwärts und
     rückwärts gleich lautet. Groß-/Kleinschreibung zählt nicht, und es
     zählen nur Buchstaben und Ziffern (`char.IsLetterOrDigit`, nicht im
     Buch, hier vorgegeben; zum Vergleichen `char.ToUpper` wie in 6.6):
     `"Ein Esel lese nie."` ist ein Palindrom. Der leere Text auch.
   - `AnzahlWoerter` (Eigenschaft): Wörter sind durch Leerzeichen getrennt,
     mehrere Leerzeichen hintereinander zählen wie eines
     (`Split(' ', StringSplitOptions.RemoveEmptyEntries)`).
   - `Umgedreht()`: der Text rückwärts (ein `StringBuilder` hilft).
   - `WortanfaengeGross()`: jeder Buchstabe am Textanfang oder nach einem
     Leerzeichen wird groß, alles andere bleibt, wie es ist:
     `"hallo  welt"` wird `"Hallo  Welt"`.
2. Im Block `extension(string)` (statische Mitglieder):
   - `string.Wiederhole(text, anzahl)`: den Text `anzahl`-mal
     hintereinander; `anzahl <= 0` liefert `""`.
   - `operator *`: `"ab" * 3` ergibt `"ababab"`; nutze `Wiederhole`.
3. Klassische Erweiterungsmethode `Zaehle(this string text, char zeichen)`:
   wie oft kommt das Zeichen vor?

Diese Tests müssen bestehen:

- `TextwerkzeugeTests.IstPalindrom_ignoriert_Gross_und_Satzzeichen`
- `TextwerkzeugeTests.AnzahlWoerter_ueberspringt_mehrfache_Leerzeichen`
- `TextwerkzeugeTests.Umgedreht_liefert_den_Text_rueckwaerts`
- `TextwerkzeugeTests.WortanfaengeGross_aendert_nur_Wortanfaenge`
- `TextwerkzeugeTests.Wiederhole_ist_ein_statisches_Erweiterungsmitglied`
- `TextwerkzeugeTests.Operator_Mal_wiederholt_den_Text`
- `TextwerkzeugeTests.Zaehle_ist_eine_klassische_Erweiterungsmethode`
