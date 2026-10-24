# Kollektionsinitialisierer und Kollektionsausdrücke

Lies im Buch **11.3 Kollektionsinitialisierer und Kollektionsausdrücke**
(Seite 695) und überfliege **11.2** (Seite 692) zu den Interfaces
`ICollection<T>` und `IEnumerable<T>`.

Öffne `Sammler.cs`. Die Klasse `Lager` ist vorgegeben und bleibt, wie sie ist.

1. `Wochentage()` liefert Montag bis Sonntag, gebaut mit einem
   **Kollektionsinitialisierer** (`new List<string> { ... }`).
2. `Zusammen(a, b)` und `MitRand(mitte, rand)` verwenden einen
   **Kollektionsausdruck** mit Spread-Element (`[..a, ..b]`).
3. `Leer<T>()` liefert mit `[]` eine leere, schreibgeschützte Liste.
4. `NeuesLager()` erzeugt ein `Lager` mit einem Objektinitialisierer, der die
   Eigenschaft `Artikel` mit einem verschachtelten Kollektionsinitialisierer
   füllt: `Artikel = { "...", "..." }`. Name und Artikel stehen im
   Kommentar im Code.
5. `FuelleAuf` schreibt gegen `ICollection<int>` und wird von den Tests mit
   einer `List<int>` und einem `HashSet<int>` aufgerufen. `Zaehle<T>` nutzt
   `Count`; `Gesamt` bekommt nur ein `IEnumerable<int>`, das kein `Count`
   kennt, und muss deshalb aufzählen.

Beantworte danach die Frage, welche Zeilen kompilieren.

Tests: `Wochentage_sind_sieben_in_der_richtigen_Reihenfolge`,
`Zusammen_haengt_b_hinter_a`, `MitRand_setzt_rand_vorn_und_hinten`,
`Leer_liefert_eine_leere_Liste_jeden_Typs`, `NeuesLager_hat_Name_und_drei_Artikel`,
`FuelleAuf_funktioniert_fuer_List`,
`FuelleAuf_funktioniert_fuer_HashSet_und_Duplikate_fallen_weg`,
`Zaehle_nutzt_ICollection` und
`Gesamt_summiert_jede_Folge_auch_eine_ohne_Count`.
