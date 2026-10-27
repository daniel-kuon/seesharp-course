# Rubrik — Verständnisfragen Level 16 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0) geprüft. Eine
Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen; Wortlaut
und Fachbegriffe müssen nicht exakt stimmen.

## attribut-grundlagen

Kernpunkte:
- Ein Attribut ist ein **Vermerk (Metadatum)** an einem Programmelement (Typ, Methode, Eigenschaft, Parameter …) in eckigen Klammern; ausgewertet wird er vom **Compiler** (z. B. `Obsolete`, `Conditional`), von der **Laufzeit/Werkzeugen** oder vom eigenen Programm per **Reflexion**.
- Ein Attribut **allein ändert den Code nicht**: Es tut nur etwas, wenn jemand es auswertet.
- Positional = Argumente des Konstruktors (`[Autor("Ada")]`); benannt = `Name = wert` für eine öffentliche schreibbare Eigenschaft (`Version = 2`), steht nach den positionalen.
- Der Klassenname endet auf `Attribute`; beim Anwenden darf das Suffix entfallen.

Typische Irrtümer: Attribute führten selbst Code aus oder änderten Methoden; benannte Parameter seien Konstruktorargumente; das Suffix dürfe man in der Klassendeklaration weglassen.

## eigenes-attribut

Kernpunkte:
- Eine Attributklasse **erbt von `Attribute`** (Name endet auf `Attribute`, empfohlen `sealed`); Konstruktorparameter für Pflichtwerte, öffentliche Eigenschaften für benannte Werte.
- `[AttributeUsage]` legt die **erlaubten Ziele** (`AttributeTargets`: Klasse, Methode, Eigenschaft …) fest und ob es **mehrfach** vorkommen darf (`AllowMultiple`).
- Als Parameter nur **Konstanten** (Zahlen, Text), `typeof`-Ausdrücke, Aufzählungswerte und Arrays davon, weil das Attribut zur Übersetzungszeit in die Metadaten geschrieben wird; `DateTime.Now` entsteht erst zur Laufzeit.

Typische Irrtümer: Beliebige Objekte oder Ausdrücke seien als Parameter möglich; `AttributeUsage` sei nur Dokumentation; Attributklassen brauchten keine Basisklasse.

## reflexion-wann

Kernpunkte:
- Reflexion = Ein Programm **ermittelt zur Laufzeit Informationen über Typen, Methoden usw.** und ihre Attribute (Seite 921, 14.2).
- Zusammenspiel: Ein Attribut allein bewirkt nichts; Frameworks fragen per Reflexion ab, ob ein Attribut vorhanden ist (`IsDefined`) und welche Werte es trägt (`GetCustomAttribute`), und richten ihr Verhalten danach.
- Einsatzgebiete (zwei genügen): Frameworks wie Entity Framework Core, Persistenz- oder Serialisierungshelfer, Plugin-Lader, Prüfung auf veraltete Mitglieder (`Obsolete`), Validierung per Attribut.
- `Activator.CreateInstance(typ)` erzeugt ein Objekt eines Typs, der erst zur Laufzeit feststeht (14.7.1, Seite 943). Vorher prüft `typeof(ISchnittstelle).IsAssignableFrom(typ)`, ob der Typ die erwartete Schnittstelle erfüllt; sonst scheitert der spätere Cast oder Aufruf.

Typische Irrtümer: Ein Attribut ändere ohne Auswertung schon das Verhalten; `Activator` brauche den Typ zur Übersetzungszeit.

Bonus (Deep Dive, nicht im Buch): Nachteile der Reflexion (langsamer als direkter Zugriff, umgeht die Typprüfung des Compilers, Fehler erst zur Laufzeit).

## conditional-caller

Kernpunkte:
- `[Conditional("DEBUG")]`: Ist das Symbol beim Übersetzen **nicht** definiert, entfernt der Compiler die **Aufrufe** der Methode (nur `void`-Methoden); die Methode selbst bleibt in der Assembly. **Argumente** der entfernten Aufrufe werden **nicht ausgewertet** (keine Nebenwirkungen).
- `[CallerMemberName]` (an einem optionalen Parameter mit Standardwert): Der **Compiler** setzt zur **Übersetzungszeit** den Namen des aufrufenden Mitglieds als Argument ein, wenn der Aufrufer nichts übergibt; kein Reflexionsaufwand zur Laufzeit.

Typische Irrtümer: Die Methode werde zur Laufzeit übersprungen oder aus der Assembly entfernt; Argumente würden trotzdem berechnet; der Name werde zur Laufzeit per Reflexion ermittelt.

## code-nameof


Ausgabe, zwei Zeilen: `Einzahlen: Saldo` und `Einzahlen: -`.
Kernpunkte:
- `[CallerMemberName]` an einem optionalen Parameter: Der **Compiler** setzt beim Aufruf den Namen des aufrufenden Mitglieds ein, hier `Einzahlen` (14.5.1, Seite 934).
- `nameof(Saldo)` liefert zur Übersetzungszeit den Bezeichner als Text, `"Saldo"`, nicht den Wert 50 (14.4, Seite 933).
- Beim zweiten Aufruf fehlt `was`; der Standardwert `null` führt über `??` zu `-`.

Typische Irrtümer: `Melde: …` (Name der aufgerufenen statt der aufrufenden Methode); `Einzahlen: 50` (`nameof` liefere den Wert).

## code-autor

Ausgabe, drei Zeilen: `2`, `Addiere: Bob`, `Minus: -`.
Kernpunkte:
- `Attribute.GetCustomAttribute(t, typeof(AutorAttribute))` an der Klasse liefert das Attributobjekt mit `Version = 2` (benannter Parameter überschreibt den Standardwert 1; 14.2, Seite 927 f.). Der Cast macht aus `Attribute` den eigenen Typ.
- `FindMembers` mit `Type.FilterName` und dem Namen liefert genau die passende Methode als `MemberInfo` (Seite 925 f.).
- `Addiere` trägt `[Autor("Bob")]` → "Bob"; `Minus` hat kein Attribut, `GetCustomAttribute` liefert `null`, `?.Name` bleibt `null`, `?? "-"` ergibt "-".

Typische Irrtümer: `Minus` werfe eine Ausnahme (nein, `null`); Version sei 1; das Klassenattribut gelte automatisch für die Methoden.

## code-flags

Ausgabe, vier Zeilen: `Lesen, Loeschen`, `5`, `False`, `Loeschen`.
Kernpunkte:
- Mit `[Flags]` formatiert `ToString` Kombinationen als Liste der gesetzten Namen; ohne `[Flags]` stünde in der ersten Zeile `5`.
- Die Werte sind Zweierpotenzen (Bitfeld): `1 | 4` = 5.
- `HasFlag(Schreiben)`: Bit 2 ist nicht gesetzt → `False`.
- `r & ~Lesen` löscht das Bit für Lesen → nur `Loeschen`.

Typische Irrtümer: `Lesen, Loeschen` auch ohne `[Flags]`; `6` oder `3` als Summe; `HasFlag` liefere `True`.

## code-activator


Ausgabe, zwei Zeilen: `Hund: Wuff` und `Stein: kein Tier`.
Kernpunkte:
- `typeof(ITier).IsAssignableFrom(typ)` fragt, ob ein Objekt von `typ` einer `ITier`-Variablen zugewiesen werden kann: für `Hund` ja, für `Stein` nein (14.7.1, Seite 943).
- Nur für `Hund` erzeugt `Activator.CreateInstance(typ)` zur Laufzeit ein Objekt; der Cast auf `ITier` gelingt, `Laut()` liefert "Wuff".
- `Stein` wird gar nicht erst erzeugt; ohne die Prüfung würde der Cast `(ITier)` mit einer `InvalidCastException` scheitern.

Typische Irrtümer: `IsAssignableFrom` in falscher Richtung gelesen (`typ.IsAssignableFrom(typeof(ITier))`); `Activator` erzeuge Objekte nur für Typen, die zur Übersetzungszeit bekannt sind.

