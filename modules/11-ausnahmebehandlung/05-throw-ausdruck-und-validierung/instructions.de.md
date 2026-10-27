# throw-Ausdrücke und Validierung im SimpleStack

Lies im Buch **13.6 Ausnahmen werfen (throw)** (Seite 913) mit dem
`throw`-Ausdruck und danach die Übungsaufgabe **13.8 Nr. 4** (Seite 920). Den
generischen `SimpleStack<T>` kennst du aus Level 8 (Buch 8.2.1).

Der Stapel in `SimpleStack.cs` hat eine feste Kapazität, reagiert aber auf
Fehler zufällig: `Push` auf den vollen Stapel löst eine `IndexOutOfRangeException`
aus, `Pop` auf den leeren verdirbt `Count`. Melde jeden Fehler mit einer
Ausnahme, die zur Situation passt:

1. **Konstruktor:** Eine Kapazität `<= 0` löst eine
   `ArgumentOutOfRangeException` mit Parametername `"kapazitaet"` aus (statt
   still eine Standardgröße zu nehmen).
2. **`Push`** auf einem vollen Stapel und **`Pop`** auf einem leeren: eine
   `InvalidOperationException` mit deutscher Meldung. Das Objekt befindet sich
   dann im falschen Zustand für diese Operation (kein falsches Argument). Der Stapel
   darf nach dem Fehler nicht beschädigt sein.
3. **`Peek()`** wird per Lambda-Symbol und Ausdruck definiert (Buch 5.9.1):
   `=> anzahl > 0 ? items[anzahl - 1] : throw new InvalidOperationException(…);`
4. **`Name`:** Der Setter wirft bei `null` eine `ArgumentNullException`
   (Parametername `"value"`), geschrieben als throw-Ausdruck
   `value ?? throw new …`. Der Name bleibt dann unverändert.
5. **`Fuelle(IEnumerable<T> quelle)`** legt alle Elemente nacheinander auf den
   Stapel. Bei `null` wirft `ArgumentNullException.ThrowIfNull(quelle)` die Ausnahme
   (Parametername `"quelle"`).

Die Tests prüfen den Ausnahmetyp, `ParamName` und dass der Zustand nach dem
Fehler stimmt: `Konstruktor_wirft_bei_nicht_positiver_Kapazitaet`,
`Push_auf_vollem_Stapel_wirft_InvalidOperationException`,
`Pop_auf_leerem_Stapel_wirft_InvalidOperationException_und_ueberlebt`,
`Peek_auf_leerem_Stapel_wirft_InvalidOperationException`,
`Name_null_wirft_ArgumentNullException_und_laesst_den_Namen_unveraendert` und
`Fuelle_mit_null_wirft_ArgumentNullException_mit_Parametername`.
