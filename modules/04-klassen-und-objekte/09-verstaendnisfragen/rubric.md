# Rubrik: Verständnisfragen Level 4 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, die Fachbegriffe müssen aber stimmen. Bei den Programmfragen zählt neben der Ausgabe die Begründung. Die Auswahlfragen (`konstruktor-deklaration`, `ueberladung`, `operator-plus`, `nenner-field`) sind automatisch bewertet und haben hier keinen Eintrag.

## eigenschaft-feld

Kernpunkte:
- Die Felder sind **privat** (Kapselung); von außen kommt man nur über Eigenschaften oder Methoden an den Zustand. So kann die Klasse **Regeln durchsetzen**, ein Nenner darf zum Beispiel nie 0 werden.
- Setter für `Nenner`: `set { if (value != 0) nenner = value; }`, der Wert 0 wird ignoriert, der Nenner bleibt unverändert. `value` ist der zugewiesene Wert.
- Der **Konstruktor weist über die Eigenschaften zu**, damit die **Validierung im Setter auch beim Erzeugen greift**; ein direkter Zugriff auf das Feld würde sie umgehen (und etwa einen Nenner 0 zulassen).

Typische Irrtümer: Eigenschaften seien nur Schreibarbeit ohne Nutzen; der Konstruktor dürfe nicht auf Eigenschaften zugreifen; die Validierung gehöre in den Aufrufer.

## referenz-kopie

Exakte Ausgabe (zwei Zeilen):

```
5
5
```

Kernpunkte:
- Eine Variable vom Klassentyp enthält eine **Referenz** auf ein Objekt. `Punkt b = a;` kopiert nur die **Referenz**; `a` und `b` zeigen auf **dasselbe Objekt**. `b.X = 5` ändert deshalb auch `a.X`.
- `a.Klone()` legt mit `new` ein **neues, unabhängiges Objekt** mit denselben Werten an. Die Änderung `c.X = 9` betrifft `a` nicht, `a.X` bleibt `5`.
- Eine echte Kopie braucht also eine Methode wie `Klone()`; die Zuweisung allein kopiert nicht.

Typische Irrtümer: Ausgabe `1`/`1` (Zuweisung kopiere das Objekt); zweite Ausgabe `9` (der Klon teile sich das Objekt mit `a`).

## konstruktor-regeln

Kernpunkte:
- Sobald man einen **expliziten Konstruktor** schreibt, **entfällt der automatische Standardkonstruktor**; `new Bruch()` kompiliert dann nicht mehr.
- Soll `new Bruch()` weiter möglich sein, **deklariert man den parameterlosen Konstruktor selbst** (zusätzlich, Konstruktoren dürfen überladen werden).
- Ein **Objektinitialisierer** setzt direkt nach dem Konstruktoraufruf **Eigenschaften** (`new Bruch { Zaehler = 3, Nenner = 7 }`); man braucht dafür keinen passenden Konstruktor mit Parametern, nur einen zugänglichen Konstruktor und Eigenschaften mit Setter.

Typische Irrtümer: Der Standardkonstruktor bleibe immer erhalten; der Objektinitialisierer ersetze den Konstruktor; man müsse die Felder direkt setzen.

## statischer-konstruktor

Exakte Ausgabe (vier Zeilen):

```
statisch
Objekt 1
Objekt 2
2
```

Kernpunkte:
- Der **statische Konstruktor läuft genau einmal**, automatisch, **bevor** die Klasse zum ersten Mal benutzt wird (hier beim ersten `new Zaehler()`), also vor `Objekt 1`.
- Der Instanzkonstruktor läuft bei **jedem `new`**; er erhöht die **statische** Eigenschaft `Anzahl` (die der Klasse gehört, nicht einem Objekt).
- `Zaehler c = a;` erzeugt **kein neues Objekt**, es kopiert nur die Referenz. Deshalb ist `Anzahl` am Ende 2, nicht 3.

Typische Irrtümer: Der statische Konstruktor laufe bei jedem Objekt; er laufe erst am Programmende; `c = a` zähle als drittes Objekt (`3`); `Anzahl` gehöre zu jedem Objekt einzeln.

## quersumme

Exakte Ausgabe: `10`

Kernpunkte:
- `Rueck` berechnet die **Quersumme**: `4 + Rueck(123)`, `3 + Rueck(12)`, `2 + Rueck(1)`, `1 + Rueck(0)`, `Rueck(0)` liefert 0; also `4 + 3 + 2 + 1 = 10`. Jeder Aufruf verkleinert das Problem (`n / 10`).
- **Fünf** Aufrufe insgesamt (`1234`, `123`, `12`, `1`, `0`).
- Ohne die Zeile `if (n == 0) return 0;` fehlt die **Abbruchbedingung**: Die Kette endet nie (`Rueck(0)` ruft `Rueck(0)` auf), der Stapel läuft über, das Programm bricht mit einer **Stapelüberlauf-Ausnahme** (`StackOverflowException`) ab.

Typische Irrtümer: Ausgabe `1234` oder `4`; vier statt fünf Aufrufe; ohne die Zeile liefere die Methode 0 oder laufe „einfach endlos“ ohne Absturz.

## statisch-vs-instanz

Kernpunkte:
- **Instanzmitglieder** gehören einem **Objekt**: jedes `Bruch`-Objekt hat eigene Werte; man braucht ein Objekt, um sie zu benutzen (`b.Kuerze()`).
- **Statische Mitglieder** gehören der **Klasse**, es gibt sie einmal, unabhängig von der Zahl der Objekte; aufgerufen über den Klassennamen. Beispiel: `Anzahl` wird in jedem Konstruktor erhöht und zählt die erzeugten Objekte; eine Fabrikmethode wie `BenDef()` ist statisch, weil sie ein Objekt **erst erzeugt** (es gibt noch keines, auf dem man sie aufrufen könnte).
- Der **statische Konstruktor** läuft einmalig vor dem ersten Zugriff auf die Klasse und setzt Voreinstellungen (zum Beispiel Zufallswerte für `ZaehlerVoreinst`).

Typische Irrtümer: `static` heiße „unveränderlich“ oder „öffentlich“; ein statisches Mitglied gebe es pro Objekt; Instanzmethoden kann man ohne Objekt aufrufen.

## nenner-setter

Exakte Ausgabe (zwei Zeilen):

```
1
4
```

Kernpunkte:
- Beim ersten Setzen ist `value` 0; die Bedingung `value != 0` ist falsch, `nenner` bleibt beim Startwert `1`. Beim zweiten Setzen wird `4` übernommen.
- Mit `return Nenner;` im Getter **ruft der Getter sich selbst auf**: endlose Rekursion, Programmabbruch durch **Stapelüberlauf** (`StackOverflowException`). Der Getter muss das **Feld** `nenner` lesen, nicht die Eigenschaft.

Typische Irrtümer: Ausgabe `0` und `4`; der Compiler melde bei `return Nenner;` einen Fehler (es kompiliert; der Fehler tritt erst zur Laufzeit auf); es werde einfach der Wert zurückgegeben.

## rekursion-regeln

Kernpunkte:
- Jeder Aufruf muss das **Problem verkleinern** und ein **direkt lösbarer Fall (Abbruchbedingung)** muss die Kette beenden; die Abbruchbedingung prüft man zuerst.
- Fehlt sie, läuft die Kette endlos, der **Stapel läuft über** (Stapelüberlauf-Ausnahme).
- Elegant: zum Beispiel **Fakultät** (`n! = n * (n-1)!`) oder der **ggT** (`ggT(a, b) = ggT(b, a % b)`). Teuer: **rekursive Fibonacci-Zahlen**, weil dieselben Teilprobleme immer wieder berechnet werden (Aufrufzahl wächst stark).

Typische Irrtümer: Rekursion brauche immer eine Schleife; jede Rekursion sei langsamer oder schneller als Iteration; Fibonacci sei „deshalb“ nicht rekursiv berechenbar.

## operator-vs-methode

Kernpunkte:
- `operator +` liefert ein **neues Objekt** und lässt die **Operanden unverändert**; `Addiere(Bruch b)` **verändert das vorhandene Objekt** (und liefert nichts Neues).
- Ein überladener Operator ist **`static`**, weil er **zur Klasse gehört** und seine Operanden als **Parameter** bekommt (`b1 + b2` gehört keinem der beiden Objekte allein).
- Seit C# 14 kann man **`+=` getrennt als Instanzoperator** überladen: Er **verändert das vorhandene Objekt** und legt **keine neue Instanz** an; ohne ihn wird `a += b` als `a = a + b` mit einem neuen Objekt ausgeführt.

Typische Irrtümer: `+` verändere den linken Operanden; ein Operator brauche kein `static`; `+=` und `+` seien identisch.
