# Warteschlange, Stapel und verkettete Liste

Lies im Buch die Einleitung von **11.4 Verwaltung einer Liste** (Seite 697),
wo `Queue<T>` (Warteschlange, FIFO) und `Stack<T>` (Stapel, LIFO) kurz genannt
werden, und **11.4.2 Klasse LinkedList<T> mit doppelt verketteten Knoten**
(Seite 700).

Öffne `Warteschlangen.cs`. Dort stehen vier Klassen. Die Signaturen bleiben
unverändert. Pflicht ist die verkettete Liste:

1. `ZuletztGeoeffnet` hält in einer `LinkedList<string>` die zuletzt
   geöffneten Namen. `Oeffne()` stellt den Namen nach vorn (ein vorhandener wird
   verschoben) und wirft bei voller Liste den letzten Eintrag weg. `Liste()`
   läuft vom ersten Knoten über `Next`, `ListeRueckwaerts()` vom letzten über
   `Previous`.

Die Aufgabe gilt als bestanden, wenn diese Tests grün sind:
`Zuletzt_geoeffnet_stellt_den_neuesten_Namen_nach_vorn`,
`Zuletzt_geoeffnet_verschiebt_vorhandene_Namen`,
`Zuletzt_geoeffnet_wirft_den_aeltesten_Namen_bei_voller_Liste_raus`,
`Zuletzt_geoeffnet_erneutes_Oeffnen_bei_voller_Liste_wirft_nichts_raus` und
`Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge`.

> **Deep Dive (optional):** Das Buch nennt `Queue<T>` und `Stack<T>` nur
> (einen einfachen Stapel hast du in 8.2.1 selbst gebaut). Die drei übrigen
> Klassen sind ein Beispiel dafür, was du dir als Nächstes ansehen kannst. Du
> brauchst: `Queue<T>` mit `Enqueue()`, `Dequeue()` (entnimmt das älteste
> Element), `Peek()` (zeigt es nur) und `Count`; `Stack<T>` mit `Push()`,
> `Pop()` (entnimmt das oberste Element), `Peek()`, `Count` und `Clear()`.
> `Dequeue()`, `Pop()` und `Peek()` lösen bei einer leeren Kollektion eine
> Ausnahme aus.
>
> - `Druckerwarteschlange` arbeitet nach dem FIFO-Prinzip mit einer
>   `Queue<string>`. `Naechster()` und `Peek()` liefern `null`, wenn nichts
>   wartet; `Dequeue()` auf einer leeren Queue würde eine Ausnahme auslösen,
>   also erst `Count` prüfen. `Peek()` entnimmt nichts.
> - `KlammernPruefer.IstAusgeglichen` prüft mit einem `Stack<char>`, ob `()`,
>   `[]` und `{}` richtig verschachtelt sind: `"([]{})"` ja, `"([)]"` und
>   `"(("` nein, der leere Text ja. Andere Zeichen werden ignoriert.
> - `Verlauf` ist ein Browserverlauf mit zwei Stapeln. `Besuche()` zeigt eine
>   neue Seite und löscht den Vor-Stapel; `Zurueck()` und `Vor()` liefern die
>   Seite, die danach angezeigt wird, oder `null`, wenn es keine gibt.
>
> Zusätzliche Tests (sie zählen nicht für das Bestehen):
> `Warteschlange_liefert_in_Ankunftsreihenfolge`,
> `Warteschlange_leer_liefert_null_statt_Ausnahme`, `Peek_entnimmt_nichts`,
> `Warteschlange_kann_nach_dem_Leeren_weiterverwendet_werden`,
> `Klammern_werden_richtig_geprueft`, `Verlauf_vor_dem_ersten_Besuch_ist_leer`,
> `Verlauf_zurueck_und_vor` und `Neuer_Besuch_loescht_den_Vor_Stapel`.
