# Zusatz: Berechtigungen mit Flags

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**14.5.4 Bitfelder per FlagsAttribute** (Seite 937) und im Buch den
Abschnitt über Aufzählungstypen (6.4).

Ein Benutzer kann mehrere Rollen gleichzeitig haben. Statt vier
`bool`-Eigenschaften genügt ein einziges Bitfeld: Jede Rolle ist ein Bit,
eine Kombination ist die ODER-Verknüpfung.

1. `Rolle.cs`: Mach die Aufzählung mit `[Flags]` zum Bitfeld. Die Werte
   (1, 2, 4, 8) sind schon Zweierpotenzen; ohne `[Flags]` würde
   `Rolle.Leser | Rolle.Autor` als `3` ausgegeben.
2. `Benutzer.cs`: Implementiere
   - `Vergib(rolle)`: Bits setzen (`|=`),
   - `Entziehe(rolle)`: Bits löschen (`&= ~`),
   - `Darf(benoetigt)`: sind **alle** benötigten Bits gesetzt?
   - `Beschreibung()`: die Rollen als Text, z. B. `"Leser, Autor"`,
   - `Parse(text)`: der Gegenweg mit `Enum.Parse<Rolle>`, Groß- und
     Kleinschreibung egal; ein unbekannter Name wirft `ArgumentException`.

Diese Tests müssen bestehen:

- `RechteFlagsTests.Rolle_ist_ein_Bitfeld`
- `RechteFlagsTests.Neuer_Benutzer_hat_keine_Rolle`
- `RechteFlagsTests.Vergib_fuegt_Rollen_hinzu_und_behaelt_die_vorhandenen`
- `RechteFlagsTests.Entziehe_nimmt_nur_die_genannten_Rollen_weg`
- `RechteFlagsTests.Darf_verlangt_alle_benoetigten_Rollen`
- `RechteFlagsTests.Beschreibung_zaehlt_die_Rollen_auf`
- `RechteFlagsTests.Parse_liest_einzelne_und_kombinierte_Rollen`
- `RechteFlagsTests.Parse_wirft_bei_unbekanntem_Namen`
- `RechteFlagsTests.Beschreibung_und_Parse_sind_umkehrbar_fuer_alle_16_Kombinationen`
