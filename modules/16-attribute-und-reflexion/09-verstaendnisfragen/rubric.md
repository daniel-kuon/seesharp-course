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
- Reflexion = Ein Programm **untersucht zur Laufzeit seine eigenen Typen und Metadaten** (Eigenschaften, Methoden, Attribute auflisten, Werte lesen/setzen, Methoden aufrufen, Objekte per `Activator.CreateInstance` erzeugen).
- Einsatzgebiete (zwei genügen): Serialisierer (JSON), Validierung per Attribut, Datenbank-Mapper, Plugin-Lader, Testläufer, Mapper zwischen Objekten.
- Nachteile (zwei genügen): **langsamer** als direkter Zugriff; **umgeht die Typprüfung** des Compilers (Namen als Text, Fehler erst zur Laufzeit; Umbenennen bricht den Code); `TargetInvocationException` verpackt Ausnahmen.
- Verzichten: wenn die Typen schon beim Schreiben feststehen (dann direkter Zugriff, ggf. generisch).

Typische Irrtümer: Reflexion sei genauso schnell oder sicher; sie sei nur für Debugging.

## conditional-caller

Kernpunkte:
- `[Conditional("DEBUG")]`: Ist das Symbol beim Übersetzen **nicht** definiert, entfernt der Compiler die **Aufrufe** der Methode (nur `void`-Methoden); die Methode selbst bleibt in der Assembly. **Argumente** der entfernten Aufrufe werden **nicht ausgewertet** (keine Nebenwirkungen).
- `[CallerMemberName]` (an einem optionalen Parameter mit Standardwert): Der **Compiler** setzt zur **Übersetzungszeit** den Namen des aufrufenden Mitglieds als Argument ein, wenn der Aufrufer nichts übergibt; kein Reflexionsaufwand zur Laufzeit.

Typische Irrtümer: Die Methode werde zur Laufzeit übersprungen oder aus der Assembly entfernt; Argumente würden trotzdem berechnet; der Name werde zur Laufzeit per Reflexion ermittelt.

## code-eigenschaften

Ausgabe, drei Zeilen: `Alter = 36`, `Name = Ada`, `37`.
Kernpunkte:
- `GetProperties()` liefert die öffentlichen Eigenschaften `Name` und `Alter` (hier alphabetisch sortiert: Alter, Name); `GetValue(p)` liest den aktuellen Wert des Objekts `p`.
- `GetProperty("Alter")!.SetValue(p, 37)` schreibt per Reflexion in das Objekt; `p.Alter` ist danach 37.

Typische Irrtümer: Reihenfolge Name, Alter (ohne `OrderBy` ist die Reihenfolge nicht garantiert, hier aber sortiert); `SetValue` ändere nur eine Kopie; Ausgabe `36` in der dritten Zeile.

## code-autor

Ausgabe, drei Zeilen: `2`, `Addiere: Bob`, `Minus: -`.
Kernpunkte:
- `GetCustomAttribute<AutorAttribute>()` an der Klasse liefert das Attributobjekt mit `Version = 2` (benannter Parameter überschreibt den Standardwert 1).
- `Addiere` trägt `[Autor("Bob")]` → "Bob"; `Minus` hat kein Attribut, `GetCustomAttribute` liefert `null`, `?.Name` bleibt `null`, `?? "-"` ergibt "-".
- `DeclaredOnly` begrenzt auf die in `Rechner` deklarierten Methoden (ohne `ToString` usw.), `OrderBy` sortiert: Addiere vor Minus.

Typische Irrtümer: `Minus` werfe eine Ausnahme (nein, `null`); Version sei 1; das Klassenattribut gelte automatisch für die Methoden.

## code-flags

Ausgabe, vier Zeilen: `Lesen, Loeschen`, `5`, `False`, `Loeschen`.
Kernpunkte:
- Mit `[Flags]` formatiert `ToString` Kombinationen als Liste der gesetzten Namen; ohne `[Flags]` stünde in der ersten Zeile `5`.
- Die Werte sind Zweierpotenzen (Bitfeld): `1 | 4` = 5.
- `HasFlag(Schreiben)`: Bit 2 ist nicht gesetzt → `False`.
- `r & ~Lesen` löscht das Bit für Lesen → nur `Loeschen`.

Typische Irrtümer: `Lesen, Loeschen` auch ohne `[Flags]`; `6` oder `3` als Summe; `HasFlag` liefere `True`.

## code-invoke

Ausgabe, zwei Zeilen: `5`, `DivideByZeroException`.
Kernpunkte:
- `Invoke` ruft die Methode per Namen auf: `10 / 2` = 5 (Rückgabe als `object`).
- Eine Ausnahme aus der **aufgerufenen** Methode kommt bei `Invoke` **eingepackt** in einer `TargetInvocationException` an; die ursprüngliche steht in `InnerException`. Deshalb greift der erste `catch`, und der Name der inneren Ausnahme ist `DivideByZeroException`; der zweite `catch` (`direkt`) wird nie erreicht.

Typische Irrtümer: Es erscheine `direkt` (die Ausnahme komme unverpackt an); die Ausgabe sei `TargetInvocationException` (das ist der äußere Typ, ausgegeben wird der innere).
