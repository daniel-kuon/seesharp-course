# Attribute und Reflexion

Attribute hängen Metadaten an Programmelemente, ohne deren Code zu ändern:
Ein Vermerk, den der Compiler, die Laufzeit oder ein Werkzeug auswertet
(Kapitel 14, Seite 921). Reflexion ist die Gegenseite: Ein Programm
untersucht zur Laufzeit seine eigenen Typen und Metadaten. Beides zusammen
ist das Fundament von Serialisierern, Validierung, Datenbank-Mappern und
Plugin-Systemen. Dieses Level ist ein Wahlmodul.

## Attribute vergeben (14.1, Seite 922)

Ein Attribut steht in eckigen Klammern vor Typ, Methode, Eigenschaft,
Parameter oder Rückgabewert: `[Obsolete("Bitte Neu() verwenden")]`. Der
Klassenname endet auf `Attribute`, beim Anwenden lässt man das Suffix weg.
Parameter sind **positional** (Konstruktor) oder **benannt**
(`Name = wert`, öffentliche schreibbare Eigenschaft). Mehrere Attribute
dürfen untereinander oder durch Komma getrennt stehen, bei manchen sogar
dasselbe mehrfach.

## Auswerten per Reflexion (14.2, Seite 924)

Einstieg ist ein `Type`: `typeof(Klasse)` kennt der Compiler, `objekt.GetType()`
liefert den Laufzeittyp. `GetCustomAttribute<T>()` und `GetCustomAttributes<T>()`
holen die Attributobjekte (dabei läuft deren Konstruktor), `IsDefined`
fragt nur, ob eines vorhanden ist. `GetProperties()` und `GetMethods()`
zählen die Mitglieder eines Typs auf; mit `BindingFlags` grenzt man ein
(öffentlich, Instanz, statisch). Für Assemblies gilt dasselbe, die Attribute
stehen dort mit Ziel `assembly:` irgendwo auf oberster Ebene (14.3,
Seite 929).

## nameof (14.4, Seite 933)

`nameof(Person.Alter)` liefert den Bezeichner als Text, vom Compiler
geprüft und beim Umbenennen automatisch mitgeführt. Er ersetzt Literale in
Fehlermeldungen und bei Änderungsbenachrichtigungen.

## Wichtige Attribute der Klassenbibliothek (14.5, Seite 934 bis 940)

`[CallerMemberName]` und `[CallerLineNumber]` an optionalen Parametern
lassen den Compiler Name und Zeile der Aufrufstelle einsetzen (14.5.1).
`[Conditional("DEBUG")]` entfernt beim Übersetzen die **Aufrufe** einer
void-Methode, wenn das Symbol fehlt (14.5.2, Seite 935).
`[DebuggerStepThrough]` hält den Debugger im Einzelschritt heraus
(14.5.3). `[Flags]` macht aus einer Aufzählung ein Bitfeld, dessen
Kombinationen als `Lesen, Schreiben` erscheinen (14.5.4, Seite 937).
`[StructLayout(LayoutKind.Explicit)]` mit `[FieldOffset]` legt Felder
übereinander wie eine Union in C (14.5.5, Seite 940).

## Eigene Attribute (14.6 bis 14.8, Seite 940 bis 945)

Eine Attributklasse erbt von `Attribute`. `[AttributeUsage]` legt die
erlaubten Ziele (`AttributeTargets`) fest und ob sie mehrfach vorkommen
darf (`AllowMultiple`); Microsoft empfiehlt `sealed`. Erlaubt sind als
Parameter nur Konstanten, Text, `typeof`-Ausdrücke, Aufzählungswerte und
Arrays davon. Seit C# 11 dürfen Attribute generisch sein (14.7, Seite 942):
`[Implementierung<StandardRechnung>]` statt `typeof(...)`, samt
Typeinschränkung, die der Compiler prüft. Seit C# 10 dürfen Lambda-Ausdrücke
Attribute tragen (14.8, Seite 945).

## Reflexion in der Praxis

Das Buch zeigt, wie ein Objekt zu einem Typ erst zur Laufzeit entsteht:
`Activator.CreateInstance(typ)` (14.7.1, Seite 943). Die Zusammenfassung
ergänzt zwei Werkzeuge: `PropertyInfo.GetValue` und `SetValue` lesen und
schreiben Eigenschaften nach Namen, `MethodInfo.Invoke` ruft Methoden nach
Namen auf. Ausnahmen aus dem aufgerufenen Code kommen als
`TargetInvocationException` zurück. Reflexion ist langsamer als direkter
Zugriff und umgeht die Typprüfung des Compilers; setze sie dort ein, wo
Typen wirklich erst zur Laufzeit feststehen.

## Übungen

Die Aufgaben gehen von den Bibliotheksattributen über eigene Attribute und
das Auslesen bis zu einem kleinen Mapper und Plugin-Lader. Ein Quiz
behandelt `Conditional`, `[assembly: ...]` und Attributziele, weil das vom
Build abhängt und nicht automatisch geprüft werden kann. Die optionalen
Aufgaben: Validierung per Attribut, Berechtigungen mit `[Flags]` und ein
Mini-Testläufer.
