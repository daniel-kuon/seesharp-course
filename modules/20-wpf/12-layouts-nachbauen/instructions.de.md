# Zusatz: Layouts nachbauen

Zusatzaufgabe: freiwillig, sie schaltet nichts frei und wird von der
Betreuung geprüft. Sie braucht Windows und ein WPF-Projekt in Rider (Zieltyp
`net10.0-windows`, wie in Aufgabe 5). Zum Nachlesen: **12.11 Layoutcontainer**
(Seite 804) mit **12.11.1 Grid** (Seite 807), **12.11.2 DockPanel**
(Seite 812), **12.11.3 StackPanel** (Seite 814), **12.11.4 WrapPanel**
(Seite 815) und **12.11.7 Geschachtelte Layoutcontainer** (Seite 818).

Baue zwei Fenster nach. Die Skizzen sind nur Anhaltspunkte: Es kommt auf das
Verhalten beim Verändern der Fenstergröße an, nicht auf Pixel.

**Skizze 1: Anmeldung**

```text
+--------------------------------------+
|  Anmeldung                           |
|                                      |
|  Benutzername  [____________________]|
|  Passwort      [____________________]|
|  [x] Angemeldet bleiben              |
|                                      |
|              [Abbrechen]  [Anmelden] |
+--------------------------------------+
```

- Beschriftungen und Eingabefelder bilden ein `Grid` mit zwei Spalten
  (`Auto` und `*`). Die Eingabefelder wachsen mit dem Fenster.
- Die Schaltflächen liegen in einem `StackPanel` (horizontal) rechts unten.

**Skizze 2: Mail-Fenster**

```text
+----------------------------------------------------------+
| Datei  Bearbeiten  Ansicht                  (Menüleiste) |
+----------------------------------------------------------+
| [Alle] [Ungelesen] [Wichtig] [Anhang] ...  (Schnellfilter)|
+------------+-------------------+-------------------------+
| Ordner     | Nachrichten       | Lesebereich             |
|  Posteingang|  Betreff 1        |                         |
|  Gesendet  |  Betreff 2        |  (nimmt den Rest ein)   |
|  Entwürfe  |  Betreff 3        |                         |
+------------+-------------------+-------------------------+
| 3 Nachrichten                              (Statuszeile) |
+----------------------------------------------------------+
```

- Das Fenster ist ein `DockPanel`: Menüleiste oben, Statuszeile unten, der
  Rest füllt die Mitte.
- Die Schnellfilter liegen in einem `WrapPanel`: Wird das Fenster schmaler,
  rutschen die Knöpfe in eine zweite Zeile.
- Die drei Bereiche sind ein `Grid` mit drei Spalten und zwei `GridSplitter`.
  Der Lesebereich (`*`) nimmt den Platz.

Beantworte außerdem: Warum ist `Canvas` für beide Fenster ungeeignet?
