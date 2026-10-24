# Null-Operatoren: ?., ??, ??= und null-bedingte Zuweisung

Lies im Buch **15.1.5 null-Operatoren** (Seite 968) mit **15.1.5.2
null-bedingter Operator** (Seite 969), dort auch die **null-bedingte
Zuweisung** von C# 14.

Öffne `Auskunft.cs` (die Klassen `Adresse`, `Kunde` und `Zaehler` stehen in
`Modell.cs`). Löse jede Methode mit den Operatoren und ohne `if (x == null)`:

1. `Ortsname(Kunde? k)`: Ort in Großbuchstaben (`ToUpper()`), sonst
   `"unbekannt"`, egal auf welcher Ebene der Kette `null` steht. Eine Zeile
   mit `?.` und `??`.
2. `Laenge(string[]? a)`: Länge oder 0. `Erstes(List<string>? l)`: erstes
   Element oder `null` (der Indexzugriff heißt `?[ ]`).
3. `Nachschlagen(Dictionary<string,string>? d, string schluessel)`: der Wert
   oder `"(kein Eintrag)"`, wenn es das Wörterbuch nicht gibt oder der
   Schlüssel fehlt. Tipp: `d?.TryGetValue(schluessel, out var wert) == true`.
4. `Zaehler.Fuege(string)`: Die Liste `Eintraege` wird erst beim ersten
   Eintrag angelegt, mit `??=`.
5. `SetzeAlter`, `SetzeAlterBerechnet` und `Erhoehe`: Verwende die
   **null-bedingte Zuweisung** `k?.Alter = alter` (bzw. `+=`). Der Rückgabewert
   sagt, ob es einen Kunden gab. Bei `SetzeAlterBerechnet` darf die
   Funktion `berechne` nur aufgerufen werden, wenn `k` nicht `null` ist.

Diese Tests müssen bestehen:

- `NulloperatorenTests.Ortsname_mit_vollstaendiger_Kette`
- `NulloperatorenTests.Ortsname_mit_null_auf_jeder_Ebene`
- `NulloperatorenTests.Laenge_von_Array_und_null`
- `NulloperatorenTests.Erstes_liefert_Element_oder_null`
- `NulloperatorenTests.Nachschlagen_findet_oder_liefert_Vorgabe`
- `NulloperatorenTests.Zaehler_legt_die_Liste_erst_beim_ersten_Eintrag_an`
- `NulloperatorenTests.SetzeAlter_ohne_Kunde_tut_nichts`
- `NulloperatorenTests.SetzeAlter_setzt_das_Alter`
- `NulloperatorenTests.SetzeAlterBerechnet_wertet_die_rechte_Seite_nur_bei_Kunde_aus`
- `NulloperatorenTests.Erhoehe_addiert_nur_bei_vorhandenem_Kunde`
