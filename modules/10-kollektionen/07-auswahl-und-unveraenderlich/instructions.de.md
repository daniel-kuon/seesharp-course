# Die richtige Kollektion; schreibgeschützt und unveränderlich

Lies im Buch **11.7 Unveränderliche Kollektionen** (Seite 716), dazu
**11.1 Arrays versus Kollektionen** (Seite 691) und die Übungsaufgaben
**11.8** (Seite 723).

**Teil 1: Programmieren.** Öffne `Kurs.cs`. Ein `Kurs` verwaltet seine
Teilnehmer in einer privaten `List<string>`. Gib sie auf zwei Arten nach
außen:

1. `Teilnehmer` liefert eine schreibgeschützte **Sicht** (`AsReadOnly()`). Wer
   sie bekommt, kann nichts ändern, sieht aber spätere Anmeldungen. Gib nicht
   die Liste selbst als `IReadOnlyList<string>` zurück: Der Aufrufer könnte sie
   mit einem Cast wieder zur Liste machen und verändern. Der Test prüft das.
2. `Schnappschuss()` liefert eine `ImmutableList<string>` (`using
   System.Collections.Immutable;` steht schon in der Datei). Sie ist eine
   **Kopie** zum Zeitpunkt des Aufrufs und sieht spätere Anmeldungen nicht.
3. `MitTeilnehmer(liste, name)` zeigt, dass `Add()` bei einer unveränderlichen
   Liste eine **neue** Liste liefert; die alte bleibt, wie sie war.

**Teil 2: Fragen.** Beantworte die Fragen im Anschluss: die Aussagen aus
Buchaufgabe 11.8 Nr. 1, sechs Szenarien (welche Kollektion passt?) und die
Frage zu den zwölf Monaten.

Tests: `Teilnehmer_ist_eine_Sicht_und_sieht_spaetere_Anmeldungen`,
`Teilnehmer_gibt_nicht_die_List_selbst_heraus`,
`Schnappschuss_sieht_spaetere_Anmeldungen_nicht` und
`MitTeilnehmer_liefert_eine_neue_Liste_und_laesst_das_Original_unveraendert`.
