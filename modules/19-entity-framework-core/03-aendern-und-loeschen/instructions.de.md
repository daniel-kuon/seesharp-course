# Ändern, Löschen und Änderungsnachverfolgung

Lies im Buch **20.10 Nachverfolgung** und **20.11 Entitäten erstellen, modifizieren und
löschen**, besonders **20.11.2 Entitäten ändern** (Seite 1474), sowie **20.15.2**
(Seite 1492) zur Massenaktualisierung. Der Kontext **verfolgt** geladene Entitäten
**nach**: Er merkt sich ihren Zustand (`EntityState`: `Added`, `Unchanged`,
`Modified`, `Deleted`, `Detached`), und `SaveChanges` schreibt genau die Unterschiede.

`Produkt` (`Id`, `Name`, `Preis`, `Angelegt`), `ProduktContext` und die Aufzählung
`Aktion` sind vorgegeben. Öffne `Verwaltung.cs`:

1. `Umbenennen(id, neu)`: `Find`, Namen ändern, `SaveChanges()`; liefert dessen Rückgabewert
   (die Zahl der geschriebenen Zeilen). Gibt es das Produkt nicht, `0`. Du brauchst kein
   `Update`.
2. `Entfernen(id)`: `Find`, `Remove`, `SaveChanges`; `true`, wenn es etwas zu löschen gab.
3. `ZustandNach(aktion, id)`: führt die Aktion aus (neu mit `Add`; ohne zu laden mit
   `Attach`; laden und Namen ändern; laden und `Remove`; mit `AsNoTracking` laden) und liefert
   `kontext.Entry(produkt).State`. Erwartet: `Added`, `Unchanged`, `Modified`, `Deleted`,
   `Detached`. Es wird nichts gespeichert.
4. `UmbenennenOhneNachverfolgung(id, neu)`: lädt mit `AsNoTracking`, ändert den Namen, ruft
   `SaveChanges` auf und liefert dessen Ergebnis. Es ist `0`: Der Kontext kennt die
   Entität nicht, also wird nichts gespeichert.
5. `ErhoehePreise(kontext, faktor)`: **Massenänderung** mit `ExecuteUpdate` und `SetProperty`,
   ohne ein Produkt zu laden; liefert die Zahl der geänderten Zeilen.
   `LoescheAlte(kontext, grenze)`: dasselbe mit `ExecuteDelete` für Produkte, die vor `grenze`
   angelegt wurden. Der Test prüft, dass der Kontext danach nichts nachverfolgt.

Beantworte danach die Quizfrage.

Tests: `Umbenennen_aendert_die_verfolgte_Entitaet_und_speichert_eine_Zeile`,
`Umbenennen_eines_unbekannten_Produkts_schreibt_nichts`,
`Entfernen_loescht_das_Produkt_und_meldet_ob_es_eines_gab`, `ZustandNach_meldet_den_EntityState`,
`ZustandNach_speichert_nichts`, `Ohne_Nachverfolgung_speichert_SaveChanges_nichts`,
`ErhoehePreise_aendert_alle_Zeilen_ohne_Entitaeten_zu_laden`,
`LoescheAlte_loescht_per_ExecuteDelete_ohne_zu_laden`.
