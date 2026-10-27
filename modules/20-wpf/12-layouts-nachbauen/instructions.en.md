# Extra: Recreating Layouts

Extra exercise: optional; it unlocks nothing and will be reviewed by the supervisor. It requires Windows and a WPF project in Rider (target type `net10.0-windows`, as in Exercise 5). For further reading: **12.11 Layout Containers** (page 804) including **12.11.1 Grid** (page 807), **12.11.2 DockPanel** (page 812), **12.11.3 StackPanel** (page 814), **12.11.4 WrapPanel** (page 815), and **12.11.7 Nested Layout Containers** (page 818).

Recreate two windows. The sketches are just guidelines: What matters is how the windows behave when their size is changed, not the exact pixel dimensions.

**Sketch 1: Login**

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

- Label text and input fields form a `Grid` with two columns (`Auto` and `*`). The input fields resize along with the window.
- The buttons are located in a `StackPanel` (horizontal) at the bottom right.

**Sketch 2: Email Window**

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

- The window is a `DockPanel`: the menu bar is at the top, the status bar is at the bottom, and the rest fills the center.
- The quick filters are contained in a `WrapPanel`: If the window becomes narrower, the buttons shift to a second row.
- The three areas are a `Grid` with three columns. The reading area (`*`) takes up the remaining space.

> **Deep Dive (optional):** `GridSplitter` is not in the book. A `GridSplitter` in its own narrow column between two areas lets the user drag the column widths with the mouse. Put two of them between the three areas; the exercise is also solved without them.

Also, answer the following: Why is `Canvas` unsuitable for both windows?
