# ToString überschreiben

Lies im Buch Abschnitt **7.16 Übungsaufgaben zum Kapitel 7**, Aufgabe 5
(Seite 588), und zur Einordnung den Anfang von **7.9 Polymorphie** (Seite 566):
`ToString()` ist in `Object` als `virtual` deklariert und darf in jeder Klasse
mit `override` ersetzt werden. Mehr Vererbung brauchst du hier noch nicht.

Öffne `Bruch.cs`. Die Methode `ToString()` ist bereits mit `override`
vorbereitet, aber leer. Sie soll `"Zaehler/Nenner"` liefern, also `"7/8"` für
`new Bruch(7, 8, "")`. Das Etikett gehört nicht dazu, und gekürzt wird nicht.

Probiere danach in `Bruchrechnung.cs`, was `Console.WriteLine(b)`,
`$"Bruch: {b}"` und `b + "!"` ausgeben: alle drei rufen `ToString()` auf, ohne
dass du es hinschreibst.
