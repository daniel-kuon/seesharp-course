# Zusatz: Druckaufträge und Rückgängig-Stapel

Lies noch einmal die Einleitung von **11.4 Verwaltung einer Liste** (Seite 697),
wo `Stack<T>` und `Queue<T>` kurz genannt werden; die Methoden kennst du aus
Aufgabe 3.

Öffne `Druckauftraege.cs`. Dort stehen zwei Klassen.

1. `Texteditor` hat `Tippe(string)`, `Rueckgaengig()` und `Wiederholen()`,
   umgesetzt mit zwei Stapeln, die frühere Textstände enthalten. `Tippe` hängt
   Text an, merkt den alten Stand und leert den Wiederholen-Stapel.
   `Rueckgaengig` und `Wiederholen` liefern `false`, wenn es nichts zu tun gibt.
2. `Druckwarteschlange` druckt Aufträge strikt in Ankunftsreihenfolge, Seite
   für Seite. `Auftrag("Bericht", 3)` reiht die Seiten `"Bericht 1/3"`,
   `"Bericht 2/3"` und `"Bericht 3/3"` ein, `NaechsteSeite()` liefert die
   nächste (oder `null`), `Wartend` zählt die offenen Seiten. Bei weniger als
   einer Seite wird nichts eingereiht.

Tests (sie rufen die Methoden nacheinander auf und prüfen die Ergebnisse):
`Rueckgaengig_nimmt_die_letzte_Aenderung_zurueck`,
`Wiederholen_stellt_zurueckgenommene_Aenderungen_wieder_her`,
`Neues_Tippen_loescht_den_Wiederholen_Stapel` und
`Auftraege_werden_in_Ankunftsreihenfolge_Seite_fuer_Seite_gedruckt`.
