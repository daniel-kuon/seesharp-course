# Closures, Func und Action

Lies im Buch **10.1.5 Delegatenobjekte durch anonyme Funktionen erstellen**
(Seite 665) mit **10.1.5.3 Eingefangene Kontextvariablen** (Seite 671) und die
Übungsaufgabe **10.3 Aufgabe 3** (Seite 689, `ListLE(k)`).

Ein Lambda darf Variablen der Umgebung benutzen; sie leben dann so lange
wie das Delegatenobjekt (Closure). Öffne `Fabrik.cs`:

1. `KleinerGleich(k)`: liefert ein `Predicate<int>` für Werte `<= k`.
2. `Zaehler()`: liefert ein `Func<int>`, das bei jedem Aufruf 1, 2, 3, ...
   zurückgibt. Jeder Aufruf von `Zaehler()` hat seinen eigenen Zustand.
3. `Addierer(n)`: `Func<int, int>`, das `n` addiert.
4. `Komponiere(f, g)`: liefert die Funktion `x => g(f(x))`.
5. `FuehreAus(aktionen)`: ruft alle `Action`-Delegaten der Reihe nach auf.
6. `ErzeugeAktionen(sb, n)`: liefert `n` Aktionen; Aktion `i` hängt `i` an
   `sb` an (`i` = 0 bis `n - 1`). Die Tests führen sie in umgekehrter
   Reihenfolge aus. Achtung: Welche Variable fängt das Lambda ein?
7. `Merke(f)`: liefert eine Funktion, die `f` für jedes Argument höchstens
   einmal aufruft und sich die Ergebnisse merkt.

Tests: `KleinerGleich_erzeugt_passende_Praedikate`,
`Zaehler_zaehlt_ab_eins`, `Zaehler_haben_getrennten_Zustand`,
`Addierer_addiert`, `Komponiere_wendet_erst_f_dann_g_an`,
`FuehreAus_ruft_alle_Aktionen_auf`,
`Aktionen_fangen_ihren_eigenen_Index_ein`,
`Merke_ruft_f_pro_Argument_einmal_auf`.
