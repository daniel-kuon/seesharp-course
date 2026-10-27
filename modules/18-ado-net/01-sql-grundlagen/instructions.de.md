# SQL-Grundlagen mit SQLite

Lies im Buch **19.6 SQL** ab Seite 1296 (besonders 19.6.2 bis 19.6.4). Das Buch
verwendet den SQL Server, wir arbeiten mit **SQLite**: kein Server, die Datenbank
liegt im Speicher. Die Befehle sind fast dieselben. Unterschiede, die dir hier
begegnen:

| SQL Server (Buch) | SQLite |
|---|---|
| `INT IDENTITY(1,1) PRIMARY KEY` | `INTEGER PRIMARY KEY` (zählt automatisch hoch; `AUTOINCREMENT` ist meist unnötig) |
| `SELECT TOP 3 ...` | `SELECT ... LIMIT 3` |
| Spaltentypen `NVARCHAR(50)`, `MONEY`, `DECIMAL` | `TEXT`, `REAL`, `INTEGER` (SQLite typisiert locker) |

Einiges brauchst du hier, was das Buch nicht zeigt:

- `UNIQUE` hinter einer Spalte verbietet doppelte Werte (wie `NOT NULL` und `CHECK`
  aus 19.6.2.1 eine Spaltenrestriktion).
- `HAVING bedingung` steht hinter `GROUP BY` und filtert die **Gruppen**; anders als
  in `WHERE` darf die Bedingung Aggregatfunktionen enthalten (`HAVING COUNT(*) > 1`).
- Eine **Unterabfrage** ist ein `SELECT` in Klammern innerhalb eines anderen Befehls,
  etwa `WHERE KategorieId = (SELECT Id FROM Kategorie WHERE Name = 'Werkzeug')`.
- `NOT EXISTS (SELECT ...)` ist wahr, wenn die Unterabfrage keine Zeile liefert.

Öffne `Skripte.cs`. Die statische Klasse `Skripte` enthält SQL-Texte; du füllst
sie aus. Die Tests führen sie gegen eine frische Datenbank aus (mit eingeschalteten
Fremdschlüsseln) und vergleichen die Ergebnisse.

1. **`Schema`**: zwei Tabellen.
   - `Kategorie(Id, Name)`: `Id` ist Primärschlüssel, `Name` ist Text, nie NULL
     und eindeutig (`UNIQUE`).
   - `Artikel(Id, Name, Preis, KategorieId)`: `Id` ist Primärschlüssel, `Name`
     ist Text und nie NULL (`NOT NULL`), `Preis` ist eine Gleitkommazahl mit
     `CHECK (Preis >= 0)`, `KategorieId` verweist als Fremdschlüssel auf
     `Kategorie(Id)`.
2. **`Daten`**: füge diese Zeilen mit `INSERT` ein (die Ids sind vorgegeben):

   | Kategorie | Id | | Artikel | Id | Preis | KategorieId |
   |---|---:|---|---|---:|---:|---:|
   | Werkzeug | 1 | | Hammer | 1 | 12.50 | 1 |
   | Garten | 2 | | Zange | 2 | 9.90 | 1 |
   | Buero | 3 | | Saege | 3 | 18.00 | 1 |
   | Reserve | 4 | | Spaten | 4 | 24.90 | 2 |
   | | | | Harke | 5 | 11.00 | 2 |
   | | | | Giesskanne | 6 | 7.50 | 2 |
   | | | | Handschuhe | 7 | 5.90 | 2 |
   | | | | Locher | 8 | 4.20 | 3 |

3. **`TeureArtikel`**: Spalten `Name`, `Preis` aller Artikel mit Preis über 10,
   teuerster zuerst.
4. **`ArtikelMitKategorie`**: Spalten `Kategorie` (Name der Kategorie) und `Name`
   (des Artikels) per `JOIN`, sortiert nach Kategorie, dann nach Artikelname.
5. **`AnzahlProKategorie`**: Spalten `Kategorie` und `Anzahl` mit `GROUP BY`; nur
   Kategorien mit mehr als einem Artikel (`HAVING`); sortiert nach `Anzahl`
   absteigend, dann nach `Kategorie`.
6. **`Preiserhoehung`**: ein `UPDATE`, das die Preise aller Artikel der Kategorie
   `Garten` um 10 % erhöht. Schreibe nicht die Id 2 hinein, sondern suche sie
   über den Namen (Unterabfrage).
7. **`LoescheLeereKategorien`**: ein `DELETE`, das alle Kategorien ohne Artikel
   entfernt (`NOT EXISTS`).

Beantworte danach die Quizfrage.

Tests: `Schema_legt_beide_Tabellen_an`, `Schema_deklariert_Primaerschluessel_und_Fremdschluessel`,
`Schema_weist_Artikel_mit_unbekannter_Kategorie_ab`, `Schema_weist_negative_Preise_ab`,
`Schema_verlangt_Namen_und_eindeutige_Kategorienamen`, `Daten_fuegt_Kategorien_und_Artikel_ein`,
`TeureArtikel_liefert_Artikel_ueber_10_absteigend`, `ArtikelMitKategorie_verknuepft_und_sortiert`,
`AnzahlProKategorie_gruppiert_und_filtert_mit_HAVING`,
`Preiserhoehung_erhoeht_nur_die_Kategorie_Garten`,
`LoescheLeereKategorien_entfernt_nur_Kategorien_ohne_Artikel`.
