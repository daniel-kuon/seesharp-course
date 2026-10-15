# Reparatur: Basiskonstruktor und private Erbstücke

Lies im Buch **7.16 Übungsaufgaben zum Kapitel 7**, Aufgaben 1 und 2 (Seite
586); zur Erklärung **7.4.1 base-Konstruktoren** (Seite 549) und **7.5
Zugriffsmodifikator protected** (Seite 554).

Der Starter **kompiliert nicht**. Baue das Projekt, lies die beiden
Fehlermeldungen und repariere:

1. `Basisklasse.cs`: `Abgeleitet` deklariert keinen Konstruktor, also
   erzeugt der Compiler einen parameterlosen, der `base()` aufruft. Den gibt
   es nicht, weil `Basisklasse` nur `Basisklasse(int)` hat. Ergänze in
   `Abgeleitet` einen Konstruktor `Abgeleitet(int i) : base(i)`. Die
   Basisklasse bleibt unverändert, der Test prüft das.
2. `Figur.cs`: `Kreis` greift im Konstruktor auf `xpos` und `ypos` zu. Die
   Felder werden zwar vererbt (jeder Kreis hat sie), sind aber `private`
   und damit in `Kreis` unsichtbar. Du könntest sie `protected` machen;
   schöner ist, die Positionsprüfung dem Basiskonstruktor zu überlassen:
   `: base(x, y)` und in `Kreis` nur noch den Radius prüfen. Bei ungültiger
   Position bleibt dann wie in `Figur` die Vorgabe 100/100 stehen.

Beantworte zum Schluss die offene Frage in eigenen Worten; sie wird im
Review besprochen.
