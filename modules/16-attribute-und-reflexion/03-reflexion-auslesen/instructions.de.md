# Attribute per Reflexion auslesen

Lies im Buch **14.2 Attribute per Reflexion auswerten** (Seite 924) bis
einschließlich der Methoden `GetCustomAttributes` (Seite 929) und die
Übungsaufgabe **14.9 Aufgabe 1** (Seite 947). Reflexion heißt: Ein Programm
fragt zur Laufzeit die Metadaten seiner Typen ab. Einstieg ist immer ein
`Type`-Objekt, entweder zur Übersetzungszeit mit `typeof(T)` oder zur
Laufzeit mit `objekt.GetType()`.

Das Buch arbeitet mit `Attribute.IsDefined`, `Attribute.GetCustomAttribute(s)`
und `FindMembers`. Diese Aufgabe nutzt kürzere Schreibweisen derselben Ideen,
die nicht im Buch stehen und hier vorgegeben sind: die generischen Methoden
`GetCustomAttribute<T>()` und `GetCustomAttributes<T>()`, `IsDefined(typ)` am
`MemberInfo`, `GetMethods(BindingFlags)` statt `FindMembers` sowie
`GetProperties()` mit `PropertyInfo.Name` und `PropertyType`. Jede Teilaufgabe
nennt den genauen Aufruf.

Das Attribut `[Autor("Name")]` ist vorgegeben (Klassen und Methoden,
mehrfach erlaubt). In `Dokumentation.cs` fehlen die Auswertungen:

1. `AutorenVon(Type t)`: die Namen aller `[Autor]`-Attribute einer Klasse,
   sortiert. `t.GetCustomAttributes<AutorAttribute>()` liefert alle
   Attributobjekte (`using System.Reflection;`).
2. `MethodenMitAutor(Type t)`: die Namen der **öffentlichen Instanzmethoden**
   mit `[Autor]`, sortiert. `GetMethods(BindingFlags.Public |
   BindingFlags.Instance)` filtert statische und nicht öffentliche
   Methoden schon heraus, `IsDefined(typeof(AutorAttribute))` fragt nach
   dem Attribut, ohne es zu instanziieren.
3. `Eigenschaften(Type t)`: pro öffentlicher Eigenschaft ein Text
   `"Name:Typ"` (z. B. `"Alter:Int32"`), sortiert. `GetProperties()` liefert
   `PropertyInfo`-Objekte mit `Name` und `PropertyType`.
4. `TypName(object o)` benutzt `o.GetType().Name`, `TypNameStatisch<T>()`
   benutzt `typeof(T).Name`. Die Tests zeigen, wann beide verschiedene
   Ergebnisse liefern: bei einer Variablen, deren Laufzeittyp spezieller ist als
   ihr deklarierter Typ.
5. `Veraltet(Type t)`: die Meldung des `[Obsolete]`-Attributs oder `null`.
   `GetCustomAttribute<ObsoleteAttribute>()` liefert `null`, wenn das
   Attribut fehlt.

Sortiere mit `List<string>.Sort(StringComparer.Ordinal)`, dann stimmt die
Reihenfolge unabhängig von der Spracheinstellung des Rechners.

Diese Tests müssen bestehen:

- `DokumentationTests.AutorenVon_liefert_alle_Autoren_sortiert`
- `DokumentationTests.AutorenVon_ohne_Attribute_ist_leer`
- `DokumentationTests.MethodenMitAutor_liefert_nur_oeffentliche_Instanzmethoden_mit_Autor`
- `DokumentationTests.MethodenMitAutor_ohne_Attribute_ist_leer`
- `DokumentationTests.Eigenschaften_liefert_Name_und_Typ_sortiert`
- `DokumentationTests.TypName_verwendet_den_Laufzeittyp`
- `DokumentationTests.TypNameStatisch_verwendet_den_Typparameter`
- `DokumentationTests.Laufzeittyp_und_statischer_Typ_koennen_sich_unterscheiden`
- `DokumentationTests.Veraltet_liefert_die_Meldung_des_Obsolete_Attributs`
- `DokumentationTests.Veraltet_liefert_null_ohne_das_Attribut`
