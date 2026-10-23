# Rubrik — Zusatzaufgabe Girokonto (nur für die Betreuung)

- `Kontostand` hat einen `private set`: Nur die Methoden der Klasse ändern
  ihn. Nachfragen, warum ein öffentlicher Setter die ganze Validierung in
  `Abheben` aushebeln würde (Datenkapselung, Level 1).
- Doppelter Code in den beiden Konstruktoren ist hier erwartet; die
  Verkettung mit `: this(...)` kommt erst in Level 6. Wer sie schon kennt,
  darf sie benutzen.
- `Ueberweise` sollte `Abheben` und `Einzahlen` wiederverwenden statt
  `Kontostand` direkt zu rechnen. `ziel == this` vergleicht Referenzen.
- `decimal` statt `double`: Test `Einzahlen_nur_positive_Betraege` rechnet
  mit `5.50m`; mit `double` wäre das hier zwar noch exakt, im Gespräch aber
  an `0.1 + 0.2` erinnern.
- Nachfrage: Warum ist `naechsteNummer` statisch, `Nummer` aber nicht?

Modellantwort: `solution/Konto/Konto.cs`.
