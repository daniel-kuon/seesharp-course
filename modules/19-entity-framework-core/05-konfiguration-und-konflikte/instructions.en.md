# Value Converters, Conflicts, Transactions, Migrations

Read sections **20.13 "Conflicts Due to Parallel Access"** (page 1482), **20.14** (Transactions), **20.5.6** (Value Converters), and **20.3** (Migrations, page 1404) in the book.

`Konto` (`Id`, `Inhaber`, `Saldo`, `Status`, `Version`) and `KontoContext` are defined in `Datenmodell.cs`; `Kontodienst.Anlegen` is predefined.

1. **Value converter** in `OnModelCreating`: The `Status` enumeration type is stored as **text** (`"Neu"`, `"Aktiv"`, `"Gesperrt"`), not as a number: `Property(k => k.Status).HasConversion<string>()`. The test reads the raw column using a simple SQL statement.
2. **Concurrency Token**: The `Version` property is marked with `[ConcurrencyCheck]`. SQLite does not have a `rowversion` type, so the code increments the version manually with every change. EF Core then adds `WHERE Version = <geladener Wert>` to every `UPDATE`; if another context has modified the row in the meantime, this condition does not match any row, and `SaveChanges` throws a `DbUpdateConcurrencyException`.
3. **`Konfliktloeser.Speichere(kontext, konto, aenderung)`**: Applies the `aenderung`, increments the version, and saves. If a `DbUpdateConcurrencyException` occurs: `Entry(konto).Reload()`; reapply the change using the latest data, increment the version, and repeat **once**. If that also fails, the exception is passed to the caller. Return value: the number of attempts (1 or 2).
4. **`Kontodienst.Ueberweisung(von, nach, betrag)`** : using `kontext.Database.BeginTransaction()`. First debit and save, then credit and save, then `Commit()`. If an account is missing or the balance is insufficient: `InvalidOperationException`. For every exception, call `Rollback()` and `throw;` to ensure nothing is left undone.
5. **Review exercise (migrations)**: cannot be graded automatically. The instructions are provided under the `migration` quiz item on the exercise sheet: A small Scratch project using `dotnet ef migrations add Anfang`; the supervisor will review the `Migrations` folder.

Also, answer the quiz question about the concurrency token.

Tests: `Status_wird_als_Text_gespeichert`, `Status_wird_beim_Lesen_wieder_zum_Enum`, `Zwei_Kontexte_aendern_dieselbe_Zeile_der_zweite_SaveChanges_scheitert`, `Konfliktloeser_ohne_Konflikt_speichert_beim_ersten_Versuch`, `Konfliktloeser_laedt_bei_Konflikt_neu_und_wiederholt_einmal`, `Konfliktloeser_gibt_nach_dem_zweiten_Konflikt_auf`, `Ueberweisung_bucht_um_und_zaehlt_die_Versionen_hoch`, `Ueberweisung_ohne_Guthaben_aendert_nichts`, `Ueberweisung_auf_fehlendes_Konto_nimmt_die_Abbuchung_zurueck`, `Ueberweisung_von_fehlendem_Konto_wirft`.
