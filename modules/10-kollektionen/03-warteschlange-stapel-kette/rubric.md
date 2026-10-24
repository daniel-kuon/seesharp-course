# Rubrik: Warteschlange, Stapel und verkettete Liste (nur für die Betreuung)

- **Kernidee:** Die Wahl der Kollektion drückt die Reihenfolge aus: `Queue<T>`
  ist FIFO (Drucker), `Stack<T>` ist LIFO (Klammern, Zurück-Taste),
  `LinkedList<T>` erlaubt Einfügen und Entfernen an bekannten Knoten ohne
  Umkopieren und in beide Richtungen zu laufen.
- `KlammernPruefer`: Typische Fehler sind `Pop()` auf leerem Stapel (bei `"}"`
  oder `")("`) und das Vergessen, am Ende auf `Count == 0` zu prüfen (bei
  `"(("`). Nur eine Zählvariable reicht für gemischte Klammern nicht
  (`"([)]"`): Warum? Das ist die Begründung für den Stapel.
- `Verlauf`: Warum muss `Besuche()` den Vor-Stapel leeren? (Wie im Browser:
  Nach einem neuen Link gibt es kein "Vor" mehr.) Wer nur eine Liste und einen
  Index nimmt, besteht die Tests ebenfalls; die Aufgabe will aber zwei Stapel
  sehen.
- `ZuletztGeoeffnet`: `Remove(name)` liefert `bool`, ein Fehlschlag ist
  harmlos. Beim erneuten Öffnen eines vorhandenen Namens darf bei voller Liste
  nichts herausfallen (eigener Test). Die Rückwärtsliste soll mit `Last` und
  `Previous` gebaut werden, nicht mit `Reverse()`; bitte kurz ansehen.
- Nachfragen: Wann ist `LinkedList<T>` besser als `List<T>`? (Viele Einfügungen
  und Löschungen mitten in der Folge, wenn der Knoten schon bekannt ist; sonst
  gewinnt `List<T>` durch Indexzugriff und Speicherlokalität.)
- Modellantwort: `solution/`. Kein Beispielprojekt aus `samples/`.
