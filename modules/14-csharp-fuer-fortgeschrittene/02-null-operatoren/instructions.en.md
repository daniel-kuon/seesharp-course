# Null Operators: ?., ??, ??=, and Null-Conditional Assignment

Read the section on **null operators** (page 968) in Chapter **15.1.5**, along with **15.1.5.2**, "**Null-Conditional Operators**" (page 969), and also the section on **null-conditional assignments** in C# 14.

Open `Auskunft.cs` (the classes `Adresse`, `Kunde`, and `Zaehler` are defined in `Modell.cs`). Break down each method using the operators and without the `if (x == null)` statement:

1. `Ortsname(Kunde? k)`: Place name in uppercase (`ToUpper()`); otherwise, `"unbekannt"`, regardless of the level in the chain where `null` appears. A line containing `?.` and `??`.
2. `Laenge(string[]? a)`: Length or 0. `Erstes(List<string>? l)`: First element or `null` (the index access is denoted by `?[ ]`).
3. `Nachschlagen(Dictionary<string,string>? d, string schluessel)`: the value or `"(kein Eintrag)"` if the dictionary does not exist or the key is missing. Tip: `d?.TryGetValue(schluessel, out var wert) == true`.
4. `Zaehler.Fuege(string)`: The list `Eintraege` is created only when the first entry is made, using `??=`.
5. `SetzeAlter`, `SetzeAlterBerechnet`, and `Erhoehe`: Use the **null-conditional assignment** `k?.Alter = alter` (or `+=`). The return value indicates whether a customer existed. For `SetzeAlterBerechnet`, the function `berechne` must only be called if `k` is not `null`.

The following tests must be passed:

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
