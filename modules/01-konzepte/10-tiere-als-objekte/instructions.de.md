# Zusatz: Tiere als Objekte

Zusatzaufgabe: freiwillig, sie blockiert nichts. Level 1 ist sonst reine
Theorie; hier probierst du Klasse, Objekt und Nachricht einmal im Code aus.

Lies im Buch **1.3 Objektorientierte Programmierung** (Seite 9) und
**1.5 Startklasse und Main()-Methode** (Seite 12). Dort entsteht ein Objekt
mit `Bruch b = new Bruch();`, und `b.Kuerze()` schickt ihm eine Nachricht.

Öffne `Tiere.cs`. Die Klassen `Hund` und `Katze` sind Baupläne; ihre
Methoden haben kein `static`, sie gehören also zu den **Objekten**, nicht zur
Klasse. Vervollständige:

1. `Hund`: `Name()` liefert `Bello`, `Laut()` liefert `Wuff`,
   `StellDichVor()` liefert `Bello sagt Wuff` und ruft dafür `Name()` und
   `Laut()` auf (Zeichenketten verbindest du mit `+`).
2. `Katze`: dasselbe mit `Minka` und `Miau`.
3. `Zoo.Konzert()` ist `static`. Erzeuge darin mit `new` einen Hund und eine
   Katze und liefere `Bello sagt Wuff, Minka sagt Miau`, indem du beiden
   Objekten die Nachricht `StellDichVor()` schickst.

Diese Tests müssen bestehen:

- `TiereTests.Ein_Hund_heisst_Bello_und_sagt_Wuff`
- `TiereTests.Ein_Hund_stellt_sich_vor`
- `TiereTests.Eine_Katze_heisst_Minka_und_sagt_Miau`
- `TiereTests.Eine_Katze_stellt_sich_vor`
- `TiereTests.Im_Konzert_stellen_sich_beide_vor`
