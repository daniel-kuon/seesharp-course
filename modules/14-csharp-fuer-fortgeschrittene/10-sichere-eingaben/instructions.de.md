# Zusatz: Sichere Eingaben

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**15.1.5 null-Operatoren** (Seite 968) und **15.1.2 Nullzustandsanalyse**
(Seite 953).

Echte Eingaben sind oft `null`, leer oder unvollständig. Die drei Methoden
in `Eingaben.cs` funktionieren nur für saubere Daten. Mach sie robust, ohne
ein einziges `!`; das Projekt hat `<WarningsAsErrors>nullable</WarningsAsErrors>`,
jede offene Nullwarnung bricht also den Build.

1. `Bereinige(string? s)`: Leerraum an den Rändern entfernen; bleibt nichts
   übrig (oder ist `s` `null`), kommt `"(leer)"` heraus.
2. `ErstesWort(string? s)`: das erste Wort (durch Leerzeichen getrennt,
   leere Teile ignorieren); `""` bei `null`, leerem Text oder nur
   Leerzeichen.
3. `Alter(Dictionary<string, string>? daten)`: der Eintrag `"alter"` als
   Zahl; `0`, wenn es kein Wörterbuch, keinen Eintrag oder keine Zahl gibt.

Diese Tests müssen bestehen:

- `EingabenTests.Parameter_sind_als_nullable_markiert`
- `EingabenTests.Bereinige_trimmt_und_ersetzt_Leeres`
- `EingabenTests.Bereinige_null_ist_leer`
- `EingabenTests.ErstesWort_findet_das_erste_Wort`
- `EingabenTests.ErstesWort_null_ist_leer`
- `EingabenTests.Alter_liest_den_Eintrag`
- `EingabenTests.Alter_hat_den_Vorgabewert_null`
