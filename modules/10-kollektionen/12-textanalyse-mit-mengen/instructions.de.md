# Zusatz: Textanalyse mit Mengen

Lies noch einmal **11.5.2 Hashtabellen und die Klasse HashSet<T>** (Seite 704).

Öffne `Textvergleich.cs`. Zwei Texte werden verglichen, indem man ihre
Wortmengen vergleicht.

1. `Woerter(text)` liefert die **verschiedenen** Wörter als `HashSet<string>`,
   klein geschrieben. Trennzeichen sind Leerzeichen und `, . ; : ! ? -`.
2. `Gemeinsam(a, b)` liefert die Wörter, die in beiden Mengen vorkommen,
   alphabetisch sortiert als `List<string>` (`Sort()`).
3. `NurInA(a, b)` liefert die Wörter, die nur in `a` vorkommen, ebenfalls
   sortiert.
4. `Aehnlichkeit(a, b)` berechnet die Jaccard-Ähnlichkeit: Anzahl der
   gemeinsamen Wörter geteilt durch Anzahl aller Wörter (Vereinigung), als
   `double`. Zwei leere Mengen ergeben 0.

Die Argumente `a` und `b` dürfen nicht verändert werden. Die Tests verwenden
zwei kurze deutsche Sätze: `Woerter_liefert_verschiedene_Woerter_in_Kleinbuchstaben`,
`Gemeinsam_liefert_die_gemeinsamen_Woerter_alphabetisch`,
`NurInA_liefert_die_Woerter_die_in_b_fehlen`,
`Aehnlichkeit_ist_Schnittmenge_durch_Vereinigung` und
`Die_Eingabemengen_bleiben_unveraendert`.
