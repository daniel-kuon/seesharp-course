# Indexer: eine Personenliste wie ein Array ansprechen

Lies im Buch Abschnitt **5.12 Indexer** (Seite 393) mit den Unterabschnitten
5.12.1 (verkettete Liste als Beispiel) und 5.12.2 (Indexer überladen, Seite 397).

`PersList` ist eine einfach verkettete Liste: jedes `Element` kennt seine
Person (`VP`) und seinen Nachfolger (`Next`); die Liste merkt sich `first`,
`last` und `Count`. Die geschachtelte Klasse `Element` ist fertig, du kümmerst
dich um die Liste selbst. Öffne `PersList.cs` und vervollständige:

1. `Add(Person neu)`: ein neues Element anhängen. Bei der ersten Person sind
   `first` und `last` dasselbe Element; sonst wird `last.Next` gesetzt und
   `last` weitergerückt. `Count` erhöhen.
2. `FindElement(int i)`: bei `first` starten und `i`-mal zu `Next` gehen.
3. Der Indexer `this[int i]`: der Getter liefert die Person an Position `i`
   oder wirft `ArgumentOutOfRangeException`; der Setter ersetzt bei gültigem
   Index die Person im Element und tut sonst nichts.
4. Der überladene Indexer `this[string vn]` liefert die **erste** Person mit
   diesem Vornamen; gibt es keine, wirft er `ArgumentException`. Tipp: Du
   kannst dafür den `int`-Indexer wiederverwenden.

`PersListDemo.cs` zeigt die Verwendung: `pl[1]`, `pl[1] = …`, `pl["Ilse"]`.

`first`, `last` und `Next` sind als `Element?` deklariert: Das Fragezeichen
sagt dem Compiler, dass dort `null` stehen darf (Buch Seite 338, Fußnote;
ausführlich kommt das in Kapitel 15.1.1). Das Buchbeispiel auf Seite 394
schreibt nur `Element`. Meldet der Compiler deswegen in deinem Code eine
Warnung (kein Fehler), darfst du sie hier stehen lassen.
