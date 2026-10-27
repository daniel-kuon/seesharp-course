# Nullable-Kontext und Nullzustandsanalyse

Lies im Buch **15.1.1 Explizite null-(Un)zulässigkeit** (Seite 949),
**15.1.2 Nullzustandsanalyse** (Seite 953) und **15.1.4 Attribute zur
Unterstützung der Nullzustandsanalyse** (Seite 962).

Im Projekt steht `<Nullable>enable</Nullable>` und zusätzlich
`<WarningsAsErrors>nullable</WarningsAsErrors>`: Jede offene Warnung der
Nullzustandsanalyse bricht den Build (15.1.3.3, Seite 961; das Buch zählt
dort die einzelnen Warnungsnummern auf, `nullable` steht für alle
Nullwarnungen). `Reverse` ist die Methode aus Übungsaufgabe 1 in 15.7
(Seite 1012). Das Starterprojekt übersetzt deshalb
noch nicht; ändere die `.csproj`-Datei nicht, sondern behebe die Ursachen
im Code. Öffne `PalindromReverse.cs` und `Kunde.cs`:

1. `PalindromReverse.Reverse`: Der Parameter darf `null` sein, dann ist das
   Ergebnis `null`, sonst der umgekehrte Text. Beschreibe das mit `string?`
   und `[return: NotNullIfNotNull(nameof(s))]`, damit `string r =
   Reverse("abc");` ohne Warnung übersetzt.
2. `PalindromReverse.TryFinde`: Liefert `true` und den ersten Eintrag, der
   mit `prefix` beginnt (`StringComparison.Ordinal`), sonst `false` und
   `null`. Der `out`-Parameter ist `string?` mit `[NotNullWhen(true)]`.
3. `PalindromReverse.ErstesVorhandenes`: Der Build bricht an `First`.
   Behebe die Warnung durch eine Schleife **oder** durch genau ein `!`
   mit einem Kommentar, warum der Wert hier nicht `null` sein kann. Mehr
   als ein `!` im Projekt ist ein Zeichen, dass etwas falsch modelliert ist.
4. `Kunde`: `Name` ist nie `null` und wird im Konstruktor gesetzt,
   `Spitzname` darf fehlen. `Anzeige()` liefert `"Name (Spitzname)"` oder nur
   `"Name"`.

Diese Tests müssen bestehen:

- `NullsicherheitTests.Reverse_kehrt_um`
- `NullsicherheitTests.Reverse_null_liefert_null`
- `NullsicherheitTests.Reverse_Parameter_ist_als_nullable_markiert`
- `NullsicherheitTests.Reverse_hat_NotNullIfNotNull`
- `NullsicherheitTests.TryFinde_findet_den_ersten_Treffer`
- `NullsicherheitTests.TryFinde_ohne_Treffer_liefert_false_und_null`
- `NullsicherheitTests.TryFinde_hat_NotNullWhen_true`
- `NullsicherheitTests.ErstesVorhandenes_ueberspringt_null`
- `NullsicherheitTests.ErstesVorhandenes_wirft_wenn_alles_null_ist`
- `NullsicherheitTests.Kunde_Name_ist_nicht_nullable_Spitzname_schon`
- `NullsicherheitTests.Anzeige_mit_Spitzname`
- `NullsicherheitTests.Anzeige_ohne_Spitzname`
