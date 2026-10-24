# Zusatz: Ordnerstatistik

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**16.6.1 Dateiverwaltung** (Seite 1052), **16.6.2 Ordnerverwaltung**
(Seite 1055) und **16.6.4 Klasse Path** (Seite 1057).

Die Klasse `Ordnerstatistik` in `Ordnerstatistik.cs` wertet einen
Ordnerbaum aus. Die Tests bauen in einem Temp-Ordner einen kleinen Baum mit
Leerzeichen und Umlauten in den Namen auf, darunter `Büro Ordner` und
`Übersicht.TXT`.

1. `AnzahlDateien(ordner)`: alle Dateien, auch in Unterordnern.
2. `GroessteDatei(ordner)`: Pfad der größten Datei **relativ** zum Ordner
   (`Path.GetRelativePath`, `FileInfo.Length`); bei Gleichstand gewinnt der
   ordinal kleinere Pfad; ohne Datei `null`.
3. `ProEndung(ordner)`: Dictionary mit der Zahl der Dateien je Endung; der
   Schlüssel ist die Endung klein geschrieben und mit Punkt (`".txt"`), Dateien
   ohne Endung zählen unter `"(keine)"`.
4. `KopiereAlleTxt(quelle, ziel)`: kopiert alle `.txt`-Dateien (auch
   `.TXT`) samt Unterordnerstruktur nach `ziel`, legt fehlende Ordner an und
   liefert die Anzahl der Kopien.

Diese Tests müssen bestehen:

- `OrdnerstatistikTests.AnzahlDateien_zaehlt_rekursiv`
- `OrdnerstatistikTests.GroessteDatei_liefert_den_relativen_Pfad`
- `OrdnerstatistikTests.GroessteDatei_ohne_Dateien_ist_null`
- `OrdnerstatistikTests.GroessteDatei_bei_Gleichstand_gewinnt_der_ordinal_kleinere_Pfad`
- `OrdnerstatistikTests.ProEndung_zaehlt_klein_geschrieben_und_mit_Punkt`
- `OrdnerstatistikTests.KopiereAlleTxt_behaelt_die_Ordnerstruktur`
