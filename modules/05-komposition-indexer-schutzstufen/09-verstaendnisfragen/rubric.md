# Rubrik: Verständnisfragen Level 5 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, die Fachbegriffe müssen aber stimmen. Bei den Programmfragen zählt neben der Ausgabe die Begründung. Die Auswahlfragen (`tostring-override`, `readonly-feld`, `indexer-deklaration`, `ggt-schutzstufe`) sind automatisch bewertet und haben hier keinen Eintrag.

## aggregation-komposition

Kernpunkte:
- Ein Objekt kann **andere Objekte als Felder** halten: `Aufgabe` besitzt `b1`, `b2` und `lsg` vom Typ `Bruch`. Das Ganze ist aus Teilen zusammengesetzt.
- **Aggregation** ist die lose Form (das Teil könnte auch ohne das Ganze leben), **Komposition** die enge (das Teil entsteht und vergeht mit dem Ganzen). In C# sieht beides gleich aus: ein **Feld mit Klassentyp**.
- **Delegieren:** `Aufgabe` rechnet nicht selbst, sondern **bittet ihre Brüche** darum (`lsg.Addiere(b2)`); sie schickt eine Nachricht an das Teilobjekt.
- **`readonly`** fixiert nur die **Referenz**, nicht das Objekt dahinter: `NeueWerte()` darf die vorhandenen Brüche verändern, aber keine neuen anlegen.

Typische Irrtümer: Aggregation sei Vererbung; `readonly` mache auch den Inhalt des Objekts unveränderlich; die Klasse müsse die Rechnung selbst durchführen.

## tostring-ausgabe

Exakte Ausgabe (drei Zeilen):

```
3/4
Bruch: 3/4
3/4!
```

Kernpunkte:
- In allen drei Zeilen wird **`ToString()`** aufgerufen, ohne dass es dasteht: `Console.WriteLine(b)`, die Interpolation `$"{b}"` und die Verkettung `b + "!"` wandeln das Objekt automatisch in Text um.
- Ohne Überschreiben liefert die von `Object` **geerbte Fassung nur den Typnamen**: `Bruch`, `Bruch: Bruch` und `Bruch!`.
- `public override string ToString()` ersetzt die geerbte Fassung (Name und Rückgabetyp müssen passen).

Typische Irrtümer: Es müsse `b.ToString()` ausdrücklich dastehen; ohne Überschreiben werde `3/4` oder die Speicheradresse ausgegeben; die Ausgabe sei leer.

## vektor-plus-addiere

Exakte Ausgabe (drei Zeilen):

```
5
10
10
```

Kernpunkte:
- **`Plus`** lässt beide Operanden **unverändert** und liefert ein **neues Objekt** (`c` = (6, 8)); **`Addiere`** **verändert das Objekt, auf dem es aufgerufen wird** (`a` wird (6, 8)), und liefert nichts. Daher: `a.Laenge` ist zuerst 5, nach `Addiere` 10; `c.Laenge` bleibt 10.
- **`Laenge`** ist eine **berechnete Eigenschaft**: Sie hat **kein Feld**, sondern rechnet bei jedem Lesen neu, kann deshalb nie veralten (nach `Addiere` stimmt sie sofort).

Typische Irrtümer: `Plus` verändere `a`, dann wäre die erste Zeile schon falsch oder `a.Laenge` bliebe 5; `Laenge` müsse nach `Addiere` neu gesetzt werden; `c` zeige auf dasselbe Objekt wie `a`.

## geschachtelte-klassen

Kernpunkte:
- Man schachtelt eine Klasse, wenn sie **nur zu der äußeren gehört** (Hilfsklasse, Implementierungsdetail, zum Beispiel die `Element`-Klasse einer verketteten Liste).
- Die **innere Klasse sieht alle Mitglieder der äußeren, auch private**. Für Instanzmitglieder braucht sie dafür eine **Referenz auf ein Objekt der äußeren Klasse** (`f.name`).
- **Ohne Modifizierer ist eine geschachtelte Klasse `private`** und von außen unsichtbar; mit `public` spricht man sie als `Familie.Sohn` an.
- Gut, aber nicht verlangt: Primärkonstruktoren `class Sohn(Familie f, …)`.

Typische Irrtümer: Eine geschachtelte Klasse sei automatisch öffentlich; die innere Klasse brauche keine Referenz auf ein äußeres Objekt; die äußere Klasse sehe die privaten Mitglieder der inneren (umgekehrt gilt das nicht).

## familie-privat

Exakte Ausgabe: `Ich bin von Familie Meier`

Kernpunkte:
- `Kind` ist **in** `Familie` geschachtelt und darf deshalb auf deren **private** Mitglieder zugreifen, auch auf `f.name`, vorausgesetzt, sie hat eine Referenz `f` auf ein `Familie`-Objekt (hier per Parameter).
- `Familie.Kind k = new Familie.Kind();` in `Main` kompiliert **nicht**: `Kind` hat keinen Modifizierer und ist deshalb **`private`**, von außerhalb der Klasse `Familie` unzugänglich (CS0122). Mit `public class Kind` ginge es.

Typische Irrtümer: Der Zugriff auf `f.name` sei ein Fehler, weil das Feld privat ist; `Kind` sei von außen sichtbar.

## indexer-konzept

Kernpunkte:
- Ein **Indexer** ist eine **Eigenschaft mit Parametern**: `public Person this[int i] { get … set … }`. Damit lässt sich ein Objekt, meist eine eigene Kollektion, **wie ein Array ansprechen** (`liste[1]`, `liste[1] = p`).
- Eine gewöhnliche Eigenschaft hat einen Namen und keinen Parameter; der Indexer heißt `this` und hat **mindestens einen Parameter** in eckigen Klammern.
- **Überladen** geht über **verschiedene Parameterlisten**: anderer Typ (`this[string vorname]` sucht nach dem Vornamen) oder **mehrere Parameter** (`this[int zeile, int spalte]`, zum Beispiel für eine Matrix).

Typische Irrtümer: Ein Indexer sei dasselbe wie ein Array-Feld; er habe einen frei wählbaren Namen; er könne nur `int` als Index haben; Indexer dürften nicht überladen werden.

## tabelle-indexer

Exakte Ausgabe (zwei Zeilen):

```
30
34
```

Kernpunkte:
- `t[3]` ruft den Indexer mit einem Parameter auf: `10 * 3 = 30`. `t[3, 4]` ruft den **überladenen** Indexer mit zwei Parametern auf: `10 * 3 + 4 = 34`. Der Compiler wählt die Überladung nach Anzahl und Typ der Argumente.
- `t[1] = 5;` kompiliert **nicht** (CS0200): Der Indexer hat **nur einen `get`-Accessor**, ist also **schreibgeschützt**; für Zuweisungen bräuchte er einen `set`. Es gibt auch kein Feld, in das man schreiben könnte, der Wert wird berechnet.

Typische Irrtümer: Ausgabe `30` und `3` oder `7`; `t[1] = 5` setze `Basis`; die Zeile kompiliere und tue nichts.

## schutzstufen

Kernpunkte:
- **`public`:** überall sichtbar, auch in anderen Projekten. **`internal`:** nur **innerhalb desselben Assemblys** (Projekts) sichtbar. **`private`:** nur innerhalb der eigenen Klasse.
- Standardwerte: eine **nicht geschachtelte Klasse** ist ohne Angabe **`internal`**; ein **Mitglied** (Feld, Methode, Eigenschaft) ist ohne Angabe **`private`**; (eine geschachtelte Klasse ist ebenfalls `private`).
- „Assembly-intern“ konkret: Ein **anderes Projekt**, das die Bibliothek per Projektverweis einbindet, **sieht das Mitglied nicht**, der Compiler dort meldet, es gebe keine Definition dafür. Innerhalb der Bibliothek ist es normal benutzbar. So hält man die **Schnittstelle der Bibliothek klein** (zum Beispiel eine Hilfsmethode `Ggt`).
- Gut, aber nicht verlangt: `protected` für abgeleitete Klassen (Level 7).

Typische Irrtümer: Klassen seien standardmäßig `public`; `internal` heiße „innerhalb der Klasse“ oder „innerhalb des Namensraums“; `private` sei die Standardstufe für Klassen.

## bibliothek-verweis

Kernpunkte:
- Eine **Klassenbibliothek** ist ein Projekt vom Typ Library **ohne `Main`-Methode**; sie liefert Typen, wird aber nicht gestartet.
- Das Konsolenprojekt braucht einen **Projektverweis** auf `FractionLib` (damit sein Assembly mitgebaut und eingebunden wird) **und** eine **`using`-Direktive** `using de.bebagoe.fraction;` oder den voll qualifizierten Namen, um `Bruch` kurz anzusprechen.
- Der Projektverweis reicht allein nicht, weil **Namensraum und Assembly zwei verschiedene Dinge** sind: Der Verweis macht das **Assembly** bekannt, `using` importiert den **Namensraum** (das logische Präfix der Typnamen). Ein Namensraum ist keine Datei; ein Assembly kann mehrere Namensräume enthalten.

Typische Irrtümer: `using` binde das Assembly ein (so entstünde kein Projektverweis); der Projektverweis importiere automatisch den Namensraum; die Bibliothek brauche eine `Main`-Methode; die Bibliothek müsse in dasselbe Projekt kopiert werden.
