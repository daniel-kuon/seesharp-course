# Zusatz: Taschenrechner-ViewModel

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**12.13.3 Kommandobindung** (Seite 865) und **12.13.3.2 ... mit
CommandParameter-Übergabe** (Seite 867).

Ein Taschenrechner hat viele Tasten, aber nur wenige Befehle: Alle
Zifferntasten sind **derselbe** Befehl `ZifferCommand`, der per
`CommandParameter="7"` erfährt, welche Taste gedrückt wurde. Genauso
`OperatorCommand` (`"+"`, `"-"`, `"*"`, `"/"`). `ViewModelBase` und
`RelayCommand` liegen fertig bei. Öffne `RechnerViewModel.cs`: Die `TODO`-Hinweise
beschreiben jede Methode genau.

- `Anzeige` ist eine **berechnete** Eigenschaft (ohne eigenes Feld): Sie
  ergibt sich aus dem Zustand des Rechners (getippte Zahl, bisheriges
  Ergebnis, Fehlerzustand). Jede Taste, die etwas bewirkt, meldet
  `PropertyChanged("Anzeige")` genau einmal; Tasten ohne Wirkung melden nichts.
- Gerechnet wird von links nach rechts (`2 + 3 * 4 =` ergibt 20), mit
  Dezimalkomma. Nach `=` kann man mit einem Operator weiterrechnen; eine
  Ziffer beginnt eine neue Rechnung.
- Division durch 0 zeigt `Fehler`. Im Fehlerzustand wirkt nur `C`.
- Die Befehle prüfen ihre Parameter in `CanExecute`: Der Parameter ist ein
  `string` (so kommt er aus XAML), alles andere ist nicht ausführbar.

Diese Tests müssen bestehen:

- `RechnerTests.Startanzeige_ist_0`
- `RechnerTests.Ziffern_werden_angehaengt`
- `RechnerTests.Fuehrende_Null_wird_ersetzt`
- `RechnerTests.Komma_wird_einmal_angehaengt_und_ergibt_bei_leerer_Eingabe_0_Komma`
- `RechnerTests.Addition`
- `RechnerTests.Grundrechenarten`
- `RechnerTests.Es_wird_von_links_nach_rechts_gerechnet`
- `RechnerTests.Ein_zweiter_Operator_zeigt_das_Zwischenergebnis`
- `RechnerTests.Ein_zweiter_Operator_ersetzt_den_ersten`
- `RechnerTests.Nach_dem_Operator_zeigt_die_Anzeige_noch_den_linken_Operand`
- `RechnerTests.Nach_Gleich_kann_mit_dem_Ergebnis_weitergerechnet_werden`
- `RechnerTests.Nach_Gleich_beginnt_eine_Ziffer_eine_neue_Rechnung`
- `RechnerTests.Division_durch_0_zeigt_Fehler`
- `RechnerTests.Im_Fehlerzustand_wirkt_nur_C`
- `RechnerTests.C_setzt_alles_zurueck`
- `RechnerTests.Jede_wirksame_Taste_meldet_Anzeige_genau_einmal`
- `RechnerTests.Wirkungslose_Tasten_melden_nichts`
- `RechnerTests.Anzeige_ist_eine_berechnete_Eigenschaft`
- `RechnerTests.Die_Eingabe_ist_auf_15_Zeichen_begrenzt`
- `RechnerTests.ZifferCommand_lehnt_ungueltige_Parameter_ab`
- `RechnerTests.OperatorCommand_lehnt_ungueltige_Parameter_ab`
- `RechnerTests.Gueltige_Parameter_sind_ausfuehrbar`
