# Warteschlange, Stapel und verkettete Liste

Lies im Buch die Einleitung von **11.4 Verwaltung einer Liste** (Seite 697),
wo `Queue<T>` und `Stack<T>` kurz genannt werden, und
**11.4.2 Klasse LinkedList<T> mit doppelt verketteten Knoten** (Seite 700).
Das Buch behandelt `Queue<T>` und `Stack<T>` nicht weiter (einen einfachen
Stapel hast du in 8.2.1 selbst gebaut). Du brauchst: `Queue<T>` mit
`Enqueue()`, `Dequeue()` (entnimmt das älteste Element), `Peek()` (zeigt es
nur) und `Count`; `Stack<T>` mit `Push()`, `Pop()` (entnimmt das oberste
Element), `Peek()`, `Count` und `Clear()`. `Dequeue()`, `Pop()` und `Peek()`
lösen bei einer leeren Kollektion eine Ausnahme aus.

Öffne `Warteschlangen.cs`. Dort stehen vier Klassen. Die Signaturen bleiben
unverändert.

1. `Druckerwarteschlange` arbeitet nach dem FIFO-Prinzip mit einer
   `Queue<string>`. `Naechster()` und `Peek()` liefern `null`, wenn nichts
   wartet; `Dequeue()` auf einer leeren Queue würde eine Ausnahme auslösen,
   also erst `Count` prüfen. `Peek()` entnimmt nichts.
2. `KlammernPruefer.IstAusgeglichen` prüft mit einem `Stack<char>`, ob `()`, `[]`
   und `{}` richtig verschachtelt sind: `"([]{})"` ja, `"([)]"` und `"(("`
   nein, der leere Text ja. Andere Zeichen werden ignoriert.
3. `Verlauf` ist ein Browserverlauf mit zwei Stapeln. `Besuche()` zeigt eine
   neue Seite und löscht den Vor-Stapel; `Zurueck()` und `Vor()` liefern die
   Seite, die danach angezeigt wird, oder `null`, wenn es keine gibt.
4. `ZuletztGeoeffnet` hält in einer `LinkedList<string>` die zuletzt
   geöffneten Namen. `Oeffne()` stellt den Namen nach vorn (ein vorhandener wird
   verschoben) und wirft bei voller Liste den letzten Eintrag weg. `Liste()`
   läuft vom ersten Knoten über `Next`, `ListeRueckwaerts()` vom letzten über
   `Previous`.

Die Tests prüfen nur Inhalt und Reihenfolge. Wichtige Tests:
`Warteschlange_liefert_in_Ankunftsreihenfolge`, `Peek_entnimmt_nichts`,
`Klammern_werden_richtig_geprueft`, `Verlauf_zurueck_und_vor`,
`Neuer_Besuch_loescht_den_Vor_Stapel`,
`Zuletzt_geoeffnet_verschiebt_vorhandene_Namen` und
`Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge`.
