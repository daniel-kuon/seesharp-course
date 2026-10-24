# Rubrik — Bibliotheksauskunft (Zusatzaufgabe, nur für die Betreuung)

- Kernidee: `Join` für „Paare, die zusammenpassen“, `GroupJoin` für „zu jedem
  Element die (evtl. leere) Menge seiner Partner“. `NieAusgeliehen` ist der
  typische Anwendungsfall der leeren Gruppe.
- Das Buch mit unbekanntem Autor (AutorId 99) fehlt in `BuecherMitAutor` (innerer
  Join) und erscheint in `NieAusgeliehen`.
- Typischer Fehler: `Where` vor dem `Join` statt danach oder `Any` statt
  `GroupJoin` — beides richtig, wenn es funktioniert; Effizienz besprechen:
  `Join` baut intern eine Nachschlagetabelle, geschachteltes `Any` rechnet n * m.

Modellantwort: `solution/`.
