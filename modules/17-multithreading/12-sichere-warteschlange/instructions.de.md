# Zusatz: Eine sichere Warteschlange

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**17.2.1.1 Produzent-Konsument-Beispiel** (Seite 1065), **17.2.4.1
Zugriffsexklusivität** und **17.2.4.1.1 Die lock-Anweisung** (Seite 1073).

Die Sammlungen der Klassenbibliothek (`List<T>`, `Queue<T>`,
`Dictionary<K,V>`) sind **nicht** für gleichzeitigen Zugriff gebaut. Zwei
Threads, die gleichzeitig `Enqueue` aufrufen, können Elemente verlieren,
die Datenstruktur beschädigen oder eine Ausnahme auslösen. Die Lösung ist ein
`lock` um jeden Zugriff auf die gemeinsame Sammlung.

`SichereWarteschlange<T>` kapselt eine `Queue<T>`:

- `Einreihen(element)` hängt hinten an,
- `TryNaechster(out element)` entnimmt das vorderste Element oder liefert
  `false` (mit `default` als Wert), wenn nichts da ist,
- `Anzahl` liefert die Zahl der wartenden Elemente.

Alle drei Mitglieder benutzen dasselbe private Sperrobjekt. Bei
`TryNaechster` gehören die Prüfung `Count > 0` und das `Dequeue`
**zusammen** unter ein einziges `lock`: Sonst kann ein anderer Thread
zwischen beiden Schritten das letzte Element entnehmen.

Der große Test startet vier Erzeuger (je 2500 Elemente) und vier Verbraucher
gleichzeitig. Er wartet mit `Join()` und prüft, dass jedes Element
**genau einmal** verbraucht wurde. Er schläft nie und misst keine Zeit; die
Verbraucher hören auf, sobald alle Erzeuger fertig sind und die Warteschlange
leer ist.

Diese Tests müssen bestehen:

- `SichereWarteschlangeTests.Elemente_kommen_in_der_Reihenfolge_des_Einreihens_heraus`
- `SichereWarteschlangeTests.Eine_leere_Warteschlange_liefert_false_und_den_Standardwert`
- `SichereWarteschlangeTests.Vier_Erzeuger_und_vier_Verbraucher_jedes_Element_genau_einmal`
