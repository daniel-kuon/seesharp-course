# Zusatz: Sortieren mit Vergleichslambda

Lies im Buch **10.3 Übungsaufgaben zum Kapitel 10** (Seite 688) und
wiederhole `Sort`, `FindAll` und `RemoveAll` mit Lambdas aus Aufgabe 12/03.

`Person` ist ein Record (`Name`, `Alter`). In `Sortierer.cs`:

1. `NachAlter(liste)`: sortiert die Liste selbst aufsteigend nach Alter
   (Ausdruckslambda für `Comparison<Person>`).
2. `NachNameDannAlter(liste)`: erst nach Name (`string.CompareOrdinal`),
   bei gleichem Namen nach Alter.
3. `AelterAls(liste, grenze)`: neue Liste mit allen Personen, deren Alter
   **größer** als `grenze` ist (`FindAll`).
4. `EntferneMinderjaehrige(liste)`: löscht alle unter 18 mit `RemoveAll` aus
   der Liste selbst; Rückgabe: Anzahl.
5. `Juengste(liste)`: die jüngste Person (bei Gleichstand die erste in der
   Liste) oder `null` bei leerer Liste. Verwende `ForEach` mit einem Lambda
   mit **Anweisungsblock**, das das bisherige Minimum in einer lokalen
   Variablen mitführt.

Tests: `NachAlter_sortiert_aufsteigend`,
`NachNameDannAlter_bricht_Gleichstand_nach_Alter`,
`AelterAls_ist_strikt_groesser`,
`EntferneMinderjaehrige_veraendert_die_Liste`,
`Juengste_nimmt_bei_Gleichstand_die_erste`,
`Juengste_einer_leeren_Liste_ist_null`, `Juengste_bei_einer_Person`.
