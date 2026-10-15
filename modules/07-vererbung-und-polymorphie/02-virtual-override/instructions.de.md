# Polymorphie: virtual und override

Lies im Buch **7.9 Polymorphie (Überschreiben von Methoden)** (Seite 566)
und **7.10 Versiegelte Methoden und Klassen** (Seite 570). Zum Kontrast
hilft ein Blick in **7.6.1 Methoden ausblenden** (Seite 555): Der Starter
benutzt dort noch `new`.

Im Starter verdeckt `Kreis` die Mitglieder `Name`, `Wo()` und `Skaliere()`
mit `new`. Das funktioniert nur, solange man über eine `Kreis`-Referenz
zugreift; über eine `Figur`-Referenz läuft die Basisfassung. Die Tests
greifen über `Figur`-Referenzen zu.

1. Markiere in `Figur` die drei Mitglieder `Name`, `Wo()` und `Skaliere()`
   als `virtual`.
2. Ersetze in `Kreis` `new` durch `override`. `Wo()` nutzt weiterhin
   `base.Wo()` für die erste Zeile und hängt die zweite an.
3. Überschreibe in `Rechteck` dieselben drei Mitglieder: `Name` liefert
   `"Rechteck"`, `Wo()` ergänzt `"\nUnten Rechts: (x + breite; y + hoehe)"`
   (Zahlen im Format `{wert:0}` wie in `Figur`), `Skaliere` multipliziert
   Breite und Höhe. `Wo()` bekommt zusätzlich `sealed`, damit Unterklassen
   von `Rechteck` es nicht mehr überschreiben können.

`Beschreibe()` in `Figur` ist absichtlich **nicht** virtuell: Es ruft `Name`
und `Wo()` auf und bekommt trotzdem das Verhalten der abgeleiteten Klasse,
weil diese Aufrufe virtuell aufgelöst werden.
